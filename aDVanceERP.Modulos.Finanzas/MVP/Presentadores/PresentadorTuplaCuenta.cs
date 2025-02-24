using aDVanceERP.Core.MVP.Presentadores;
using aDVanceERP.Modulos.Finanzas.MVP.Modelos;
using aDVanceERP.Modulos.Finanzas.MVP.Vistas.Cuenta.Plantillas;

namespace aDVanceERP.Modulos.Finanzas.MVP.Presentadores {
    public class PresentadorTuplaCuenta : PresentadorTuplaBase<IVistaTuplaCuenta, Cuenta> {
        public PresentadorTuplaCuenta(IVistaTuplaCuenta vista, Cuenta objeto) : base(vista, objeto) {
        }
    }
}
