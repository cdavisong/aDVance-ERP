using aDVanceERP.Core.Modelos.Comun.Interfaces;
using aDVanceERP.Core.MVP.Vistas.Plantillas;

namespace aDVanceERP.Core.MVP.Presentadores.Plantillas; 

public interface IPresentadorTupla<Vt, O> : IPresentadorBase<Vt>, IDisposable
    where Vt : IVistaTupla
    where O : class, IEntidadBase, new() {
    bool TuplaSeleccionada { get; set; }
    Vt Vista { get; }
    O Entidad { get; }

    event EventHandler? ObjetoSeleccionado;
    event EventHandler? ObjetoDeseleccionado;
    event EventHandler? EditarObjeto;
    event EventHandler? EliminarObjeto;
}