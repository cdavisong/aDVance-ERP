using aDVanceERP.Core.Utiles.Datos;
using aDVanceERP.Desktop.Utiles;
using aDVanceERP.Modulos.Finanzas.MVP.Modelos;
using aDVanceERP.Modulos.Finanzas.MVP.Presentadores;
using aDVanceERP.Modulos.Finanzas.MVP.Vistas.CuentaBancaria;

namespace aDVanceERP.Desktop.MVP.Presentadores.ContenedorModulos; 

public partial class PresentadorContenedorModulos {
    private PresentadorRegistroCuentaBancaria? _registroCuentaBancaria;

    private void InicializarVistaRegistroCuentaBancaria() {
        _registroCuentaBancaria = new PresentadorRegistroCuentaBancaria(new VistaRegistroCuentaBancaria());
        _registroCuentaBancaria.Vista.CargarNombresContactos(UtilesContacto.ObtenerNombresContactos());
        _registroCuentaBancaria.Vista.EstablecerCoordenadasVistaRegistro(Vista.Dimensiones.Width);
        _registroCuentaBancaria.Vista.EstablecerDimensionesVistaRegistro(Vista.Dimensiones.Height);
        _registroCuentaBancaria.Salir += async (sender, e) => {
            await _gestionCuentasBancarias.RefrescarListaObjetos();
        };
    }

    private void MostrarVistaRegistroCuentaBancaria(object? sender, EventArgs e) {
        InicializarVistaRegistroCuentaBancaria();

        if (_registroCuentaBancaria == null) 
            return;

        MostrarVistaPanelTransparente(_registroCuentaBancaria.Vista);

        _registroCuentaBancaria.Vista.Mostrar();
        _registroCuentaBancaria.Dispose();
    }

    private async void MostrarVistaEdicionCuentaBancaria(object? sender, EventArgs e) {
        InicializarVistaRegistroCuentaBancaria();

        if (sender is CuentaBancaria cuentaBancaria) {
            if (_registroCuentaBancaria != null) {
                MostrarVistaPanelTransparente(_registroCuentaBancaria.Vista);

                _registroCuentaBancaria.PopularVistaDesdeObjeto(cuentaBancaria);
                _registroCuentaBancaria.Vista.Mostrar();
            }
        }

        _registroCuentaBancaria?.Dispose();
    }
}