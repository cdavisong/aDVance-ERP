using aDVanceERP.Core.Utiles;
using aDVanceERP.Modulos.Finanzas.MVP.Presentadores;
using aDVanceERP.Modulos.Finanzas.MVP.Vistas.QR;

namespace aDVanceERP.Desktop.MVP.Presentadores.ContenedorModulos; 

public partial class PresentadorContenedorModulos {
    private PresentadorQR _qr;

    private void InicializarVistaQR() {
        _qr = new PresentadorQR(new VistaQR());
        _qr.Vista.Coordenadas = new Point(Vista.Dimensiones.Width - _qr.Vista.Dimensiones.Width - 20,
            VariablesGlobales.AlturaBarraTituloPredeterminada);
        _qr.Vista.Dimensiones = new Size(_qr.Vista.Dimensiones.Width, Vista.Dimensiones.Height);
        _qr.Salir += delegate { _qr.Vista.Cerrar(); };
    }

    private void MostrarVistaQR(object? sender, EventArgs e) {
        InicializarVistaQR();

        _qr.Vista.CargarCodigoQR(sender as string);
        _qr.Vista.Restaurar();
        _qr.Vista.Mostrar();
    }
}