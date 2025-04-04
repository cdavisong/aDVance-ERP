using aDVanceERP.Core.MVP.Vistas.Plantillas;

namespace aDVanceERP.Core.Seguridad.MVP.Vistas.Menu.Plantillas; 

public interface IVistaMenuSeguridad : IVistaMenu {
    event EventHandler? VerCuentasUsuarios;
    event EventHandler? VerRolesUsuarios;
}