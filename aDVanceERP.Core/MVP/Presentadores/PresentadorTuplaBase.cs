using aDVanceERP.Core.MVP.Modelos.Plantillas;
using aDVanceERP.Core.MVP.Presentadores.Plantillas;
using aDVanceERP.Core.MVP.Vistas.Plantillas;
using aDVanceERP.Core.Utiles;

namespace aDVanceERP.Core.MVP.Presentadores {
    public abstract class PresentadorTuplaBase<Vt, O> : PresentadorBase<Vt>, IPresentadorTupla<Vt, O>
        where Vt : IVistaTupla
        where O : class, IObjetoUnico, new() {
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
                    ObjetoSeleccionado?.Invoke(Objeto, EventArgs.Empty);
                } else {
                    Vista.Restaurar();
                    ObjetoDeseleccionado?.Invoke(Objeto, EventArgs.Empty);
                }
            }
        }

        public O Objeto { get; }

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
    }
}