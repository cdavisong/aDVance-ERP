using aDVanceERP.Core.MVP.Modelos.Plantillas;

namespace aDVanceERP.Core.MVP.Vistas.Plantillas {
    public interface IVistaRegistro : IVista, IGestorDatos {
        bool ModoEdicionDatos { get; set; }
    }
}
