using Manigest.Modulos.Contactos.MVP.Presentadores;
using Manigest.Modulos.Contactos.MVP.Vistas.Cliente;

namespace Manigest.Desktop.MVP.Presentadores.ContenedorModulos {
    public partial class PresentadorContenedorModulos {
        private PresentadorGestionClientes _gestionClientes;

        private void InicializarVistaGestionClientes() {
            _gestionClientes = new PresentadorGestionClientes(new VistaGestionClientes());
            _gestionClientes.EditarObjeto += MostrarVistaEdicionCliente;
            _gestionClientes.Vista.RegistrarDatos += MostrarVistaRegistroCliente;

            Vista.Vistas.Registrar("vistaGestionClientes", _gestionClientes.Vista);
        }

        private void MostrarVistaGestionClientes(object? sender, EventArgs e) {
            _gestionClientes.Vista.Mostrar();
            _gestionClientes.Vista.Restaurar();
            _gestionClientes.RefrescarListaObjetos();
        }
    }
}
