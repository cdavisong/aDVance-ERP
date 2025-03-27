using aDVanceERP.Core.MVP.Vistas.Plantillas;

namespace aDVanceERP.Modulos.CompraVenta.MVP.Vistas.Compra.Plantillas {
    public interface IVistaRegistroCompra : IVistaRegistro {
        string? RazonSocialProveedor { get; set; }
        string? NombreAlmacen { get; set; }
        string? NombreArticulo { get; set; }
        int Cantidad { get; set; }
        decimal Total { get; set; }

        event EventHandler? RegistrarArticulo;

        void CargarRazonesSocialesProveedores(object[] nombresProveedores);
        void CargarNombresAlmacenes(object[] nombresAlmacenes);
        void CargarNombresArticulos(string[] nombresArticulos);
    }
}
