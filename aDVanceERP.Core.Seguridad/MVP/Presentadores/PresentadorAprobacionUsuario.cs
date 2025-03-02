using aDVanceERP.Core.MVP.Presentadores;
using aDVanceERP.Core.Seguridad.MVP.Vistas.Autenticacion.Plantillas;

namespace aDVanceERP.Core.Seguridad.MVP.Presentadores {
    public class PresentadorAprobacionUsuario : PresentadorBase<IVistaAprobacionUsuario> {
        public PresentadorAprobacionUsuario(IVistaAprobacionUsuario vista) : base(vista) {
        }
    }
}
