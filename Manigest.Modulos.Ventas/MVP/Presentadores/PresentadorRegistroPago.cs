using Manigest.Core.MVP.Presentadores;
using Manigest.Modulos.Ventas.MVP.Modelos;
using Manigest.Modulos.Ventas.MVP.Modelos.Repositorios;
using Manigest.Modulos.Ventas.MVP.Vistas.Pago.Plantillas;

namespace Manigest.Modulos.Ventas.MVP.Presentadores {
    public class PresentadorRegistroPago : PresentadorRegistroBase<IVistaRegistroPago, Pago, DatosPago, CriterioBusquedaPago> {
        public PresentadorRegistroPago(IVistaRegistroPago vista) : base(vista) {
        }

        public override void PopularVistaDesdeObjeto(Pago objeto) {
            throw new NotImplementedException();
        }

        protected override Pago ObtenerObjetoDesdeVista() {
            throw new NotImplementedException();
        }
    }
}
