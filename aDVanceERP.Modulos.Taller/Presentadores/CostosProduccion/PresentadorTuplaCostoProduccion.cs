using aDVanceERP.Core.MVP.Presentadores;
using aDVanceERP.Modulos.Taller.Interfaces;
using aDVanceERP.Modulos.Taller.Modelos;

namespace aDVanceERP.Modulos.Taller.Presentadores.CostosProduccion {
    public class PresentadorTuplaCostoProduccion : PresentadorTuplaBase<IVistaTuplaCostoProduccion, CostoProduccion> {
        public PresentadorTuplaCostoProduccion(IVistaTuplaCostoProduccion vista, CostoProduccion objeto) : base(vista, objeto) { }
    }
}