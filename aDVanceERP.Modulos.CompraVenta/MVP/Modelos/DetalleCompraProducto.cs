using aDVanceERP.Core.MVP.Modelos.Plantillas;

namespace aDVanceERP.Modulos.CompraVenta.MVP.Modelos; 

public class DetalleCompraProducto : IEntidad {
    public DetalleCompraProducto() { }

    public DetalleCompraProducto(long id, long idCompra, long idProducto, float cantidad, decimal precioCompra) {
        Id = id;
        IdCompra = idCompra;
        IdProducto = idProducto;
        Cantidad = cantidad;
        PrecioCompra = precioCompra;
    }

    public long IdCompra { get; set; }
    public long IdProducto { get; set; }
    public float Cantidad { get; set; }
    public decimal PrecioCompra { get; set; }

    public long Id { get; set; }
}

public enum FbCompraProducto {
    Todos,
    Id,
    IdCompra,
    IdProducto
}