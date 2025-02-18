namespace Manigest.Core.MVP.Vistas.Plantillas {
    public interface IVistaMenu : IVista {
        event EventHandler? CambioMenu;

        void PresionarBotonSeleccion(object? sender, EventArgs e);
    }
}
