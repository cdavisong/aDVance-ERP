using Manigest.Core.MVP.Presentadores;
using Manigest.Modulos.Ventas.MVP.Modelos;
using Manigest.Modulos.Ventas.MVP.Modelos.Repositorios;
using Manigest.Modulos.Ventas.MVP.Vistas.DetallePagoTransferencia.Plantillas;

namespace Manigest.Modulos.Ventas.MVP.Presentadores {
    public class PresentadorRegistroDetallePagoTransferencia : PresentadorRegistroBase<IVistaRegistroDetallePagoTransferencia, DetallePagoTransferencia, DatosDetallePagoTransferencia, CriterioBusquedaDetallePagoTransferencia> {
        public PresentadorRegistroDetallePagoTransferencia(IVistaRegistroDetallePagoTransferencia vista) : base(vista) {
        }

        public override void PopularVistaDesdeObjeto(DetallePagoTransferencia objeto) {
            throw new NotImplementedException();
        }

        protected override DetallePagoTransferencia ObtenerObjetoDesdeVista() {
            throw new NotImplementedException();
        }
    }
}
