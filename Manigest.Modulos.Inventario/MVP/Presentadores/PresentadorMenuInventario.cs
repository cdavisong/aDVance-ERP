using Manigest.Core.MVP.Presentadores;
using Manigest.Modulos.Inventario.MVP.Vistas.Menu.Plantillas;

namespace Manigest.Modulos.Inventario.MVP.Presentadores {
    public class PresentadorMenuInventario : PresentadorBase<IVistaMenuInventario> {
        public PresentadorMenuInventario(IVistaMenuInventario vista) : base(vista) {
        }
    }
}
