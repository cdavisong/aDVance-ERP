using aDVanceERP.Core.MVP.Presentadores;
using aDVanceERP.Modulos.Finanzas.MVP.Vistas.QR.Plantillas;

namespace aDVanceERP.Modulos.Finanzas.MVP.Presentadores; 

public class PresentadorQR : PresentadorBase<IVistaQR> {
    public PresentadorQR(IVistaQR vista) : base(vista) {
        Vista.Salir += delegate(object? sender, EventArgs e) {
            Salir?.Invoke(sender, e);
            Vista.Cerrar();
        };
    }

    public event EventHandler? Salir;
}