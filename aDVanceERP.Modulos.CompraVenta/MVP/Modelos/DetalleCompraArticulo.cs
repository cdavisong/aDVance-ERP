using aDVanceERP.Core.MVP.Modelos.Plantillas;

namespace aDVanceERP.Modulos.CompraVenta.MVP.Modelos {
    public class DetalleCompraArticulo : IObjetoUnico {
        public DetalleCompraArticulo() {
        }

        public DetalleCompraArticulo(long id, long idCompra, long idArticulo, int cantidad, decimal precioCompra) {
            Id = id;
            IdCompra = idCompra;
            IdArticulo = idArticulo;
            Cantidad = cantidad;
            PrecioCompra = precioCompra;
        }

        public long Id { get; set; }
        public long IdCompra { get; set; }
        public long IdArticulo { get; set; }
        public int Cantidad { get; set; }
        public decimal PrecioCompra { get; set; }
    }

    public enum CriterioDetalleCompraArticulo {
        Todos,
        Id,
        IdCompra,
        IdArticulo
    }
}
