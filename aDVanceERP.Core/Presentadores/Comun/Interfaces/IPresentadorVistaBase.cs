using aDVanceERP.Core.Vistas.Interfaces;

namespace aDVanceERP.Core.Presentadores.Comun.Interfaces;

public interface IPresentadorVistaBase<Vb> : IDisposable
    where Vb : class, IVistaBase {
    Vb Vista { get; }
}