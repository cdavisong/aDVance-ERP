using aDVanceERP.Core.MVP.Modelos.Plantillas;
using aDVanceERP.Core.MVP.Presentadores.Plantillas;
using aDVanceERP.Core.MVP.Vistas.Plantillas;
using aDVanceERP.Core.Utiles;

namespace aDVanceERP.Core.MVP.Presentadores; 

public abstract class PresentadorTuplaBase<Vt, En> : PresentadorBase<Vt>, IPresentadorTupla<Vt, En>
    where Vt : class, IVistaTupla
    where En : class, IEntidad, new() {
    protected PresentadorTuplaBase(Vt vista, En emtidad) : base(vista) {
        Entidad = emtidad ?? throw new ArgumentNullException(nameof(emtidad));

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
                EntidadSeleccionada?.Invoke(Entidad, EventArgs.Empty);
            }
            else {
                Vista.Restaurar();
                EntidadDeseleccionada?.Invoke(Entidad, EventArgs.Empty);
            }
        }
    }

    public En Entidad { get; }

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
}