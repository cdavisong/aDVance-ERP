using aDVanceERP.Core.Repositorios.Comun;

namespace aDVanceERP.Core.Vistas.Interfaces;

public interface IVistaContenedor : IVistaBase {
    int AlturaContenedorVistas { get; }
    int TuplasMaximasContenedor { get; }

    RepoVistaBase Vistas { get; }
}