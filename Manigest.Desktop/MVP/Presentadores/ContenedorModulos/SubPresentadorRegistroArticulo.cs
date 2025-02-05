using Manigest.Core.Utiles;
using Manigest.Modulos.Inventario.MVP.Modelos;
using Manigest.Modulos.Inventario.MVP.Presentadores;
using Manigest.Modulos.Inventario.MVP.Vistas.Articulo;
using Manigest.Core.Utiles.Datos;

namespace Manigest.Desktop.MVP.Presentadores.ContenedorModulos {
    public partial class PresentadorContenedorModulos {
        private PresentadorRegistroArticulo _registroArticulo;

        private void InicializarVistaRegistroArticulo() {
            _registroArticulo = new PresentadorRegistroArticulo(new VistaRegistroArticulo());
            _registroArticulo.Vista.CargarRazonesSocialesProveedores(UtilesProveedor.ObtenerRazonesSocialesProveedores());
            _registroArticulo.Vista.Coordenadas = new Point(Vista.Dimensiones.Width - _registroArticulo.Vista.Dimensiones.Width - 20, VariablesGlobales.AlturaBarraTituloPredeterminada);
            _registroArticulo.Vista.Dimensiones = new Size(_registroArticulo.Vista.Dimensiones.Width, Vista.Dimensiones.Height);
            _registroArticulo.Salir += delegate { _gestionArticulos.RefrescarListaObjetos(); };
        }

        private void MostrarVistaRegistroArticulo(object? sender, EventArgs e) {
            InicializarVistaRegistroArticulo();

            _registroArticulo.Vista.Mostrar();
            _registroArticulo = null;
        }

        private void MostrarVistaEdicionArticulo(object? sender, EventArgs e) {
            InicializarVistaRegistroArticulo();

            _registroArticulo.PopularVistaDesdeObjeto(sender as Articulo);
            _registroArticulo.Vista.Mostrar();
            _registroArticulo = null;
        }
    }
}
