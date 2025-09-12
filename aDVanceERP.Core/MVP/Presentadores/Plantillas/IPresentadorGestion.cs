using aDVanceERP.Core.Modelos.Comun.Interfaces;
using aDVanceERP.Core.MVP.Vistas.Plantillas;
using aDVanceERP.Core.Repositorios.Comun.Interfaces;

namespace aDVanceERP.Core.MVP.Presentadores.Plantillas;

public interface IPresentadorGestion<Vg, Do, En, C> : IPresentadorBase<Vg>, IDisposable
    where Vg : IVistaContenedor, IGestorEntidades, IBuscadorEntidades<C>, INavegadorTuplasEntidades
    where Do : class, IRepoEntidadBaseDatos<En, C>, new()
    where En : class, IEntidadBaseDatos, new()
    where C : Enum {
    Do RepositorioEntidad { get; }
    C? FiltroBusqueda { get; }
    string? CriterioBusqueda { get; }

    event EventHandler? EditarObjeto;

    void BusquedaEntidades(C criterio, string dato);
    void ActualizarResultadosBusqueda();
}