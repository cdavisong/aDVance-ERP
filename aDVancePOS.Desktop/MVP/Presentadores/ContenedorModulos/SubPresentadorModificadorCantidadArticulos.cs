using aDVancePOS.Desktop.Utiles;
using aDVancePOS.Modulos.TerminalVenta.MVP.Presentadores;
using aDVancePOS.Modulos.TerminalVenta.MVP.Vistas.Venta;

namespace aDVancePOS.Desktop.MVP.Presentadores.ContenedorModulos {
    public partial class PresentadorContenedorModulos {
        private PresentadorModificadorCantidadArticulo? _modificadorCantidadArticulos;

        private int Cantidad { get; set; } = 1;

        private void InicializarVistaModificadorCantidadArticulo() {
            _modificadorCantidadArticulos = new PresentadorModificadorCantidadArticulo(new VistaModificadorCantidadArticulo());
            _modificadorCantidadArticulos.Vista.EstablecerCoordenadasVistaModal(Vista.Dimensiones.Width);
            _modificadorCantidadArticulos.Vista.EstablecerDimensionesVistaModal(_modificadorCantidadArticulos.Vista.Dimensiones);
            _modificadorCantidadArticulos.Vista.Salir += delegate {
                Cantidad = _modificadorCantidadArticulos.Vista.CantidadArticulo;
            };
        }

        private void MostrarVistaModificadorCantidadArticulo(object? sender, EventArgs e) {
            InicializarVistaModificadorCantidadArticulo();

            if (_modificadorCantidadArticulos?.Vista == null)
                return;

            MostrarVistaPanelTransparente(_modificadorCantidadArticulos.Vista);

            _modificadorCantidadArticulos.Vista.Restaurar();
            _modificadorCantidadArticulos.Vista.Mostrar();
            
            // Actualizar la cantidad en el terminal de venta
            if (_terminalVenta != null) _terminalVenta.Vista.Cantidad = Cantidad;
        }
    }
}
