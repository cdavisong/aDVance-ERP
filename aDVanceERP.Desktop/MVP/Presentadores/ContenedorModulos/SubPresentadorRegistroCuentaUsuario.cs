using aDVanceERP.Core.Seguridad.MVP.Modelos;
using aDVanceERP.Core.Seguridad.MVP.Presentadores;
using aDVanceERP.Core.Seguridad.MVP.Vistas.CuentaUsuario;
using aDVanceERP.Core.Seguridad.Utiles;
using aDVanceERP.Desktop.Utiles;

namespace aDVanceERP.Desktop.MVP.Presentadores.ContenedorModulos {
    public partial class PresentadorContenedorModulos {
        private PresentadorRegistroCuentaUsuario _registroCuentaUsuario;

        private async Task InicializarVistaRegistroCuentaUsuario() {
            _registroCuentaUsuario = new PresentadorRegistroCuentaUsuario(new VistaRegistroCuentaUsuario());
            _registroCuentaUsuario.Vista.CargarRolesUsuarios(UtilesRolUsuario.ObtenerNombresRolesUsuarios());
            _registroCuentaUsuario.Vista.EstablecerCoordenadasVistaRegistro(Vista.Dimensiones.Width); ;
            _registroCuentaUsuario.Vista.EstablecerDimensionesVistaRegistro(Vista.Dimensiones.Height);
            _registroCuentaUsuario.Salir += async (sender, e) => {
                if (_gestionCuentasUsuarios != null) {
                    _gestionCuentasUsuarios.Vista.HabilitarBtnAprobacionSolicitudCuenta = false;
                    await _gestionCuentasUsuarios.RefrescarListaObjetos();
                }
            };
        }

        private async void MostrarVistaRegistroCuentaUsuario(object? sender, EventArgs e) {
            await InicializarVistaRegistroCuentaUsuario();

            if (_registroCuentaUsuario != null) {
                _registroCuentaUsuario.Vista.Mostrar();
            }

            _registroCuentaUsuario?.Dispose();
        }

        private async void MostrarVistaEdicionCuentaUsuario(object? sender, EventArgs e) {
            await InicializarVistaRegistroCuentaUsuario();

            if (_registroCuentaUsuario != null && sender is CuentaUsuario cuentaUsuario) {
                _registroCuentaUsuario.PopularVistaDesdeObjeto(cuentaUsuario);
                _registroCuentaUsuario.Vista.Mostrar();
            }

            _registroCuentaUsuario?.Dispose();
        }
    }
}
