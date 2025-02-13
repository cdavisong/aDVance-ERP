using Manigest.Core.MVP.Presentadores;
using Manigest.Modulos.PuntoVenta.MVP.Modelos;
using Manigest.Modulos.PuntoVenta.MVP.Modelos.Repositorios;
using Manigest.Modulos.PuntoVenta.MVP.Vistas.Venta.Plantillas;

namespace Manigest.Modulos.PuntoVenta.MVP.Presentadores {
    public class PresentadorGestionVenta : PresentadorGestionBase<PresentadorTuplaVenta, IVistaGestionVentas, IVistaTuplaVenta, Venta, DatosVenta, CriterioBusquedaVenta> {
        public PresentadorGestionVenta(IVistaGestionVentas vista) : base(vista) {
        }

        public override CriterioBusquedaVenta CriterioBusquedaObjeto { get; protected set; } = CriterioBusquedaVenta.Fecha;

        protected override PresentadorTuplaVenta ObtenerValoresTupla(Venta objeto) {
            throw new NotImplementedException();
        }
    }
}
