using aDVanceERP.Core.MVP.Presentadores;
using aDVanceERP.Modulos.Taller.Interfaces;

namespace aDVanceERP.Modulos.Taller.Presentadores.Menu {
    public class PresentadorMenuTaller : PresentadorBase<IVistaMenuTaller> {
        public PresentadorMenuTaller(IVistaMenuTaller vista) : base(vista) { }

        public override void Dispose() {
            //...
        }
    }
}