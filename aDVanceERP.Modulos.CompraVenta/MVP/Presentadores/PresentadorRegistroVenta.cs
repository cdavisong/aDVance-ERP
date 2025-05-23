using aDVanceERP.Core.MVP.Presentadores;
using aDVanceERP.Core.Utiles.Datos;
using aDVanceERP.Modulos.CompraVenta.MVP.Modelos;
using aDVanceERP.Modulos.CompraVenta.MVP.Modelos.Repositorios;
using aDVanceERP.Modulos.CompraVenta.MVP.Vistas.DetalleCompraventaProducto.Plantillas;
using aDVanceERP.Modulos.CompraVenta.MVP.Vistas.Venta.Plantillas;

namespace aDVanceERP.Modulos.CompraVenta.MVP.Presentadores; 

public class
    PresentadorRegistroVenta : PresentadorRegistroBase<IVistaRegistroVenta, Venta, DatosVenta, CriterioBusquedaVenta> {
    public PresentadorRegistroVenta(IVistaRegistroVenta vista) : base(vista) { }

    public override void PopularVistaDesdeObjeto(Venta objeto) {
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

        Objeto = objeto;
    }

    protected override async Task<Venta?> ObtenerObjetoDesdeVista() {
        return new Venta(Objeto?.Id ?? 0,
            DateTime.Now,
            await UtilesAlmacen.ObtenerIdAlmacen(Vista.NombreAlmacen),
            UtilesCliente.ObtenerIdCliente(Vista.RazonSocialCliente),
            Vista.IdTipoEntrega,
            Vista.Direccion,
            Vista.EstadoEntrega,
            Vista.Total
        );
    }
}