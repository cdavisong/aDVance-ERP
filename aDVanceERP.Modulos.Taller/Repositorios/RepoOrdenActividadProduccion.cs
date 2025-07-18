using aDVanceERP.Core.MVP.Modelos.Repositorios;
using aDVanceERP.Modulos.Taller.Modelos;

using MySql.Data.MySqlClient;
using System.Globalization;

namespace aDVanceERP.Modulos.Taller.Repositorios {
    public class RepoOrdenActividadProduccion : RepositorioDatosBase<OrdenActividadProduccion, CriterioBusquedaOrdenActividadProduccion> {
        public override string ComandoCantidad() {
            return """
                SELECT COUNT(id_orden_actividad) 
                FROM adv__orden_actividad;
                """;
        }

        public override string ComandoAdicionar(OrdenActividadProduccion objeto) {
            return $"""
                INSERT INTO adv__orden_actividad (
                    id_orden_produccion,
                    id_actividad_produccion,
                    cantidad,
                    costo_total,
                    observaciones
                )
                VALUES (
                    {objeto.IdOrdenProduccion},
                    {objeto.IdActividadProduccion},
                    {objeto.Cantidad.ToString(CultureInfo.InvariantCulture)},
                    {objeto.CostoTotal.ToString(CultureInfo.InvariantCulture)},
                    '{objeto.Observaciones?.Replace("'", "''") ?? string.Empty}'
                );
                """;
        }

        public override string ComandoEditar(OrdenActividadProduccion objeto) {
            return $"""
                UPDATE adv__orden_actividad
                SET
                    id_orden_produccion = {objeto.IdOrdenProduccion},
                    id_actividad_produccion = {objeto.IdActividadProduccion},
                    cantidad = {objeto.Cantidad.ToString(CultureInfo.InvariantCulture)},
                    costo_total = {objeto.CostoTotal.ToString(CultureInfo.InvariantCulture)},
                    observaciones = '{objeto.Observaciones?.Replace("'", "''") ?? string.Empty}'
                WHERE id_orden_actividad = {objeto.Id};
                """;
        }

        public override string ComandoEliminar(long id) {
            return $"""
                DELETE FROM adv__orden_actividad 
                WHERE id_orden_actividad = {id};
                """;
        }

        public override string ComandoObtener(CriterioBusquedaOrdenActividadProduccion criterio, string dato) {
            return criterio switch {
                CriterioBusquedaOrdenActividadProduccion.Todas =>
                    "SELECT * FROM adv__orden_actividad;",
                CriterioBusquedaOrdenActividadProduccion.Id =>
                    $"SELECT * FROM adv__orden_actividad WHERE id_orden_actividad = {dato};",
                CriterioBusquedaOrdenActividadProduccion.OrdenProduccion =>
                    $"SELECT * FROM adv__orden_actividad WHERE id_orden_produccion = {dato};",
                CriterioBusquedaOrdenActividadProduccion.Actividad =>
                    $"SELECT * FROM adv__orden_actividad WHERE id_actividad_produccion = {dato};",
                CriterioBusquedaOrdenActividadProduccion.FechaRegistro =>
                    $"SELECT * FROM adv__orden_actividad WHERE DATE(fecha_registro) = '{dato}';",
                _ => throw new ArgumentOutOfRangeException(nameof(criterio), criterio, null)
            };
        }

        public override OrdenActividadProduccion ObtenerObjetoDataReader(MySqlDataReader lectorDatos) {
            return new OrdenActividadProduccion {
                Id = lectorDatos.GetInt64("id_orden_actividad"),
                IdOrdenProduccion = lectorDatos.GetInt64("id_orden_produccion"),
                IdActividadProduccion = lectorDatos.GetInt64("id_actividad_produccion"),
                Cantidad = lectorDatos.GetDecimal("cantidad"),
                CostoTotal = lectorDatos.GetDecimal("costo_total"),
                FechaRegistro = lectorDatos.GetDateTime("fecha_registro"),
                Observaciones = lectorDatos.IsDBNull(lectorDatos.GetOrdinal("observaciones")) ?
                    null : lectorDatos.GetString("observaciones")
            };
        }

        public override string ComandoExiste(string dato) {
            return $"""
                SELECT COUNT(1) 
                FROM adv__orden_actividad 
                WHERE id_orden_actividad = {dato};
                """;
        }
    }
}