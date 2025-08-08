using aDVanceERP.Core.Interfaces;

namespace aDVanceERP.Core.Presentadores;

public abstract class PresentadorVistaBase<Vi> 
    where Vi : class, IVista {
    protected PresentadorVistaBase(Vi vista) {
        Vista = vista ?? throw new ArgumentNullException(nameof(vista));
    }

    public Vi Vista { get; }

    public virtual void Dispose() {
        // Aquí puedes liberar recursos si es necesario
        // Por ejemplo, si la vista tiene eventos suscritos, desuscribirse de ellos
        Vista.Dispose();
    }
}