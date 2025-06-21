using aDVanceERP.Core.MVP.Modelos.Plantillas;
using aDVanceERP.Core.MVP.Vistas.Plantillas;
using aDVanceERP.Modulos.Inventario.MVP.Modelos;

namespace aDVanceERP.Modulos.Inventario.MVP.Vistas.Producto.Plantillas; 

public interface IVistaGestionProductos : IVistaContenedor, IGestorDatos, IBuscadorDatos<FbProducto>,
    IGestorTablaDatos {
    string? NombreAlmacen { get; }
    string ValorBrutoInversion { get; }

    void CargarNombresAlmacenes(object[] nombresAlmacenes);
}