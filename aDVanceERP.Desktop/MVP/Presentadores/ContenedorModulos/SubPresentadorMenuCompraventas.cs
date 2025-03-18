using aDVanceERP.Modulos.CompraVenta.MVP.Presentadores;
using aDVanceERP.Modulos.CompraVenta.MVP.Vistas.Menu;

namespace aDVanceERP.Desktop.MVP.Presentadores.ContenedorModulos {
    public partial class PresentadorContenedorModulos {
        private PresentadorMenuCompraventas _menuVentas;

        private void InicializarVistaMenuVentas() {
            _menuVentas = new PresentadorMenuCompraventas(new VistaMenuCompraventas());
            _menuVentas.Vista.VerVentas += MostrarVistaGestionVentas;
            _menuVentas.Vista.CambioMenu += delegate { Vista.Vistas?.Ocultar(true); };

            VistaPrincipal.Menus.Registrar("vistaMenuVentas", _menuVentas.Vista);
        }

        private void MostrarVistaMenuVentas(object? sender, EventArgs e) {
            _menuVentas.Vista.Restaurar();
            _menuVentas.Vista.Mostrar();

            _menuVentas.Vista.PresionarBotonSeleccion(sender is int opcion ? opcion : 1, e);
        }
    }
}
