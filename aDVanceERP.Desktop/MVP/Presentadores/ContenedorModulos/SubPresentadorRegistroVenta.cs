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
using aDVanceERP.Modulos.Contactos.MVP.Modelos;
using aDVanceERP.Modulos.Contactos.MVP.Modelos.Repositorios;
using aDVanceERP.Modulos.Inventario.MVP.Modelos;
using aDVanceERP.Modulos.Inventario.MVP.Modelos.Repositorios;

namespace aDVanceERP.Desktop.MVP.Presentadores.ContenedorModulos; 

public partial class PresentadorContenedorModulos {
    private PresentadorRegistroVenta? _registroVentaArticulo;

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
                RegistrarSeguimientoEntrega();
                RegistrarPagosVenta();
                RegistrarTransferenciaVenta();

                if (_gestionVentas == null)
                    return;

                _gestionVentas.Vista.HabilitarBtnConfirmarEntrega = false;
                _gestionVentas.Vista.HabilitarBtnConfirmarPagos = false;
                _ = _gestionVentas?.RefrescarListaObjetos();
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

        _registroVentaArticulo.Vista.EfectuarPago += delegate {
            if (_registroVentaArticulo == null)
                return;

            MostrarVistaRegistroPago(_registroVentaArticulo.Vista.Total, e);

            _registroVentaArticulo.Vista.PagoConfirmado = Pagos.Count > 0;
        };
        _registroVentaArticulo.Vista.AsignarMensajeria += async delegate {
            ArticulosVenta = _registroVentaArticulo.Vista.Articulos;

            #region Datos del cliente

            using var datosCliente = new DatosCliente();
            var cliente = datosCliente.Obtener(CriterioBusquedaCliente.Id,
                    UtilesCliente.ObtenerIdCliente(_registroVentaArticulo.Vista.RazonSocialCliente).ToString())
                .FirstOrDefault();

            if (cliente == null) {
                CentroNotificaciones.Mostrar(
                    "Para asignar una mensajería a la venta actual debe primero especificar un cliente válido desde la lista de clientes",
                    TipoNotificacion.Advertencia);

                return;
            }

            #endregion

            #region Datos de contacto asociados al cliente

            string telefonoString;
            string direccion;
            using (var datosContacto = new DatosContacto()) {
                var contacto = datosContacto.Obtener(CriterioBusquedaContacto.Id, cliente.IdContacto.ToString())
                    .FirstOrDefault();

                using (var datosTelefonoContacto = new DatosTelefonoContacto()) {
                    var telefonosContacto = datosTelefonoContacto.Obtener(CriterioBusquedaTelefonoContacto.IdContacto,
                        contacto?.Id.ToString());
                    telefonoString = telefonosContacto.Aggregate(string.Empty,
                        (current, telefono) => current + $"{telefono.Prefijo} {telefono.Numero}, ");

                    if (!string.IsNullOrEmpty(telefonoString))
                        telefonoString = telefonoString[..^2];
                }

                direccion = contacto?.Direccion ?? string.Empty;
            }

            #endregion

            var datos = new object[] {
                new[] { cliente.RazonSocial ?? string.Empty, telefonoString, direccion },
                ArticulosVenta
            };

            MostrarVistaRegistroMensajeria(datos, e);

            if (DatosMensajeria.Count == 0)
                return;

            _registroVentaArticulo.Vista.IdTipoEntrega =
                await UtilesMensajero.ObtenerIdTipoEntrega(DatosMensajeria.ElementAt(0)[0]);
            _registroVentaArticulo.Vista.Direccion = DatosMensajeria.ElementAt(2)[2];
            _registroVentaArticulo.Vista.PagoConfirmado = DatosMensajeria.ElementAt(1)[0] == "Mensajería (sin fondo)";
            _registroVentaArticulo.Vista.EstadoEntrega = "Pendiente";
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

                _registroVentaArticulo.Vista.PagoConfirmado = Pagos.Count > 0;
            };
            _registroVentaArticulo.Vista.AsignarMensajeria += async delegate {
                MostrarVistaEdicionMensajeria(sender, e);

                _registroVentaArticulo.Vista.IdTipoEntrega =
                    await UtilesMensajero.ObtenerIdTipoEntrega(DatosMensajeria.ElementAt(0)[0]);
                _registroVentaArticulo.Vista.Direccion = DatosMensajeria.ElementAt(2)[2];
                _registroVentaArticulo.Vista.PagoConfirmado =
                    DatosMensajeria.ElementAt(1)[0] == "Mensajería (sin fondo)";
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