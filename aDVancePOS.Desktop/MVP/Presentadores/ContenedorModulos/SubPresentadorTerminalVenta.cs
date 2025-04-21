using aDVanceERP.Core.Utiles.Datos;
using aDVanceERP.Modulos.CompraVenta.MVP.Modelos.Repositorios;
using aDVanceERP.Modulos.CompraVenta.MVP.Modelos;
using aDVanceERP.Modulos.Inventario.MVP.Modelos.Repositorios;
using aDVanceERP.Modulos.Inventario.MVP.Modelos;

using aDVancePOS.Modulos.TerminalVenta.MVP.Presentadores;
using aDVancePOS.Modulos.TerminalVenta.MVP.Vistas.Venta;

using System.Globalization;
using aDVanceERP.Core.Mensajes.MVP.Modelos;
using aDVanceERP.Core.Mensajes.Utiles;
using aDVanceERP.Modulos.Contactos.MVP.Modelos;
using aDVanceERP.Modulos.Contactos.MVP.Modelos.Repositorios;

namespace aDVancePOS.Desktop.MVP.Presentadores.ContenedorModulos;

public partial class PresentadorContenedorModulos {
    private PresentadorTerminalVenta? _terminalVenta;

    private List<string[]>? ArticulosVenta { get; set; } = new();

    private async Task InicializarVistaTerminalVenta() {
        _terminalVenta = new PresentadorTerminalVenta(new VistaTerminalVenta());
        _terminalVenta.Vista.CargarNombresAlmacenes(UtilesAlmacen.ObtenerNombresAlmacenes(true));
        _terminalVenta.Vista.IdTipoEntrega = await UtilesMensajero.ObtenerIdTipoEntrega("Presencial");
        _terminalVenta.Vista.ModificarCantidadArticulos += MostrarVistaModificadorCantidadArticulo;
        _terminalVenta.Vista.RegistrarDatos += delegate {
            ArticulosVenta = _terminalVenta.Vista.Articulos;

            RegistrarDetallesVentaArticulo();
            RegistrarSeguimientoEntrega();
            RegistrarPagosVenta();
            RegistrarTransferenciaVenta();
        };

        Vista.Vistas?.Registrar("terminalVenta", _terminalVenta.Vista);
    }

    private void MostrarVistaTerminalVenta(object? sender, EventArgs e) { 
        if (_terminalVenta?.Vista == null)
            return;

        _terminalVenta.Vista.EfectuarPago += delegate {
            if (_terminalVenta == null)
                return;

            MostrarVistaRegistroPago(_terminalVenta.Vista.Total, e);

            _terminalVenta.Vista.PagoConfirmado = Pagos.Count > 0;
        };
        _terminalVenta.Vista.AsignarMensajeria += async delegate {
            ArticulosVenta = _terminalVenta.Vista.Articulos;

            #region Datos del cliente

            using var datosCliente = new DatosCliente();
            var cliente = datosCliente.Obtener(CriterioBusquedaCliente.Id,
                    UtilesCliente.ObtenerIdCliente(_terminalVenta.Vista.RazonSocialCliente).ToString())
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

            if (ArticulosVenta != null) {
                var datos = new object[] {
                    new[] { cliente.RazonSocial ?? string.Empty, telefonoString, direccion },
                    ArticulosVenta
                };

                MostrarVistaRegistroMensajeria(datos, e);
            }

            if (DatosMensajeria.Count == 0)
                return;

            _terminalVenta.Vista.IdTipoEntrega = await UtilesMensajero.ObtenerIdTipoEntrega(DatosMensajeria.ElementAt(0)[0]);
            _terminalVenta.Vista.Direccion = DatosMensajeria.ElementAt(2)[2];
            _terminalVenta.Vista.PagoConfirmado = DatosMensajeria.ElementAt(1)[0] == "Mensajería (sin fondo)";
            _terminalVenta.Vista.EstadoEntrega = "Pendiente";
        };

        _terminalVenta.Vista.Restaurar();
        _terminalVenta.Vista.Mostrar();
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
