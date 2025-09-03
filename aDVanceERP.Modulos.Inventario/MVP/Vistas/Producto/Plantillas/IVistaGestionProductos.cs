using aDVanceERP.Core.Modelos.Modulos.Inventario;
using aDVanceERP.Core.MVP.Modelos.Plantillas;
using aDVanceERP.Core.MVP.Vistas.Plantillas;

namespace aDVanceERP.Modulos.Inventario.MVP.Vistas.Producto.Plantillas; 

public interface IVistaGestionProductos : IVistaContenedor, IGestorDatos, IBuscadorDatos<FiltroBusquedaProducto>,
    IGestorTablaDatos {
    string? NombreAlmacen { get; }
    string ValorBrutoInversion { get; }

    void CargarNombresAlmacenes(object[] nombresAlmacenes);
}