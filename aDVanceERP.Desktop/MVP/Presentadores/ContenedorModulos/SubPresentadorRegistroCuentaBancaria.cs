using aDVanceERP.Core.Utiles;
using aDVanceERP.Core.Utiles.Datos;
using aDVanceERP.Modulos.Finanzas.MVP.Modelos;
using aDVanceERP.Modulos.Finanzas.MVP.Presentadores;
using aDVanceERP.Modulos.Finanzas.MVP.Vistas.CuentaBancaria;

namespace aDVanceERP.Desktop.MVP.Presentadores.ContenedorModulos {
    public partial class PresentadorContenedorModulos {
        private PresentadorRegistroCuentaBancaria _registroCuentaBancaria;

        private void InicializarVistaRegistroCuentaBancaria() {
            _registroCuentaBancaria = new PresentadorRegistroCuentaBancaria(new VistaRegistroCuentaBancaria());
            _registroCuentaBancaria.Vista.CargarNombresContactos(UtilesContacto.ObtenerNombresContactos());
            _registroCuentaBancaria.Vista.Coordenadas = new Point(Vista.Dimensiones.Width - _registroCuentaBancaria.Vista.Dimensiones.Width - 20, VariablesGlobales.AlturaBarraTituloPredeterminada);
            _registroCuentaBancaria.Vista.Dimensiones = new Size(_registroCuentaBancaria.Vista.Dimensiones.Width, Vista.Dimensiones.Height);
            _registroCuentaBancaria.Salir += delegate { _gestionCuentasBancarias.RefrescarListaObjetos(); };
        }

        private void MostrarVistaRegistroCuentaBancaria(object? sender, EventArgs e) {
            InicializarVistaRegistroCuentaBancaria();

            _registroCuentaBancaria.Vista.Mostrar();
            _registroCuentaBancaria = null;
        }

        private void MostrarVistaEdicionCuentaBancaria(object? sender, EventArgs e) {
            InicializarVistaRegistroCuentaBancaria();

            _registroCuentaBancaria.PopularVistaDesdeObjeto(sender as CuentaBancaria);
            _registroCuentaBancaria.Vista.Mostrar();
            _registroCuentaBancaria = null;
        }
    }
}
