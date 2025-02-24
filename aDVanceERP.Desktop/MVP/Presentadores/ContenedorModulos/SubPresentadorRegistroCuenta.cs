using aDVanceERP.Core.Utiles;
using aDVanceERP.Core.Utiles.Datos;
using aDVanceERP.Modulos.Finanzas.MVP.Modelos;
using aDVanceERP.Modulos.Finanzas.MVP.Presentadores;
using aDVanceERP.Modulos.Finanzas.MVP.Vistas.Cuenta;

namespace aDVanceERP.Desktop.MVP.Presentadores.ContenedorModulos {
    public partial class PresentadorContenedorModulos {
        private PresentadorRegistroCuenta _registroCuenta;

        private void InicializarVistaRegistroCuenta() {
            _registroCuenta = new PresentadorRegistroCuenta(new VistaRegistroCuenta());
            _registroCuenta.Vista.CargarNombresContactos(UtilesContacto.ObtenerNombresContactos());
            _registroCuenta.Vista.Coordenadas = new Point(Vista.Dimensiones.Width - _registroCuenta.Vista.Dimensiones.Width - 20, VariablesGlobales.AlturaBarraTituloPredeterminada);
            _registroCuenta.Vista.Dimensiones = new Size(_registroCuenta.Vista.Dimensiones.Width, Vista.Dimensiones.Height);
            _registroCuenta.Salir += delegate { _gestionCuentas.RefrescarListaObjetos(); };
        }

        private void MostrarVistaRegistroCuenta(object? sender, EventArgs e) {
            InicializarVistaRegistroCuenta();

            _registroCuenta.Vista.Mostrar();
            _registroCuenta = null;
        }

        private void MostrarVistaEdicionCuenta(object? sender, EventArgs e) {
            InicializarVistaRegistroCuenta();

            _registroCuenta.PopularVistaDesdeObjeto(sender as Cuenta);
            _registroCuenta.Vista.Mostrar();
            _registroCuenta = null;
        }
    }
}
