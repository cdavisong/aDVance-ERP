using Manigest.Modulos.Ventas.MVP.Presentadores;
using Manigest.Modulos.Ventas.MVP.Vistas.Menu;

namespace Manigest.Desktop.MVP.Presentadores.ContenedorModulos {
    public partial class PresentadorContenedorModulos {
        private PresentadorMenuVentas _menuVentas;

        private void InicializarVistaMenuVentas() {
            _menuVentas = new PresentadorMenuVentas(new VistaMenuVentas());
            _menuVentas.Vista.VerVentaArticulos += MostrarVistaGestionVentasArticulos;
            _menuVentas.Vista.CambioMenu += delegate { Vista.Vistas.Ocultar(true); };

            VistaPrincipal.Menus.Registrar("vistaMenuVentas", _menuVentas.Vista);
        }

        private void MostrarVistaMenuVentas(object? sender, EventArgs e) {
            _menuVentas.Vista.Mostrar();
            _menuVentas.Vista.Restaurar();
            _menuVentas.Vista.PresionarBotonSeleccion(1, e);
        }
    }
}
