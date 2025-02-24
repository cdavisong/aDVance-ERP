using aDVanceERP.Core.MVP.Presentadores;
using aDVanceERP.Modulos.Ventas.MVP.Modelos;
using aDVanceERP.Modulos.Ventas.MVP.Vistas.Venta.Plantillas;

namespace aDVanceERP.Modulos.Ventas.MVP.Presentadores {
    public class PresentadorTuplaVenta : PresentadorTuplaBase<IVistaTuplaVenta, Venta> {
        public PresentadorTuplaVenta(IVistaTuplaVenta vista, Venta objeto) : base(vista, objeto) {
        }
    }
}
