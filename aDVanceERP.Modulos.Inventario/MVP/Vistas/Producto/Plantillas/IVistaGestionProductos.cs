using aDVanceERP.Core.Modelos.Comun.Interfaces;
using aDVanceERP.Core.Modelos.Modulos.Inventario;
using aDVanceERP.Core.MVP.Vistas.Plantillas;

namespace aDVanceERP.Modulos.Inventario.MVP.Vistas.Producto.Plantillas;

public interface IVistaGestionProductos : IVistaContenedor, IGestorEntidades, IBuscadorEntidades<FiltroBusquedaProducto>,
    IGestorTablaDatos {
    string? NombreAlmacen { get; }
    decimal ValorTotalInventario { get; }
    bool MostrarBtnHabilitarDeshabilitarProducto { get; set; }

    event EventHandler? HabilitarDeshabilitarProducto;

    void CargarNombresAlmacenes(object[] nombresAlmacenes);
}