using aDVanceERP.Core.MVP.Presentadores.Plantillas;
using aDVanceERP.Core.MVP.Vistas.Plantillas;

namespace aDVanceERP.Core.MVP.Presentadores; 

public abstract class PresentadorBase<V> : IPresentadorBase<V> where V : class, IVista {
    protected PresentadorBase(V vista) {
        Vista = vista ?? throw new ArgumentNullException(nameof(vista));
    }

    public V Vista { get; }

    public abstract void Dispose();
}