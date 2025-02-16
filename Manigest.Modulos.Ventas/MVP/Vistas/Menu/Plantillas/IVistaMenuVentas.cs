using Manigest.Core.MVP.Vistas.Plantillas;

namespace Manigest.Modulos.Ventas.MVP.Vistas.Menu.Plantillas {
    public interface IVistaMenuVentas : IVista {
        event EventHandler? VerVentaArticulos;
        event EventHandler? CambioMenu;
    }
}
