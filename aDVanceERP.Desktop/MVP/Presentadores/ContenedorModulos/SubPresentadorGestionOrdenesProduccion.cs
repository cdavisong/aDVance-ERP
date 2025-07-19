using aDVanceERP.Core.Utiles.Datos;
using aDVanceERP.Modulos.CompraVenta.MVP.Modelos;
using aDVanceERP.Modulos.Inventario.MVP.Modelos.Repositorios;
using aDVanceERP.Modulos.Inventario.MVP.Modelos;
using aDVanceERP.Modulos.Taller.Modelos;
using aDVanceERP.Modulos.Taller.Presentadores.OrdenProduccion;
using aDVanceERP.Modulos.Taller.Vistas.OrdenProduccion;

namespace aDVanceERP.Desktop.MVP.Presentadores.ContenedorModulos {
    public partial class PresentadorContenedorModulos {
        private PresentadorGestionOrdenesProduccion? _gestionOrdenesProduccion;

        private void InicializarVistaGestionOrdenesProduccion() {
            _gestionOrdenesProduccion = new PresentadorGestionOrdenesProduccion(new VistaGestionOrdenesProduccion());
            _gestionOrdenesProduccion.EditarObjeto += MostrarVistaEdicionOrdenProduccion;
            _gestionOrdenesProduccion.Vista.RegistrarDatos += MostrarVistaRegistroOrdenProduccion;

            if (Vista.Vistas != null)
                Vista.Vistas?.Registrar("vistaGestionOrdenesProduccion", _gestionOrdenesProduccion.Vista);
        }

        private async void MostrarVistaGestionOrdenesProduccion(object? sender, EventArgs e) {
            if (_gestionOrdenesProduccion?.Vista == null)
                return;

            _gestionOrdenesProduccion.Vista.CargarNombresAlmacenes(UtilesAlmacen.ObtenerNombresAlmacenesProductosTerminados());
            _gestionOrdenesProduccion.Vista.CargarCriteriosBusqueda(UtilesBusquedaOrdenProduccion.CriterioBusquedaOrdenProduccion);
            _gestionOrdenesProduccion.Vista.Restaurar();
            _gestionOrdenesProduccion.Vista.Mostrar();

            await _gestionOrdenesProduccion.RefrescarListaObjetos()!;
        }
    }
}