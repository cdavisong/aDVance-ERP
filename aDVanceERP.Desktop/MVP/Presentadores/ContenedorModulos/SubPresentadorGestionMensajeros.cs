using aDVanceERP.Modulos.Contactos.MVP.Modelos;
using aDVanceERP.Modulos.Contactos.MVP.Presentadores;
using aDVanceERP.Modulos.Contactos.MVP.Vistas.Mensajero;

namespace aDVanceERP.Desktop.MVP.Presentadores.ContenedorModulos;

public partial class PresentadorContenedorModulos {
    private PresentadorGestionMensajeros? _gestionMensajeros;

    private async void InicializarVistaGestionMensajeros() {
        _gestionMensajeros = new PresentadorGestionMensajeros(new VistaGestionMensajeros());
        _gestionMensajeros.EditarEntidad += MostrarVistaEdicionMensajero;
        _gestionMensajeros.Vista.RegistrarDatos += MostrarVistaRegistroMensajero;

        if (Vista.Vistas != null)
            await Task.Run(() => Vista.Vistas?.Registrar("vistaGestionMensajeros", _gestionMensajeros.Vista));
    }

    private async void MostrarVistaGestionMensajeros(object? sender, EventArgs e) {
        if (_gestionMensajeros?.Vista == null)
            return;

        _gestionMensajeros.Vista.CargarCriteriosBusqueda(UtilesBusquedaMensajero.CriterioBusquedaMensajero);
        _gestionMensajeros.Vista.Restaurar();
        _gestionMensajeros.Vista.Mostrar();

        await _gestionMensajeros.PopularTuplasDatosEntidades();
    }
}