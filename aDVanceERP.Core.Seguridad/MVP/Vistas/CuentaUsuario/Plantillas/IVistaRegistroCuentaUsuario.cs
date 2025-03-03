using aDVanceERP.Core.MVP.Vistas.Plantillas;

using System.Security;

namespace aDVanceERP.Core.Seguridad.MVP.Vistas.CuentaUsuario.Plantillas {
    public interface IVistaRegistroCuentaUsuario : IVistaRegistro {
        string? NombreUsuario { get; set; }
        SecureString? Password { get; }
        string? NombreRolUsuario { get; set; }

        void CargarRolesUsuarios(string[] rolesUsuarios);
    }
}
