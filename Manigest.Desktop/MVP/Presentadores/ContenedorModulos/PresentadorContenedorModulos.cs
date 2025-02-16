using Manigest.Desktop.MVP.Vistas.ContenedorModulos.Plantillas;
using Manigest.Desktop.MVP.Vistas.Principal.Plantillas;

namespace Manigest.Desktop.MVP.Presentadores.ContenedorModulos {
    public partial class PresentadorContenedorModulos {
        public PresentadorContenedorModulos(IVistaPrincipal vistaPrincipal, IVistaContenedorModulos vista) {
            VistaPrincipal = vistaPrincipal;
            Vista = vista;

            // Eventos
            Vista.MostrarMenuContactos += MostrarVistaMenuContacto;
            Vista.MostrarMenuInventario += MostrarVistaMenuInventario;
            Vista.MostrarMenuVentas += MostrarVistaMenuVentas;

            #region Módulo : Contactos

            InicializarVistaMenuContacto();
            InicializarVistaGestionProveedores();
            InicializarVistaGestionClientes();
            InicializarVistaGestionContactos();

            #endregion

            #region Módulo : Inventario

            InicializarVistaMenuInventario();
            InicializarVistaGestionArticulos();
            InicializarVistaGestionMovimientos();
            InicializarVistaGestionAlmacenes();

            #endregion

            #region Módulo : Ventas

            InicializarVistaMenuVentas();
            InicializarVistaGestionVentasArticulos();

            #endregion
        }

        private IVistaPrincipal VistaPrincipal { get; }

        public IVistaContenedorModulos Vista { get; }
    }
}
