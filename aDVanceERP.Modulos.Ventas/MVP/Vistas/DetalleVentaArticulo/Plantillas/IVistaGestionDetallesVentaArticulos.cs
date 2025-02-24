using aDVanceERP.Core.MVP.Modelos.Plantillas;
using aDVanceERP.Core.MVP.Vistas.Plantillas;

namespace aDVanceERP.Modulos.Ventas.MVP.Vistas.DetalleVentaArticulo.Plantillas {
    public interface IVistaGestionDetallesVentaArticulos : IVistaContenedor, IGestorDatos {
        void AdicionarArticulo(string nombreAlmacen = "", string nombreArticulo = "", string cantidad = "");
    }
}
