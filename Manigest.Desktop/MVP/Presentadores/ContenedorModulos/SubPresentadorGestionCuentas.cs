using Manigest.Modulos.Finanzas.MVP.Presentadores;
using Manigest.Modulos.Finanzas.MVP.Vistas.Cuenta;

namespace Manigest.Desktop.MVP.Presentadores.ContenedorModulos {
    public partial class PresentadorContenedorModulos {
        private PresentadorGestionCuentas _gestionCuentas;

        private void InicializarVistaGestionCuentas() {
            _gestionCuentas = new PresentadorGestionCuentas(new VistaGestionCuentas());
            _gestionCuentas.MostrarQrTupla += MostrarVistaQR;
            _gestionCuentas.EditarObjeto += MostrarVistaEdicionCuenta;
            _gestionCuentas.Vista.RegistrarDatos += MostrarVistaRegistroCuenta;            

            Vista.Vistas.Registrar("vistaGestionCuentas", _gestionCuentas.Vista);
        }

        private void MostrarVistaGestionCuentas(object? sender, EventArgs e) {
            _gestionCuentas.Vista.Mostrar();
            _gestionCuentas.Vista.Restaurar();
            _gestionCuentas.RefrescarListaObjetos();
        }
    }
}
