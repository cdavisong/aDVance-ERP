using aDVanceERP.Core.MVP.Modelos.Repositorios.Plantillas;
using aDVanceERP.Core.Vistas.Interfaces;

namespace aDVanceERP.Core.MVP.Vistas.Plantillas; 

public interface IVistaContenedor : IVistaBase {
    int AlturaContenedorVistas { get; }
    int TuplasMaximasContenedor { get; }

    IRepoVista? Vistas { get; }
}