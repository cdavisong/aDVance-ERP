using aDVanceERP.Core.MVP.Presentadores.Plantillas;
using aDVanceERP.Core.MVP.Vistas.Plantillas;

namespace aDVanceERP.Core.MVP.Presentadores; 

public abstract class PresentadorBase<Vi> : IPresentadorBase<Vi> 
    where Vi : class, IVista {
    protected PresentadorBase(Vi vista) {
        Vista = vista ?? throw new ArgumentNullException(nameof(vista));
    }

    public Vi Vista { get; }

    public abstract void Dispose();
}