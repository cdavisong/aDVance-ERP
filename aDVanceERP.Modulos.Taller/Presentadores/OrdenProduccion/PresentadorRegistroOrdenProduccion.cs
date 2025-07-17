using aDVanceERP.Modulos.Taller.Interfaces;
using aDVanceERP.Modulos.Taller.Modelos;

namespace aDVanceERP.Modulos.Taller.Presentadores.OrdenProduccion {
    public class PresentadorRegistroOrdenProduccion : PresentadorRegistroBase<IVistaRegistroOrdenProduccion, > {
        public PresentadorRegistroOrdenProduccion(IVistaRegistroCostoDirecto vista) : base(vista) {
        }

        public override void PopularVistaDesdeObjeto(CostoDirecto objeto) {
            Vista.ModoEdicionDatos = true;

        }

        protected override Task<CostoDirecto?> ObtenerObjetoDesdeVista() {
            throw new NotImplementedException();
        }
    }
}