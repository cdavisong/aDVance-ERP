using aDVanceERP.Core.MVP.Presentadores;
using aDVanceERP.Modulos.Contactos.MVP.Modelos;
using aDVanceERP.Modulos.Contactos.MVP.Vistas.Contacto.Plantillas;

namespace aDVanceERP.Modulos.Contactos.MVP.Presentadores {
    public class PresentadorTuplaContacto : PresentadorTuplaBase<IVistaTuplaContacto, Contacto> {
        public PresentadorTuplaContacto(IVistaTuplaContacto vista, Contacto objeto) : base(vista, objeto) {
        }
    }
}
