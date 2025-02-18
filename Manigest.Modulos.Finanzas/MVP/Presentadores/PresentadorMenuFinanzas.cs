using Manigest.Core.MVP.Presentadores;
using Manigest.Modulos.Finanzas.MVP.Vistas.Menu.Plantillas;

namespace Manigest.Modulos.Finanzas.MVP.Presentadores {
    public class PresentadorMenuFinanzas : PresentadorBase<IVistaMenuFinanzas> {
        public PresentadorMenuFinanzas(IVistaMenuFinanzas vista) : base(vista) { }
    }
}
