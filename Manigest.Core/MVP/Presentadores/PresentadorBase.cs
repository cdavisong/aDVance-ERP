using Manigest.Core.MVP.Presentadores.Plantillas;
using Manigest.Core.MVP.Vistas.Plantillas;

namespace Manigest.Core.MVP.Presentadores {
    public abstract class PresentadorBase<V> : IPresentadorBase<V>
        where V : IVista {
        protected PresentadorBase(V vista) {
            Vista = vista;
        }

        public V Vista { get; protected set; }
    }
}
