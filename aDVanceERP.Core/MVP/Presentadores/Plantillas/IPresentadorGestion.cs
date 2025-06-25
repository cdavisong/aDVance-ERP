using aDVanceERP.Core.MVP.Modelos.Plantillas;
using aDVanceERP.Core.MVP.Vistas.Plantillas;
using aDVanceERP.Core.Repositorios.Plantillas;

namespace aDVanceERP.Core.MVP.Presentadores.Plantillas; 

public interface IPresentadorGestion<Vg, Do, O, C> : IPresentadorBase<Vg>, IDisposable
    where Vg : IVistaContenedor, IGestorDatos, IBuscadorDatos<C>, IGestorTablaDatos
    where Do : class, IRepositorioDatos<O, C>, new()
    where O : class, IObjetoUnico, new()
    where C : Enum {
    Do DatosObjeto { get; }
    C? CriterioBusquedaObjeto { get; }
    string? DatoBusquedaObjeto { get; }

    event EventHandler? EditarEntidad;

    void BuscarDatosEntidad(Fb filtroBusqueda, string datosComplementarios);
    Task PopularTuplasDatosEntidades();
}