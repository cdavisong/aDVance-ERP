using aDVanceERP.Core.MVP.Modelos.Plantillas;
using aDVanceERP.Core.MVP.Presentadores.Plantillas;
using aDVanceERP.Core.MVP.Vistas.Plantillas;
using aDVanceERP.Core.Repositorios.Plantillas;

namespace aDVanceERP.Core.MVP.Presentadores; 

public abstract class PresentadorRegistroBase<Vr, En, Rd, Fb> : PresentadorBase<Vr>, IPresentadorRegistro<Vr, Rd, En, Fb>,
    IDisposable
    where Vr : class, IVistaRegistro
    where Rd : class, IRepositorioDatosEntidad<En, Fb>, new()
    where En : class, IEntidad, new()
    where Fb : Enum {
    private bool _disposed; // Para evitar llamadas redundantes a Dispose

    protected PresentadorRegistroBase(Vr vista) : base(vista) {
        //TODO: Opcional, para mostrar las ventanas modales siempre antes que otras ventanas
        //if (vista != null && vista is Form vistaForm)
        //    vistaForm.TopMost = true; // Asegurar que la ventana esté siempre al frente

        Vista.RegistrarDatos += RegistrarDatosObjeto;
        Vista.EditarDatos += EditarDatosObjeto;
        Vista.Salir += OnSalir;
    }

    protected En? Entidad { get; set; } // Entidad que se va a registrar o editar

    // Implementación de IDisposable
    public void Dispose() {
        Dispose(true);
        GC.SuppressFinalize(this); // Evitar que el GC llame al finalizador
    }

    public Rd RepoDatosEntidad {
        get => new();
    }

    public event EventHandler? DatosEntidadRegistradosActualizados;
    public event EventHandler? Salir;

    public abstract void PopularVistaDesdeEntidad(En Entidad);

    protected abstract En? ObtenerEntidadDesdeVista();

    protected virtual bool DatosEntidadCorrectos() {
        return true;
    }

    protected virtual void RegistroAuxiliar(Rd datosObjeto, long id) { }

    protected virtual void RegistrarDatosObjeto(object? sender, EventArgs e) {
        RegistrarEditarEntidad(sender, e);
    }

    protected virtual void EditarDatosObjeto(object? sender, EventArgs e) {
        RegistrarEditarEntidad(sender, e);
    }

    private void RegistrarEditarEntidad(object? sender, EventArgs e) {
        if (!DatosEntidadCorrectos())
            return;

        Entidad = ObtenerEntidadDesdeVista();

        if (Entidad == null)
            return;

        if (Vista.ModoEdicionDatos && Entidad.Id != 0)
            RepoDatosEntidad.Actualizar(Entidad);
        else if (Entidad.Id != 0)
            RepoDatosEntidad.Actualizar(Entidad);
        else
            Entidad.Id = RepoDatosEntidad.Insertar(Entidad);

        RegistroAuxiliar(RepoDatosEntidad, Entidad.Id);

        DatosEntidadRegistradosActualizados?.Invoke(sender, e);
        Salir?.Invoke(sender, e);
        Vista.Ocultar();
    }

    private void OnSalir(object? sender, EventArgs e) {
        Salir?.Invoke(sender, e);
        Vista.Ocultar();
    }

    protected void InvokeDatosRegistradosActualizados(object? sender, EventArgs e) {
        DatosEntidadRegistradosActualizados?.Invoke(sender, e);
    }

    protected virtual void Dispose(bool disposing) {
        if (_disposed)
            return;

        if (disposing)
            // Liberar recursos administrados
            if (Vista is IDisposable disposableVista)
                disposableVista.Dispose();
        // Liberar otros recursos administrados si es necesario
        // Liberar recursos no administrados si es necesario

        _disposed = true;
    }

    ~PresentadorRegistroBase() {
        Dispose(false);
    }
}