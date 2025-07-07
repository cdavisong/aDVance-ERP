using aDVanceERP.Core.MVP.Presentadores;
using aDVanceERP.Modulos.Taller.Interfaces;
using aDVanceERP.Modulos.Taller.Modelos;
using aDVanceERP.Modulos.Taller.Repositorios;

namespace aDVanceERP.Modulos.Taller.Presentadores.CostosProduccion {
    public class PresentadorRegistroCostoProduccion : PresentadorRegistroBase<IVistaRegistroCostoProduccion, CostoProduccion, RepoCostoProduccion, FiltroBusquedaCostoProduccion> {
        public PresentadorRegistroCostoProduccion(IVistaRegistroCostoProduccion vista) : base(vista) {
        }

        public override void PopularVistaDesdeObjeto(CostoProduccion objeto) {
            Vista.ModoEdicionDatos = true;

        }

        protected override Task<CostoProduccion?> ObtenerObjetoDesdeVista() {
            throw new NotImplementedException();
        }
    }
}