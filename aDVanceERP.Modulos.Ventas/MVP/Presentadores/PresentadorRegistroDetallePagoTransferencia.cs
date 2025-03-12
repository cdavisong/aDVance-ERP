using aDVanceERP.Core.MVP.Presentadores;
using aDVanceERP.Modulos.Ventas.MVP.Modelos;
using aDVanceERP.Modulos.Ventas.MVP.Modelos.Repositorios;
using aDVanceERP.Modulos.Ventas.MVP.Vistas.DetallePagoTransferencia.Plantillas;

namespace aDVanceERP.Modulos.Ventas.MVP.Presentadores {
    public class PresentadorRegistroDetallePagoTransferencia : PresentadorRegistroBase<IVistaRegistroDetallePagoTransferencia, DetallePagoTransferencia, DatosDetallePagoTransferencia, CriterioBusquedaDetallePagoTransferencia> {
        public PresentadorRegistroDetallePagoTransferencia(IVistaRegistroDetallePagoTransferencia vista) : base(vista) {
        }

        public override void PopularVistaDesdeObjeto(DetallePagoTransferencia objeto) {
            throw new NotImplementedException();
        }

        protected override async Task<DetallePagoTransferencia?> ObtenerObjetoDesdeVista() {
            throw new NotImplementedException();
        }
    }
}
