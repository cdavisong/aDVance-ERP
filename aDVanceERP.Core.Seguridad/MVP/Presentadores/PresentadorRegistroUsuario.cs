using aDVanceERP.Core.MVP.Presentadores;
using aDVanceERP.Core.Seguridad.MVP.Modelos;
using aDVanceERP.Core.Seguridad.MVP.Modelos.Repositorios;
using aDVanceERP.Core.Seguridad.MVP.Vistas.Autenticacion.Plantillas;
using aDVanceERP.Core.Seguridad.Utiles;

namespace aDVanceERP.Core.Seguridad.MVP.Presentadores {
    public class PresentadorRegistroUsuario : PresentadorRegistroBase<IVistaRegistroUsuario, CuentaUsuario, DatosCuentaUsuario, CriterioBusquedaCuentaUsuario> {
        public PresentadorRegistroUsuario(IVistaRegistroUsuario vista) : base(vista) {
            vista.Salir += delegate (object? sender, EventArgs args) {
                MostrarVistaAutenticacionUsuario?.Invoke(sender, args);
            };
            vista.RegistrarDatos += delegate (object? sender, EventArgs args) {
                UsuarioRegistrado?.Invoke(sender, args);
            };
        }

        public event EventHandler? UsuarioRegistrado;
        public event EventHandler? MostrarVistaAutenticacionUsuario;

        public override void PopularVistaDesdeObjeto(CuentaUsuario objeto) {
            throw new NotImplementedException();
        }

        protected override void RegistroAuxiliar() {
            UsuarioRegistrado?.Invoke("user", EventArgs.Empty);
        }

        protected override CuentaUsuario? ObtenerObjetoDesdeVista() {
            if (UtilesCuentaUsuario.EsTablaCuentasUsuarioVacia()) {
                if (Vista.Password != null)
                    UtilesCuentaUsuario.CrearUsuarioAdministrador(Vista.NombreUsuario, Vista.Password);

                UsuarioRegistrado?.Invoke("admin", EventArgs.Empty);

                return null;
            }

            var passwordSeguro = UtilesPassword.HashPassword(Vista.Password);            

            return new CuentaUsuario(_objeto?.Id ?? 0,
                nombre: Vista.NombreUsuario,
                passwordHash: passwordSeguro.hash,
                passwordSalt: passwordSeguro.salt,
                idRolUsuario: 0
                );
        }
    }
}
