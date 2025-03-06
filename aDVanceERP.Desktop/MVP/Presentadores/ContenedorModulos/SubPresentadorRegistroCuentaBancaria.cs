using aDVanceERP.Core.Utiles.Datos;
using aDVanceERP.Desktop.Utiles;
using aDVanceERP.Modulos.Finanzas.MVP.Modelos;
using aDVanceERP.Modulos.Finanzas.MVP.Presentadores;
using aDVanceERP.Modulos.Finanzas.MVP.Vistas.CuentaBancaria;

namespace aDVanceERP.Desktop.MVP.Presentadores.ContenedorModulos {
    public partial class PresentadorContenedorModulos {
        private PresentadorRegistroCuentaBancaria _registroCuentaBancaria;

        private async Task InicializarVistaRegistroCuentaBancaria() {
            _registroCuentaBancaria = new PresentadorRegistroCuentaBancaria(new VistaRegistroCuentaBancaria());
            _registroCuentaBancaria.Vista.CargarNombresContactos(UtilesContacto.ObtenerNombresContactos());
            _registroCuentaBancaria.Vista.EstablecerCoordenadasVistaRegistro(Vista.Dimensiones.Width);
            _registroCuentaBancaria.Vista.EstablecerDimensionesVistaRegistro(Vista.Dimensiones.Height);
            _registroCuentaBancaria.Salir += async (sender, e) => {
                if (_gestionCuentasBancarias != null) {
                    await _gestionCuentasBancarias.RefrescarListaObjetos();
                }
            };
        }

        private async void MostrarVistaRegistroCuentaBancaria(object? sender, EventArgs e) {
            await InicializarVistaRegistroCuentaBancaria();

            if (_registroCuentaBancaria != null) {
                _registroCuentaBancaria.Vista.Mostrar();
            }

            _registroCuentaBancaria?.Dispose();
        }

        private async void MostrarVistaEdicionCuentaBancaria(object? sender, EventArgs e) {
            await InicializarVistaRegistroCuentaBancaria();

            if (_registroCuentaBancaria != null && sender is CuentaBancaria cuentaBancaria) {
                _registroCuentaBancaria.PopularVistaDesdeObjeto(cuentaBancaria);
                _registroCuentaBancaria.Vista.Mostrar();
            }

            _registroCuentaBancaria?.Dispose();
        }
    }
}
