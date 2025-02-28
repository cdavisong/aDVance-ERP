using aDVanceERP.Core.MVP.Vistas.Plantillas;

using System.Security;

namespace aDVanceERP.Core.Seguridad.MVP.Vistas.Autenticacion.Plantillas {
    public interface IVistaAutenticacionUsuario : IVista {
        string NombreUsuario { get; }
        SecureString Password { get; }

        event EventHandler? Autenticar;
        event EventHandler? RegistrarCuenta;
    }
}
