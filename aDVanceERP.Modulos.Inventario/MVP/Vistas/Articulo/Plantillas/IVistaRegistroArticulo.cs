using aDVanceERP.Core.MVP.Vistas.Plantillas;

namespace aDVanceERP.Modulos.Inventario.MVP.Vistas.Articulo.Plantillas {
    public interface IVistaRegistroArticulo : IVistaRegistro {
        string Codigo { get; set; }
        string Nombre { get; set; }
        string Descripcion { get; set; }
        string RazonSocialProveedor { get; set; }
        decimal PrecioCompraBase { get; set; }
        decimal PrecioVentaBase { get; set; }

        void CargarRazonesSocialesProveedores(object[] nombresProveedores);
    }
}
