using aDVanceERP.Core.MVP.Presentadores;
using aDVanceERP.Modulos.Taller.Interfaces;
using aDVanceERP.Modulos.Taller.Modelos;
using aDVanceERP.Modulos.Taller.Repositorios;

namespace aDVanceERP.Modulos.Taller.Presentadores.OrdenProduccion {
    public class PresentadorRegistroOrdenProduccion : PresentadorRegistroBase<IVistaRegistroOrdenProduccion, Modelos.OrdenProduccion, RepoOrdenProduccion, CriterioBusquedaOrdenProduccion> {
        public PresentadorRegistroOrdenProduccion(IVistaRegistroOrdenProduccion vista) : base(vista) {
        }

        public override void PopularVistaDesdeObjeto(Modelos.OrdenProduccion objeto) {
            Vista.ModoEdicionDatos = true;

        }

        protected override async Task<Modelos.OrdenProduccion?> ObtenerObjetoDesdeVista() {
            throw new NotImplementedException();
        }
    }
}