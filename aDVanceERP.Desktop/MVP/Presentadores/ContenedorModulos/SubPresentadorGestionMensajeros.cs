using aDVanceERP.Modulos.Contactos.MVP.Modelos;
using aDVanceERP.Modulos.Contactos.MVP.Presentadores;
using aDVanceERP.Modulos.Contactos.MVP.Vistas.Mensajero;

namespace aDVanceERP.Desktop.MVP.Presentadores.ContenedorModulos;

public partial class PresentadorContenedorModulos {
    private PresentadorGestionMensajeros? _gestionMensajeros;

    private async void InicializarVistaGestionMensajeros() {
        _gestionMensajeros = new PresentadorGestionMensajeros(new VistaGestionMensajeros());
        _gestionMensajeros.EditarEntidad += MostrarVistaEdicionMensajero;
        _gestionMensajeros.Vista.RegistrarEntidad += MostrarVistaRegistroMensajero;

        if (Vista.Vistas != null)
            await Task.Run(() => Vista.Vistas?.Registrar("vistaGestionMensajeros", _gestionMensajeros.Vista));
    }

    private  void MostrarVistaGestionMensajeros(object? sender, EventArgs e) {
        if (_gestionMensajeros?.Vista == null)
            return;

        _gestionMensajeros.Vista.CargarFiltrosBusqueda(UtilesBusquedaMensajero.FiltroBusquedaMensajero);
        _gestionMensajeros.Vista.Restaurar();
        _gestionMensajeros.Vista.Mostrar();

        _gestionMensajeros.ActualizarResultadosBusqueda();
    }
}