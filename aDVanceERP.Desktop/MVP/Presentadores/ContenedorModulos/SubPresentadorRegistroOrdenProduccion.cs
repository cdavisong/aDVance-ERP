using aDVanceERP.Core.Utiles.Datos;
using aDVanceERP.Modulos.Taller.Modelos;
using aDVanceERP.Modulos.Taller.Presentadores.OrdenProduccion;
using aDVanceERP.Modulos.Taller.Vistas.OrdenProduccion;

namespace aDVanceERP.Desktop.MVP.Presentadores.ContenedorModulos {
    public partial class PresentadorContenedorModulos {
        private PresentadorRegistroOrdenProduccion? _registroOrdenProduccion;

        private void InicializarVistaRegistroOrdenProduccion() {
            _registroOrdenProduccion = new PresentadorRegistroOrdenProduccion(new VistaRegistroOrdenProduccion());
            _registroOrdenProduccion.DatosRegistradosActualizados += async delegate {
                if (_gestionOrdenesProduccion == null)
                    return;

                await _gestionOrdenesProduccion.RefrescarListaObjetos();
            };

            if (Vista.Vistas != null)
                Vista.Vistas?.Registrar("vistaRegistroOrdenProduccion", _registroOrdenProduccion.Vista);
        }

        private void MostrarVistaRegistroOrdenProduccion(object? sender, EventArgs e) {
            if (_registroOrdenProduccion == null)
                return;

            _registroOrdenProduccion.Vista.CargarNombresProductosTerminados(UtilesProducto.ObtenerNombresProductos(0, "ProductoTerminado").Result);
            _registroOrdenProduccion.Vista.CargarNombresMateriasPrimas(UtilesProducto.ObtenerNombresProductos(0, "MateriaPrima").Result);
            _registroOrdenProduccion.Vista.CargarNombresActividadesProduccion([.. UtilesOrdenProduccion.ObtenerNombresActividadesUtilizadas()]);
            _registroOrdenProduccion.Vista.CargarConceptosGastosIndirectos([.. UtilesOrdenProduccion.ObtenerConceptosGastosIndirectosUtilizados()]);
            _registroOrdenProduccion.Vista.Mostrar();
        }

        private void MostrarVistaEdicionOrdenProduccion(object? sender, EventArgs e) {
            if (sender is OrdenProduccion ordenProduccion) {
                if (_registroOrdenProduccion != null) {
                    _registroOrdenProduccion.PopularVistaDesdeObjeto(ordenProduccion);
                    _registroOrdenProduccion.Vista.Mostrar();
                }
            }
        }
    }
}