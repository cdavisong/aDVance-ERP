using aDVanceERP.Core.Utiles.Datos;
using aDVanceERP.Modulos.Inventario.MVP.Modelos;
using aDVanceERP.Modulos.Inventario.MVP.Presentadores;
using aDVanceERP.Modulos.Inventario.MVP.Vistas.Articulo;

namespace aDVanceERP.Desktop.MVP.Presentadores.ContenedorModulos {
    public partial class PresentadorContenedorModulos {
        private PresentadorGestionArticulos _gestionArticulos;

        private void InicializarVistaGestionArticulos() {
            _gestionArticulos = new PresentadorGestionArticulos(new VistaGestionArticulos());
            _gestionArticulos.MovimientoPositivoStock += MostrarVistaRegistroMovimiento;
            _gestionArticulos.MovimientoNegativoStock += MostrarVistaRegistroMovimiento;
            _gestionArticulos.EditarObjeto += MostrarVistaEdicionArticulo;
            _gestionArticulos.Vista.RegistrarDatos += MostrarVistaRegistroArticulo;
            _gestionArticulos.Vista.CargarNombresAlmacenes(UtilesAlmacen.ObtenerNombresAlmacenes());
            _gestionArticulos.Vista.CargarCriteriosBusqueda(UtilesBusquedaArticulo.CriterioBusquedaArticulo);

            Vista.Vistas.Registrar("vistaGestionArticulos", _gestionArticulos.Vista);
        }

        private void MostrarVistaGestionArticulos(object? sender, EventArgs e) {
            _gestionArticulos.Vista.Mostrar();
            _gestionArticulos.Vista.Restaurar();
            _gestionArticulos.RefrescarListaObjetos();
        }
    }
}
