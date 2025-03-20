using aDVanceERP.Core.MVP.Vistas.Plantillas;

namespace aDVanceERP.Modulos.CompraVenta.MVP.Vistas.Venta.Plantillas {
    public interface IVistaRegistroVenta : IVistaRegistro {
        string? RazonSocialCliente { get; set; }
        string? NombreAlmacen { get; set; }
        string? NombreArticulo { get; set; }
        List<string[]>? Articulos { get; }
        int Cantidad { get; set; }
        decimal Total { get; set; }
        bool PagoConfirmado { get; set; }

        event EventHandler? ArticuloAgregado;
        event EventHandler? ArticuloEliminado;
        event EventHandler? EfectuarPago;

        void CargarRazonesSocialesClientes(string[] nombresClientes);
        void CargarNombresAlmacenes(string[] nombresAlmacenes);
        void CargarNombresArticulos(string[] nombresArticulos);
    }
}
