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
using aDVanceERP.Modulos.Inventario.MVP.Modelos.Repositorios;

namespace aDVanceERP.Desktop.MVP.Presentadores.ContenedorModulos; 

public partial class PresentadorContenedorModulos {
    private PresentadorRegistroVenta? _registroVentaArticulo;

    private long _proximoIdVenta = 0;
    private List<string[]>? ArticulosVenta { get; set; } = new();

    private async Task InicializarVistaRegistroVentaArticulo() {
        try {
            _registroVentaArticulo = new PresentadorRegistroVenta(new VistaRegistroVenta());
            _registroVentaArticulo.Vista.EstablecerCoordenadasVistaRegistro(Vista.Dimensiones.Width);
            _registroVentaArticulo.Vista.EstablecerDimensionesVistaRegistro(Vista.Dimensiones.Height);
            _registroVentaArticulo.Vista.CargarRazonesSocialesClientes(UtilesCliente.ObtenerRazonesSocialesClientes());
            _registroVentaArticulo.Vista.CargarNombresAlmacenes(UtilesAlmacen.ObtenerNombresAlmacenes(true));
            _registroVentaArticulo.Vista.IdTipoEntrega = await UtilesMensajero.ObtenerIdTipoEntrega("Presencial");
            _registroVentaArticulo.Vista.RegistrarDatos += delegate {
                ArticulosVenta = _registroVentaArticulo.Vista.Articulos;

                RegistrarDetallesVentaArticulo();
                RegistrarTransferenciaVenta();

                if (_gestionVentas == null)
                    return;

                _gestionVentas.Vista.HabilitarBtnConfirmarEntrega = false;
                _gestionVentas.Vista.HabilitarBtnConfirmarPagos = false;
                _ = _gestionVentas?.RefrescarListaObjetos();
            };
            _registroVentaArticulo.Vista.Salir += delegate {
                var ventaCancelada = !UtilesVenta.ExisteVenta(_proximoIdVenta);
                
                if (ventaCancelada) {
                    // Eliminar pagos registrados si se cancela la venta
                    var pagosVenta = UtilesVenta.ObtenerPagosPorVenta(_proximoIdVenta);

                    if (pagosVenta.Count > 0) {
                        using (var datosPago = new DatosPago()) {
                            foreach (var pago in pagosVenta) {
                                var pagoSplit = pago.Split("|");

                                datosPago.Eliminar(long.Parse(pagoSplit[0]));
                            }
                        }
                    }

                    //TODO: Eliminar seguimientos de entrega registrados si se cancela la venta
                }
            };

            ArticulosVenta?.Clear();
        }
        catch (ExcepcionConexionServidorMySQL e) {
            CentroNotificaciones.Mostrar(e.Message, TipoNotificacion.Error);
        }
    }

    private async void MostrarVistaRegistroVentaArticulo(object? sender, EventArgs e) {
        await InicializarVistaRegistroVentaArticulo();

        if (_registroVentaArticulo == null)
            return;

        _proximoIdVenta = UtilesBD.ObtenerUltimoIdTabla("venta") + 1;
        _registroVentaArticulo.Vista.EfectuarPago += delegate {
            MostrarVistaRegistroPago(sender, e);
        };
        _registroVentaArticulo.Vista.AsignarMensajeria += delegate {
            if (string.IsNullOrEmpty(_registroVentaArticulo.Vista.RazonSocialCliente) || _registroVentaArticulo.Vista.RazonSocialCliente.Equals("Anónimo")) {
                CentroNotificaciones.Mostrar(
                    "Debe asignar un cliente válido desde la lista antes de asignar una orden de entrega para la mensajería de los artículos seleccionados",
                    TipoNotificacion.Advertencia);
                return;
            }

            MostrarVistaRegistroMensajeria(sender, e);
        };

        MostrarVistaPanelTransparente(_registroVentaArticulo.Vista);

        _registroVentaArticulo?.Vista.Mostrar();
        _registroVentaArticulo?.Dispose();
    }

    private async void MostrarVistaEdicionVentaArticulo(object? sender, EventArgs e) {
        await InicializarVistaRegistroVentaArticulo();

        if (_registroVentaArticulo != null && sender is Venta venta) {
            _registroVentaArticulo.PopularVistaDesdeObjeto(venta);
            _registroVentaArticulo.Vista.EfectuarPago += delegate {
                MostrarVistaEdicionPago(sender, e);
            };
            _registroVentaArticulo.Vista.AsignarMensajeria += async delegate {
                MostrarVistaEdicionMensajeria(sender, e);
            };

            MostrarVistaPanelTransparente(_registroVentaArticulo.Vista);

            _registroVentaArticulo?.Vista.Mostrar();
        }

        _registroVentaArticulo?.Dispose();
    }

    private void RegistrarDetallesVentaArticulo() {
        if (ArticulosVenta == null || ArticulosVenta.Count == 0)
            return;

        var ultimoIdVenta = UtilesBD.ObtenerUltimoIdTabla("venta");

        foreach (var articulo in ArticulosVenta) {
            var detalleVentaArticulo = new DetalleVentaArticulo(
                0,
                ultimoIdVenta,
                long.Parse(articulo[0]),
                decimal.TryParse(articulo[2], NumberStyles.Any, CultureInfo.InvariantCulture,
                    out var precioCompraVigente)
                    ? precioCompraVigente
                    : 0.00m,
                decimal.TryParse(articulo[3], NumberStyles.Any, CultureInfo.InvariantCulture, out var precioVentaFinal)
                    ? precioVentaFinal
                    : 0.00m,
                int.Parse(articulo[4])
            );

            using (var datosArticulo = new DatosDetalleVentaArticulo()) {
                datosArticulo.Adicionar(detalleVentaArticulo);
            }

            RegistrarMovimientoVentaArticulo(detalleVentaArticulo, articulo);
            ModificarStockVentaArticulo(detalleVentaArticulo, articulo);

            // Actualizar precio de venta en tabla articulo
            UtilesArticulo.ActualizarPrecioVentaBase(
                detalleVentaArticulo.IdArticulo,
                detalleVentaArticulo.PrecioVentaFinal
            );
        }
    }

    private static void RegistrarMovimientoVentaArticulo(DetalleVentaArticulo detalleVentaArticulo,
        IReadOnlyList<string> articulo) {
        using (var datosMovimiento = new DatosMovimiento()) {
            datosMovimiento.Adicionar(new Movimiento(
                0,
                detalleVentaArticulo.IdArticulo,
                long.Parse(articulo[4]),
                0,
                DateTime.Now,
                detalleVentaArticulo.Cantidad,
                UtilesMovimiento.ObtenerIdTipoMovimiento("Venta")
            ));
        }
    }

    private static void ModificarStockVentaArticulo(DetalleVentaArticulo detalleVentaArticulo,
        IReadOnlyList<string> articulo) {
        UtilesMovimiento.ModificarStockArticuloAlmacen(
            detalleVentaArticulo.IdArticulo,
            long.Parse(articulo[5]),
            0,
            detalleVentaArticulo.Cantidad
        );
    }
}