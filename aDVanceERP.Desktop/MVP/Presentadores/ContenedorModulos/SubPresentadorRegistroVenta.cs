using System.Globalization;
using aDVanceERP.Core.Excepciones;
using aDVanceERP.Core.Mensajes.MVP.Modelos;
using aDVanceERP.Core.Mensajes.Utiles;
using aDVanceERP.Core.Utiles.Datos;
using aDVanceERP.Desktop.Utiles;
using aDVanceERP.Modulos.CompraVenta.MVP.Modelos;
using aDVanceERP.Modulos.CompraVenta.MVP.Modelos.Repositorios;
using aDVanceERP.Modulos.CompraVenta.MVP.Presentadores;
using aDVanceERP.Modulos.CompraVenta.MVP.Vistas.Venta;
using aDVanceERP.Modulos.Inventario.MVP.Modelos;
using aDVanceERP.Modulos.Inventario.Repositorios;

namespace aDVanceERP.Desktop.MVP.Presentadores.ContenedorModulos; 

public partial class PresentadorContenedorModulos {
    private PresentadorRegistroVenta? _registroVentaProducto;
    private long _proximoIdVenta = 0;

    private List<string[]>? ProductosVenta { get; set; } = new();

    private async Task InicializarVistaRegistroVentaProducto() {
        try {
            _registroVentaProducto = new PresentadorRegistroVenta(new VistaRegistroVenta());
            _registroVentaProducto.Vista.EstablecerCoordenadasVistaRegistro(Vista.Dimensiones);
            _registroVentaProducto.Vista.EstablecerDimensionesVistaRegistro(Vista.Dimensiones.Height);
            _registroVentaProducto.Vista.CargarNombresAlmacenes(UtilesAlmacen.ObtenerNombresAlmacenes(true));
            _registroVentaProducto.Vista.IdTipoEntrega = await UtilesEntrega.ObtenerIdTipoEntrega("Presencial");
            _registroVentaProducto.DatosRegistradosActualizados += delegate {
                ProductosVenta = _registroVentaProducto.Vista.Productos;

                RegistrarDetallesVentaProducto();
                RegistrarTransferenciaVenta();

                if (_gestionVentas == null)
                    return;

                _gestionVentas.Vista.HabilitarBtnConfirmarEntrega = false;
                _gestionVentas.Vista.HabilitarBtnConfirmarPagos = false;
                _gestionVentas.RefrescarListaObjetos();
            };
            _registroVentaProducto.Vista.Salir += delegate {
                // Verificar cancelación de la venta
                if (!_registroVentaProducto.Vista.ModoEdicion && !UtilesVenta.ExisteVenta(_proximoIdVenta))
                    CancelarVenta();
            };

            ProductosVenta?.Clear();
        }
        catch (ExcepcionConexionServidorMySQL e) {
            CentroNotificaciones.Mostrar(e.Message, TipoNotificacion.Error);
        }
    }

    private void CancelarVenta() {
        // Eliminar pagos registrados si se cancela la venta
        var pagosVenta = UtilesVenta.ObtenerPagosPorVenta(_proximoIdVenta);

        if (pagosVenta.Count > 0) {
            using (var datosPago = new DatosPago())
                foreach (var pago in pagosVenta) {
                    var pagoSplit = pago.Split("|");

                    datosPago.Eliminar(long.Parse(pagoSplit[0]));
                }
        }

        // Eliminar seguimientos de entrega registrados si se cancela la venta
        var idSeguimientoEntrega = UtilesEntrega.ObtenerIdSeguimientoEntrega(_proximoIdVenta).Result;

        if (idSeguimientoEntrega != 0)
            using (var datosSeguimientoEntrega = new DatosSeguimientoEntrega())
                datosSeguimientoEntrega.Eliminar(idSeguimientoEntrega);
    }

    private async void OnMostrarVistaRegistroVentaProducto(object? sender, EventArgs e) {
        // Comprobar la existencia de al menos un almacén registrado.
        var existenAlmacenes = false;

        using (var datos = new DatosAlmacen())
            existenAlmacenes = datos.Cantidad() > 0;

        if (!existenAlmacenes) {
            CentroNotificaciones.Mostrar("No es posible registrar nuevas ventas. Debe existir al menos un almacén registrado.", Core.Mensajes.MVP.Modelos.TipoNotificacion.Advertencia);
            return;
        }

        await InicializarVistaRegistroVentaProducto();

        if (_registroVentaProducto == null)
            return;

        _proximoIdVenta = UtilesBD.ObtenerUltimoIdTabla("venta") + 1;
        _registroVentaProducto.Vista.EfectuarPago += delegate {
            MostrarVistaRegistroPago(sender, e);
        };
        _registroVentaProducto.Vista.AsignarMensajeria += delegate {
            MostrarVistaRegistroMensajeria(sender, e);
        };
        _registroVentaProducto.Vista.Mostrar();
        _registroVentaProducto.Dispose();
    }

    private async void OnMostrarVistaEdicionVentaProducto(object? sender, EventArgs e) {
        await InicializarVistaRegistroVentaProducto();

        if (_registroVentaProducto != null && sender is Venta venta) {            
            _registroVentaProducto.Vista.EfectuarPago += delegate {
                MostrarVistaEdicionPago(sender, e);
            };
            _registroVentaProducto.Vista.AsignarMensajeria += delegate {
                MostrarVistaEdicionMensajeria(sender, e);
            };

            _registroVentaProducto.PopularVistaDesdeObjeto(venta);
            _registroVentaProducto.Vista.Mostrar();
        }

        _registroVentaProducto?.Dispose();
    }

    private void RegistrarDetallesVentaProducto() {
        if (ProductosVenta == null || ProductosVenta.Count == 0)
            return;

        var ultimoIdVenta = UtilesBD.ObtenerUltimoIdTabla("venta");

        foreach (var producto in ProductosVenta) {
            var detalleVentaProducto = new DetalleVentaProducto(
                0,
                ultimoIdVenta,
                long.Parse(producto[0]),
                decimal.TryParse(producto[2], NumberStyles.Any, CultureInfo.InvariantCulture,
                    out var precioCompraVigente)
                    ? precioCompraVigente
                    : 0.00m,
                decimal.TryParse(producto[3], NumberStyles.Any, CultureInfo.InvariantCulture, out var precioVentaFinal)
                    ? precioVentaFinal
                    : 0.00m,
                decimal.TryParse(producto[4], NumberStyles.Any, CultureInfo.InvariantCulture, out var cantidad)
                    ? cantidad
                    : 0.00m
            );

            using (var datosProducto = new DatosDetalleVentaProducto()) {
                datosProducto.Insertar(detalleVentaProducto);
            }

            RegistrarMovimientoVentaProducto(detalleVentaProducto, producto);
            ModificarStockVentaProducto(detalleVentaProducto, producto);

            // Actualizar precio de venta en tabla producto
            UtilesProducto.ActualizarPrecioVentaBase(
                detalleVentaProducto.IdProducto,
                detalleVentaProducto.PrecioVentaFinal
            );
        }
    }

    private static void RegistrarMovimientoVentaProducto(DetalleVentaProducto detalleVentaProducto,
        IReadOnlyList<string> producto) {
        using (var datosMovimiento = new DatosMovimiento()) {
            datosMovimiento.Adicionar(new Movimiento(
                0,
                detalleVentaProducto.IdProducto,
                long.Parse(producto[5]),
                0,
                DateTime.Now,
                detalleVentaProducto.Cantidad,
                UtilesMovimiento.ObtenerIdTipoMovimiento("Venta")
            ));
        }
    }

    private static void ModificarStockVentaProducto(DetalleVentaProducto detalleVentaProducto,
        IReadOnlyList<string> producto) {
        UtilesMovimiento.ModificarInventario(
            detalleVentaProducto.IdProducto,
            long.Parse(producto[5]),
            0,
            detalleVentaProducto.Cantidad,
            UtilesProducto.ObtenerCostoUnitario(detalleVentaProducto.IdProducto).Result
        );
    }
}