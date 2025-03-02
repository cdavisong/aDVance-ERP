using aDVanceERP.Core.MVP.Presentadores;
using aDVanceERP.Desktop.MVP.Vistas.ContenedorSeguridad.Plantillas;
using aDVanceERP.Desktop.MVP.Vistas.Principal.Plantillas;

namespace aDVanceERP.Desktop.MVP.Presentadores.ContenedorSeguridad {
    public partial class PresentadorContenedorSeguridad : PresentadorBase<IVistaContenedorSeguridad> {
        public PresentadorContenedorSeguridad(IVistaPrincipal vistaPrincipal, IVistaContenedorSeguridad vista) : base(vista) {
            VistaPrincipal = vistaPrincipal;

            // Eventos

            #region Gestión de autenticación y registro primario de usuarios

            InicializarVistaAutenticacionUsuario();
            InicializarVistaRegistroUsuario();

            #endregion

            // Otros
            MostrarVistaAutenticacionUsuario(null, EventArgs.Empty);
        }

        private IVistaPrincipal VistaPrincipal { get; }
    }
}
