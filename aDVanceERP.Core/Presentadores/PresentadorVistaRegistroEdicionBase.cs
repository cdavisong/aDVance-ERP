using aDVanceERP.Core.Interfaces;

namespace aDVanceERP.Core.Presentadores;

public abstract class PresentadorVistaRegistroEdicionBase<Vre, En, Rep, Fb> : PresentadorVistaBase<Vre>, IPresentadorVistaRegistroEdicionBase<Vre, En, Rep, Fb>
    where Vre : class, IVistaRegistroEdicion
    where En : class, IEntidadBd, new()
    where Rep : class, IRepoBase<En, Fb>
    where Fb : Enum {

    protected PresentadorVistaRegistroEdicionBase(Vre vista, bool modoEdicion = false) : base(vista) {
        Vista.ModoEdicion = modoEdicion;        
        Vista.Registrar += OnRegistrarEntidadBd;
        Vista.Editar += OnEditarEntidadBd;

        EntidadBd = new();
    }

    public En EntidadBd { get; set; } // Entidad que se va a registrar o editar

    public Rep? RepositorioEntidadBd { get; set; }

    public event EventHandler<En>? EntidadBdRegistradaActualizada;

    /// <summary>
    /// Llena los campos de la vista con los datos del objeto proporcionado.
    /// </summary>
    public abstract void PopularVistaDesdeEntidadBd(En objeto);

    /// <summary>
    /// Obtiene el objeto de registro desde los campos de la vista.
    /// </summary>
    /// <returns>Un objeto de tipo En con los datos ingresados en la vista.</returns>
    public abstract En ObtenerEntidadBdDesdeVista();

    protected virtual void OnRegistrarEntidadBd(object? sender, EventArgs e) {
        RegistrarActualizarEntidadBd();
    }

    protected virtual void OnEditarEntidadBd(object? sender, EventArgs e) {
        RegistrarActualizarEntidadBd();
    }

    private void RegistrarActualizarEntidadBd() {
        if (!Vista.VerificarCamposObligatorios())
            return;

        EntidadBd = ObtenerEntidadBdDesdeVista();

        if (EntidadBd == null)
            return;

        if (Vista.ModoEdicion)
            RepositorioEntidadBd?.Actualizar(EntidadBd);
        else
            EntidadBd.Id = RepositorioEntidadBd?.Insertar(EntidadBd) ?? 0;

        RegistroAuxiliar(RepositorioEntidadBd, EntidadBd.Id);

        EntidadBdRegistradaActualizada?.Invoke(this, EntidadBd);

        Vista.Ocultar();
    }

    protected virtual void RegistroAuxiliar(Rep repositorioEntidadBd, long id) { }

    protected void InvokeDatosRegistradosActualizados(object? sender, EventArgs e) {
        EntidadBdRegistradaActualizada?.Invoke(sender, EntidadBd);
    }

    public override void Dispose() {
        Vista.Registrar -= OnRegistrarEntidadBd;
        Vista.Editar -= OnEditarEntidadBd;
        Vista.Dispose();

        GC.SuppressFinalize(this);
    }
}