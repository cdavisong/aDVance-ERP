namespace aDVanceERP.Core.MVP.Modelos.Plantillas; 

public interface IBuscadorDatos<C>
    where C : Enum {
    C FiltroBusqueda { get; }
    string? DatoBusqueda { get; }


    event EventHandler? BuscarDatos;

    void CargarCriteriosBusqueda(object[] criteriosBusqueda);
}