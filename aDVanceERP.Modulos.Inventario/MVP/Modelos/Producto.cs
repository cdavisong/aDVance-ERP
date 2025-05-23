using aDVanceERP.Core.MVP.Modelos.Plantillas;

namespace aDVanceERP.Modulos.Inventario.MVP.Modelos; 

public class Producto : IObjetoUnico {
    public Producto() { }

    public Producto(long id, string codigo, string nombre, string descripcion, long idProveedor,
        decimal precioCompraBase, decimal precioVentaBase) {
        Id = id;
        Codigo = codigo;
        Nombre = nombre;
        Descripcion = descripcion;
        IdProveedor = idProveedor;
        PrecioCompraBase = precioCompraBase;
        PrecioVentaBase = precioVentaBase;
    }

    public string? Codigo { get; }
    public string? Nombre { get; }
    public string? Descripcion { get; set; }
    public long IdProveedor { get; set; }
    public decimal PrecioCompraBase { get; }
    public decimal PrecioVentaBase { get; }
    public string? Stock { get; set; }
    public string? NombreAlmacen { get; set; }

    public long Id { get; set; }
}

public enum CriterioBusquedaProducto {
    Todos,
    Id,
    Codigo,
    Nombre
}

public static class UtilesBusquedaProducto {
    public static object[] CriterioBusquedaProducto = {
        "Todos los productos",
        "Identificador de BD",
        "Código del producto",
        "Nombre del producto"
    };
}