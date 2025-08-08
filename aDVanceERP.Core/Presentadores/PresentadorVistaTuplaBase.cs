using aDVanceERP.Core.Interfaces;

namespace aDVanceERP.Core.Presentadores;

public abstract class PresentadorVistaTuplaBase<Vt, En> : PresentadorVistaBase<Vt>, IPresentadorVistaTuplaBase<Vt, En>
    where Vt : class, IVistaTupla
    where En : class, IEntidadBd, new() {
    private Color _colorResaltadoTupla = Color.Gainsboro;

    protected PresentadorVistaTuplaBase(Vt vista, En entidadBd) : base(vista) {
        EntidadBd = entidadBd ?? throw new ArgumentNullException(nameof(entidadBd));

        // Suscribir a eventos de la vista
        OnCambioSeleccionTupla();
        Vista.EditarTuplaDatos += OnEditarEntidadBd;
        Vista.EliminarTuplaDatos += OnEliminarEntidadBd;
    }

    public En EntidadBd { get; private set; }

    public bool TuplaSeleccionada { get; private set; }

    public event EventHandler<En>? EntidadBdSeleccionada;
    public event EventHandler<En>? EditarEntidadBd;
    public event EventHandler<En>? EliminarEntidadBd;

    private void OnCambioSeleccionTupla() {
        foreach (var control in Vista.PanelDatosTupla.Controls) {
            if (control is Label columnaTupla)
                columnaTupla.Click += delegate {
                    TuplaSeleccionada = !TuplaSeleccionada;
                    EntidadBdSeleccionada?.Invoke(this, EntidadBd);

                    if (TuplaSeleccionada)
                        Vista.ColorFondo = _colorResaltadoTupla;
                    else
                        Vista.Restaurar();
                };
        }
    }

    private void OnEditarEntidadBd(object? sender, EventArgs e) {
        EditarEntidadBd?.Invoke(this, EntidadBd);
    }

    private void OnEliminarEntidadBd(object? sender, EventArgs e) {
        EliminarEntidadBd?.Invoke(this, EntidadBd);
    }

    public override void Dispose() {
        // Desuscribirse de eventos para evitar fugas de memoria
        Vista.EditarTuplaDatos -= OnEditarEntidadBd;
        Vista.EliminarTuplaDatos -= OnEliminarEntidadBd;

        // Liberar recursos específicos de la vista
        base.Dispose();

        GC.SuppressFinalize(this);
    }
}