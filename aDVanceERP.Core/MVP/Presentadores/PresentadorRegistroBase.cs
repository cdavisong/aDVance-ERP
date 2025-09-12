using aDVanceERP.Core.Modelos.Comun.Interfaces;
using aDVanceERP.Core.MVP.Presentadores.Plantillas;
using aDVanceERP.Core.MVP.Vistas.Plantillas;
using aDVanceERP.Core.Repositorios.Comun.Interfaces;

namespace aDVanceERP.Core.MVP.Presentadores;

public abstract class PresentadorRegistroBase<Vr, En, Re, Fb> : PresentadorBase<Vr>, IPresentadorRegistro<Vr, Re, En, Fb>
    where Vr : class, IVistaRegistro
    where Re : class, IRepoEntidadBaseDatos<En, Fb>, new()
    where En : class, IEntidadBaseDatos, new()
    where Fb : Enum {
    private bool _disposed; // Para evitar llamadas redundantes a Dispose

    protected PresentadorRegistroBase(Vr vista) : base(vista) {
        //TODO: Opcional, para mostrar las ventanas modales siempre antes que otras ventanas
        //if (vista != null && vista is Form vistaForm)
        //    vistaForm.TopMost = true; // Asegurar que la ventana esté siempre al frente

        Vista.RegistrarEntidad += RegistrarDatosObjeto;
        Vista.EditarEntidad += EditarDatosObjeto;
    }

    protected En? Entidad { get; set; } // Objeto que se va a registrar o editar

    public Re DatosObjeto {
        get => new();
    }

    public event EventHandler? DatosRegistradosActualizados;
    public event EventHandler? Salir;

    public abstract void PopularVistaDesdeObjeto(En objeto);

    protected abstract En? ObtenerEntidadDesdeVista();

    protected virtual bool RegistroEdicionDatosAutorizado() {
        return true;
    }

    protected virtual void RegistroAuxiliar(Re datosObjeto, long id) { }

    protected virtual void RegistrarDatosObjeto(object? sender, EventArgs e) {
        RegistrarEditarObjeto(sender, e);
    }

    protected virtual void EditarDatosObjeto(object? sender, EventArgs e) {
        RegistrarEditarObjeto(sender, e);
    }

    private void RegistrarEditarObjeto(object? sender, EventArgs e) {
        if (!RegistroEdicionDatosAutorizado())
            return;

        Entidad = ObtenerEntidadDesdeVista();

        if (Entidad == null)
            return;

        if (Vista.ModoEdicionDatos && Entidad.Id != 0)
            DatosObjeto.Editar(Entidad);
        else if (Entidad.Id != 0)
            DatosObjeto.Editar(Entidad);
        else
            Entidad.Id = DatosObjeto.Adicionar(Entidad);

        RegistroAuxiliar(DatosObjeto, Entidad.Id);

        DatosRegistradosActualizados?.Invoke(sender, e);
        Salir?.Invoke(sender, e);

        Vista.Ocultar();
    }

    private void OnSalir(object? sender, EventArgs e) {
        Salir?.Invoke(sender, e);

        Vista.Ocultar();
    }

    protected void InvokeDatosRegistradosActualizados(object? sender, EventArgs e) {
        DatosRegistradosActualizados?.Invoke(sender, e);
    }

    protected virtual void Dispose(bool disposing) {
        if (_disposed)
            return;

        if (disposing)
            // Liberar recursos administrados
            if (Vista is IDisposable disposableVista)
                disposableVista.Dispose();

        Vista.RegistrarEntidad -= RegistrarDatosObjeto;
        Vista.EditarEntidad -= EditarDatosObjeto;

        _disposed = true;
    }

    public override void Dispose() {
        Dispose(disposing: true);
        GC.SuppressFinalize(this);
    }
}