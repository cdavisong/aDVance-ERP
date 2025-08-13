using aDVanceERP.Core.Modelos.Comun.Interfaces;
using aDVanceERP.Core.MVP.Modelos.Plantillas;
using aDVanceERP.Core.MVP.Modelos.Repositorios.Plantillas;
using aDVanceERP.Core.MVP.Vistas.Plantillas;

namespace aDVanceERP.Core.MVP.Presentadores.Plantillas; 

public interface IPresentadorGestion<Vg, Do, En, C> : IPresentadorBase<Vg>, IDisposable
    where Vg : IVistaContenedor, IGestorDatos, IBuscadorDatos<C>, IGestorTablaDatos
    where Do : class, IRepositorioDatos<En, C>, new()
    where En : class, IEntidadBaseDatos, new()
    where C : Enum {
    Do DatosObjeto { get; }
    C? FiltroBusquedaObjeto { get; }
    string? DatoBusquedaObjeto { get; }

    event EventHandler? EditarObjeto;

    void BusquedaDatos(C criterio, string dato);
    void RefrescarListaObjetos();
}