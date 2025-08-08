using aDVanceERP.Core.Modelos.Modulos.Seguridad;
using aDVanceERP.Core.Presentadores;
using aDVanceERP.Core.Seguridad.MVP.Vistas.RolUsuario.Plantillas;

namespace aDVanceERP.Core.Seguridad.MVP.Presentadores;

public class PresentadorTuplaRolUsuario : PresentadorVistaTuplaBase<IVistaTuplaRolUsuario, RolUsuario> {
    public PresentadorTuplaRolUsuario(IVistaTuplaRolUsuario vista, RolUsuario objeto) : base(vista, objeto) { }
}