using aDVanceERP.Core.Interfaces;

namespace aDVanceERP.Core.Seguridad.MVP.Vistas.Autenticacion.Plantillas;

public interface IVistaAprobacionUsuario : IVista {
    event EventHandler? CambiarDeUsuario;
}