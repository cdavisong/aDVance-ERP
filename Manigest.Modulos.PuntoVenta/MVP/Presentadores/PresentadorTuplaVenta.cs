using Manigest.Core.MVP.Presentadores;
using Manigest.Modulos.PuntoVenta.MVP.Modelos;
using Manigest.Modulos.PuntoVenta.MVP.Vistas.Venta.Plantillas;

namespace Manigest.Modulos.PuntoVenta.MVP.Presentadores {
    public class PresentadorTuplaVenta : PresentadorTuplaBase<IVistaTuplaVenta, Venta> {
        public PresentadorTuplaVenta(IVistaTuplaVenta vista, Venta objeto) : base(vista, objeto) {
        }
    }
}
