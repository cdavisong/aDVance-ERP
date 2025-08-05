using aDVanceERP.Core.Repositorios.Comun;
using aDVanceERP.Modulos.Taller.Modelos;

using MySql.Data.MySqlClient;
using System.Globalization;

namespace aDVanceERP.Modulos.Taller.Repositorios
{
    public class RepoOrdenActividadProduccion : RepoBase<OrdenActividadProduccion, CriterioBusquedaOrdenActividadProduccion> {
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
                    nombre,
                    cantidad,
                    costo,
                    total,
                    fecha_registro
                )
                VALUES (
                    {objeto.IdOrdenProduccion},
                    '{objeto.Nombre}',
                    {objeto.Cantidad.ToString(CultureInfo.InvariantCulture)},
                    {objeto.Costo.ToString(CultureInfo.InvariantCulture)},
                    {objeto.Total.ToString(CultureInfo.InvariantCulture)},
                    '{objeto.FechaRegistro.ToString("yyyy-MM-dd HH:mm:ss", CultureInfo.InvariantCulture)}'
                );
                """;
        }

        public override string ComandoEditar(OrdenActividadProduccion objeto) {
            return $"""
                UPDATE adv__orden_actividad
                SET
                    id_orden_produccion = {objeto.IdOrdenProduccion},
                    nombre = '{objeto.Nombre}',
                    cantidad = {objeto.Cantidad.ToString(CultureInfo.InvariantCulture)},
                    costo = {objeto.Costo.ToString(CultureInfo.InvariantCulture)},
                    total = {objeto.Total.ToString(CultureInfo.InvariantCulture)},
                    fecha_registro = '{objeto.FechaRegistro.ToString("yyyy-MM-dd HH:mm:ss", CultureInfo.InvariantCulture)}'
                WHERE id_orden_actividad = {objeto.Id};
                """;
        }

        public override string ComandoEliminar(long id) {
            return $"""
                DELETE FROM adv__orden_actividad 
                WHERE id_orden_actividad = {id};
                """;
        }

        public override string GenerarQueryObtener(CriterioBusquedaOrdenActividadProduccion criterio, string dato) {
            var datoSplit = dato.Split(';');

            return criterio switch {
                CriterioBusquedaOrdenActividadProduccion.Todos =>
                    "SELECT * FROM adv__orden_actividad;",
                CriterioBusquedaOrdenActividadProduccion.Id =>
                    $"SELECT * FROM adv__orden_actividad WHERE id_orden_actividad = {dato};",
                CriterioBusquedaOrdenActividadProduccion.OrdenProduccion =>
                    $"SELECT * FROM adv__orden_actividad WHERE id_orden_produccion = {dato};",
                CriterioBusquedaOrdenActividadProduccion.Nombre =>
                    datoSplit.Length > 1
                        ? $"SELECT * FROM adv__orden_actividad WHERE id_orden_produccion = {datoSplit[0]} AND nombre = '{datoSplit[1]}';"
                        : $"SELECT * FROM adv__orden_actividad WHERE nombre LIKE '%{dato}%';",
                CriterioBusquedaOrdenActividadProduccion.FechaRegistro =>
                    $"SELECT * FROM adv__orden_actividad WHERE DATE(fecha_registro) = '{dato}';",
                _ => throw new ArgumentOutOfRangeException(nameof(criterio), criterio, null)
            };
        }

        public override OrdenActividadProduccion MapearEntidad(MySqlDataReader lectorDatos) {
            return new OrdenActividadProduccion {
                Id = lectorDatos.GetInt64("id_orden_actividad"),
                IdOrdenProduccion = lectorDatos.GetInt64("id_orden_produccion"),
                Nombre = lectorDatos.GetString("nombre"),
                Cantidad = lectorDatos.GetDecimal("cantidad"),
                Costo = lectorDatos.GetDecimal("costo"),
                Total = lectorDatos.GetDecimal("total"),
                FechaRegistro = lectorDatos.GetDateTime("fecha_registro")
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