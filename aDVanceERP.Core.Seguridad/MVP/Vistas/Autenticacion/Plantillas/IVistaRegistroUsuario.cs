using aDVanceERP.Core.MVP.Vistas.Plantillas;

using System.Security;

namespace aDVanceERP.Core.Seguridad.MVP.Vistas.Autenticacion.Plantillas {
    public interface IVistaRegistroUsuario : IVistaRegistro {
        string NombreUsuario { get; }
        SecureString? Password { get; }
        bool ConfirmacionTerminosServicio { get; }
    }
}
