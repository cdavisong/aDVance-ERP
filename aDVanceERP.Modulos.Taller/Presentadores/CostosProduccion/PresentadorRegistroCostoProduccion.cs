using aDVanceERP.Core.MVP.Presentadores;
using aDVanceERP.Modulos.Taller.Interfaces;
using aDVanceERP.Modulos.Taller.Modelos;
using aDVanceERP.Modulos.Taller.Repositorios;

namespace aDVanceERP.Modulos.Taller.Presentadores.CostosProduccion {
    public class PresentadorRegistroCostoProduccion : PresentadorRegistroBase<IVistaRegistroCostoDirecto, CostoDirecto, RepoCostoDirecto, FiltroBusquedaCostoProduccion> {
        public PresentadorRegistroCostoProduccion(IVistaRegistroCostoDirecto vista) : base(vista) {
        }

        public override void PopularVistaDesdeObjeto(CostoDirecto objeto) {
            Vista.ModoEdicionDatos = true;

        }

        protected override Task<CostoDirecto?> ObtenerObjetoDesdeVista() {
            throw new NotImplementedException();
        }
    }
}