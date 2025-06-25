using aDVanceERP.Core.MVP.Presentadores;
using aDVanceERP.Modulos.Finanzas.MVP.Vistas.QR.Plantillas;

namespace aDVanceERP.Modulos.Finanzas.MVP.Presentadores; 

public class PresentadorQR : PresentadorBase<IVistaQR> {
    public PresentadorQR(IVistaQR vista) : base(vista) {
        Vista.Salir += OnSalir;
    }

    private void OnSalir(object? sender, EventArgs e) {
        Salir?.Invoke(sender, e);
        Vista.Cerrar();
    }

    public event EventHandler? Salir;

    public override void Dispose() {
        Vista.Salir -= OnSalir;
    }
}