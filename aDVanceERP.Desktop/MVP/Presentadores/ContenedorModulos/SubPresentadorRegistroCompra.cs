using System.Globalization;

using aDVanceERP.Core.Excepciones;
using aDVanceERP.Core.Mensajes.MVP.Modelos;
using aDVanceERP.Core.Mensajes.Utiles;
using aDVanceERP.Core.Modelos.Modulos.Inventario;
using aDVanceERP.Core.Repositorios.Modulos.Inventario;
using aDVanceERP.Core.Utiles.Datos;
using aDVanceERP.Desktop.Utiles;
using aDVanceERP.Modulos.CompraVenta.MVP.Modelos;
using aDVanceERP.Modulos.CompraVenta.MVP.Modelos.Repositorios;
using aDVanceERP.Modulos.CompraVenta.MVP.Presentadores;
using aDVanceERP.Modulos.CompraVenta.MVP.Vistas.Compra;

namespace aDVanceERP.Desktop.MVP.Presentadores.ContenedorModulos;

public partial class PresentadorContenedorModulos {
    private PresentadorRegistroCompra? _registroCompraProducto;
    private long _proximoIdCompra = 0;

    private List<string[]>? ProductosCompra { get; set; } = new();

    private async Task InicializarVistaRegistroCompraProducto() {
        try {
            _registroCompraProducto = new PresentadorRegistroCompra(new VistaRegistroCompra());
            _registroCompraProducto.Vista.EstablecerCoordenadasVistaRegistro(Vista.Dimensiones);
            _registroCompraProducto.Vista.EstablecerDimensionesVistaRegistro(Vista.Dimensiones.Height);
            _registroCompraProducto.Vista.CargarRazonesSocialesProveedores(UtilesProveedor.ObtenerRazonesSocialesProveedores());
            _registroCompraProducto.Vista.CargarNombresAlmacenes(UtilesAlmacen.ObtenerNombresAlmacenes());
            _registroCompraProducto.Vista.CargarNombresProductos(await UtilesProducto.ObtenerNombresProductos());
            _registroCompraProducto.DatosRegistradosActualizados += delegate {
                ProductosCompra = _registroCompraProducto.Vista.Productos;

                RegistrarDetallesCompraProducto();

                if (_gestionCompras == null)
                    return;

                _gestionCompras.ActualizarResultadosBusqueda();
            };

            ProductosCompra?.Clear();
        } catch (ExcepcionConexionServidorMySQL e) {
            CentroNotificaciones.Mostrar(e.Message, TipoNotificacion.Error);
        }
    }

    private async void MostrarVistaRegistroCompraProducto(object? sender, EventArgs e) {
        // Comprobar la existencia de al menos un almacén registrado.
        var existenAlmacenes = false;

        using (var datos = new RepoAlmacen())
            existenAlmacenes = datos.Cantidad() > 0;

        if (!existenAlmacenes) {
            CentroNotificaciones.Mostrar("No es posible registrar nuevas compras. Debe existir al menos un almacén registrado.", Core.Mensajes.MVP.Modelos.TipoNotificacion.Advertencia);
            return;
        }

        await InicializarVistaRegistroCompraProducto();

        if (_registroCompraProducto == null)
            return;

        _proximoIdCompra = UtilesBD.ObtenerUltimoIdTabla("compra") + 1;

        _registroCompraProducto.Vista.Mostrar();
        _registroCompraProducto.Dispose();
    }

    private async void MostrarVistaEdicionCompraProducto(object? sender, EventArgs e) {
        await InicializarVistaRegistroCompraProducto();

        if (sender is Compra compra) {
            if (_registroCompraProducto != null) {
                _registroCompraProducto.PopularVistaDesdeObjeto(compra);
                _registroCompraProducto.Vista.Mostrar();
            }
        }

        _registroCompraProducto?.Dispose();
    }

    private void RegistrarDetallesCompraProducto() {
        if (ProductosCompra == null || ProductosCompra.Count == 0)
            return;

        var ultimoIdCompra = UtilesBD.ObtenerUltimoIdTabla("compra");

        foreach (var producto in ProductosCompra) {
            var detalleCompraProducto = new DetalleCompraProducto(
                0,
                ultimoIdCompra,
                long.Parse(producto[0]),
                decimal.Parse(producto[3], NumberStyles.Any, CultureInfo.InvariantCulture),
                decimal.TryParse(producto[2], NumberStyles.Any, CultureInfo.InvariantCulture, out var precioCompra)
                    ? precioCompra
                    : 0.00m
            );

            using (var datosProducto = new RepoDetalleCompraProducto())
                datosProducto.Adicionar(detalleCompraProducto);

            RegistrarMovimientoCompraProducto(detalleCompraProducto, producto);
            ModificarStockCompraProducto(detalleCompraProducto, producto);

            // Actualizar precio de compra en tabla producto
            UtilesProducto.ActualizarPrecioCompra(
                detalleCompraProducto.IdProducto,
                detalleCompraProducto.PrecioCompra
            );
        }
    }

    private static void RegistrarMovimientoCompraProducto(DetalleCompraProducto detalleCompraProducto,
        IReadOnlyList<string> producto) {
        using (var datosMovimiento = new RepoMovimiento()) {
            datosMovimiento.Adicionar(new Movimiento(
                0,
                detalleCompraProducto.IdProducto,
                0,
                long.Parse(producto[4]),
                DateTime.Now,
                detalleCompraProducto.Cantidad,
                UtilesMovimiento.ObtenerIdTipoMovimiento("Compra")
            ));
        }
    }

    private static void ModificarStockCompraProducto(DetalleCompraProducto detalleCompraProducto,
        IReadOnlyList<string> producto) {
        UtilesMovimiento.ModificarInventario(
            detalleCompraProducto.IdProducto,
            0,
            long.Parse(producto[4]),
            detalleCompraProducto.Cantidad,
            UtilesProducto.ObtenerCostoUnitario(detalleCompraProducto.IdProducto).Result
        );
    }
}