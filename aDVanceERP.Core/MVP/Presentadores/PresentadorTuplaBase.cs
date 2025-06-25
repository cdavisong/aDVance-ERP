using aDVanceERP.Core.MVP.Modelos.Plantillas;
using aDVanceERP.Core.MVP.Presentadores.Plantillas;
using aDVanceERP.Core.MVP.Vistas.Plantillas;
using aDVanceERP.Core.Utiles;

namespace aDVanceERP.Core.MVP.Presentadores; 

public abstract class PresentadorTuplaBase<Vt, En> : PresentadorBase<Vt>, IPresentadorTupla<Vt, En>
    where Vt : class, IVistaTupla
    where O : class, IObjetoUnico, new() {
    private bool disposedValue;

    protected PresentadorTuplaBase(Vt vista, O objeto) : base(vista) {
        Objeto = objeto ?? throw new ArgumentNullException(nameof(objeto));

        // Suscribir a eventos de la vista
        Vista.TuplaSeleccionada += OnTuplaSeleccionada;
        Vista.EditarDatosTupla += OnEditarDatosTupla;
        Vista.EliminarDatosTupla += OnEliminarDatosTupla;
    }

    public bool TuplaSeleccionada {
        get => Vista.ColorFondoTupla.Equals(VariablesGlobales.ColorResaltadoTupla);
        set {
            if (value) {
                Vista.ColorFondoTupla = VariablesGlobales.ColorResaltadoTupla;
                ObjetoSeleccionado?.Invoke(Vista, EventArgs.Empty);
            }
            else {
                Vista.Restaurar();
                ObjetoDeseleccionado?.Invoke(Vista, EventArgs.Empty);
            }
        }
    }

    public O Objeto { get; private set; }

    public event EventHandler? EntidadSeleccionada;
    public event EventHandler? EntidadDeseleccionada;
    public event EventHandler? EditarDatosEntidad;
    public event EventHandler? EliminarDatosEntidad;

    private void OnTuplaSeleccionada(object? sender, EventArgs e) {
        TuplaSeleccionada = !TuplaSeleccionada;
    }

    private void OnEditarDatosTupla(object? sender, EventArgs e) {
        EditarDatosEntidad?.Invoke(Entidad, e);
    }

    private void OnEliminarDatosTupla(object? sender, EventArgs e) {
        EliminarDatosEntidad?.Invoke(Entidad, e);
    }

    protected virtual void Dispose(bool disposing) {
        if (!disposedValue) {
            if (disposing) {
                // TODO: eliminar el estado administrado (objetos administrados)
            }

            Vista.TuplaSeleccionada -= OnTuplaSeleccionada;
            Vista.EditarDatosTupla -= OnEditarDatosTupla;
            Vista.EliminarDatosTupla -= OnEliminarDatosTupla;

            disposedValue = true;
        }
    }

    public override void Dispose() {
        Dispose(disposing: true);
        GC.SuppressFinalize(this);
    }
}