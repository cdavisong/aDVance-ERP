using aDVanceERP.Core.Vistas.Interfaces;

namespace aDVanceERP.Core.MVP.Vistas.Plantillas; 

public interface IVistaTupla : IVistaBase {
    Color ColorFondoTupla { get; set; }

    event EventHandler? TuplaSeleccionada;
    event EventHandler? EditarDatosTupla;
    event EventHandler? EliminarDatosTupla;
}