using aDVanceERP.Core.MVP.Presentadores;
using aDVanceERP.Core.Utiles.Datos;
using aDVanceERP.Modulos.CompraVenta.MVP.Modelos;
using aDVanceERP.Modulos.CompraVenta.MVP.Vistas.DetalleCompraventaProducto.Plantillas;
using aDVanceERP.Modulos.CompraVenta.MVP.Vistas.Venta.Plantillas;
using aDVanceERP.Modulos.CompraVenta.Repositorios;

namespace aDVanceERP.Modulos.CompraVenta.MVP.Presentadores;

public class
    PresentadorRegistroVenta : PresentadorRegistroBase<IVistaRegistroVenta, Venta, RepoVenta, FbVenta> {
    public PresentadorRegistroVenta(IVistaRegistroVenta vista) : base(vista) { }

    public override void PopularVistaDesdeEntidad(Venta objeto) {
        Vista.ModoEdicionDatos = true;
        Vista.RazonSocialCliente = UtilesCliente.ObtenerRazonSocialCliente(objeto.IdCliente) ?? string.Empty;
        Vista.NombreAlmacen = UtilesAlmacen.ObtenerNombreAlmacen(objeto.IdAlmacen) ?? string.Empty;
        Vista.Direccion = objeto.DireccionEntrega;
        Vista.EstadoEntrega = objeto.EstadoEntrega;

        var productosVenta = UtilesVenta.ObtenerProductosPorVenta(objeto.Id);

        foreach (var productoSplit in productosVenta.Select(producto => producto.Split('|')))
            ((IVistaGestionDetallesCompraventaProductos)Vista).AdicionarProducto(Vista.NombreAlmacen, productoSplit[0],
                productoSplit[1]);

        Vista.IdTipoEntrega = objeto.IdTipoEntrega;

        Entidad = objeto;
    }

    protected override Venta? ObtenerEntidadDesdeVista() {
        return new Venta(Entidad?.Id ?? 0,
            DateTime.Now,
            UtilesAlmacen.ObtenerIdAlmacen(Vista.NombreAlmacen).Result,
            UtilesCliente.ObtenerIdCliente(Vista.RazonSocialCliente),
            Vista.IdTipoEntrega,
            Vista.Direccion,
            Vista.EstadoEntrega,
            Vista.Total
        );
    }
}