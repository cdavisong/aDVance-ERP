using Manigest.Modulos.Inventario.MVP.Presentadores;
using Manigest.Modulos.Inventario.MVP.Vistas.Menu;

namespace Manigest.Desktop.MVP.Presentadores.ContenedorModulos {
    public partial class PresentadorContenedorModulos {
        private PresentadorMenuInventario _menuInventario;

        private void InicializarVistaMenuInventario() {
            _menuInventario = new PresentadorMenuInventario(new VistaMenuInventario());
            _menuInventario.Vista.VerArticulos += MostrarVistaGestionArticulos;
            _menuInventario.Vista.VerMovimientos += MostrarVistaGestionMovimientos;
            _menuInventario.Vista.VerAlmacenes += MostrarVistaGestionAlmacenes;
            _menuInventario.Vista.CambioMenu += delegate { Vista.Vistas.Ocultar(true); };

            VistaPrincipal.Menus.Registrar("vistaMenuInventario", _menuInventario.Vista);
        }

        private void MostrarVistaMenuInventario(object? sender, EventArgs e) {
            _menuInventario.Vista.Mostrar();
            _menuInventario.Vista.Restaurar();
        }
    }
}
