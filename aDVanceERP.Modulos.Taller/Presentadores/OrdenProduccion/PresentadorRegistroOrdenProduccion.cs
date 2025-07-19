using aDVanceERP.Core.MVP.Presentadores;
using aDVanceERP.Core.Utiles.Datos;
using aDVanceERP.Modulos.Taller.Interfaces;
using aDVanceERP.Modulos.Taller.Modelos;
using aDVanceERP.Modulos.Taller.Repositorios;
using System.Globalization;

namespace aDVanceERP.Modulos.Taller.Presentadores.OrdenProduccion {
    public class PresentadorRegistroOrdenProduccion : PresentadorRegistroBase<IVistaRegistroOrdenProduccion, Modelos.OrdenProduccion, RepoOrdenProduccion, CriterioBusquedaOrdenProduccion> {
        public PresentadorRegistroOrdenProduccion(IVistaRegistroOrdenProduccion vista) : base(vista) {
        }

        public override void PopularVistaDesdeObjeto(Modelos.OrdenProduccion objeto) {
            Vista.ModoEdicionDatos = true;

        }

        protected override void RegistroAuxiliar(RepoOrdenProduccion datosObjeto, long id) {
            RegistrarEditarMateriasPrimasOrden(id);
            RegistrarEditarActividadesProduccionOrden(id);

            base.RegistroAuxiliar(datosObjeto, id);
        }

        public void RegistrarEditarMateriasPrimasOrden(long idOrdenProduccion) {
            using (var datosObjeto = new RepoOrdenMateriaPrima()) {
                foreach (var tuplaMateriaPrima in Vista.MateriasPrimas) {
                    var materiaPrimaExistente = datosObjeto.Obtener(CriterioBusquedaOrdenMateriaPrima.Producto, UtilesProducto.ObtenerIdProducto(Vista.NombreProductoTerminado).Result.ToString()).FirstOrDefault();
                    var materiaPrima = materiaPrimaExistente ?? new OrdenMateriaPrima(0,
                        idOrdenProduccion,
                        UtilesProducto.ObtenerIdProducto(Vista.NombreProductoTerminado).Result,
                        decimal.TryParse(tuplaMateriaPrima[1], NumberStyles.Any, CultureInfo.InvariantCulture, out var cantidad) ? cantidad : 0m,
                        decimal.TryParse(tuplaMateriaPrima[2], NumberStyles.Any, CultureInfo.InvariantCulture, out var costoUnitario) ? costoUnitario : 0m,
                        costoUnitario * cantidad
                        );

                    if (materiaPrimaExistente != null )
                        datosObjeto.Editar(materiaPrima);
                    else datosObjeto.Adicionar(materiaPrima);
                }
            }
        }

        private void RegistrarEditarActividadesProduccionOrden(long idOrdenProduccion) {


            using (var datosObjeto = new RepoOrdenActividadProduccion()) {
                foreach (var tuplaActividadProduccion in Vista.ActividadesProduccion) {
                    var actividadProduccionExistente = datosObjeto.Obtener(CriterioBusquedaOrdenActividadProduccion.Actividad, tuplaActividadProduccion[0]).FirstOrDefault();
                    var actividadProduccion = actividadProduccionExistente ?? new OrdenActividadProduccion(0,
                        idOrdenProduccion,

                        );
                }
            }
        }

        protected override async Task<Modelos.OrdenProduccion?> ObtenerObjetoDesdeVista() {
            return new Modelos.OrdenProduccion(
                Objeto?.Id ?? 0,
                Vista.NumeroOrden,
                Vista.FechaApertura,
                DateTime.MinValue,
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