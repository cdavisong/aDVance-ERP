using aDVanceERP.Desktop.MVP.Vistas.Principal;
using aDVanceERP.Desktop.MVP.Vistas.Principal.Plantillas;

namespace aDVanceERP.Desktop.MVP.Presentadores.Principal {
    public partial class PresentadorPrincipal {
        public PresentadorPrincipal() {
            Vista = new VistaPrincipal();

            // Eventos
            //Vista.SubMenuUsuario += MostrarSubMenuUsuario;
            Vista.Salir += DisponerModulos;

            #region Contenedores

            //InicializarVistaContenedorAutenticacionRegistro();
            InicializarVistaContenedorModulos();

            #endregion

            // Otros
            //MostrarVistaContenedorAutenticacionRegistro(this, EventArgs.Empty);
            MostrarVistaContenedorModulos(this, EventArgs.Empty);
        }

        public IVistaPrincipal Vista { get; }

        private void DisponerModulos(object? sender, EventArgs e) {
            _contenedorModulos.Vista.Vistas.Cerrar(true);
        }
    }
}
