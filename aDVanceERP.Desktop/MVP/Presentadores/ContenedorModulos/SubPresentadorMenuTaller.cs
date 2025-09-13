using aDVanceERP.Modulos.Taller.Presentadores.Menu;
using aDVanceERP.Modulos.Taller.Vistas.Menu;

namespace aDVanceERP.Desktop.MVP.Presentadores.ContenedorModulos {
    public partial class PresentadorContenedorModulos {
        private PresentadorMenuTaller? _menuTaller;

        private void InicializarVistaMenuTaller() {
            _menuTaller = new PresentadorMenuTaller(new VistaMenuTaller());
            _menuTaller.Vista.VerOrdenesProduccion += MostrarVistaGestionOrdenesProduccion;
            _menuTaller.Vista.CambioMenu += delegate { Vista.Vistas?.OcultarTodos(); };

            VistaPrincipal.BarraTitulo.Registrar("vistaMenuTaller", _menuTaller.Vista);
        }

        private void MostrarVistaMenuTaller(object? sender, EventArgs e) {
            if (_menuTaller == null)
                return;

            _menuTaller.Vista.Restaurar();
            _menuTaller.Vista.Mostrar();
            _menuTaller.Vista.MostrarCaracteristicaInicial();
        }
    }
}