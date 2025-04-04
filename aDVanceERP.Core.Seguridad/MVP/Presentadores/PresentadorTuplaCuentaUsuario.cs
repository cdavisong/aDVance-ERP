using aDVanceERP.Core.MVP.Presentadores;
using aDVanceERP.Core.Seguridad.MVP.Modelos;
using aDVanceERP.Core.Seguridad.MVP.Vistas.CuentaUsuario.Plantillas;

namespace aDVanceERP.Core.Seguridad.MVP.Presentadores; 

public class PresentadorTuplaCuentaUsuario : PresentadorTuplaBase<IVistaTuplaCuentaUsuario, CuentaUsuario> {
    public PresentadorTuplaCuentaUsuario(IVistaTuplaCuentaUsuario vista, CuentaUsuario objeto) : base(vista, objeto) { }
}