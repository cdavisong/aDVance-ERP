using aDVanceERP.Core.MVP.Presentadores;
using aDVanceERP.Modulos.CompraVenta.MVP.Vistas.Menu.Plantillas;

namespace aDVanceERP.Modulos.CompraVenta.MVP.Presentadores {
    public class PresentadorMenuVentas : PresentadorBase<IVistaMenuVentas> {
        public PresentadorMenuVentas(IVistaMenuVentas vista) : base(vista) { }
    }
}
