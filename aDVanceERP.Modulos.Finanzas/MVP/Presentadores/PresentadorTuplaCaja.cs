using aDVanceERP.Core.MVP.Presentadores;
using aDVanceERP.Modulos.Finanzas.MVP.Modelos;
using aDVanceERP.Modulos.Finanzas.MVP.Vistas.Caja.Plantillas;

namespace aDVanceERP.Modulos.Finanzas.MVP.Presentadores {
    public class PresentadorTuplaCaja : PresentadorTuplaBase<IVistaTuplaCaja, Caja> {
        public PresentadorTuplaCaja(IVistaTuplaCaja vista, Caja objeto) 
            : base(vista, objeto) { }
    }
}
