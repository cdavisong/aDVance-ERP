using aDVanceERP.Core.MVP.Presentadores;
using aDVanceERP.Core.Utiles.Datos;
using aDVanceERP.Modulos.CompraVenta.MVP.Modelos;
using aDVanceERP.Modulos.CompraVenta.MVP.Modelos.Repositorios;
using aDVanceERP.Modulos.CompraVenta.MVP.Vistas.Compra.Plantillas;
using aDVanceERP.Modulos.CompraVenta.MVP.Vistas.DetalleCompraventaArticulo.Plantillas;

namespace aDVanceERP.Modulos.CompraVenta.MVP.Presentadores; 

public class
    PresentadorRegistroCompra : PresentadorRegistroBase<IVistaRegistroCompra, Compra, DatosCompra,
        CriterioBusquedaCompra> {
    public PresentadorRegistroCompra(IVistaRegistroCompra vista) : base(vista) { }

    public override void PopularVistaDesdeObjeto(Compra objeto) {
        Vista.RazonSocialProveedor = UtilesProveedor.ObtenerRazonSocialProveedor(objeto.IdProveedor) ?? string.Empty;
        Vista.NombreAlmacen = UtilesAlmacen.ObtenerNombreAlmacen(objeto.IdAlmacen) ?? string.Empty;
        Vista.ModoEdicionDatos = true;

        var articulosCompra = UtilesCompra.ObtenerArticulosPorCompra(objeto.Id);

        foreach (var articuloSplit in articulosCompra.Select(articulo => articulo.Split('|')))
            ((IVistaGestionDetallesCompraventaArticulos)Vista).AdicionarArticulo(Vista.NombreAlmacen, articuloSplit[0],
                articuloSplit[1]);

        Objeto = objeto;
    }

    protected override async Task<Compra?> ObtenerObjetoDesdeVista() {
        return new Compra(Objeto?.Id ?? 0,
            DateTime.Now,
            await UtilesAlmacen.ObtenerIdAlmacen(Vista.NombreAlmacen),
            await UtilesProveedor.ObtenerIdProveedor(Vista.RazonSocialProveedor),
            Vista.Total
        );
    }
}