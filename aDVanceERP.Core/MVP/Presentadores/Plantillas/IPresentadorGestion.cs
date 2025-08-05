using aDVanceERP.Core.Interfaces.Comun;
using aDVanceERP.Core.MVP.Vistas.Plantillas;

namespace aDVanceERP.Core.MVP.Presentadores.Plantillas;

public interface IPresentadorGestion<Vg, Do, O, C> : IPresentadorBase<Vg>, IDisposable
    where Vg : IVistaContenedor, IGestorDatos, IBuscadorDatos<C>, IGestorTablaDatos
    where Do : class, new()
    where O : class, IEntidadBd, new()
    where C : Enum {
    Do DatosObjeto { get; }
    C? CriterioBusquedaObjeto { get; }
    string? DatoBusquedaObjeto { get; }

    event EventHandler? EditarObjeto;

    Task BusquedaDatos(C criterio, string dato);
    Task RefrescarListaObjetos();
}