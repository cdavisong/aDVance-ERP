using Manigest.Core.MVP.Vistas.Plantillas;

namespace Manigest.Modulos.Finanzas.MVP.Vistas.Menu.Plantillas {
    public interface IVistaMenuFinanzas : IVistaMenu {
        event EventHandler? VerCuentas;
    }
}
