using aDVanceERP.Core.MVP.Modelos.Plantillas;
using aDVanceERP.Core.MVP.Modelos.Repositorios.Plantillas;
using aDVanceERP.Core.MVP.Vistas.Plantillas;

namespace aDVanceERP.Core.MVP.Presentadores.Plantillas; 

public interface IPresentadorGestion<Vg, Do, O, C> : IPresentadorBase<Vg>
    where Vg : IVistaContenedor, IGestorDatos, IBuscadorDatos<C>, IGestorTablaDatos
    where Do : class, IRepositorioDatosEntidad<O, C>, new()
    where O : class, IEntidad, new()
    where C : Enum {
    Do DatosObjeto { get; }
    C? CriterioBusquedaObjeto { get; }
    string? DatoBusquedaObjeto { get; }

    event EventHandler? EditarObjeto;

    Task BusquedaDatos(C criterio, string dato);
    Task RefrescarListaObjetos();
}