using aDVanceERP.Core.Vistas.Interfaces;

namespace aDVanceERP.Core.Seguridad.MVP.Vistas.Menu.Plantillas;

public interface IVistaMenuSeguridad : IVistaMenu {
    event EventHandler? VerCuentasUsuarios;
    event EventHandler? VerRolesUsuarios;
}