using aDVanceERP.Core.MVP.Presentadores;
using aDVanceERP.Modulos.Inventario.MVP.Vistas.Menu.Plantillas;

namespace aDVanceERP.Modulos.Inventario.MVP.Presentadores {
    public class PresentadorMenuInventario : PresentadorBase<IVistaMenuInventario> {
        public PresentadorMenuInventario(IVistaMenuInventario vista) : base(vista) {
        }
    }
}
