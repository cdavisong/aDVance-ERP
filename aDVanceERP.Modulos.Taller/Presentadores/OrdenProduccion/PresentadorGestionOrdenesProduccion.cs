
using aDVanceERP.Core.Mensajes.Utiles;
using aDVanceERP.Core.MVP.Presentadores;
using aDVanceERP.Core.Utiles.Datos;
using aDVanceERP.Modulos.Taller.Interfaces;
using aDVanceERP.Modulos.Taller.Modelos;
using aDVanceERP.Modulos.Taller.Repositorios;
using aDVanceERP.Modulos.Taller.Vistas.OrdenProduccion;

using System.Globalization;

namespace aDVanceERP.Modulos.Taller.Presentadores.OrdenProduccion {
    public class PresentadorGestionOrdenesProduccion : PresentadorGestionBase<PresentadortuplaOrdenProduccion, IVistaGestionOrdenesProduccion, IVistaTuplaOrdenProduccion, Modelos.OrdenProduccion, RepoOrdenProduccion, FiltroBusquedaOrdenProduccion> {
        public PresentadorGestionOrdenesProduccion(IVistaGestionOrdenesProduccion vista) : base(vista) {
            vista.CerrarOrdenProduccionSeleccionada += OnCerrarOrdenProduccionSeleccionada;
            vista.EditarDatos += delegate {
                Vista.HabilitarBtnCierreOrdenProduccion = false;
            };
        }

        public event EventHandler<Modelos.OrdenProduccion> OrdenProduccionCerrada;

        protected override PresentadortuplaOrdenProduccion ObtenerValoresTupla(Modelos.OrdenProduccion objeto) {
            var presentadorTupla = new PresentadortuplaOrdenProduccion(new VistaTuplaOrdenProduccion(), objeto);

            presentadorTupla.Vista.Id = objeto.Id.ToString();
            presentadorTupla.Vista.NumeroOrden = objeto.NumeroOrden;
            presentadorTupla.Vista.FechaApertura = objeto.FechaApertura.ToString("yyyy-MM-dd");
            presentadorTupla.Vista.NombreProducto = UtilesProducto.ObtenerNombreProducto(objeto.IdProducto).Result ?? string.Empty;
            presentadorTupla.Vista.TotalUnidadesProducidas = objeto.Cantidad.ToString(CultureInfo.InvariantCulture);
            presentadorTupla.Vista.CostoTotal = objeto.CostoTotal.ToString("N2", CultureInfo.InvariantCulture);
            presentadorTupla.Vista.PrecioUnitario = objeto.PrecioUnitario.ToString("N2", CultureInfo.InvariantCulture);
            presentadorTupla.Vista.Estado = (int) objeto.Estado;
            presentadorTupla.Vista.FechaCierre = objeto.FechaCierre.HasValue ? !objeto.FechaCierre.Equals(DateTime.MinValue) ? objeto.FechaCierre.Value.ToString("yyyy-MM-dd") : "-" : "-";
            presentadorTupla.ObjetoSeleccionado += CambiarVisibilidadBtnCierreOrdenProduccion;
            presentadorTupla.ObjetoDeseleccionado += CambiarVisibilidadBtnCierreOrdenProduccion;

            return presentadorTupla;
        }

        private void OnCerrarOrdenProduccionSeleccionada(object? sender, EventArgs e) {
            if (_tuplasObjetos.Any(t => t.TuplaSeleccionada)) {
                foreach (var tupla in _tuplasObjetos) {
                    if (tupla.TuplaSeleccionada) {
                        tupla.Objeto.Estado = EstadoOrdenProduccion.Cerrada;
                        tupla.Objeto.FechaCierre = DateTime.Now;

                        // Editar la orden de producción
                        DatosObjeto.Editar(tupla.Objeto);

                        // Actualizar el costo unitario de producción en el producto correspondiente
                        UtilesProducto.ActualizarCostoProduccionUnitario(tupla.Objeto.IdProducto, tupla.Objeto.PrecioUnitario);

                        // Disminuir el cantidad de materiales utilizados en la orden de producción
                        using (var datosObjeto = new RepoOrdenMateriaPrima()) {
                            var materiasPrimas = datosObjeto.Buscar(FiltroBusquedaOrdenMateriaPrima.OrdenProduccion, tupla.Objeto.Id.ToString()).resultados;

                            if (materiasPrimas != null) {
                                foreach (var materiaPrima in materiasPrimas) {
                                    UtilesMovimiento.ModificarInventario(
                                        materiaPrima.IdProducto,
                                        materiaPrima.IdAlmacen,
                                        0,
                                        materiaPrima.Cantidad,
                                        UtilesProducto.ObtenerCostoUnitario(materiaPrima.IdProducto).Result
                                    );
                                }
                            }
                        }

                        // Aumentar el cantidad del producto terminado en el almacén seleccionado
                        UtilesMovimiento.ModificarInventario(
                            tupla.Objeto.IdProducto,
                            0,
                            tupla.Objeto.IdAlmacen,
                            tupla.Objeto.Cantidad,
                            UtilesProducto.ObtenerCostoUnitario(tupla.Objeto.IdProducto).Result
                        );

                        // Invocar evento de cierre para la orden de produccion y registrar los movimientos correspondientes
                        OrdenProduccionCerrada?.Invoke(this, tupla.Objeto);

                        break;
                    }
                }

                RefrescarListaObjetos();
            } else {
                CentroNotificaciones.Mostrar("Debe seleccionar una orden de producción para cerrar.", Core.Mensajes.MVP.Modelos.TipoNotificacion.Advertencia);
            }
        }

        public override void RefrescarListaObjetos() {
            // Cambiar la visibilidad del botón de cierre de orden de producción al refrescar la lista de objetos.
            Vista.HabilitarBtnCierreOrdenProduccion = false;

            base.RefrescarListaObjetos();
        }

        private void CambiarVisibilidadBtnCierreOrdenProduccion(object? sender, EventArgs e) {
            if (_tuplasObjetos.Any(t => t.TuplaSeleccionada)) {
                foreach (var tupla in _tuplasObjetos) {
                    if (tupla.TuplaSeleccionada) {
                        var ordenProduccion = tupla.Objeto;

                        if (ordenProduccion != null && ordenProduccion.Estado != EstadoOrdenProduccion.Cerrada) {
                            Vista.HabilitarBtnCierreOrdenProduccion = true;
                            return;
                        }
                    }
                }
            } else {
                Vista.HabilitarBtnCierreOrdenProduccion = false;
            }
        }
    }
}