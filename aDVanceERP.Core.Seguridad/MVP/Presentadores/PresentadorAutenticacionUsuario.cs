using aDVanceERP.Core.Excepciones;
using aDVanceERP.Core.Mensajes.MVP.Modelos;
using aDVanceERP.Core.Mensajes.Utiles;
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
                MostrarVistaRegistroCuentaUsuario?.Invoke("register-user", args);
            };
        }

        public event EventHandler? UsuarioAutenticado;
        public event EventHandler? MostrarVistaRegistroCuentaUsuario;

        private async void AutenticarUsuario(object? sender, EventArgs args) {
            try {
                using (var datosUsuario = new DatosCuentaUsuario()) {
                    var usuario = (await datosUsuario.ObtenerAsync(CriterioBusquedaCuentaUsuario.Nombre, Vista.NombreUsuario))?.FirstOrDefault();

                    if (usuario == null)
                        return;

                    if (UtilesPassword.VerificarPassword(Vista.Password, usuario.PasswordHash, usuario.PasswordSalt)) {
                        UtilesCuentaUsuario.UsuarioAutenticado = usuario;
                        UtilesCuentaUsuario.PermisosUsuario = UtilesRolUsuario.ObtenerPermisosDeRol(usuario.IdRolUsuario);

                        UsuarioAutenticado?.Invoke(usuario, args);
                    }
                }
            } catch (ExcepcionConexionServidorMySQL e) {
                CentroNotificaciones.Mostrar(e.Message, TipoNotificacion.Error);
            }
        }
    }
}
