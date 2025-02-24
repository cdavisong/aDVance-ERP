namespace aDVanceERP.Core.MVP.Modelos.Plantillas {
    public interface IGestorTablaDatos {
        int PaginaActual { get; set; }
        int PaginasTotales { get; set; }

        event EventHandler? AlturaContenedorTuplasModificada;
        event EventHandler? MostrarPrimeraPagina;
        event EventHandler? MostrarPaginaAnterior;
        event EventHandler? MostrarPaginaSiguiente;
        event EventHandler? MostrarUltimaPagina;
        event EventHandler? SincronizarDatos;
    }
}
