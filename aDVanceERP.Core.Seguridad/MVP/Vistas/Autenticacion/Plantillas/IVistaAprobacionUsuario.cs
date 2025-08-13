using aDVanceERP.Core.Vistas.Interfaces;

namespace aDVanceERP.Core.Seguridad.MVP.Vistas.Autenticacion.Plantillas; 

public interface IVistaAprobacionUsuario : IVistaBase {
    event EventHandler? CambiarDeUsuario;
}