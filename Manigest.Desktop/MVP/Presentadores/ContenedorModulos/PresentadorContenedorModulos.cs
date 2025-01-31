using Manigest.Desktop.MVP.Vistas.ContenedorModulos.Plantillas;
using Manigest.Desktop.MVP.Vistas.Principal.Plantillas;

namespace Manigest.Desktop.MVP.Presentadores.ContenedorModulos {
    public partial class PresentadorContenedorModulos {
        public PresentadorContenedorModulos(IVistaPrincipal vistaPrincipal, IVistaContenedorModulos vista) {
            VistaPrincipal = vistaPrincipal;
            Vista = vista;

            // Eventos
            Vista.MostrarMenuContactos += MostrarVistaMenuContacto;

            #region Módulo : Contactos

            InicializarVistaMenuContacto();
            InicializarVistaGestionProveedores();
            InicializarVistaGestionClientes();
            InicializarVistaGestionContactos();

            #endregion
        }

        private IVistaPrincipal VistaPrincipal { get; }

        public IVistaContenedorModulos Vista { get; }
    }
}
