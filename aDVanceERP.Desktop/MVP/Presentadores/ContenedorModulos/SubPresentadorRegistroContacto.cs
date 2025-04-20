using aDVanceERP.Desktop.Utiles;
using aDVanceERP.Modulos.Contactos.MVP.Modelos;
using aDVanceERP.Modulos.Contactos.MVP.Presentadores;
using aDVanceERP.Modulos.Contactos.MVP.Vistas.Contacto;

namespace aDVanceERP.Desktop.MVP.Presentadores.ContenedorModulos; 

public partial class PresentadorContenedorModulos {
    private PresentadorRegistroContacto? _registroContacto;

    private async Task InicializarVistaRegistroContacto() {
        _registroContacto = new PresentadorRegistroContacto(new VistaRegistroContacto());
        _registroContacto.Vista.EstablecerCoordenadasVistaRegistro(Vista.Dimensiones.Width);
        _registroContacto.Vista.EstablecerDimensionesVistaRegistro(Vista.Dimensiones.Height);
        _registroContacto.Salir += async (sender, e) => {
            await _gestionContactos.RefrescarListaObjetos();
        };
    }

    private async void MostrarVistaRegistroContacto(object? sender, EventArgs e) {
        await InicializarVistaRegistroContacto();

        if (_registroContacto == null) 
            return;

        MostrarVistaPanelTransparente(_registroContacto.Vista);

        _registroContacto.Vista.Mostrar();
        _registroContacto.Dispose();
    }

    private async void MostrarVistaEdicionContacto(object? sender, EventArgs e) {
        await InicializarVistaRegistroContacto();

        if (sender is Contacto contacto) {
            if (_registroContacto != null) {
                MostrarVistaPanelTransparente(_registroContacto.Vista);

                _registroContacto.PopularVistaDesdeObjeto(contacto);
                _registroContacto.Vista.Mostrar();
            }
        }

        _registroContacto?.Dispose();
    }
}