using System.Security;
using aDVanceERP.Core.MVP.Vistas.Plantillas;

namespace aDVanceERP.Core.Seguridad.MVP.Vistas.Autenticacion.Plantillas; 

public interface IVistaRegistroUsuario : IVistaRegistro {
    string NombreUsuario { get; }
    SecureString? Password { get; }
    bool ConfirmacionTerminosServicio { get; }

    event EventHandler? AutenticarUsuario;
}