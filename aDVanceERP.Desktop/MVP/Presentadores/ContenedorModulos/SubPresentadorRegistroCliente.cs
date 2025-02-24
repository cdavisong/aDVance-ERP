using aDVanceERP.Core.Utiles;
using aDVanceERP.Core.Utiles.Datos;
using aDVanceERP.Modulos.Contactos.MVP.Modelos;
using aDVanceERP.Modulos.Contactos.MVP.Presentadores;
using aDVanceERP.Modulos.Contactos.MVP.Vistas.Cliente;

namespace aDVanceERP.Desktop.MVP.Presentadores.ContenedorModulos {
    public partial class PresentadorContenedorModulos {
        private PresentadorRegistroCliente _registroCliente;

        private void InicializarVistaRegistroCliente() {
            _registroCliente = new PresentadorRegistroCliente(new VistaRegistroCliente());
            _registroCliente.Vista.CargarNombresContactos(UtilesContacto.ObtenerNombresContactos());
            _registroCliente.Vista.Coordenadas = new Point(Vista.Dimensiones.Width - _registroCliente.Vista.Dimensiones.Width - 20, VariablesGlobales.AlturaBarraTituloPredeterminada);
            _registroCliente.Vista.Dimensiones = new Size(_registroCliente.Vista.Dimensiones.Width, Vista.Dimensiones.Height);
            _registroCliente.Salir += delegate { _gestionClientes.RefrescarListaObjetos(); };
        }

        private void MostrarVistaRegistroCliente(object? sender, EventArgs e) {
            InicializarVistaRegistroCliente();

            _registroCliente.Vista.Mostrar();
            _registroCliente = null;
        }

        private void MostrarVistaEdicionCliente(object? sender, EventArgs e) {
            InicializarVistaRegistroCliente();

            _registroCliente.PopularVistaDesdeObjeto(sender as Cliente);
            _registroCliente.Vista.Mostrar();
            _registroCliente = null;
        }
    }
}
