using aDVanceERP.Core.MVP.Presentadores;
using aDVanceERP.Modulos.CompraVenta.MVP.Vistas.Menu.Plantillas;

namespace aDVanceERP.Modulos.CompraVenta.MVP.Presentadores {
    public class PresentadorMenuCompraventas : PresentadorBase<IVistaMenuVentas> {
        public PresentadorMenuCompraventas(IVistaMenuVentas vista) : base(vista) { }
    }
}
