using Manigest.Core.MVP.Presentadores;
using Manigest.Modulos.Finanzas.MVP.Modelos;
using Manigest.Modulos.Finanzas.MVP.Vistas.Cuenta.Plantillas;

namespace Manigest.Modulos.Finanzas.MVP.Presentadores {
    public class PresentadorTuplaCuenta : PresentadorTuplaBase<IVistaTuplaCuenta, Cuenta> {
        public PresentadorTuplaCuenta(IVistaTuplaCuenta vista, Cuenta objeto) : base(vista, objeto) {
        }
    }
}
