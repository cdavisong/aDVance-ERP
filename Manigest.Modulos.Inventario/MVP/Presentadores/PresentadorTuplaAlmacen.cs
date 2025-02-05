using Manigest.Core.MVP.Presentadores;
using Manigest.Modulos.Inventario.MVP.Modelos;
using Manigest.Modulos.Inventario.MVP.Vistas.Almacen.Plantillas;

namespace Manigest.Modulos.Inventario.MVP.Presentadores {
    public class PresentadorTuplaAlmacen : PresentadorTuplaBase<IVistaTuplaAlmacen, Almacen> {
        public PresentadorTuplaAlmacen(IVistaTuplaAlmacen vista, Almacen objeto) : base(vista, objeto) {
        }
    }

}
