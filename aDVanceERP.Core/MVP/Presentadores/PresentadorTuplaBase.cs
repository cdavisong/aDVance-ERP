using aDVanceERP.Core.Interfaces.Comun;
using aDVanceERP.Core.MVP.Presentadores.Plantillas;
using aDVanceERP.Core.MVP.Vistas.Plantillas;
using aDVanceERP.Core.Utiles;

namespace aDVanceERP.Core.MVP.Presentadores; 

public abstract class PresentadorTuplaBase<Vt, O> : PresentadorBase<Vt>, IPresentadorTupla<Vt, O>
    where Vt : class, IVistaTupla
    where O : class, IEntidadBd, new() {
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

    public event EventHandler? ObjetoSeleccionado;
    public event EventHandler? ObjetoDeseleccionado;
    public event EventHandler? EditarObjeto;
    public event EventHandler? EliminarObjeto;

    private void OnTuplaSeleccionada(object? sender, EventArgs e) {
        TuplaSeleccionada = !TuplaSeleccionada;
    }

    private void OnEditarDatosTupla(object? sender, EventArgs e) {
        EditarObjeto?.Invoke(Objeto, e);
    }

    private void OnEliminarDatosTupla(object? sender, EventArgs e) {
        EliminarObjeto?.Invoke(Objeto, e);
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