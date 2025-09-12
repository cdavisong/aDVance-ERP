using aDVanceERP.Core.Repositorios.Comun;
using aDVanceERP.Core.Vistas.Interfaces;

namespace aDVanceERP.Core.MVP.Vistas.Plantillas;

public interface IVistaContenedor : IVistaBase {
    int AlturaContenedorVistas { get; }
    int TuplasMaximasContenedor { get; }

    RepoVistaBase? Vistas { get; }
}