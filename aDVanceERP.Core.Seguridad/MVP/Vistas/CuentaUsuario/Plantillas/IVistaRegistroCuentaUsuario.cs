using System.Security;
using aDVanceERP.Core.Interfaces;

namespace aDVanceERP.Core.Seguridad.MVP.Vistas.CuentaUsuario.Plantillas;

public interface IVistaRegistroCuentaUsuario : IVistaRegistroEdicion {
    string? NombreUsuario { get; set; }
    SecureString? Password { get; }
    string? NombreRolUsuario { get; set; }

    void CargarRolesUsuarios(string[] rolesUsuarios);
}