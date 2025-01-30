using System.Drawing;

namespace Manigest.Core.MVP.Vistas.Plantillas {
    public interface IVistaTupla : IVista {
        Color ColorFondoTupla { get; set; }

        event EventHandler? TuplaSeleccionada;
        event EventHandler? EditarDatosTupla;
        event EventHandler? EliminarDatosTupla;
    }
}
