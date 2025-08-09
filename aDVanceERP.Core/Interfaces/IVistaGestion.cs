namespace aDVanceERP.Core.Interfaces;

public interface IVistaGestion<Fb> : IVista
    where Fb : Enum {
    IBarraBusquedaEntidadesBd<Fb> BarraBusqueda { get; }
    ITablaResultadosBusqueda TablaResultadosBusqueda { get; }
}