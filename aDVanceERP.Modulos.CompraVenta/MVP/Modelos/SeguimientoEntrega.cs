using aDVanceERP.Core.Interfaces;

namespace aDVanceERP.Modulos.CompraVenta.MVP.Modelos;

public class SeguimientoEntrega : IEntidadBd {
    public SeguimientoEntrega() { }

    public SeguimientoEntrega(long id, long idVenta, long idMensajero, DateTime fechaAsignacion, DateTime fechaEntrega,
        DateTime fechaPago, string? observaciones) {
        Id = id;
        IdVenta = idVenta;
        IdMensajero = idMensajero;
        FechaAsignacion = fechaAsignacion;
        FechaEntrega = fechaEntrega;
        FechaPago = fechaPago;
        Observaciones = observaciones;
    }

    public long IdVenta { get; set; }
    public long IdMensajero { get; set; }
    public DateTime FechaAsignacion { get; set; }
    public DateTime FechaEntrega { get; set; }
    public DateTime FechaPago { get; set; }
    public string? Observaciones { get; set; }

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

public enum CriterioBusquedaSeguimientoEntrega {
    Todos,
    Id,
    IdVenta,
    NombreMensajero,
    FechaAsignacion,
    FechaEntrega,
    FechaConfirmacion,
    FechaPago
}

public static class UtilesBusquedaSeguimientoEntrega {
    public static object[] CriterioSeguimientoEntrega = {
        "Todas las entregas",
        "Identificador de BD",
        "Identificador de la venta",
        "Nombre del mensajero",
        "Fecha de asignación de entrega",
        "Fecha de entrega",
        "Fecha de confirmación de entrega",
        "Fecha del pago de la venta"
    };
}