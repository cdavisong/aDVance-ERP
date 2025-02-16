using Manigest.Core.MVP.Presentadores;
using Manigest.Modulos.Ventas.MVP.Modelos;
using Manigest.Modulos.Ventas.MVP.Vistas.Venta.Plantillas;

namespace Manigest.Modulos.Ventas.MVP.Presentadores {
    public class PresentadorTuplaVenta : PresentadorTuplaBase<IVistaTuplaVenta, Venta> {
        public PresentadorTuplaVenta(IVistaTuplaVenta vista, Venta objeto) : base(vista, objeto) {
        }
    }
}
