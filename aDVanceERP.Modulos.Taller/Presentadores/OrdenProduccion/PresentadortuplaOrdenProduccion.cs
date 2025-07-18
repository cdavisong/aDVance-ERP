using aDVanceERP.Core.MVP.Presentadores;
using aDVanceERP.Modulos.Taller.Interfaces;

namespace aDVanceERP.Modulos.Taller.Presentadores.OrdenProduccion {
    public class PresentadortuplaOrdenProduccion : PresentadorTuplaBase<IVistaTuplaOrdenProduccion, Modelos.OrdenProduccion> {
        public PresentadortuplaOrdenProduccion(IVistaTuplaOrdenProduccion vista, Modelos.OrdenProduccion objeto) : base(vista, objeto) {
        }
    }
}