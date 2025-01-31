using Manigest.Core.MVP.Presentadores;
using Manigest.Modulos.Contactos.MVP.Modelos;
using Manigest.Modulos.Contactos.MVP.Vistas.Cliente.Plantillas;

namespace Manigest.Modulos.Contactos.MVP.Presentadores {
    public class PresentadorTuplaCliente : PresentadorTuplaBase<IVistaTuplaCliente, Cliente> {
        public PresentadorTuplaCliente(IVistaTuplaCliente vista, Cliente objeto) : base(vista, objeto) {
        }
    }
}
