using Manigest.Core.MVP.Presentadores;
using Manigest.Modulos.Contactos.MVP.Modelos;
using Manigest.Modulos.Contactos.MVP.Vistas.Proveedor.Plantillas;

namespace Manigest.Modulos.Contactos.MVP.Presentadores {
    public class PresentadorTuplaProveedor : PresentadorTuplaBase<IVistaTuplaProveedor, Proveedor> {
        public PresentadorTuplaProveedor(IVistaTuplaProveedor vista, Proveedor objeto) : base(vista, objeto) {
        }
    }
}
