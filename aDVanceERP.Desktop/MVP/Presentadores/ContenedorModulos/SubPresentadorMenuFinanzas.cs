using aDVanceERP.Modulos.Finanzas.MVP.Presentadores;
using aDVanceERP.Modulos.Finanzas.MVP.Vistas.Menu;

namespace aDVanceERP.Desktop.MVP.Presentadores.ContenedorModulos {
    public partial class PresentadorContenedorModulos {
        private PresentadorMenuFinanzas _menuFinanzas;

        private void InicializarVistaMenuFinanzas() {
            _menuFinanzas = new PresentadorMenuFinanzas(new VistaMenuFinanzas());
            _menuFinanzas.Vista.VerCuentas += MostrarVistaGestionCuentasBancarias;
            _menuFinanzas.Vista.CambioMenu += delegate { 
                Vista.Vistas?.OcultarVistas(); 
            };

            VistaPrincipal.Menus.Registrar("vistaMenuFinanzas", _menuFinanzas.Vista);
        }

        private void MostrarVistaMenuFinanzas(object? sender, EventArgs e) {
            _menuFinanzas.Vista.Restaurar();
            _menuFinanzas.Vista.Mostrar();

            _menuFinanzas.Vista.PresionarBotonSeleccion(sender is int opcion ? opcion : 1, e);
        }
    }
}
