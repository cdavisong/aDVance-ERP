using aDVanceERP.Core.Interfaces.Comun;

namespace aDVanceERP.Core.MVP.Vistas.Plantillas;

public interface IVistaRegistro : IVista, IGestorDatos {
    bool ModoEdicionDatos { get; set; }
}