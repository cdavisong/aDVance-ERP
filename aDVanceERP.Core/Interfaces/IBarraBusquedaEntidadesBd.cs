namespace aDVanceERP.Core.Interfaces;

public interface IBarraBusquedaEntidadesBd<Fb> 
    where Fb : Enum {
    Fb FiltroBusqueda { get; }
    string? CriterioBusqueda { get; }

    event EventHandler? Buscar;

    void CargarFiltrosBusqueda(object[] filtros);
}