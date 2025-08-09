namespace aDVanceERP.Core.Interfaces;

public interface ITablaResultadosBusqueda {
    IPanelContenedorVistas PanelResultados {  get; }
    int TuplasMaximasPanel { get; }
    int PaginaActual { get; set; }
    int PaginasTotales { get; set; }

    event EventHandler? MostrarPaginaPrimera;
    event EventHandler? MostrarPaginaAnterior;
    event EventHandler? MostrarPaginaSiguiente;
    event EventHandler? MostrarPaginaUltima;
    event EventHandler? SincronizarDatosEntidadesBd;

    void ActualizarResultadosBusqueda<En>(int cantidad, List<En> resultados) where En : class, IEntidadBd, new();
}