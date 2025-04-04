using aDVanceERP.Core.MVP.Presentadores;
using aDVanceERP.Core.Utiles.Datos;
using aDVanceERP.Modulos.Inventario.MVP.Modelos;
using aDVanceERP.Modulos.Inventario.MVP.Modelos.Repositorios;
using aDVanceERP.Modulos.Inventario.MVP.Vistas.Articulo.Plantillas;

namespace aDVanceERP.Modulos.Inventario.MVP.Presentadores; 

public class PresentadorRegistroArticulo : PresentadorRegistroBase<IVistaRegistroArticulo, Articulo, DatosArticulo,
    CriterioBusquedaArticulo> {
    public PresentadorRegistroArticulo(IVistaRegistroArticulo vista) : base(vista) { }

    public override void PopularVistaDesdeObjeto(Articulo objeto) {
        Vista.ModoEdicionDatos = true;
        Vista.Codigo = objeto.Codigo ?? string.Empty;
        Vista.Nombre = objeto.Nombre ?? string.Empty;
        Vista.Descripcion = objeto.Descripcion ?? string.Empty;
        Vista.RazonSocialProveedor = UtilesProveedor.ObtenerRazonSocialProveedor(objeto.IdProveedor) ?? string.Empty;
        Vista.PrecioCompraBase = objeto.PrecioCompraBase;
        Vista.PrecioVentaBase = objeto.PrecioVentaBase;
        Vista.ModoEdicionDatos = true;

        Objeto = objeto;
    }

    protected override async Task<Articulo?> ObtenerObjetoDesdeVista() {
        return new Articulo(
            Objeto?.Id ?? 0,
            Vista.Codigo,
            Vista.Nombre,
            Vista.Descripcion,
            await UtilesProveedor.ObtenerIdProveedor(Vista.RazonSocialProveedor),
            Vista.PrecioCompraBase,
            Vista.PrecioVentaBase
        );
    }
}