using aDVanceERP.Core.Presentadores;
using aDVanceERP.Core.Seguridad.MVP.Vistas.Menu.Plantillas;

namespace aDVanceERP.Core.Seguridad.MVP.Presentadores;

public class PresentadorMenuSeguridad : PresentadorVistaBase<IVistaMenuSeguridad> {
    public PresentadorMenuSeguridad(IVistaMenuSeguridad vista) : base(vista) { }

    public override void Dispose() {
        //...
    }
}