using aDVanceERP.Core.MVP.Presentadores;
using aDVanceERP.Modulos.Finanzas.MVP.Modelos;
using aDVanceERP.Modulos.Finanzas.MVP.Vistas.CuentaBancaria.Plantillas;

namespace aDVanceERP.Modulos.Finanzas.MVP.Presentadores {
    public class PresentadorTuplaCuentaBancaria : PresentadorTuplaBase<IVistaTuplaCuentaBancaria, CuentaBancaria> {
        public PresentadorTuplaCuentaBancaria(IVistaTuplaCuentaBancaria vista, CuentaBancaria objeto) : base(vista, objeto) {
        }
    }
}
