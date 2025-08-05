using aDVanceERP.Core.Interfaces.Comun;

namespace aDVanceERP.Modulos.CompraVenta.MVP.Modelos; 

public class DetallePagoTransferencia : IEntidadBd {
    public DetallePagoTransferencia() { }

    public DetallePagoTransferencia(long id, long idVenta, long idTarjeta, string numeroConfirmacion,
        string numeroTransaccion) {
        Id = id;
        IdVenta = idVenta;
        IdTarjeta = idTarjeta;
        NumeroConfirmacion = numeroConfirmacion;
        NumeroTransaccion = numeroTransaccion;
    }

    public long IdVenta { get; set; }
    public long IdTarjeta { get; set; }
    public string? NumeroConfirmacion { get; set; }
    public string? NumeroTransaccion { get; set; }

    public long Id { get; set; }

    public (string query, Dictionary<string, object> parametros) GenerarQueryDelete() {
        throw new NotImplementedException();
    }

    public (string query, Dictionary<string, object> parametros) GenerarQueryInsert() {
        throw new NotImplementedException();
    }

    public (string query, Dictionary<string, object> parametros) GenerarQueryUpdate() {
        throw new NotImplementedException();
    }
}

public enum CriterioBusquedaDetallePagoTransferencia {
    Todos,
    Id,
    IdVenta,
    IdTarjeta
}