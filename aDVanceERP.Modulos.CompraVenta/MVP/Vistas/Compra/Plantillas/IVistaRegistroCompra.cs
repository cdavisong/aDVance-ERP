using aDVanceERP.Core.MVP.Vistas.Plantillas;

namespace aDVanceERP.Modulos.CompraVenta.MVP.Vistas.Compra.Plantillas; 

public interface IVistaRegistroCompra : IVistaRegistro {
    string? RazonSocialProveedor { get; set; }
    string? NombreAlmacen { get; set; }
    string? NombreProducto { get; set; }
    List<string[]>? Productos { get; }
    float Cantidad { get; set; }
    decimal Total { get; set; }

    event EventHandler? AlturaContenedorTuplasModificada;
    event EventHandler? ProductoAgregado;
    event EventHandler? ProductoEliminado;

    void CargarRazonesSocialesProveedores(object[] nombresProveedores);
    void CargarNombresAlmacenes(object[] nombresAlmacenes);
    void CargarNombresProductos(string[] nombresProductos);
}