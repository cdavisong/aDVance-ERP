using Manigest.Core.MVP.Modelos.Plantillas;

namespace Manigest.Core.MVP.Vistas.Plantillas {
    public interface IVistaRegistro : IVista, IGestorDatos {
        bool ModoEdicionDatos { get; set; }
    }
}
