namespace aDVanceERP.Core.Interfaces;

public interface IPresentadorVistaGestionBase<Vg, Pt, Vt, En, Rep, Fb> : IPresentadorVistaBase<Vg>
    where Vg : class, IVistaGestion<Fb>
    where Pt : class, IPresentadorVistaTuplaBase<Vt, En>
    where Vt : class, IVistaTupla
    where En : class, IEntidadBd, new()
    where Rep : class, IRepoBase<En, Fb>
    where Fb : Enum {
}
