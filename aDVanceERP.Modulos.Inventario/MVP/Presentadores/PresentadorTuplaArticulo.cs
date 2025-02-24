using aDVanceERP.Core.MVP.Presentadores;
using aDVanceERP.Modulos.Inventario.MVP.Modelos;
using aDVanceERP.Modulos.Inventario.MVP.Vistas.Articulo.Plantillas;

namespace aDVanceERP.Modulos.Inventario.MVP.Presentadores {
    public class PresentadorTuplaArticulo : PresentadorTuplaBase<IVistaTuplaArticulo, Articulo> {
        public PresentadorTuplaArticulo(IVistaTuplaArticulo vista, Articulo objeto) : base(vista, objeto) {
        }
    }
}
