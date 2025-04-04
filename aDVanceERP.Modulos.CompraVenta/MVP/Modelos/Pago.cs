using aDVanceERP.Core.MVP.Modelos.Plantillas;

namespace aDVanceERP.Modulos.CompraVenta.MVP.Modelos; 

public class Pago : IObjetoUnico {
    public Pago() { }

    public Pago(long id, long idVenta, string metodoPago, decimal monto) {
        Id = id;
        IdVenta = idVenta;
        MetodoPago = metodoPago;
        Monto = monto;
        FechaConfirmacion = DateTime.Now;
        Estado = "Pendiente";
    }

    public long IdVenta { get; set; }
    public string? MetodoPago { get; set; }
    public decimal Monto { get; set; }
    public DateTime FechaConfirmacion { get; set; }
    public string? Estado { get; set; }

    public long Id { get; set; }
}

public enum CriterioBusquedaPago {
    Todos,
    Id,
    IdVenta
}