using aDVanceERP.Core.MVP.Vistas.Plantillas;

namespace aDVanceERP.Modulos.CompraVenta.MVP.Vistas.Pago.Plantillas; 

public interface IVistaTuplaPago : IVistaTupla {
    string MetodoPago { get; set; }
    string Monto { get; set; }
}