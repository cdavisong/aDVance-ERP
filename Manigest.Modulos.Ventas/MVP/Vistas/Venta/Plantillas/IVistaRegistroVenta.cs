using Manigest.Core.MVP.Vistas.Plantillas;

namespace Manigest.Modulos.Ventas.MVP.Vistas.Venta.Plantillas {
    public interface IVistaRegistroVenta : IVistaRegistro {
        string NombreCliente {  get; set; }
        string NombreAlmacen { get; set; }
        string NombreArticulo { get; set; }
        List<string[]> Articulos { get; }
        int Cantidad { get; set; }
        float Total { get; set; }
        bool PagoConfirmado { get; set; }

        event EventHandler? ArticuloAgregado;
        event EventHandler? ArticuloEliminado;
        event EventHandler? EfectuarPago;

        void CargarRazonesSocialesClientes(string[] nombresClientes);
        void CargarNombresAlmacenes(string[] nombresAlmacenes);
        void CargarNombresArticulos(string[] nombresProductos);
    }
}
