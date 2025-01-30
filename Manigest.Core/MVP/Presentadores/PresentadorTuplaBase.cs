using Manigest.Core.MVP.Modelos.Plantillas;
using Manigest.Core.MVP.Presentadores.Plantillas;
using Manigest.Core.MVP.Vistas.Plantillas;

using System.Drawing;

namespace Manigest.Core.MVP.Presentadores {
    public abstract class PresentadorTuplaBase<Vt, O> : PresentadorBase<Vt>, IPresentadorTupla<Vt, O>
        where Vt : IVistaTupla
        where O : class, IObjetoUnico {
        protected PresentadorTuplaBase(Vt vista, O objeto) : base(vista) {
            Vista.TuplaSeleccionada += delegate { TuplaSeleccionada = !TuplaSeleccionada; };
            Vista.EditarDatosTupla += delegate (object? sender, EventArgs e) { EditarObjeto?.Invoke(Objeto, e); };
            Vista.EliminarDatosTupla += delegate (object? sender, EventArgs e) { EliminarObjeto?.Invoke(Objeto, e); };
            ColorResaltadoTupla = Color.FromArgb(255, 214, 88);
            Objeto = objeto;
        }

        public Color ColorResaltadoTupla { get; set; }

        public bool TuplaSeleccionada {
            get => Vista.ColorFondoTupla.Equals(ColorResaltadoTupla);
            set {
                if (value) {
                    Vista.ColorFondoTupla = ColorResaltadoTupla;
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
