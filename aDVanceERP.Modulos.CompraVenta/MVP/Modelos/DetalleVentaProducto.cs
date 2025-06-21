using aDVanceERP.Core.MVP.Modelos.Plantillas;

namespace aDVanceERP.Modulos.CompraVenta.MVP.Modelos; 

public class DetalleVentaProducto : IEntidad {
    public DetalleVentaProducto() { }

    public DetalleVentaProducto(long id, long idVenta, long idProducto, decimal precioCompraVigente,
        decimal precioVentaFinal, float cantidad) {
        Id = id;
        IdVenta = idVenta;
        IdProducto = idProducto;
        PrecioCompraVigente = precioCompraVigente;
        PrecioVentaFinal = precioVentaFinal;
        Cantidad = cantidad;
    }

    public long IdVenta { get; set; }
    public long IdProducto { get; set; }
    public decimal PrecioCompraVigente { get; set; }
    public decimal PrecioVentaFinal { get; set; }
    public float Cantidad { get; set; }

    public long Id { get; set; }
}

public enum CriterioDetalleVentaProducto {
    Todos,
    Id,
    IdVenta,
    IdProducto
}