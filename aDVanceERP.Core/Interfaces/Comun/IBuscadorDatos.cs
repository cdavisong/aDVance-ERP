namespace aDVanceERP.Core.Interfaces.Comun;

public interface IBuscadorDatos<C>
    where C : Enum
{
    C CriterioBusqueda { get; }
    string? DatoBusqueda { get; }


    event EventHandler? BuscarDatos;

    void CargarCriteriosBusqueda(object[] criteriosBusqueda);
}