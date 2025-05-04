using aDVanceERP.Modulos.CompraVenta.MVP.Presentadores;
using aDVanceERP.Modulos.CompraVenta.MVP.Vistas.Menu;

namespace aDVanceERP.Desktop.MVP.Presentadores.ContenedorModulos; 

public partial class PresentadorContenedorModulos {
    private PresentadorMenuCompraventas? _menuCompraventas;

    private void InicializarVistaMenuCompraventas() {
        _menuCompraventas = new PresentadorMenuCompraventas(new VistaMenuCompraventas());
        _menuCompraventas.Vista.VerCompras += MostrarVistaGestionCompras;
        _menuCompraventas.Vista.VerVentas += MostrarVistaGestionVentas;
        _menuCompraventas.Vista.CambioMenu += delegate { Vista.Vistas?.Ocultar(true); };

        VistaPrincipal.Menus.Registrar("vistaMenuCompraventas", _menuCompraventas.Vista);
    }

    private void MostrarVistaMenuVentas(object? sender, EventArgs e) {
        if (_menuCompraventas == null)
            return;

        _menuCompraventas.Vista.Restaurar();
        _menuCompraventas.Vista.Mostrar();
        _menuCompraventas.Vista.MostrarCaracteristicaInicial();
    }
}