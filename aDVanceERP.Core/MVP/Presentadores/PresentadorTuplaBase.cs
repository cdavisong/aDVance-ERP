using aDVanceERP.Core.MVP.Modelos.Plantillas;
using aDVanceERP.Core.MVP.Presentadores.Plantillas;
using aDVanceERP.Core.MVP.Vistas.Plantillas;
using aDVanceERP.Core.Utiles;

namespace aDVanceERP.Core.MVP.Presentadores {
    public abstract class PresentadorTuplaBase<Vt, O> : PresentadorBase<Vt>, IPresentadorTupla<Vt, O>
        where Vt : IVistaTupla
        where O : class, IObjetoUnico, new() {
        protected PresentadorTuplaBase(Vt vista, O objeto) : base(vista) {
            Vista.TuplaSeleccionada += delegate {
                TuplaSeleccionada = !TuplaSeleccionada;
            };
            Vista.EditarDatosTupla += delegate (object? sender, EventArgs e) {
                EditarObjeto?.Invoke(Objeto, e);
            };
            Vista.EliminarDatosTupla += delegate (object? sender, EventArgs e) {
                EliminarObjeto?.Invoke(Objeto, e);
            };
            Objeto = objeto;
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
    }
}
