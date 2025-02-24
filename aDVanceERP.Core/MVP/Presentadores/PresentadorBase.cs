using aDVanceERP.Core.MVP.Presentadores.Plantillas;
using aDVanceERP.Core.MVP.Vistas.Plantillas;

namespace aDVanceERP.Core.MVP.Presentadores {
    public abstract class PresentadorBase<V> : IPresentadorBase<V>
        where V : IVista {
        protected PresentadorBase(V vista) {
            Vista = vista;
        }

        public V Vista { get; protected set; }
    }
}
