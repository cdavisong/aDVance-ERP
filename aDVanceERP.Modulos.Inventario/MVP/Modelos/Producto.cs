using aDVanceERP.Core.MVP.Modelos.Plantillas;

namespace aDVanceERP.Modulos.Inventario.MVP.Modelos; 

public enum TipoProducto {
    Mercancia,
    ProductoTerminado,
    MateriaPrima
}

public class Producto : IObjetoUnico {
    public Producto() {
        Tipo = TipoProducto.Mercancia;
        Nombre = "Producto genérico";
    }

    public Producto(long id, TipoProducto tipo, string nombre, string codigo, string descripcion, long idProveedor,
        decimal precioCompraBase, decimal precioVentaBase) {
        Id = id;
        Tipo = tipo;
        Nombre = nombre;
        Codigo = codigo;        
        Descripcion = descripcion;
        IdProveedor = idProveedor;
        PrecioCompraBase = precioCompraBase;
        PrecioVentaBase = precioVentaBase;
    }

    public long Id { get; set; }
    public TipoProducto Tipo { get; set; }
    public string Nombre { get; set; }
    public string? Codigo { get; }
    public string? Descripcion { get; set; }
    public long IdProveedor { get; set; }
    public decimal PrecioCompraBase { get; }
    public decimal PrecioVentaBase { get; }
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