using aDVanceERP.Modulos.Inventario.MVP.Modelos;
using aDVanceERP.Modulos.Inventario.MVP.Presentadores;
using aDVanceERP.Modulos.Inventario.MVP.Vistas.Almacen;

namespace aDVanceERP.Desktop.MVP.Presentadores.ContenedorModulos {
    public partial class PresentadorContenedorModulos {
        private PresentadorGestionAlmacenes _gestionAlmacenes;

        private async void InicializarVistaGestionAlmacenes() {
            _gestionAlmacenes = new PresentadorGestionAlmacenes(new VistaGestionAlmacenes());
            _gestionAlmacenes.EditarObjeto += MostrarVistaEdicionAlmacen;
            _gestionAlmacenes.Vista.RegistrarDatos += MostrarVistaRegistroAlmacen;
            
            if (Vista.Vistas != null)
                await Task.Run(() => Vista.Vistas?.Registrar("vistaGestionAlmacenes", _gestionAlmacenes.Vista));
        }

        private async void MostrarVistaGestionAlmacenes(object? sender, EventArgs e) {
            if ((_gestionAlmacenes?.Vista) == null)
                return;

            _gestionAlmacenes.Vista.CargarCriteriosBusqueda(UtilesBusquedaAlmacen.CriterioBusquedaAlmacen);
            _gestionAlmacenes.Vista.Restaurar();
            _gestionAlmacenes.Vista.Mostrar();

            await _gestionAlmacenes.RefrescarListaObjetos();
        }
    }
}
