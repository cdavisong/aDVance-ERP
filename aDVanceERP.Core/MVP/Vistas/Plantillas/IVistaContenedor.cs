using aDVanceERP.Core.Interfaces.Comun;

namespace aDVanceERP.Core.MVP.Vistas.Plantillas;

public interface IVistaContenedor : IVista {
    int AlturaContenedorVistas { get; }
    int TuplasMaximasContenedor { get; }

    IRepositorioVista? Vistas { get; }
}