using aDVanceERP.Core.MVP.Modelos.Plantillas;

namespace aDVanceERP.Modulos.Ventas.MVP.Modelos {
    public class DetallePagoTransferencia : IObjetoUnico {
        public DetallePagoTransferencia(long id, long idVenta, long idTarjeta, string numeroConfirmacion, string numeroTransaccion) {
            Id = id;
            IdVenta = idVenta;
            IdTarjeta = idTarjeta;
            NumeroConfirmacion = numeroConfirmacion;
            NumeroTransaccion = numeroTransaccion;
        }

        public DetallePagoTransferencia(long idVenta, long idTarjeta, string numeroConfirmacion, string numeroTransaccion)
            : this(0, idVenta, idTarjeta, numeroConfirmacion, numeroTransaccion) { }

        public long Id { get; set; }
        public long IdVenta { get; set; }
        public long IdTarjeta { get; set; }
        public string NumeroConfirmacion { get; set; }
        public string NumeroTransaccion { get; set; }
    }

    public enum CriterioBusquedaDetallePagoTransferencia {
        Todos,
        Id,
        IdVenta,
        IdTarjeta
    }
}
