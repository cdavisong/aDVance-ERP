using aDVanceERP.Core.Presentadores;
using aDVanceERP.Modulos.Finanzas.MVP.Vistas.QR.Plantillas;

namespace aDVanceERP.Modulos.Finanzas.MVP.Presentadores;

public class PresentadorQR : PresentadorVistaBase<IVistaQR> {
    public PresentadorQR(IVistaQR vista) : base(vista) {
        Vista.Salir += OnSalir;
    }

    private void OnSalir(object? sender, EventArgs e) {
        Salir?.Invoke(sender, e);
        Vista.Dispose();
    }

    public event EventHandler? Salir;

    public override void Dispose() {
        Vista.Salir -= OnSalir;
    }
}