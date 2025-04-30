using aDVanceERP.Core.MVP.Presentadores;
using aDVanceERP.Core.Seguridad.MVP.Vistas.Menu.Plantillas;

namespace aDVanceERP.Core.Seguridad.MVP.Presentadores {
    public class PresentadorMenuUsuario : PresentadorBase<IVistaMenuUsuario> {
        public PresentadorMenuUsuario(IVistaMenuUsuario vista) : base(vista) {
        }
    }
}
