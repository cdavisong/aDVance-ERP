using System.Globalization;

using aDVanceERP.Core.Excepciones;
using aDVanceERP.Core.Mensajes.MVP.Modelos;
using aDVanceERP.Core.Mensajes.Utiles;
using aDVanceERP.Core.Utiles.Datos;
using aDVanceERP.Desktop.Utiles;
using aDVanceERP.Modulos.CompraVenta.MVP.Modelos;
using aDVanceERP.Modulos.CompraVenta.MVP.Modelos.Repositorios;
using aDVanceERP.Modulos.CompraVenta.MVP.Presentadores;
using aDVanceERP.Modulos.CompraVenta.MVP.Vistas.Compra;
using aDVanceERP.Modulos.Inventario.MVP.Modelos;
using aDVanceERP.Modulos.Inventario.MVP.Modelos.Repositorios;

namespace aDVanceERP.Desktop.MVP.Presentadores.ContenedorModulos;

public partial class PresentadorContenedorModulos {
    private PresentadorRegistroCompra? _registroCompraArticulo;
    private long _proximoIdCompra = 0;

    private List<string[]>? ArticulosCompra { get; set; } = new();

    private async Task InicializarVistaRegistroCompraArticulo() {
        try {
            _registroCompraArticulo = new PresentadorRegistroCompra(new VistaRegistroCompra());
            _registroCompraArticulo.Vista.EstablecerCoordenadasVistaRegistro(Vista.Dimensiones);
            _registroCompraArticulo.Vista.EstablecerDimensionesVistaRegistro(Vista.Dimensiones.Height);
            _registroCompraArticulo.Vista.CargarRazonesSocialesProveedores(UtilesProveedor.ObtenerRazonesSocialesProveedores());
            _registroCompraArticulo.Vista.CargarNombresAlmacenes(UtilesAlmacen.ObtenerNombresAlmacenes());
            _registroCompraArticulo.Vista.CargarNombresArticulos(await UtilesArticulo.ObtenerNombresArticulos());
            _registroCompraArticulo.DatosRegistradosActualizados += async delegate {
                ArticulosCompra = _registroCompraArticulo.Vista.Articulos;

                RegistrarDetallesCompraArticulo();

                if (_gestionCompras == null)
                    return;

                await _gestionCompras.RefrescarListaObjetos();
            };

            ArticulosCompra?.Clear();
        } catch (ExcepcionConexionServidorMySQL e) {
            CentroNotificaciones.Mostrar(e.Message, TipoNotificacion.Error);
        }
    }

    private async void MostrarVistaRegistroCompraArticulo(object? sender, EventArgs e) {
        await InicializarVistaRegistroCompraArticulo();

        if (_registroCompraArticulo == null)
            return;

        _proximoIdCompra = UtilesBD.ObtenerUltimoIdTabla("compra") + 1;
        MostrarVistaPanelTransparente(_registroCompraArticulo.Vista);

        _registroCompraArticulo.Vista.Mostrar();
        _registroCompraArticulo.Dispose();
    }

    private async void MostrarVistaEdicionCompraArticulo(object? sender, EventArgs e) {
        await InicializarVistaRegistroCompraArticulo();

        if (sender is Compra compra) {
            if (_registroCompraArticulo != null) {
                MostrarVistaPanelTransparente(_registroCompraArticulo.Vista);

                _registroCompraArticulo.PopularVistaDesdeObjeto(compra);
                _registroCompraArticulo.Vista.Mostrar();
            }
        }

        _registroCompraArticulo?.Dispose();
    }

    private void RegistrarDetallesCompraArticulo() {
        if (ArticulosCompra == null || ArticulosCompra.Count == 0)
            return;

        var ultimoIdCompra = UtilesBD.ObtenerUltimoIdTabla("compra");

        foreach (var articulo in ArticulosCompra) {
            var detalleCompraArticulo = new DetalleCompraArticulo(
                0,
                ultimoIdCompra,
                long.Parse(articulo[0]),
                int.Parse(articulo[3]),
                decimal.TryParse(articulo[2], NumberStyles.Any, CultureInfo.InvariantCulture, out var precioCompra)
                    ? precioCompra
                    : 0.00m
            );

            using (var datosArticulo = new DatosDetalleCompraArticulo())
                datosArticulo.Adicionar(detalleCompraArticulo);

            RegistrarMovimientoCompraArticulo(detalleCompraArticulo, articulo);
            ModificarStockCompraArticulo(detalleCompraArticulo, articulo);

            // Actualizar precio de compra en tabla articulo
            UtilesArticulo.ActualizarPrecioCompraBase(
                detalleCompraArticulo.IdArticulo,
                detalleCompraArticulo.PrecioCompra
            );
        }
    }

    private static void RegistrarMovimientoCompraArticulo(DetalleCompraArticulo detalleCompraArticulo,
        IReadOnlyList<string> articulo) {
        using (var datosMovimiento = new DatosMovimiento()) {
            datosMovimiento.Adicionar(new Movimiento(
                0,
                detalleCompraArticulo.IdArticulo,
                0,
                long.Parse(articulo[4]),
                DateTime.Now,
                detalleCompraArticulo.Cantidad,
                UtilesMovimiento.ObtenerIdTipoMovimiento("Compra")
            ));
        }
    }

    private static void ModificarStockCompraArticulo(DetalleCompraArticulo detalleCompraArticulo,
        IReadOnlyList<string> articulo) {
        UtilesMovimiento.ModificarStockArticuloAlmacen(
            detalleCompraArticulo.IdArticulo,
            0,
            long.Parse(articulo[4]),
            detalleCompraArticulo.Cantidad
        );
    }
}