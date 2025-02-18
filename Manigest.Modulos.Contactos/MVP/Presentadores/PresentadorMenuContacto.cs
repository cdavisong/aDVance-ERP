using Manigest.Core.MVP.Presentadores;
using Manigest.Modulos.Contactos.MVP.Vistas.Menu.Plantillas;

namespace Manigest.Modulos.Contactos.MVP.Presentadores {
    public class PresentadorMenuContacto : PresentadorBase<IVistaMenuContacto> {
        public PresentadorMenuContacto(IVistaMenuContacto vista) : base(vista) {
            
        }
    }
}
