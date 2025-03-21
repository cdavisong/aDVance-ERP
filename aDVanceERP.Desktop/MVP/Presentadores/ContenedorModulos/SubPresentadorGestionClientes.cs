using aDVanceERP.Modulos.Contactos.MVP.Modelos;
using aDVanceERP.Modulos.Contactos.MVP.Presentadores;
using aDVanceERP.Modulos.Contactos.MVP.Vistas.Cliente;

namespace aDVanceERP.Desktop.MVP.Presentadores.ContenedorModulos {
    public partial class PresentadorContenedorModulos {
        private PresentadorGestionClientes _gestionClientes;

        private void InicializarVistaGestionClientes() {
            _gestionClientes = new PresentadorGestionClientes(new VistaGestionClientes());
            _gestionClientes.EditarObjeto += MostrarVistaEdicionCliente;
            _gestionClientes.Vista.RegistrarDatos += MostrarVistaRegistroCliente;
            
            if (Vista.Vistas != null)
                Vista.Vistas?.Registrar("vistaGestionClientes", _gestionClientes.Vista);
        }

        private void MostrarVistaGestionClientes(object? sender, EventArgs e) {
            if ((_gestionClientes?.Vista) == null)
                return;

            _gestionClientes.Vista.CargarCriteriosBusqueda(UtilesBusquedaCliente.CriterioBusquedaCliente);
            _gestionClientes.Vista.Restaurar();
            _gestionClientes.Vista.Mostrar();

            _gestionClientes.RefrescarListaObjetos();
        }
    }
}
