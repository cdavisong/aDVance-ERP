using System.Security;
using aDVanceERP.Core.Interfaces;

namespace aDVanceERP.Core.Seguridad.MVP.Vistas.Autenticacion.Plantillas;

public interface IVistaRegistroUsuario : IVistaRegistroEdicion {
    string NombreUsuario { get; }
    SecureString? Password { get; }
    bool ConfirmacionTerminosServicio { get; }

    event EventHandler? AutenticarUsuario;
}