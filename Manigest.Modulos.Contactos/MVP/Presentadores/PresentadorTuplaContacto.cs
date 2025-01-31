using Manigest.Core.MVP.Presentadores;
using Manigest.Modulos.Contactos.MVP.Modelos;
using Manigest.Modulos.Contactos.MVP.Vistas.Contacto.Plantillas;

namespace Manigest.Modulos.Contactos.MVP.Presentadores {
    public class PresentadorTuplaContacto : PresentadorTuplaBase<IVistaTuplaContacto, Contacto> {
        public PresentadorTuplaContacto(IVistaTuplaContacto vista, Contacto objeto) : base(vista, objeto) {
        }
    }
}
