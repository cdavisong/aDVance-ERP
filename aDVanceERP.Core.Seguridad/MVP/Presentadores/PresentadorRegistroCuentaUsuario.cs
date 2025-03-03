using aDVanceERP.Core.MVP.Presentadores;
using aDVanceERP.Core.Seguridad.MVP.Modelos;
using aDVanceERP.Core.Seguridad.MVP.Modelos.Repositorios;
using aDVanceERP.Core.Seguridad.MVP.Vistas.CuentaUsuario.Plantillas;
using aDVanceERP.Core.Seguridad.Utiles;

namespace aDVanceERP.Core.Seguridad.MVP.Presentadores {
    public class PresentadorRegistroCuentaUsuario : PresentadorRegistroBase<IVistaRegistroCuentaUsuario, CuentaUsuario, DatosCuentaUsuario, CriterioBusquedaCuentaUsuario> {
        public PresentadorRegistroCuentaUsuario(IVistaRegistroCuentaUsuario vista) : base(vista) {
        }

        public override void PopularVistaDesdeObjeto(CuentaUsuario objeto) {
            Vista.NombreUsuario = objeto.Nombre;
            Vista.NombreRolUsuario = UtilesRolUsuario.ObtenerNombreRolUsuario(objeto.IdRolUsuario);
            Vista.ModoEdicionDatos = true;

            _objeto = objeto;
        }

        protected override CuentaUsuario? ObtenerObjetoDesdeVista() {
            var passwordSeguro = UtilesPassword.HashPassword(Vista.Password);

            return new CuentaUsuario(_objeto?.Id ?? 0,
                nombre: Vista.NombreUsuario,
                passwordHash: passwordSeguro.hash,
                passwordSalt: passwordSeguro.salt,
                idRolUsuario: UtilesRolUsuario.ObtenerIdRolUsuario(Vista.NombreRolUsuario)
                ) { 
                    Administrador = false,
                    Aprobado = true
                };
        }
    }
}
