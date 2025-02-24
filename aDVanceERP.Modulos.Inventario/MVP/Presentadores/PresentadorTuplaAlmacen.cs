using aDVanceERP.Core.MVP.Presentadores;
using aDVanceERP.Modulos.Inventario.MVP.Modelos;
using aDVanceERP.Modulos.Inventario.MVP.Vistas.Almacen.Plantillas;

namespace aDVanceERP.Modulos.Inventario.MVP.Presentadores {
    public class PresentadorTuplaAlmacen : PresentadorTuplaBase<IVistaTuplaAlmacen, Almacen> {
        public PresentadorTuplaAlmacen(IVistaTuplaAlmacen vista, Almacen objeto) : base(vista, objeto) {
        }
    }

}
