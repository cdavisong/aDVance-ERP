using Manigest.Core.MVP.Presentadores;
using Manigest.Modulos.Inventario.MVP.Modelos;
using Manigest.Modulos.Inventario.MVP.Vistas.Movimiento.Plantillas;

namespace Manigest.Modulos.Inventario.MVP.Presentadores {
    public class PresentadorTuplaMovimiento : PresentadorTuplaBase<IVistaTuplaMovimiento, Movimiento> {
        public PresentadorTuplaMovimiento(IVistaTuplaMovimiento vista, Movimiento objeto) : base(vista, objeto) {
        }
    }
}
