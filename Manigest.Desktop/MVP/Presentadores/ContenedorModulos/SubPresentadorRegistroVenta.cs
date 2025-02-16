using Manigest.Core.Utiles;
using Manigest.Core.Utiles.Datos;
using Manigest.Modulos.Ventas.MVP.Modelos;
using Manigest.Modulos.Ventas.MVP.Presentadores;
using Manigest.Modulos.Ventas.MVP.Vistas.Venta;

namespace Manigest.Desktop.MVP.Presentadores.ContenedorModulos {
    public partial class PresentadorContenedorModulos {
        private PresentadorRegistroVenta _registroVentaArticulo;

        private void InicializarVistaRegistroVentaArticulo() {
            _registroVentaArticulo = new PresentadorRegistroVenta(new VistaRegistroVenta());
            _registroVentaArticulo.Vista.CargarRazonesSocialesClientes(UtilesCliente.ObtenerRazonesSocialesClientes());
            _registroVentaArticulo.Vista.CargarNombresAlmacenes(UtilesAlmacen.ObtenerNombresAlmacenes(true));
            _registroVentaArticulo.Vista.Coordenadas = new Point(Vista.Dimensiones.Width - _registroVentaArticulo.Vista.Dimensiones.Width - 20, VariablesGlobales.AlturaBarraTituloPredeterminada);
            _registroVentaArticulo.Vista.Dimensiones = new Size(_registroVentaArticulo.Vista.Dimensiones.Width, Vista.Dimensiones.Height);
            _registroVentaArticulo.Salir += delegate { _gestionVentasArticulos.RefrescarListaObjetos(); };
        }

        private void MostrarVistaRegistroVentaArticulo(object? sender, EventArgs e) {
            InicializarVistaRegistroVentaArticulo();

            _registroVentaArticulo.Vista.Mostrar();
            _registroVentaArticulo = null;
        }

        private void MostrarVistaEdicionVentaArticulo(object? sender, EventArgs e) {
            InicializarVistaRegistroVentaArticulo();

            _registroVentaArticulo.PopularVistaDesdeObjeto(sender as Venta);
            _registroVentaArticulo.Vista.Mostrar();
            _registroVentaArticulo = null;
        }
    }
}
