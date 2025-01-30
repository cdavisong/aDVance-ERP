using Manigest.Core.MVP.Modelos.Plantillas;
using Manigest.Core.MVP.Vistas.Plantillas;
using System.Drawing;

namespace Manigest.Core.MVP.Presentadores.Plantillas {
    public interface IPresentadorTupla<Vt, O> : IPresentadorBase<Vt>
        where Vt : IVistaTupla
        where O : class, IObjetoUnico {
        Color ColorResaltadoTupla { get; set; }
        bool TuplaSeleccionada { get; set; }
        Vt Vista { get; }
        O Objeto { get; }

        event EventHandler? ObjetoSeleccionado;
        event EventHandler? ObjetoDeseleccionado;
        event EventHandler? EditarObjeto;
        event EventHandler? EliminarObjeto;
    }
}
