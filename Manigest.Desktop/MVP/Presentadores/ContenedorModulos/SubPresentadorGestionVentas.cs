using Manigest.Modulos.Ventas.MVP.Presentadores;
using Manigest.Modulos.Ventas.MVP.Vistas.Venta;

namespace Manigest.Desktop.MVP.Presentadores.ContenedorModulos {
    public partial class PresentadorContenedorModulos {
        private PresentadorGestionVentas _gestionVentasArticulos;

        private void InicializarVistaGestionVentasArticulos() {
            _gestionVentasArticulos = new PresentadorGestionVentas(new VistaGestionVentas());
            _gestionVentasArticulos.EditarObjeto += MostrarVistaEdicionVentaArticulo;
            _gestionVentasArticulos.Vista.RegistrarDatos += MostrarVistaRegistroVentaArticulo;

            Vista.Vistas.Registrar("vistaGestionVentas", _gestionVentasArticulos.Vista);
        }

        private void MostrarVistaGestionVentasArticulos(object? sender, EventArgs e) {
            _gestionVentasArticulos.Vista.Mostrar();
            _gestionVentasArticulos.Vista.Restaurar();
            _gestionVentasArticulos.RefrescarListaObjetos();
        }
    }
}
