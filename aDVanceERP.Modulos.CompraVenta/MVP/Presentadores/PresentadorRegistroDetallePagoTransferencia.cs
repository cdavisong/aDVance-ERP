using aDVanceERP.Core.MVP.Presentadores;
using aDVanceERP.Modulos.CompraVenta.MVP.Modelos;
using aDVanceERP.Modulos.CompraVenta.MVP.Modelos.Repositorios;
using aDVanceERP.Modulos.CompraVenta.MVP.Vistas.DetallePagoTransferencia.Plantillas;

namespace aDVanceERP.Modulos.CompraVenta.MVP.Presentadores {
    public class PresentadorRegistroDetallePagoTransferencia : PresentadorRegistroBase<IVistaRegistroDetallePagoTransferencia, DetallePagoTransferencia, DatosDetallePagoTransferencia, CriterioBusquedaDetallePagoTransferencia> {
        public PresentadorRegistroDetallePagoTransferencia(IVistaRegistroDetallePagoTransferencia vista) : base(vista) {
        }

        public override void PopularVistaDesdeObjeto(DetallePagoTransferencia objeto) {
            throw new NotImplementedException();
        }

        protected override DetallePagoTransferencia? ObtenerObjetoDesdeVista() {
            throw new NotImplementedException();
        }
    }
}
