using aDVanceERP.Core.MVP.Vistas.Plantillas;

namespace aDVanceERP.Modulos.CompraVenta.MVP.Vistas.Menu.Plantillas {
    public interface IVistaMenuVentas : IVistaMenu {
        event EventHandler? VerVentas;
    }
}
