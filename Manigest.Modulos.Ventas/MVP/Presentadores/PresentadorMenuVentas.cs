using Manigest.Core.MVP.Presentadores;
using Manigest.Modulos.Ventas.MVP.Vistas.Menu.Plantillas;

namespace Manigest.Modulos.Ventas.MVP.Presentadores {
    public class PresentadorMenuVentas : PresentadorBase<IVistaMenuVentas> {
        public PresentadorMenuVentas(IVistaMenuVentas vista) : base(vista) {
        }
    }
}
