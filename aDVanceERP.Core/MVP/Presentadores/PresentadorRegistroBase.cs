using aDVanceERP.Core.Modelos.Comun.Interfaces;
using aDVanceERP.Core.MVP.Presentadores.Plantillas;
using aDVanceERP.Core.MVP.Vistas.Plantillas;
using aDVanceERP.Core.Repositorios.Interfaces;

namespace aDVanceERP.Core.MVP.Presentadores;

public abstract class PresentadorRegistroBase<Vr, O, Do, C> : PresentadorBase<Vr>, IPresentadorRegistro<Vr, Do, O, C>
    where Vr : class, IVistaRegistro
    where Do : class, IRepoEntidadBaseDatos<O, C>, new()
    where O : class, IEntidadBaseDatos, new()
    where C : Enum {
    private bool _disposed; // Para evitar llamadas redundantes a Dispose

    protected PresentadorRegistroBase(Vr vista) : base(vista) {
        //TODO: Opcional, para mostrar las ventanas modales siempre antes que otras ventanas
        //if (vista != null && vista is Form vistaForm)
        //    vistaForm.TopMost = true; // Asegurar que la ventana esté siempre al frente

        Vista.RegistrarDatos += RegistrarDatosObjeto;
        Vista.EditarDatos += EditarDatosObjeto;
    }

    protected O? Entidad { get; set; } // Objeto que se va a registrar o editar

    public Do DatosObjeto {
        get => new();
    }

    public event EventHandler? DatosRegistradosActualizados;
    public event EventHandler? Salir;

    public abstract void PopularVistaDesdeObjeto(O objeto);

    protected abstract O? ObtenerEntidadDesdeVista();

    protected virtual bool RegistroEdicionDatosAutorizado() {
        return true;
    }

    protected virtual void RegistroAuxiliar(Do datosObjeto, long id) { }

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

        Vista.RegistrarDatos -= RegistrarDatosObjeto;
        Vista.EditarDatos -= EditarDatosObjeto;

        _disposed = true;
    }

    public override void Dispose() {
        Dispose(disposing: true);
        GC.SuppressFinalize(this);
    }
}