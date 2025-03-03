using aDVanceERP.Core.MVP.Presentadores;
using aDVanceERP.Core.Seguridad.MVP.Modelos;
using aDVanceERP.Core.Seguridad.MVP.Vistas.RolUsuario.Plantillas;

namespace aDVanceERP.Core.Seguridad.MVP.Presentadores {
    public class PresentadorTuplaRolUsuario : PresentadorTuplaBase<IVistaTuplaRolUsuario, RolUsuario> {
        public PresentadorTuplaRolUsuario(IVistaTuplaRolUsuario vista, RolUsuario objeto) : base(vista, objeto) {
        }
    }
}
