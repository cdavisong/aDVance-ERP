using Manigest.Core.MVP.Vistas.Plantillas;

namespace Manigest.Modulos.Inventario.MVP.Vistas.Articulo.Plantillas {
    public interface IVistaRegistroArticulo : IVistaRegistro {
        string Codigo { get; set; }
        string Nombre { get; set; }
        string Descripcion { get; set; }
        string RazonSocialProveedor { get; set; }
        float PrecioAdquisicion { get; set; }
        float PrecioCesion { get; set; }
        int StockMinimo { get; set; }
        int PedidoMinimo { get; set; }

        void CargarRazonesSocialesProveedores(string[] nombresProveedores);
    }
}
