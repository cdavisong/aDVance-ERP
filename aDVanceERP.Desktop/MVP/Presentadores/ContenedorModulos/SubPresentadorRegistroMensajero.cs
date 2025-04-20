using aDVanceERP.Core.Utiles.Datos;
using aDVanceERP.Desktop.Utiles;
using aDVanceERP.Modulos.Contactos.MVP.Modelos;
using aDVanceERP.Modulos.Contactos.MVP.Presentadores;
using aDVanceERP.Modulos.Contactos.MVP.Vistas.Mensajero;

namespace aDVanceERP.Desktop.MVP.Presentadores.ContenedorModulos;

public partial class PresentadorContenedorModulos {
    private PresentadorRegistroMensajero? _registroMensajero;

    private Task InicializarVistaRegistroMensajero() {
        _registroMensajero = new PresentadorRegistroMensajero(new VistaRegistroMensajero());
        _registroMensajero.Vista.CargarNombresContactos(UtilesContacto.ObtenerNombresContactos());
        _registroMensajero.Vista.EstablecerCoordenadasVistaRegistro(Vista.Dimensiones.Width);
        _registroMensajero.Vista.EstablecerDimensionesVistaRegistro(Vista.Dimensiones.Height);
        _registroMensajero.Salir += async delegate {
            if (_gestionMensajeros != null) await _gestionMensajeros.RefrescarListaObjetos();
        };

        return Task.CompletedTask;
    }

    private async void MostrarVistaRegistroMensajero(object? sender, EventArgs e) {
        await InicializarVistaRegistroMensajero();

        if (_registroMensajero == null) 
            return;

        MostrarVistaPanelTransparente(_registroMensajero.Vista);

        _registroMensajero.Vista.Mostrar();
        _registroMensajero.Dispose();
    }

    private async void MostrarVistaEdicionMensajero(object? sender, EventArgs e) {
        await InicializarVistaRegistroMensajero();

        if (sender is Mensajero mensajero) {
            if (_registroMensajero != null) {
                MostrarVistaPanelTransparente(_registroMensajero.Vista);

                _registroMensajero.PopularVistaDesdeObjeto(mensajero);
                _registroMensajero.Vista.Mostrar();
            }
        }

        _registroMensajero?.Dispose();
    }
}