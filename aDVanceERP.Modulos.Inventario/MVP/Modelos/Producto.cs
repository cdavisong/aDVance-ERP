using aDVanceERP.Core.MVP.Modelos.Plantillas;

namespace aDVanceERP.Modulos.Inventario.MVP.Modelos; 

public enum CategoriaProducto {
    Mercancia,
    ProductoTerminado,
    MateriaPrima
}

public class Producto : IObjetoUnico {
    public Producto() {
        Categoria = CategoriaProducto.Mercancia;
        Nombre = "Producto genérico";
    }

    public Producto(long id, CategoriaProducto categoria, string nombre, string codigo, long idDetalleProducto, long idProveedor,
        bool esVendible, decimal precioCompraBase, decimal precioVentaBase) {
        Id = id;
        Categoria = categoria;
        Nombre = nombre;
        Codigo = codigo;        
        IdDetalleProducto = idDetalleProducto;
        IdProveedor = idProveedor;
        EsVendible = esVendible;
        PrecioCompraBase = precioCompraBase;
        PrecioVentaBase = precioVentaBase;
    }

    public long Id { get; set; }
    public CategoriaProducto Categoria { get; set; }
    public string Nombre { get; set; }
    public string? Codigo { get; }
    public long IdDetalleProducto { get; set; }
    public long IdProveedor { get; set; }
    public bool EsVendible { get; set; } = true;
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