using aDVanceERP.Core.MVP.Presentadores;
using aDVanceERP.Core.Seguridad.MVP.Vistas.Menu.Plantillas;

namespace aDVanceERP.Core.Seguridad.MVP.Presentadores; 

public class PresentadorMenuSeguridad : PresentadorBase<IVistaMenuSeguridad> {
    public PresentadorMenuSeguridad(IVistaMenuSeguridad vista) : base(vista) { }

    public override void Dispose() {
        //...
    }
}