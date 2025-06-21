using aDVanceERP.Core.MVP.Modelos.Plantillas;

namespace aDVanceERP.Modulos.Inventario.MVP.Modelos; 

public class ProductoAlmacen : IEntidad {
    public ProductoAlmacen() { }

    public ProductoAlmacen(long idProductoAlmacen, long idProducto, long idAlmacen, float stock) {
        Id = idProductoAlmacen;
        IdProducto = idProducto;
        IdAlmacen = idAlmacen;
        Stock = stock;
    }

    public long Id { get; set; }
    public long IdProducto { get; set; }
    public long IdAlmacen { get; set; }
    public float Stock { get; set; }
}

public enum FbProductoAlmacen {
    Todos,
    Id,
    IdProducto,
    IdAlmacen
}