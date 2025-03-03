using aDVanceERP.Core.Seguridad.MVP.Modelos;
using aDVanceERP.Core.Seguridad.MVP.Presentadores;
using aDVanceERP.Core.Seguridad.MVP.Vistas.RolUsuario;
using aDVanceERP.Core.Utiles;

namespace aDVanceERP.Desktop.MVP.Presentadores.ContenedorModulos {
    public partial class PresentadorContenedorModulos {
        private PresentadorRegistroRolUsuario _registroRolUsuario;

        private void InicializarVistaRegistroRolUsuario() {
            _registroRolUsuario = new PresentadorRegistroRolUsuario(new VistaRegistroRolUsuario());
            _registroRolUsuario.Vista.Coordenadas = new Point(Vista.Dimensiones.Width - _registroRolUsuario.Vista.Dimensiones.Width - 20, VariablesGlobales.AlturaBarraTituloPredeterminada);
            _registroRolUsuario.Vista.Dimensiones = new Size(_registroRolUsuario.Vista.Dimensiones.Width, Vista.Dimensiones.Height);
            _registroRolUsuario.Salir += delegate { _gestionRolesUsuarios.RefrescarListaObjetos(); };
        }

        private void MostrarVistaRegistroRolUsuario(object? sender, EventArgs e) {
            InicializarVistaRegistroRolUsuario();

            _registroRolUsuario.Vista.Mostrar();
            _registroRolUsuario = null;
        }

        private void MostrarVistaEdicionRolUsuario(object? sender, EventArgs e) {
            InicializarVistaRegistroRolUsuario();

            _registroRolUsuario.PopularVistaDesdeObjeto(sender as RolUsuario);
            _registroRolUsuario.Vista.Mostrar();
            _registroRolUsuario = null;
        }
    }
}
