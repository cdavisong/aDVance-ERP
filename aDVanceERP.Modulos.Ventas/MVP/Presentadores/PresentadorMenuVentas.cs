using aDVanceERP.Core.MVP.Presentadores;
using aDVanceERP.Modulos.Ventas.MVP.Vistas.Menu.Plantillas;

namespace aDVanceERP.Modulos.Ventas.MVP.Presentadores {
    public class PresentadorMenuVentas : PresentadorBase<IVistaMenuVentas> {
        public PresentadorMenuVentas(IVistaMenuVentas vista) : base(vista) { }
    }
}
