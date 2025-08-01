using aDVanceERP.Core.Modelos.Comun;
using aDVanceERP.Core.MVP.Vistas.Plantillas;

namespace aDVanceERP.Core.MVP.Presentadores.Plantillas; 

public interface IPresentadorTupla<Vt, O> : IPresentadorBase<Vt>, IDisposable
    where Vt : IVistaTupla
    where O : class, IEntidadBd, new() {
    bool TuplaSeleccionada { get; set; }
    Vt Vista { get; }
    O Objeto { get; }

    event EventHandler? ObjetoSeleccionado;
    event EventHandler? ObjetoDeseleccionado;
    event EventHandler? EditarObjeto;
    event EventHandler? EliminarObjeto;
}