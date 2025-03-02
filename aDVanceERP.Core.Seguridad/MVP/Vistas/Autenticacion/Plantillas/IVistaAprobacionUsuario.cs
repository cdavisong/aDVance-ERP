using aDVanceERP.Core.MVP.Vistas.Plantillas;

namespace aDVanceERP.Core.Seguridad.MVP.Vistas.Autenticacion.Plantillas {
    public interface IVistaAprobacionUsuario : IVista {
        event EventHandler? CambiarDeUsuario;
    }
}
