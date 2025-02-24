using aDVanceERP.Core.MVP.Modelos.Repositorios.Plantillas;

namespace aDVanceERP.Core.MVP.Vistas.Plantillas {
    public interface IVistaContenedor : IVista {
        int AlturaContenedorVistas { get; }
        int TuplasMaximasContenedor { get; }

        IRepositorioVista Vistas { get; }
    }
}
