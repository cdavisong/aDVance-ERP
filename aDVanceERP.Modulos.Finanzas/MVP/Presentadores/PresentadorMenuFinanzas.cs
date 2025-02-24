using aDVanceERP.Core.MVP.Presentadores;
using aDVanceERP.Modulos.Finanzas.MVP.Vistas.Menu.Plantillas;

namespace aDVanceERP.Modulos.Finanzas.MVP.Presentadores {
    public class PresentadorMenuFinanzas : PresentadorBase<IVistaMenuFinanzas> {
        public PresentadorMenuFinanzas(IVistaMenuFinanzas vista) : base(vista) { }
    }
}
