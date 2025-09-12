using aDVanceERP.Core.Modelos.Comun.Interfaces;
using aDVanceERP.Core.Vistas.Interfaces;

namespace aDVanceERP.Core.MVP.Vistas.Plantillas;

public interface IVistaRegistro : IVistaBase, IGestorEntidades {
    bool ModoEdicionDatos { get; set; }
}