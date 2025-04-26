using aDVanceERP.Desktop.Utiles;
using aDVanceERP.Modulos.Contactos.MVP.Modelos;
using aDVanceERP.Modulos.Contactos.MVP.Presentadores;
using aDVanceERP.Modulos.Contactos.MVP.Vistas.Cliente;

namespace aDVanceERP.Desktop.MVP.Presentadores.ContenedorModulos; 

public partial class PresentadorContenedorModulos {
    private PresentadorRegistroCliente? _registroCliente;

    private void InicializarVistaRegistroCliente() {
        _registroCliente = new PresentadorRegistroCliente(new VistaRegistroCliente());
        _registroCliente.Vista.EstablecerCoordenadasVistaRegistro(Vista.Dimensiones.Width);
        _registroCliente.Vista.EstablecerDimensionesVistaRegistro(Vista.Dimensiones.Height);
        _registroCliente.DatosRegistradosActualizados += async delegate {
            if (_gestionClientes != null)
                await _gestionClientes.RefrescarListaObjetos();
        };
    }

    private void MostrarVistaRegistroCliente(object? sender, EventArgs e) {
        InicializarVistaRegistroCliente();

        if (_registroCliente == null) 
            return;

        MostrarVistaPanelTransparente(_registroCliente.Vista);

        _registroCliente.Vista.Mostrar();
        _registroCliente.Dispose();
    }

    private void MostrarVistaEdicionCliente(object? sender, EventArgs e) {
        InicializarVistaRegistroCliente();

        if (sender is Cliente cliente) {
            if (_registroCliente != null) {
                MostrarVistaPanelTransparente(_registroCliente.Vista);

                _registroCliente.PopularVistaDesdeObjeto(cliente);
                _registroCliente.Vista.Mostrar();
            }
        }

        _registroCliente?.Dispose();
    }
}