using aDVanceERP.Core.MVP.Modelos.Plantillas;

namespace aDVanceERP.Modulos.CompraVenta.MVP.Modelos; 

public class DetalleVentaArticulo : IObjetoUnico {
    public DetalleVentaArticulo() { }

    public DetalleVentaArticulo(long id, long idVenta, long idArticulo, decimal precioCompraVigente,
        decimal precioVentaFinal, int cantidad) {
        Id = id;
        IdVenta = idVenta;
        IdArticulo = idArticulo;
        PrecioCompraVigente = precioCompraVigente;
        PrecioVentaFinal = precioVentaFinal;
        Cantidad = cantidad;
    }

    public long IdVenta { get; set; }
    public long IdArticulo { get; set; }
    public decimal PrecioCompraVigente { get; set; }
    public decimal PrecioVentaFinal { get; set; }
    public int Cantidad { get; set; }

    public long Id { get; set; }
}

public enum CriterioDetalleVentaArticulo {
    Todos,
    Id,
    IdVenta,
    IdArticulo
}