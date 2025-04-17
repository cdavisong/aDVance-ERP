using aDVanceERP.Core.Utiles.Datos;
using aDVancePOS.Modulos.TerminalVenta.MVP.Presentadores;
using aDVancePOS.Modulos.TerminalVenta.MVP.Vistas.Venta;

namespace aDVancePOS.Desktop.MVP.Presentadores.ContenedorModulos;

public partial class PresentadorContenedorModulos {
    private PresentadorTerminalVenta? _terminalVenta;

    private List<string[]>? ArticulosVenta { get; set; } = new();

    private void InicializarVistaTerminalVenta() {
        _terminalVenta = new PresentadorTerminalVenta(new VistaTerminalVenta());
        _terminalVenta.Vista.CargarNombresAlmacenes(UtilesAlmacen.ObtenerNombresAlmacenes(true));
        
        Vista.Vistas?.Registrar("terminalVenta", _terminalVenta.Vista);
    }

    private void MostrarVistaTerminalVenta(object? sender, EventArgs e) {
        if (_terminalVenta?.Vista == null)
            return;

        _terminalVenta.Vista.Restaurar();
        _terminalVenta.Vista.Mostrar();
    }
}
