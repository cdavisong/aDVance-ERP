namespace aDVanceERP.Core.Interfaces;

public interface IBuscadorDatos<C>
    where C : Enum
{
    C CriterioBusqueda { get; }
    string? DatoBusqueda { get; }


    event EventHandler? BuscarDatos;

    void CargarCriteriosBusqueda(object[] criteriosBusqueda);
}