using aDVanceERP.Core.Seguridad.MVP.Presentadores;
using aDVanceERP.Core.Seguridad.MVP.Vistas.Menu;

namespace aDVanceERP.Desktop.MVP.Presentadores.ContenedorModulos {
    public partial class PresentadorContenedorModulos {
        private PresentadorMenuSeguridad _menuSeguridad;

        private void InicializarVistaMenuSeguridad() {
            _menuSeguridad = new PresentadorMenuSeguridad(new VistaMenuSeguridad());
            _menuSeguridad.Vista.VerCuentasUsuarios += MostrarVistaGestionCuentasUsuarios;
            _menuSeguridad.Vista.VerRolesUsuarios += MostrarVistaGestionRolesUsuarios;
            _menuSeguridad.Vista.CambioMenu += delegate { Vista.Vistas?.Ocultar(true); };

            VistaPrincipal.Menus.Registrar("vistaMenuSeguridad", _menuSeguridad.Vista);
        }

        private void MostrarVistaMenuSeguridad(object? sender, EventArgs e) {
            _menuSeguridad.Vista.Restaurar();
            _menuSeguridad.Vista.Mostrar();

            _menuSeguridad.Vista.PresionarBotonSeleccion(sender is int opcion ? opcion : 1, e);
        }
    }
}
