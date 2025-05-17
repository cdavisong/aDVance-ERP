using aDVanceERP.Core.Utiles.Datos;
using aDVanceERP.Modulos.CompraVenta.MVP.Modelos.Repositorios;
using aDVanceERP.Modulos.CompraVenta.MVP.Modelos;
using aDVanceERP.Modulos.Inventario.MVP.Modelos.Repositorios;
using aDVanceERP.Modulos.Inventario.MVP.Modelos;

using aDVancePOS.Modulos.TerminalVenta.MVP.Presentadores;
using aDVancePOS.Modulos.TerminalVenta.MVP.Vistas.Venta;

using System.Globalization;

namespace aDVancePOS.Desktop.MVP.Presentadores.ContenedorModulos;

public partial class PresentadorContenedorModulos {
    private PresentadorTerminalVenta? _terminalVenta;
    private long _proximoIdVenta = 0;

    private List<string[]>? ArticulosVenta { get; set; } = new();

    private async void InicializarVistaTerminalVenta() {
        _terminalVenta = new PresentadorTerminalVenta(new VistaTerminalVenta());
        _terminalVenta.Vista.CargarNombresAlmacenes(UtilesAlmacen.ObtenerNombresAlmacenes(true));
        _terminalVenta.Vista.IdTipoEntrega = await UtilesEntrega.ObtenerIdTipoEntrega("Presencial");
        _terminalVenta.Vista.ModificarCantidadArticulos += MostrarVistaModificadorCantidadArticulo;
        _terminalVenta.Vista.RegistrarDatos += delegate {
            ArticulosVenta = _terminalVenta.Vista.Articulos;

            RegistrarDetallesVentaArticulo();
            RegistrarTransferenciaVenta();
        };
        //_terminalVenta.Vista.CancelarVenta += delegate {
        //    //TODO: Verificar cancelación de la venta
        //    if (!_terminalVenta.Vista.ModoEdicionDatos && !UtilesVenta.ExisteVenta(_proximoIdVenta))
        //        CancelarVenta();
        //};
        
        Vista.Vistas?.Registrar("terminalVenta", _terminalVenta.Vista);
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

    private void MostrarVistaTerminalVenta(object? sender, EventArgs e) { 
        if (_terminalVenta?.Vista == null)
            return;

        _proximoIdVenta = UtilesBD.ObtenerUltimoIdTabla("venta") + 1;
        _terminalVenta.Vista.EfectuarPago += delegate {
            MostrarVistaRegistroPago(sender, e);
        };
        _terminalVenta.Vista.AsignarMensajeria += delegate {
            MostrarVistaRegistroMensajeria(sender, e);
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
                long.Parse(articulo[5]),
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
