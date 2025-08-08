namespace aDVanceERP.Core.Interfaces;

public interface IPresentadorVistaTuplaBase<Vt, En> : IPresentadorVistaBase<Vt>
    where Vt : class, IVistaTupla
    where En : class, IEntidadBd, new() {
    En EntidadBd { get; }

    event EventHandler<En>? EntidadBdSeleccionada;
    event EventHandler<En>? EditarEntidadBd;
    event EventHandler<En>? EliminarEntidadBd;
}