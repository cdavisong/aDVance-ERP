using Manigest.Core.MVP.Vistas.Plantillas;

namespace Manigest.Modulos.Ventas.MVP.Vistas.Pago.Plantillas {
    public interface IVistaTuplaPago : IVistaTupla {
        string MetodoPago { get; set; }
        string Monto { get; set; }
    }
}
