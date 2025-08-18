using aDVanceERP.Core.MVP.Presentadores;
using aDVanceERP.Core.Utiles.Datos;
using aDVanceERP.Modulos.Taller.Interfaces;
using aDVanceERP.Modulos.Taller.Modelos;
using aDVanceERP.Modulos.Taller.Repositorios;
using System.Globalization;

namespace aDVanceERP.Modulos.Taller.Presentadores.OrdenProduccion {
    public class PresentadorRegistroOrdenProduccion : PresentadorRegistroBase<IVistaRegistroOrdenProduccion, Modelos.OrdenProduccion, RepoOrdenProduccion, FiltroBusquedaOrdenProduccion> {
        public PresentadorRegistroOrdenProduccion(IVistaRegistroOrdenProduccion vista) : base(vista) {
        }

        public override void PopularVistaDesdeObjeto(Modelos.OrdenProduccion objeto) {
            Vista.ModoEdicionDatos = true;
            Vista.Id = objeto.Id;
            Vista.NombreProductoTerminado = UtilesProducto.ObtenerNombreProducto(objeto.IdProducto).Result ?? string.Empty;
            Vista.NombreAlmacenDestino = UtilesAlmacen.ObtenerNombreAlmacen(objeto.IdAlmacen) ?? string.Empty;
            Vista.NumeroOrden = objeto.NumeroOrden;
            Vista.FechaApertura = objeto.FechaApertura;
            Vista.Cantidad = objeto.Cantidad;
            Vista.MargenGanancia = objeto.MargenGanancia;
            Vista.Observaciones = objeto.Observaciones;

            if (objeto.Estado == EstadoOrdenProduccion.Cerrada)
                Vista.Habilitada = false;

            // Popular materias primas
            using (var repoMateriaPrima = new RepoOrdenMateriaPrima()) {
                var materiasPrimas = repoMateriaPrima.Buscar(FiltroBusquedaOrdenMateriaPrima.OrdenProduccion, objeto.Id.ToString()).resultados;
                foreach (var materiaPrima in materiasPrimas) {
                    Vista.AdicionarMateriaPrima(
                        UtilesAlmacen.ObtenerNombreAlmacen(materiaPrima.IdAlmacen) ?? string.Empty,
                        UtilesProducto.ObtenerNombreProducto(materiaPrima.IdProducto).Result ?? string.Empty,
                        materiaPrima.Cantidad);
                }
            }
            // Popular actividades de producción
            using (var repoActividadProduccion = new RepoOrdenActividadProduccion()) {
                var actividadesProduccion = repoActividadProduccion.Buscar(FiltroBusquedaOrdenActividadProduccion.OrdenProduccion, objeto.Id.ToString()).resultados;
                foreach (var actividad in actividadesProduccion) {
                    Vista.AdicionarActividadProduccion(actividad.Nombre, actividad.Cantidad);
                }
            }
            // Popular gastos indirectos
            using (var repoGastoIndirecto = new RepoOrdenGastoIndirecto()) {
                var gastosIndirectos = repoGastoIndirecto.Buscar(FiltroBusquedaOrdenGastoIndirecto.OrdenProduccion, objeto.Id.ToString()).resultados;
                foreach (var gasto in gastosIndirectos) {
                    Vista.AdicionarGastoIndirecto(gasto.Concepto, gasto.Cantidad);
                }
            }

            Entidad = objeto;
        }

        protected override void RegistroAuxiliar(RepoOrdenProduccion datosObjeto, long id) {
            RegistrarEditarMateriasPrimasOrden(id);
            RegistrarEditarActividadesProduccionOrden(id);
            RegistrarEditarGastosIndirectos(id);

            base.RegistroAuxiliar(datosObjeto, id);
        }

        public void RegistrarEditarMateriasPrimasOrden(long idOrdenProduccion) {
            using (var datosObjeto = new RepoOrdenMateriaPrima()) {
                foreach (var tuplaMateriaPrima in Vista.MateriasPrimas) {
                    var criterioBusqueda = $"{idOrdenProduccion};{UtilesProducto.ObtenerIdProducto(tuplaMateriaPrima[1]).Result}";
                    var materiaPrimaExistente = datosObjeto.Buscar(FiltroBusquedaOrdenMateriaPrima.Producto, criterioBusqueda).resultados.FirstOrDefault();
                    var materiaPrima = materiaPrimaExistente ?? new OrdenMateriaPrima(0,
                        idOrdenProduccion,
                        UtilesAlmacen.ObtenerIdAlmacen(tuplaMateriaPrima[0]).Result,
                        UtilesProducto.ObtenerIdProducto(tuplaMateriaPrima[1]).Result,
                        decimal.TryParse(tuplaMateriaPrima[2], NumberStyles.Any, CultureInfo.InvariantCulture, out var cantidad) ? cantidad : 0m,
                        decimal.TryParse(tuplaMateriaPrima[3], NumberStyles.Any, CultureInfo.InvariantCulture, out var costoUnitario) ? costoUnitario : 0m,
                        costoUnitario * cantidad
                        );

                    if (materiaPrimaExistente != null ) {
                        materiaPrima.Cantidad = decimal.TryParse(tuplaMateriaPrima[2], NumberStyles.Any, CultureInfo.InvariantCulture, out cantidad) ? cantidad : 0m;
                        materiaPrima.CostoUnitario = decimal.TryParse(tuplaMateriaPrima[3], NumberStyles.Any, CultureInfo.InvariantCulture, out costoUnitario) ? costoUnitario : 0m;
                        materiaPrima.Total = costoUnitario * cantidad;
                        datosObjeto.Editar(materiaPrima);
                    } else 
                        datosObjeto.Adicionar(materiaPrima);
                }
            }
        }

        private void RegistrarEditarActividadesProduccionOrden(long idOrdenProduccion) {
            using (var datosObjeto = new RepoOrdenActividadProduccion()) {
                foreach (var tuplaActividadProduccion in Vista.ActividadesProduccion) {
                    var criterioBusqueda = $"{idOrdenProduccion};{tuplaActividadProduccion[0]}";
                    var actividadProduccionExistente = datosObjeto.Buscar(FiltroBusquedaOrdenActividadProduccion.Nombre, criterioBusqueda).resultados.FirstOrDefault();
                    var actividadProduccion = actividadProduccionExistente ?? new OrdenActividadProduccion(0,
                        idOrdenProduccion,
                        tuplaActividadProduccion[0],
                        decimal.TryParse(tuplaActividadProduccion[1], NumberStyles.Any, CultureInfo.InvariantCulture, out var cantidad) ? cantidad : 0m,
                        decimal.TryParse(tuplaActividadProduccion[2], NumberStyles.Any, CultureInfo.InvariantCulture, out var costo) ? costo : 0m,
                        costo * cantidad
                        );

                    if (actividadProduccionExistente != null) {
                        actividadProduccion.Cantidad = decimal.TryParse(tuplaActividadProduccion[1], NumberStyles.Any, CultureInfo.InvariantCulture, out cantidad) ? cantidad : 0m;
                        actividadProduccion.Costo = decimal.TryParse(tuplaActividadProduccion[2], NumberStyles.Any, CultureInfo.InvariantCulture, out costo) ? costo : 0m;
                        actividadProduccion.Total = costo * cantidad;
                        datosObjeto.Editar(actividadProduccion);
                    } else
                        datosObjeto.Adicionar(actividadProduccion);
                }
            }
        }

        private void RegistrarEditarGastosIndirectos(long idOrdenProduccion) {
            using (var datosObjeto = new RepoOrdenGastoIndirecto()) {
                foreach (var tuplaGastoIndirecto in Vista.GastosIndirectos) {
                    var criterioBusqueda = $"{idOrdenProduccion};{tuplaGastoIndirecto[0]}";
                    var gastoIndirectoExistente = datosObjeto.Buscar(FiltroBusquedaOrdenGastoIndirecto.Concepto, criterioBusqueda).resultados.FirstOrDefault();
                    var gastoIndirecto = gastoIndirectoExistente ?? new OrdenGastoIndirecto(0,
                        idOrdenProduccion,
                        tuplaGastoIndirecto[0],
                        decimal.TryParse(tuplaGastoIndirecto[1], NumberStyles.Any, CultureInfo.InvariantCulture, out var cantidad) ? cantidad : 0m,
                        decimal.TryParse(tuplaGastoIndirecto[2], NumberStyles.Any, CultureInfo.InvariantCulture, out var monto) ? monto : 0m,
                        monto * cantidad
                        );

                    if (gastoIndirectoExistente != null) {
                        gastoIndirecto.Cantidad = decimal.TryParse(tuplaGastoIndirecto[1], NumberStyles.Any, CultureInfo.InvariantCulture, out cantidad) ? cantidad : 0m;
                        gastoIndirecto.Monto = decimal.TryParse(tuplaGastoIndirecto[2], NumberStyles.Any, CultureInfo.InvariantCulture, out monto) ? monto : 0m;
                        gastoIndirecto.Total = monto * cantidad;
                        datosObjeto.Editar(gastoIndirecto);
                    } else 
                        datosObjeto.Adicionar(gastoIndirecto);
                }
            }
        }

        protected override Modelos.OrdenProduccion? ObtenerEntidadDesdeVista() {
            return new Modelos.OrdenProduccion(
                Vista.ModoEdicionDatos && Entidad != null ? Entidad.Id : 0,
                Vista.NumeroOrden,
                Vista.FechaApertura,
                DateTime.MinValue,
                UtilesAlmacen.ObtenerIdAlmacen(Vista.NombreAlmacenDestino).Result,
                UtilesProducto.ObtenerIdProducto(Vista.NombreProductoTerminado).Result,                
                Vista.Cantidad,
                EstadoOrdenProduccion.Abierta,
                Vista.Observaciones,
                Vista.CostoTotal,
                Vista.PrecioUnitario,
                Vista.MargenGanancia);
        }
    }
}