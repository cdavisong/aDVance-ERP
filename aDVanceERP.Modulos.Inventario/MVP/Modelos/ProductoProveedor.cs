using aDVanceERP.Core.MVP.Modelos.Plantillas;

namespace aDVanceERP.Modulos.Inventario.MVP.Modelos; 

public class ProductoProveedor : IEntidad {
    public ProductoProveedor() { }

    public ProductoProveedor(long id, long idProveedor, decimal precioAdquisicion, decimal precioVenta) {
        Id = id;
        IdProveedor = idProveedor;
        PrecioAdquisicion = precioAdquisicion;
        PrecioVenta = precioVenta;
    }

    public long IdProducto { get; set; }
    public long IdProveedor { get; set; }
    public decimal PrecioAdquisicion { get; }
    public decimal PrecioVenta { get; }

    public long Id { get; set; }
}

public enum FbProductoProveedor {
    Todos,
    Id
}

public static class UtilesBusquedaProductoProveedor {
    public static string[] FbProducto = {
        "Todos los productos",
        "Identificador de BD"
    };
}