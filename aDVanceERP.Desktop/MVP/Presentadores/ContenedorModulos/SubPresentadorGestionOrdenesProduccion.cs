using aDVanceERP.Core.Utiles.Datos;
using aDVanceERP.Modulos.Inventario.MVP.Modelos;
using aDVanceERP.Modulos.Inventario.Repositorios;
using aDVanceERP.Modulos.Taller.Modelos;
using aDVanceERP.Modulos.Taller.Presentadores.OrdenProduccion;
using aDVanceERP.Modulos.Taller.Repositorios;
using aDVanceERP.Modulos.Taller.Vistas.OrdenProduccion;

namespace aDVanceERP.Desktop.MVP.Presentadores.ContenedorModulos {
    public partial class PresentadorContenedorModulos {
        private PresentadorGestionOrdenesProduccion? _gestionOrdenesProduccion;

        private void InicializarVistaGestionOrdenesProduccion() {
            _gestionOrdenesProduccion = new PresentadorGestionOrdenesProduccion(new VistaGestionOrdenesProduccion());
            _gestionOrdenesProduccion.OrdenProduccionCerrada += RegistrarMovimientosOrdenProduccionCerrada;
            _gestionOrdenesProduccion.EditarObjeto += MostrarVistaEdicionOrdenProduccion;
            _gestionOrdenesProduccion.Vista.RegistrarDatos += MostrarVistaRegistroOrdenProduccion;

            if (Vista.Vistas != null)
                Vista.Vistas?.Registrar("vistaGestionOrdenesProduccion", _gestionOrdenesProduccion.Vista);
        }

        private async void MostrarVistaGestionOrdenesProduccion(object? sender, EventArgs e) {
            if (_gestionOrdenesProduccion?.Vista == null)
                return;

            _gestionOrdenesProduccion.Vista.CargarCriteriosBusqueda(UtilesBusquedaOrdenProduccion.CriterioBusquedaOrdenProduccion);
            _gestionOrdenesProduccion.Vista.Restaurar();
            _gestionOrdenesProduccion.Vista.Mostrar();

            await _gestionOrdenesProduccion.RefrescarListaObjetos()!;
        }

        private void RegistrarMovimientosOrdenProduccionCerrada(object? sender, OrdenProduccion e) {
            // Movimiento de materiales utilizados en la orden de producción
            using (var datosObjeto = new RepoOrdenMateriaPrima()) {
                var materiasPrimas = datosObjeto.Obtener(CriterioBusquedaOrdenMateriaPrima.OrdenProduccion, e.Id.ToString());

                if (materiasPrimas != null && materiasPrimas.Count() > 0) {
                    using (var datosMovimiento = new DatosMovimiento()) {
                        foreach (var materiaPrima in materiasPrimas) {
                            datosMovimiento.Adicionar(new Movimiento(
                                0,
                                materiaPrima.IdProducto,
                                materiaPrima.IdAlmacen,
                                0,
                                materiaPrima.FechaRegistro,
                                materiaPrima.Cantidad,
                                UtilesMovimiento.ObtenerIdTipoMovimiento("Gasto material")
                            ));
                        }
                    }
                }
            }

            // Movimiento generado por la orden de producción
            using (var datosMovimiento = new DatosMovimiento()) {
                datosMovimiento.Adicionar(new Movimiento(
                    0,
                    e.IdProducto,
                    0,
                    e.IdAlmacen,
                    e.FechaCierre ?? DateTime.Now,
                    e.Cantidad,
                    UtilesMovimiento.ObtenerIdTipoMovimiento("Producción")
                ));
            }
        }
    }
}