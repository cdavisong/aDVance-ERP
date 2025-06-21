using aDVanceERP.Core.MVP.Modelos.Plantillas;
using aDVanceERP.Core.MVP.Modelos.Repositorios.Plantillas;
using aDVanceERP.Core.MVP.Presentadores.Plantillas;
using aDVanceERP.Core.MVP.Vistas.Plantillas;

namespace aDVanceERP.Core.MVP.Presentadores; 

public abstract class PresentadorRegistroBase<Vr, O, Do, C> : PresentadorBase<Vr>, IPresentadorRegistro<Vr, Do, O, C>
    where Vr : class, IVistaRegistro
    where Do : class, IRepositorioDatosEntidad<O, C>, new()
    where O : class, IEntidad, new()
    where C : Enum {
    private bool _disposed; // Para evitar llamadas redundantes a Dispose

    protected PresentadorRegistroBase(Vr vista) : base(vista) {
        //TODO: Opcional, para mostrar las ventanas modales siempre antes que otras ventanas
        //if (vista != null && vista is Form vistaForm)
        //    vistaForm.TopMost = true; // Asegurar que la ventana esté siempre al frente

        Vista.RegistrarDatos += RegistrarDatosObjeto;
        Vista.EditarDatos += EditarDatosObjeto;
        Vista.Salir += OnSalir;
    }

    protected O? Objeto { get; set; } // Objeto que se va a registrar o editar

    public Do DatosObjeto {
        get => new();
    }

    public event EventHandler? DatosRegistradosActualizados;
    public event EventHandler? Salir;

    public abstract void PopularVistaDesdeObjeto(O objeto);

    protected abstract Task<O?> ObtenerObjetoDesdeVista();

    protected virtual bool RegistroEdicionDatosAutorizado() {
        return true;
    }

    protected virtual void RegistroAuxiliar(Do datosObjeto, long id) { }

    protected virtual void RegistrarDatosObjeto(object? sender, EventArgs e) {
        _ = RegistrarEditarObjetoAsync(sender, e); // Llamar asincrónicamente sin esperar
    }

    protected virtual void EditarDatosObjeto(object? sender, EventArgs e) {
        _ = RegistrarEditarObjetoAsync(sender, e); // Llamar asincrónicamente sin esperar
    }

    private async Task RegistrarEditarObjetoAsync(object? sender, EventArgs e) {
        if (!RegistroEdicionDatosAutorizado())
            return;

        Objeto = await ObtenerObjetoDesdeVista();

        if (Objeto == null)
            return;

        if (Vista.ModoEdicionDatos && Objeto.Id != 0)
            await DatosObjeto.EditarAsync(Objeto);
        else if (Objeto.Id != 0)
            await DatosObjeto.EditarAsync(Objeto);
        else
            Objeto.Id = await DatosObjeto.AdicionarAsync(Objeto);

        RegistroAuxiliar(DatosObjeto, Objeto.Id);

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
        Vista.Salir -= OnSalir;

        _disposed = true;
    }

    public override void Dispose() {
        Dispose(disposing: true);
        GC.SuppressFinalize(this);
    }
}