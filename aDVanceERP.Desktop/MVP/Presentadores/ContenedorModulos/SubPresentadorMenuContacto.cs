using aDVanceERP.Modulos.Contactos.MVP.Presentadores;
using aDVanceERP.Modulos.Contactos.MVP.Vistas.Menu;

namespace aDVanceERP.Desktop.MVP.Presentadores.ContenedorModulos; 

public partial class PresentadorContenedorModulos {
    private PresentadorMenuContacto _menuContacto;

    private void InicializarVistaMenuContacto() {
        _menuContacto = new PresentadorMenuContacto(new VistaMenuContacto());
        _menuContacto.Vista.VerProveedores += MostrarVistaGestionProveedores;
        _menuContacto.Vista.VerMensajeros += MostrarVistaGestionMensajeros;
        _menuContacto.Vista.VerClientes += MostrarVistaGestionClientes;
        _menuContacto.Vista.VerContactos += MostrarVistaGestionContactos;
        _menuContacto.Vista.CambioMenu += delegate { Vista.Vistas?.Ocultar(true); };

        VistaPrincipal.Menus.Registrar("vistaMenuContacto", _menuContacto.Vista);
    }

    private void MostrarVistaMenuContacto(object? sender, EventArgs e) {
        _menuContacto.Vista.Restaurar();
        _menuContacto.Vista.Mostrar();
        _menuContacto.Vista.MostrarCaracteristicaInicial();
    }
}