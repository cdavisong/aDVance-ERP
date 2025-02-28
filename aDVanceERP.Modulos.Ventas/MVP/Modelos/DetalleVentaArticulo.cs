using aDVanceERP.Core.MVP.Modelos.Plantillas;

namespace aDVanceERP.Modulos.Ventas.MVP.Modelos {
    public class DetalleVentaArticulo : IObjetoUnico {
        public DetalleVentaArticulo() {
        }

        public DetalleVentaArticulo(long id, long idVenta, long idArticulo, float precioUnitario, int cantidad) {
            Id = id;
            IdVenta = idVenta;
            IdArticulo = idArticulo;
            PrecioUnitario = precioUnitario;
            Cantidad = cantidad;
        }

        public long Id { get; set; }
        public long IdVenta { get; set; }
        public long IdArticulo { get; set; }
        public float PrecioUnitario { get; set; }
        public int Cantidad { get; set; }
    }

    public enum CriterioDetalleVentaArticulo {
        Todos,
        Id,
        IdVenta,
        IdArticulo
    }
}
