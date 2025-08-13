using aDVanceERP.Core.Vistas.Interfaces;

namespace aDVanceERP.Core.MVP.Vistas.Plantillas; 

public interface IVistaMenu : IVistaBase {
    event EventHandler? CambioMenu;

    void MostrarCaracteristicaInicial();
    void PresionarBotonSeleccion(object? sender, EventArgs e);
}