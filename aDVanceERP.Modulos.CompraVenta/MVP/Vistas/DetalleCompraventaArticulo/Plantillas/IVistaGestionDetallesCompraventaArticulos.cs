using aDVanceERP.Core.MVP.Modelos.Plantillas;
using aDVanceERP.Core.MVP.Vistas.Plantillas;

namespace aDVanceERP.Modulos.CompraVenta.MVP.Vistas.DetalleCompraventaArticulo.Plantillas {
    public interface IVistaGestionDetallesCompraventaArticulos : IVistaContenedor, IGestorDatos {
        void AdicionarArticulo(string nombreAlmacen = "", string nombreArticulo = "", string cantidad = "");
    }
}
