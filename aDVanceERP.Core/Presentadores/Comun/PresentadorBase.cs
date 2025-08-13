using aDVanceERP.Core.Modelos.Comun.Interfaces;
using aDVanceERP.Core.Repositorios.Interfaces;
using aDVanceERP.Core.Vistas.Interfaces;

namespace aDVanceERP.Core.Presentadores.Comun;

public abstract class PresentadorBase<Vb, Rb, En> : IDisposable
    where Vb : IVistaBase
    where Rb : class, IRepoBase<En>, new()
    where En : class, IEntidad, new() {
    private readonly Vb _vista;
    private readonly Rb _repositorio;

    protected PresentadorBase(Vb vista, Rb repositorio) {
        _vista = vista ?? throw new ArgumentNullException(nameof(vista));
        _repositorio = repositorio ?? new Rb();
        _vista.Inicializar();
    }

    public Vb Vista => _vista;

    public Rb Repositorio => _repositorio;

    public void Dispose() {
        _vista.Cerrar();
    }
}