using Manigest.Core.MVP.Vistas.Plantillas;

namespace Manigest.Modulos.PuntoVenta.MVP.Vistas.Venta.Plantillas {
    internal interface IVistaRegistroVenta : IVistaRegistro {
        string NombreCliente {  get; set; }
        string NombreAlmacen { get; set; }
        List<string> Productos { get; set; }
        float Total { get; set; }
                
        event EventHandler? AgregarProducto;
        event EventHandler? EliminarProducto;
        event EventHandler? EfectuarPago;

        void CargarNombresClientes(string[] nombresClientes);
        void CargarNombresAlmacenes(string[] nombresAlmacenes);
        void CargarNombresProductos(string[] nombresProductos);
        void ActualizarTotal(float total);
    }
}
