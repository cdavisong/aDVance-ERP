using aDVanceERP.Core.MVP.Modelos.Plantillas;
using aDVanceERP.Core.MVP.Modelos.Repositorios.Plantillas;
using aDVanceERP.Core.MVP.Vistas.Plantillas;

namespace aDVanceERP.Core.MVP.Presentadores.Plantillas; 

public interface IPresentadorGestion<Vg, Rd, En, Fb> : IPresentadorBase<Vg>
    where Vg : IVistaContenedor, IGestorDatos, IBuscadorDatos<Fb>, IGestorTablaDatos
    where Rd : class, IRepositorioDatosEntidad<En, Fb>, new()
    where En : class, IEntidad, new()
    where Fb : Enum {
    Rd RepoDatosEntidad { get; }
    Fb? FiltroBusquedaEntidad { get; }
    string? DatosComplementariosBusqueda { get; }

    event EventHandler? EditarEntidad;

    void BuscarDatosEntidad(Fb filtroBusqueda, string datosComplementarios);
    Task PopularTuplasDatosEntidades();
}