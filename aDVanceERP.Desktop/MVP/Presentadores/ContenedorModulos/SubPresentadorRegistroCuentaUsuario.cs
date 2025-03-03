using aDVanceERP.Core.Utiles;
using aDVanceERP.Core.Seguridad.MVP.Presentadores;
using aDVanceERP.Core.Seguridad.MVP.Vistas.CuentaUsuario;
using aDVanceERP.Core.Seguridad.Utiles;
using aDVanceERP.Core.Seguridad.MVP.Modelos;

namespace aDVanceERP.Desktop.MVP.Presentadores.ContenedorModulos {
    public partial class PresentadorContenedorModulos {
        private PresentadorRegistroCuentaUsuario _registroCuentaUsuario;

        private void InicializarVistaRegistroCuentaUsuario() {
            _registroCuentaUsuario = new PresentadorRegistroCuentaUsuario(new VistaRegistroCuentaUsuario());
            _registroCuentaUsuario.Vista.CargarRolesUsuarios(UtilesRolUsuario.ObtenerNombresRolesUsuarios());
            _registroCuentaUsuario.Vista.Coordenadas = new Point(Vista.Dimensiones.Width - _registroCuentaUsuario.Vista.Dimensiones.Width - 20, VariablesGlobales.AlturaBarraTituloPredeterminada);
            _registroCuentaUsuario.Vista.Dimensiones = new Size(_registroCuentaUsuario.Vista.Dimensiones.Width, Vista.Dimensiones.Height);
            _registroCuentaUsuario.Salir += delegate {
                _gestionCuentasUsuarios.Vista.HabilitarBtnAprobacionSolicitudCuenta = false;
                _gestionCuentasUsuarios.RefrescarListaObjetos(); 
            };
        }

        private void MostrarVistaRegistroCuentaUsuario(object? sender, EventArgs e) {
            InicializarVistaRegistroCuentaUsuario();

            _registroCuentaUsuario.Vista.Mostrar();
            _registroCuentaUsuario = null;
        }

        private void MostrarVistaEdicionCuentaUsuario(object? sender, EventArgs e) {
            InicializarVistaRegistroCuentaUsuario();

            _registroCuentaUsuario.PopularVistaDesdeObjeto(sender as CuentaUsuario);
            _registroCuentaUsuario.Vista.Mostrar();
            _registroCuentaUsuario = null;
        }
    }
}
