using aDVanceERP.Core.Utiles.Datos;
using aDVanceERP.Desktop.Utiles;
using aDVanceERP.Modulos.Inventario.MVP.Presentadores;
using aDVanceERP.Modulos.Inventario.MVP.Vistas.TipoMovimiento;

namespace aDVanceERP.Desktop.MVP.Presentadores.ContenedorModulos {
    public partial class PresentadorContenedorModulos {
        private PresentadorRegistroTipoMovimiento _registroTipoMovimiento;

        private async Task InicializarVistaRegistroTipoMovimiento() {
            _registroTipoMovimiento = new PresentadorRegistroTipoMovimiento(new VistaRegistroTipoMovimiento());
            _registroTipoMovimiento.Vista.EstablecerCoordenadasVistaRegistro(Vista.Dimensiones.Width);
            _registroTipoMovimiento.Vista.EstablecerDimensionesVistaRegistro(Vista.Dimensiones.Height);
            _registroTipoMovimiento.Salir += delegate {
                _registroMovimiento.Vista.CargarTiposMovimientos(UtilesMovimiento.ObtenerNombresTiposMovimientos(Signo));
            };
        }

        private async void MostrarVistaRegistroTipoMovimiento(object? sender, EventArgs e) {
            await InicializarVistaRegistroTipoMovimiento();

            if (_registroTipoMovimiento != null) {
                _registroTipoMovimiento.Vista.Mostrar();
            }

            _registroTipoMovimiento?.Dispose();
        }
        /*
        private async void MostrarVistaEdicionTipoMovimiento(object? sender, EventArgs e) {
            await InicializarVistaRegistroTipoMovimiento();

            if (_registroTipoMovimiento != null && sender is TipoMovimiento tipoMovimiento) {
                _registroTipoMovimiento.PopularVistaDesdeObjeto(tipoMovimiento);
                _registroTipoMovimiento.Vista.Mostrar();
            }

            _registroTipoMovimiento?.Dispose();
        }*/
    }
}
