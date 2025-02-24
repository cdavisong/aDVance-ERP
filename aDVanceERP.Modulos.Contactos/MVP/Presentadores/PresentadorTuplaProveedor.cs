using aDVanceERP.Core.MVP.Presentadores;
using aDVanceERP.Modulos.Contactos.MVP.Modelos;
using aDVanceERP.Modulos.Contactos.MVP.Vistas.Proveedor.Plantillas;

namespace aDVanceERP.Modulos.Contactos.MVP.Presentadores {
    public class PresentadorTuplaProveedor : PresentadorTuplaBase<IVistaTuplaProveedor, Proveedor> {
        public PresentadorTuplaProveedor(IVistaTuplaProveedor vista, Proveedor objeto) : base(vista, objeto) {
        }
    }
}
