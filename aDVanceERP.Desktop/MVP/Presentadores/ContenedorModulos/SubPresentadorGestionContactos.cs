using aDVanceERP.Modulos.Contactos.MVP.Modelos;
using aDVanceERP.Modulos.Contactos.MVP.Presentadores;
using aDVanceERP.Modulos.Contactos.MVP.Vistas.Contacto;

namespace aDVanceERP.Desktop.MVP.Presentadores.ContenedorModulos; 

public partial class PresentadorContenedorModulos {
    private PresentadorGestionContactos? _gestionContactos;

    private async void InicializarVistaGestionContactos() {
        _gestionContactos = new PresentadorGestionContactos(new VistaGestionContactos());
        _gestionContactos.EditarObjeto += MostrarVistaEdicionContacto;
        _gestionContactos.Vista.RegistrarDatos += MostrarVistaRegistroContacto;

        if (Vista.Vistas != null)
            await Task.Run(() => Vista.Vistas?.Registrar("vistaGestionContactos", _gestionContactos.Vista));
    }

    private async void MostrarVistaGestionContactos(object? sender, EventArgs e) {
        if (_gestionContactos?.Vista == null)
            return;

        _gestionContactos.Vista.CargarCriteriosBusqueda(UtilesBusquedaContacto.CriterioBusquedaContacto);
        _gestionContactos.Vista.Restaurar();
        _gestionContactos.Vista.Mostrar();

        await _gestionContactos.RefrescarListaObjetos();
    }
}