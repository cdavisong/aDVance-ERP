using aDVanceERP.Core.MVP.Modelos.Plantillas;

namespace aDVanceERP.Modulos.CompraVenta.MVP.Modelos {
    public class Pago : IObjetoUnico {
        public Pago() {
        }

        public Pago(long id, long idVenta, string metodoPago, float monto) {
            Id = id;
            IdVenta = idVenta;
            MetodoPago = metodoPago;
            Monto = monto;
        }

        public long Id { get; set; }
        public long IdVenta { get; set; }
        public string? MetodoPago { get; set; }
        public float Monto { get; set; }
    }

    public enum CriterioBusquedaPago {
        Todos,
        Id,
        IdVenta
    }
}
