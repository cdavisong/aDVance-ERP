using Manigest.Core.MVP.Presentadores;
using Manigest.Modulos.Inventario.MVP.Modelos;
using Manigest.Modulos.Inventario.MVP.Vistas.Articulo.Plantillas;

namespace Manigest.Modulos.Inventario.MVP.Presentadores {
    public class PresentadorTuplaArticulo : PresentadorTuplaBase<IVistaTuplaArticulo, Articulo> {
        public PresentadorTuplaArticulo(IVistaTuplaArticulo vista, Articulo objeto) : base(vista, objeto) {            
        }
    }
}
