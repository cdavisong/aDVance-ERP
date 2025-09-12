using aDVanceERP.Core.Modelos.Comun.Interfaces;
using aDVanceERP.Core.MVP.Vistas.Plantillas;
using aDVanceERP.Core.Presentadores.Comun.Interfaces;

namespace aDVanceERP.Core.MVP.Presentadores.Plantillas;

public interface IPresentadorTupla<Vt, O> : IPresentadorVistaBase<Vt>, IDisposable
    where Vt : class, IVistaTupla
    where O : class, IEntidadBase, new() {
    bool TuplaSeleccionada { get; set; }
    Vt Vista { get; }
    O Entidad { get; }

    event EventHandler? ObjetoSeleccionado;
    event EventHandler? ObjetoDeseleccionado;
    event EventHandler? EditarObjeto;
    event EventHandler? EliminarObjeto;
}