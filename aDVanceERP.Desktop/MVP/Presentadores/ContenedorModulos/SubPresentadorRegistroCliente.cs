using aDVanceERP.Core.Utiles.Datos;
using aDVanceERP.Desktop.Utiles;
using aDVanceERP.Modulos.Contactos.MVP.Modelos;
using aDVanceERP.Modulos.Contactos.MVP.Presentadores;
using aDVanceERP.Modulos.Contactos.MVP.Vistas.Cliente;

namespace aDVanceERP.Desktop.MVP.Presentadores.ContenedorModulos {
    public partial class PresentadorContenedorModulos {
        private PresentadorRegistroCliente _registroCliente;

        private async Task InicializarVistaRegistroCliente() {
            _registroCliente = new PresentadorRegistroCliente(new VistaRegistroCliente());
            _registroCliente.Vista.CargarNombresContactos(UtilesContacto.ObtenerNombresContactos());
            _registroCliente.Vista.EstablecerCoordenadasVistaRegistro(Vista.Dimensiones.Width);
            _registroCliente.Vista.EstablecerDimensionesVistaRegistro(Vista.Dimensiones.Height);
            _registroCliente.Salir += async (sender, e) => {
                if (_gestionClientes != null) {
                    await _gestionClientes.RefrescarListaObjetos();
                }
            };
        }

        private async void MostrarVistaRegistroCliente(object? sender, EventArgs e) {
            await InicializarVistaRegistroCliente();

            if (_registroCliente != null) {
                _registroCliente.Vista.Mostrar();
            }

            _registroCliente?.Dispose();
        }

        private async void MostrarVistaEdicionCliente(object? sender, EventArgs e) {
            await InicializarVistaRegistroCliente();

            if (_registroCliente != null && sender is Cliente cliente) {
                _registroCliente.PopularVistaDesdeObjeto(cliente);
                _registroCliente.Vista.Mostrar();
            }

            _registroCliente?.Dispose();
        }
    }
}
