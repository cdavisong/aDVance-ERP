using aDVanceERP.Core.Modelos.Comun.Interfaces;

namespace aDVanceERP.Core.Vistas.Interfaces;

public interface IVistaRegistro : IVistaBase, IGestorEntidades {
    bool ModoEdicion { get; set; }
}