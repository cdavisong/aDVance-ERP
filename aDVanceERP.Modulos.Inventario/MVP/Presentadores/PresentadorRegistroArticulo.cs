using aDVanceERP.Core.Mensajes.Utiles;
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

    protected override bool RegistroEdicionDatosAutorizado() {
        var nombreOk = !string.IsNullOrEmpty(Vista.Nombre);
        var precioCompraOk = Vista.PrecioCompraBase > 0;
        var precioVentaOk = Vista.PrecioVentaBase > 0;

        if (!nombreOk)
            CentroNotificaciones.Mostrar("El campo de nombre es obligatorio para el artículo, por favor, corrija los datos entrados", Core.Mensajes.MVP.Modelos.TipoNotificacion.Advertencia);
        if (!precioCompraOk)
            CentroNotificaciones.Mostrar("Debe especificar un monto válido para el precio de compra, por favor, corrija los datos entrados", Core.Mensajes.MVP.Modelos.TipoNotificacion.Advertencia);
        if (!precioVentaOk)
            CentroNotificaciones.Mostrar("Debe especificar un monto válido para el precio de venta, por favor, corrija los datos entrados", Core.Mensajes.MVP.Modelos.TipoNotificacion.Advertencia);

        return nombreOk && precioCompraOk && precioVentaOk;
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