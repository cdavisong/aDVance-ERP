
using aDVanceERP.Core.MVP.Presentadores;
using aDVanceERP.Modulos.Taller.Interfaces;
using aDVanceERP.Modulos.Taller.Modelos;
using aDVanceERP.Modulos.Taller.Repositorios;

namespace aDVanceERP.Modulos.Taller.Presentadores.OrdenProduccion {
    public class PresentadorGestionOrdenesProduccion : PresentadorGestionBase<PresentadortuplaOrdenProduccion, IVistaGestionOrdenesProduccion, IVistaTuplaOrdenProduccion, Modelos.OrdenProduccion, RepoOrdenProduccion, CriterioBusquedaOrdenProduccion> {
        public PresentadorGestionOrdenesProduccion(IVistaGestionOrdenesProduccion vista) : base(vista) {
        }

        protected override PresentadortuplaOrdenProduccion ObtenerValoresTupla(Modelos.OrdenProduccion objeto) {
            throw new NotImplementedException();
        }
    }
}