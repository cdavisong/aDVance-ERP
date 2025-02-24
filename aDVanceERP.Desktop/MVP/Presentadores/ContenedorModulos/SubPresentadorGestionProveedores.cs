using aDVanceERP.Modulos.Contactos.MVP.Modelos;
using aDVanceERP.Modulos.Contactos.MVP.Presentadores;
using aDVanceERP.Modulos.Contactos.MVP.Vistas.Proveedor;

namespace aDVanceERP.Desktop.MVP.Presentadores.ContenedorModulos {
    public partial class PresentadorContenedorModulos {
        private PresentadorGestionProveedores _gestionProveedores;

        private void InicializarVistaGestionProveedores() {
            _gestionProveedores = new PresentadorGestionProveedores(new VistaGestionProveedores());
            _gestionProveedores.EditarObjeto += MostrarVistaEdicionProveedor;
            _gestionProveedores.Vista.RegistrarDatos += MostrarVistaRegistroProveedor;
            _gestionProveedores.Vista.CargarCriteriosBusqueda(UtilesBusquedaProveedor.CriterioBusquedaProveedor);

            Vista.Vistas.Registrar("vistaGestionProveedores", _gestionProveedores.Vista);
        }

        private void MostrarVistaGestionProveedores(object? sender, EventArgs e) {
            _gestionProveedores.Vista.Mostrar();
            _gestionProveedores.Vista.Restaurar();
            _gestionProveedores.RefrescarListaObjetos();
        }
    }
}
