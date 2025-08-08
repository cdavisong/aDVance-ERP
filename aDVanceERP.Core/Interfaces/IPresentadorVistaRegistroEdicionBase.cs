namespace aDVanceERP.Core.Interfaces;

public interface IPresentadorVistaRegistroEdicionBase<Vre, En, Rep, Fb> : IPresentadorVistaBase<Vre>
    where Vre : class, IVistaRegistroEdicion
    where En : class, IEntidadBd, new()
    where Rep : class, IRepoBase<En, Fb>
    where Fb : Enum {
    En EntidadBd { get; }
    Rep? RepositorioEntidadBd { get; set; }

    event EventHandler<En>? EntidadBdRegistradaActualizada;

    /// <summary>
    /// Llena los campos de la vista con los datos del objeto proporcionado.
    /// </summary>
    void PopularVistaDesdeEntidadBd(En objeto);

    /// <summary>
    /// Obtiene el objeto de registro desde los campos de la vista.
    /// </summary>
    /// <returns>Un objeto de tipo En con los datos ingresados en la vista.</returns>
    En ObtenerEntidadBdDesdeVista();
}