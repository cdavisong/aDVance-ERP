using aDVanceERP.Core.MVP.Vistas.Plantillas;

namespace aDVanceERP.Modulos.Ventas.MVP.Vistas.Menu.Plantillas {
    public interface IVistaMenuVentas : IVistaMenu {
        event EventHandler? VerVentaArticulos;
    }
}
