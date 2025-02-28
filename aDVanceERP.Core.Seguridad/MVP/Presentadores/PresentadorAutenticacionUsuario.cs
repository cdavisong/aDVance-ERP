using aDVanceERP.Core.MVP.Presentadores;
using aDVanceERP.Core.Seguridad.MVP.Modelos;
using aDVanceERP.Core.Seguridad.MVP.Modelos.Repositorios;
using aDVanceERP.Core.Seguridad.MVP.Vistas.Autenticacion.Plantillas;
using aDVanceERP.Core.Seguridad.Utiles;

namespace aDVanceERP.Core.Seguridad.MVP.Presentadores {
    public class PresentadorAutenticacionUsuario : PresentadorBase<IVistaAutenticacionUsuario> {
        public PresentadorAutenticacionUsuario(IVistaAutenticacionUsuario vista) : base(vista) {
            vista.Autenticar += AutenticarUsuario;
            vista.RegistrarCuenta += delegate (object? sender, EventArgs args) {
                MostrarVistaRegistroCuentaUsuario?.Invoke(sender, args);
            };
        }

        public event EventHandler? UsuarioAutenticado;
        public event EventHandler? MostrarVistaRegistroCuentaUsuario;

        private void AutenticarUsuario(object? sender, EventArgs e) {
            using (var datosUsuario = new DatosCuentaUsuario()) {
                var usuario = datosUsuario.Obtener(CriterioBusquedaCuentaUsuario.Nombre, Vista.NombreUsuario)?.First();

                if (usuario == null)
                    return;

                if (UtilesPassword.VerificarPassword(Vista.Password, usuario.PasswordHash, usuario.PasswordSalt)) {
                    UtilesSeguridad.UsuarioAutenticado = usuario;

                    UsuarioAutenticado?.Invoke(sender, e);
                }
            }
        }
    }
}
