using Manigest.Core.MVP.Presentadores;
using Manigest.Modulos.Ventas.MVP.Modelos;
using Manigest.Modulos.Ventas.MVP.Modelos.Repositorios;
using Manigest.Modulos.Ventas.MVP.Vistas.Venta.Plantillas;

namespace Manigest.Modulos.Ventas.MVP.Presentadores {
    public class PresentadorRegistroVenta : PresentadorRegistroBase<IVistaRegistroVenta, Venta, DatosVenta, CriterioBusquedaVenta> {
        public PresentadorRegistroVenta(IVistaRegistroVenta vista) : base(vista) {
        }

        public override void PopularVistaDesdeObjeto(Venta objeto) {
            //...
        }

        protected override Venta ObtenerObjetoDesdeVista() {
            throw new NotImplementedException();
        }
    }
}
