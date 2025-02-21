using Manigest.Modulos.Inventario.MVP.Modelos;
using Manigest.Modulos.Inventario.MVP.Presentadores;
using Manigest.Modulos.Inventario.MVP.Vistas.Almacen;

namespace Manigest.Desktop.MVP.Presentadores.ContenedorModulos {
    public partial class PresentadorContenedorModulos {
        private PresentadorGestionAlmacenes _gestionAlmacenes;

        private void InicializarVistaGestionAlmacenes() {
            _gestionAlmacenes = new PresentadorGestionAlmacenes(new VistaGestionAlmacenes());
            _gestionAlmacenes.EditarObjeto += MostrarVistaEdicionAlmacen;
            _gestionAlmacenes.Vista.RegistrarDatos += MostrarVistaRegistroAlmacen;
            _gestionAlmacenes.Vista.CargarCriteriosBusqueda(UtilesBusquedaAlmacen.CriterioBusquedaAlmacen);

            Vista.Vistas.Registrar("vistaGestionAlmacenes", _gestionAlmacenes.Vista);
        }

        private void MostrarVistaGestionAlmacenes(object? sender, EventArgs e) {
            _gestionAlmacenes.Vista.Mostrar();
            _gestionAlmacenes.Vista.Restaurar();
            _gestionAlmacenes.RefrescarListaObjetos();
        }
    }
}
