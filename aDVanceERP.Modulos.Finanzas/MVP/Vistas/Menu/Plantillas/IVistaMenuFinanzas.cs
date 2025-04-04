using aDVanceERP.Core.MVP.Vistas.Plantillas;

namespace aDVanceERP.Modulos.Finanzas.MVP.Vistas.Menu.Plantillas; 

public interface IVistaMenuFinanzas : IVistaMenu {
    event EventHandler? VerCuentas;
}