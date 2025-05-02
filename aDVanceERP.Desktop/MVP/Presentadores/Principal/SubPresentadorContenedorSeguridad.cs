using aDVanceERP.Core.Seguridad.Utiles;
using aDVanceERP.Desktop.MVP.Presentadores.ContenedorSeguridad;
using aDVanceERP.Desktop.MVP.Vistas.ContenedorSeguridad;

namespace aDVanceERP.Desktop.MVP.Presentadores.Principal; 

public partial class PresentadorPrincipal {
    private PresentadorContenedorSeguridad? _contenedorSeguridad;

    private void InicializarVistaContenedorSeguridad() {
        _contenedorSeguridad = new PresentadorContenedorSeguridad(Vista, new VistaContenedorSeguridad());
        _contenedorSeguridad.UsuarioAutenticado += delegate (object? sender, EventArgs e) {
            MostrarVistaContenedorModulos(sender, e);

            if (_menuUsuario != null)
                _menuUsuario.Vista.NombreUsuario = UtilesCuentaUsuario.UsuarioAutenticado?.Nombre;
        };

        Vista.Vistas?.Registrar("vistaContenedorSeguridad", _contenedorSeguridad.Vista);
    }

    private void MostrarVistaContenedorSeguridad(object? sender, EventArgs e) {
        if (_contenedorSeguridad == null)
            return;

        _contenedorSeguridad.Vista.Restaurar();
        _contenedorSeguridad.Vista.Mostrar();

        // Mostrar el botón de sub-menu para usuarios
        Vista.BtnSubmenuUsuarioDisponible = false;
    }
}