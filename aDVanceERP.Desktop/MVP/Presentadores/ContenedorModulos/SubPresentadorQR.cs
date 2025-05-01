using aDVanceERP.Desktop.Utiles;
using aDVanceERP.Modulos.Finanzas.MVP.Presentadores;
using aDVanceERP.Modulos.Finanzas.MVP.Vistas.QR;

namespace aDVanceERP.Desktop.MVP.Presentadores.ContenedorModulos; 

public partial class PresentadorContenedorModulos {
    private PresentadorQR? _qr;

    private void InicializarVistaQR() {
        _qr = new PresentadorQR(new VistaQR());
        _qr.Vista.EstablecerCoordenadasVistaRegistro(Vista.Dimensiones);
        _qr.Vista.EstablecerDimensionesVistaRegistro(Vista.Dimensiones.Height);
        _qr.Salir += delegate { _qr.Vista.Cerrar(); };
    }

    private void MostrarVistaQR(object? sender, EventArgs e) {
        InicializarVistaQR();

        if (_qr == null) 
            return;

        MostrarVistaPanelTransparente(_qr.Vista);

        _qr.Vista.CargarCodigoQR(sender as string);
        _qr.Vista.Restaurar();
        _qr.Vista.Mostrar();
    }
}