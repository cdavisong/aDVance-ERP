using aDVanceERP.Desktop.MVP.Presentadores.ContenedorSeguridad;
using aDVanceERP.Desktop.MVP.Vistas.ContenedorSeguridad;

namespace aDVanceERP.Desktop.MVP.Presentadores.Principal {
    public partial class PresentadorPrincipal {
        private PresentadorContenedorSeguridad? _contenedorSeguridad;

        private void InicializarVistaContenedorSeguridad() {
            _contenedorSeguridad = new PresentadorContenedorSeguridad(Vista, new VistaContenedorSeguridad());
            _contenedorSeguridad.UsuarioAutenticado += MostrarVistaContenedorModulos;

            Vista.Vistas?.Registrar("vistaContenedorSeguridad", _contenedorSeguridad.Vista);
        }

        private void MostrarVistaContenedorSeguridad(object sender, EventArgs e) {
            _contenedorSeguridad?.Vista.Mostrar();
            _contenedorSeguridad?.Vista.Restaurar();
        }
    }
}
