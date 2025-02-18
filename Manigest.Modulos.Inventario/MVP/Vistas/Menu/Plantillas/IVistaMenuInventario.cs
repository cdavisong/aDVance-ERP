using Manigest.Core.MVP.Vistas.Plantillas;

namespace Manigest.Modulos.Inventario.MVP.Vistas.Menu.Plantillas {
    public interface IVistaMenuInventario : IVistaMenu {
        event EventHandler? VerArticulos;
        event EventHandler? VerMovimientos;
        event EventHandler? VerAlmacenes;
    }
}
