namespace aDVanceERP.Core.Modelos.Comun.Interfaces;

public interface IBuscadorEntidades<Fb>
    where Fb : Enum {
    Fb FiltroBusqueda { get; }
    string? CriterioBusqueda { get; }


    event EventHandler? BuscarEntidades;

    void CargarFiltrosBusqueda(object[] filtrosBusqueda);
}