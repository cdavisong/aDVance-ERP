using System.Security;
using aDVanceERP.Core.MVP.Vistas.Plantillas;

namespace aDVanceERP.Core.Seguridad.MVP.Vistas.Autenticacion.Plantillas; 

public interface IVistaAutenticacionUsuario : IVista {
    string NombreUsuario { get; }
    SecureString Password { get; }

    event EventHandler? Autenticar;
    event EventHandler? RegistrarCuenta;
}