using aDVanceERP.Core.MVP.Presentadores;
using aDVanceERP.Modulos.Inventario.MVP.Modelos;
using aDVanceERP.Modulos.Inventario.MVP.Vistas.Movimiento.Plantillas;

namespace aDVanceERP.Modulos.Inventario.MVP.Presentadores {
    public class PresentadorTuplaMovimiento : PresentadorTuplaBase<IVistaTuplaMovimiento, Movimiento> {
        public PresentadorTuplaMovimiento(IVistaTuplaMovimiento vista, Movimiento objeto) : base(vista, objeto) {
        }
    }
}
