using aDVanceERP.Core.Presentadores;
using aDVanceERP.Core.Seguridad.MVP.Vistas.Autenticacion.Plantillas;

namespace aDVanceERP.Core.Seguridad.MVP.Presentadores;

public class PresentadorAprobacionUsuario : PresentadorVistaBase<IVistaAprobacionUsuario> {
    public PresentadorAprobacionUsuario(IVistaAprobacionUsuario vista) : base(vista) { }

    public override void Dispose() {
        //...
    }
}