using aDVanceERP.Core.MVP.Modelos.Plantillas;
using aDVanceERP.Core.MVP.Vistas.Plantillas;

namespace aDVanceERP.Core.MVP.Presentadores.Plantillas; 

public interface IPresentadorTupla<Vt, O> : IPresentadorBase<Vt>, IDisposable
    where Vt : IVistaTupla
    where En : class, IEntidad, new() {
    bool TuplaSeleccionada { get; set; }
    Vt Vista { get; }
    En Entidad { get; }

    event EventHandler? EntidadSeleccionada;
    event EventHandler? EntidadDeseleccionada;
    event EventHandler? EditarDatosEntidad;
    event EventHandler? EliminarDatosEntidad;
}