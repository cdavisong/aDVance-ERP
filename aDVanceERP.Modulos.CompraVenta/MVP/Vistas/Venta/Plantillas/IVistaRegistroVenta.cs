using aDVanceERP.Core.MVP.Vistas.Plantillas;

namespace aDVanceERP.Modulos.CompraVenta.MVP.Vistas.Venta.Plantillas {
    public interface IVistaRegistroVenta : IVistaRegistro {
        string? RazonSocialCliente { get; set; }
        string? NombreAlmacen { get; set; }
        string? NombreArticulo { get; set; }
        List<string[]>? Articulos { get; }
        int Cantidad { get; set; }
        decimal Total { get; set; }
        long IdTipoEntrega { get; set; }
        string Direccion { get; set; }
        bool PagoConfirmado { get; set; }
        string EstadoEntrega { get; set; }

        event EventHandler? ArticuloAgregado;
        event EventHandler? ArticuloEliminado;
        event EventHandler? EfectuarPago;
        event EventHandler? AsignarMensajeria;

        void CargarRazonesSocialesClientes(object[] nombresClientes);
        void CargarNombresAlmacenes(object[] nombresAlmacenes);
        void CargarNombresArticulos(string[] nombresArticulos);
    }
}
