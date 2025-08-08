using aDVanceERP.Core.Interfaces;

namespace aDVanceERP.Core.MVP.Vistas.Plantillas;

public interface IVistaContenedor : IVista {
    int AlturaContenedorVistas { get; }
    int TuplasMaximasContenedor { get; }

    IRepositorioVista? Vistas { get; }
}