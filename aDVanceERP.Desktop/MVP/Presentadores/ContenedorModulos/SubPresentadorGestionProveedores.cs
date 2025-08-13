using aDVanceERP.Modulos.Contactos.MVP.Modelos;
using aDVanceERP.Modulos.Contactos.MVP.Presentadores;
using aDVanceERP.Modulos.Contactos.MVP.Vistas.Proveedor;

namespace aDVanceERP.Desktop.MVP.Presentadores.ContenedorModulos; 

public partial class PresentadorContenedorModulos {
    private PresentadorGestionProveedores? _gestionProveedores;

    private async void InicializarVistaGestionProveedores() {
        _gestionProveedores = new PresentadorGestionProveedores(new VistaGestionProveedores());
        _gestionProveedores.EditarObjeto += MostrarVistaEdicionProveedor;
        _gestionProveedores.Vista.RegistrarDatos += MostrarVistaRegistroProveedor;

        if (Vista.Vistas != null)
            await Task.Run(() => Vista.Vistas?.Registrar("vistaGestionProveedores", _gestionProveedores.Vista));
    }

    private void MostrarVistaGestionProveedores(object? sender, EventArgs e) {
        if (_gestionProveedores == null)
            return;

        _gestionProveedores.Vista.CargarCriteriosBusqueda(UtilesBusquedaProveedor.FiltroBusquedaProveedor);
        _gestionProveedores.Vista.Restaurar();
        _gestionProveedores.Vista.Mostrar();

        _gestionProveedores.RefrescarListaObjetos();
    }
}