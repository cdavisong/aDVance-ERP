using aDVanceERP.Desktop.MVP.Presentadores.ContenedorModulos;
using aDVanceERP.Desktop.MVP.Vistas.ContenedorModulos;

namespace aDVanceERP.Desktop.MVP.Presentadores.Principal {
    public partial class PresentadorPrincipal {
        private PresentadorContenedorModulos? _contenedorModulos;

        private void InicializarVistaContenedorModulos() {
            _contenedorModulos = new PresentadorContenedorModulos(Vista, new VistaContenedorModulos());
            _contenedorModulos.Vista.CambioModulo += delegate {
                Vista.Menus.Ocultar(true);
            };

            Vista.Vistas?.Registrar("vistaContenedorModulos", _contenedorModulos.Vista);
        }

        private void MostrarVistaContenedorModulos(object? sender, EventArgs e) {
            _contenedorModulos?.Vista.Mostrar();
            _contenedorModulos?.Vista.Restaurar();

            // TODO: Mostrar el botón de sub-menu para usuarios
            //Vista.BtnSubmenuUsuarioDisponible = true;
        }
    }
}
