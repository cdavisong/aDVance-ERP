using Manigest.Core.MVP.Presentadores;
using Manigest.Modulos.Finanzas.MVP.Vistas.QR.Plantillas;

namespace Manigest.Modulos.Finanzas.MVP.Presentadores {
    public class PresentadorQR : PresentadorBase<IVistaQR> {
        public PresentadorQR(IVistaQR vista) : base(vista) {
            Vista.Salir += delegate (object? sender, EventArgs e) {
                Salir?.Invoke(sender, e);
                Vista.Cerrar();
            };
        }

        public event EventHandler? Salir;
    }
}
