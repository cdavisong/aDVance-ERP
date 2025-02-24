using aDVanceERP.Core.Utiles;
using aDVanceERP.Core.Utiles.Datos;
using aDVanceERP.Modulos.Contactos.MVP.Modelos;
using aDVanceERP.Modulos.Contactos.MVP.Presentadores;
using aDVanceERP.Modulos.Contactos.MVP.Vistas.Proveedor;

namespace aDVanceERP.Desktop.MVP.Presentadores.ContenedorModulos {
    public partial class PresentadorContenedorModulos {
        private PresentadorRegistroProveedor _registroProveedor;

        private void InicializarVistaRegistroProveedor() {
            _registroProveedor = new PresentadorRegistroProveedor(new VistaRegistroProveedor());
            _registroProveedor.Vista.CargarNombresContactos(UtilesContacto.ObtenerNombresContactos());
            _registroProveedor.Vista.Coordenadas = new Point(Vista.Dimensiones.Width - _registroProveedor.Vista.Dimensiones.Width - 20, VariablesGlobales.AlturaBarraTituloPredeterminada);
            _registroProveedor.Vista.Dimensiones = new Size(_registroProveedor.Vista.Dimensiones.Width, Vista.Dimensiones.Height);
            _registroProveedor.Salir += delegate { _gestionProveedores.RefrescarListaObjetos(); };
        }

        private void MostrarVistaRegistroProveedor(object? sender, EventArgs e) {
            InicializarVistaRegistroProveedor();

            _registroProveedor.Vista.Mostrar();
            _registroProveedor = null;
        }

        private void MostrarVistaEdicionProveedor(object? sender, EventArgs e) {
            InicializarVistaRegistroProveedor();

            _registroProveedor.PopularVistaDesdeObjeto(sender as Proveedor);
            _registroProveedor.Vista.Mostrar();
            _registroProveedor = null;
        }
    }
}
