using aDVanceERP.Desktop.Utiles;
using aDVanceERP.Modulos.Inventario.MVP.Modelos;
using aDVanceERP.Modulos.Inventario.MVP.Presentadores;
using aDVanceERP.Modulos.Inventario.MVP.Vistas.Almacen;

namespace aDVanceERP.Desktop.MVP.Presentadores.ContenedorModulos {
    public partial class PresentadorContenedorModulos {
        private PresentadorRegistroAlmacen? _registroAlmacen;

        private async Task InicializarVistaRegistroAlmacen() {
            _registroAlmacen = new PresentadorRegistroAlmacen(new VistaRegistroAlmacen());

            // Configurar coordenadas y dimensiones de la vista
            _registroAlmacen.Vista.EstablecerCoordenadasVistaRegistro(Vista.Dimensiones.Width);
            _registroAlmacen.Vista.EstablecerDimensionesVistaRegistro(Vista.Dimensiones.Height);
            _registroAlmacen.Salir += async (sender, e) => {
                if (_gestionAlmacenes != null) {
                    await _gestionAlmacenes.RefrescarListaObjetos();
                }
            };
        }

        private async void MostrarVistaRegistroAlmacen(object? sender, EventArgs e) {
            await InicializarVistaRegistroAlmacen();

            if (_registroAlmacen != null) {
                _registroAlmacen?.Vista.Mostrar();
            }

            _registroAlmacen?.Dispose();
        }

        private async void MostrarVistaEdicionAlmacen(object? sender, EventArgs e) {
            await InicializarVistaRegistroAlmacen();

            if (_registroAlmacen != null && sender is Almacen almacen) {
                _registroAlmacen.PopularVistaDesdeObjeto(almacen);
                _registroAlmacen.Vista.Mostrar();
            }

            _registroAlmacen?.Dispose();
        }
    }
}