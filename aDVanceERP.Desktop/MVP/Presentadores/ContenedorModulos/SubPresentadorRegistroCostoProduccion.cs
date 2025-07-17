using aDVanceERP.Desktop.Utiles;
using aDVanceERP.Modulos.Taller.Modelos;
using aDVanceERP.Modulos.Taller.Presentadores.CostosProduccion;
using aDVanceERP.Modulos.Taller.Vistas.CostosProduccion;

namespace aDVanceERP.Desktop.MVP.Presentadores.ContenedorModulos {
    public partial class PresentadorContenedorModulos {
        private PresentadorRegistroOrdenProduccion? _registroCostoProduccion;

        private void InicializarVistaRegistroCostoProduccion() {
            _registroCostoProduccion = new PresentadorRegistroCostoProduccion(new VistaRegistroCostoDirecto());
            _registroCostoProduccion.Vista.EstablecerCoordenadasVistaRegistro(Vista.Dimensiones);
            _registroCostoProduccion.Vista.EstablecerDimensionesVistaRegistro(Vista.Dimensiones.Height);
            _registroCostoProduccion.DatosRegistradosActualizados += async delegate {
                if (_gestionCostosProduccion == null)
                    return;

                await _gestionCostosProduccion.RefrescarListaObjetos();
            };
        }

        private void MostrarVistaRegistroCostoProduccion(object? sender, EventArgs e) {
            InicializarVistaRegistroCostoProduccion();

            if (_registroCostoProduccion == null)
                return;
            
            _registroCostoProduccion.Vista.Mostrar();
            _registroCostoProduccion.Dispose();
        }

        private void MostrarVistaEdicionCostoProduccion(object? sender, EventArgs e) {
            InicializarVistaRegistroCostoProduccion();

            if (sender is CostoDirecto costoProduccion) {
                if (_registroCostoProduccion != null) {
                    _registroCostoProduccion.PopularVistaDesdeObjeto(costoProduccion);
                    _registroCostoProduccion.Vista.Mostrar();
                }
            }

            _registroCostoProduccion?.Dispose();
        }
    }
}