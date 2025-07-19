using aDVanceERP.Core.MVP.Modelos.Repositorios;
using aDVanceERP.Modulos.Taller.Modelos;

using MySql.Data.MySqlClient;
using System.Globalization;

namespace aDVanceERP.Modulos.Taller.Repositorios {
    public class RepoOrdenGastoIndirecto : RepositorioDatosBase<OrdenGastoIndirecto, CriterioBusquedaOrdenGastoIndirecto> {
        public override string ComandoCantidad() {
            return """
                SELECT COUNT(id_orden_gasto_indirecto) 
                FROM adv__orden_gasto_indirecto;
                """;
        }

        public override string ComandoAdicionar(OrdenGastoIndirecto objeto) {
            return $"""
                INSERT INTO adv__orden_gasto_indirecto (
                    id_orden_produccion,
                    concepto,
                    cantidad,
                    monto,
                    total
                )
                VALUES (
                    {objeto.IdOrdenProduccion},
                    '{objeto.Concepto}',
                    {objeto.Cantidad.ToString(CultureInfo.InvariantCulture)},
                    {objeto.Monto.ToString(CultureInfo.InvariantCulture)},
                    {objeto.Total.ToString(CultureInfo.InvariantCulture)}
                );
                """;
        }

        public override string ComandoEditar(OrdenGastoIndirecto objeto) {
            return $"""
                UPDATE adv__orden_gasto_indirecto
                SET
                    id_orden_produccion = {objeto.IdOrdenProduccion},
                    concepto = '{objeto.Concepto}',
                    cantidad = {objeto.Cantidad.ToString(CultureInfo.InvariantCulture)},
                    monto = {objeto.Monto.ToString(CultureInfo.InvariantCulture)},
                    total = {objeto.Total.ToString(CultureInfo.InvariantCulture)}
                WHERE id_orden_gasto_indirecto = {objeto.Id};
                """;
        }

        public override string ComandoEliminar(long id) {
            return $"""
                DELETE FROM adv__orden_gasto_indirecto 
                WHERE id_orden_gasto_indirecto = {id};
                """;
        }

        public override string ComandoObtener(CriterioBusquedaOrdenGastoIndirecto criterio, string dato) {
            return criterio switch {
                CriterioBusquedaOrdenGastoIndirecto.Todos =>
                    "SELECT * FROM adv__orden_gasto_indirecto;",
                CriterioBusquedaOrdenGastoIndirecto.Id =>
                    $"SELECT * FROM adv__orden_gasto_indirecto WHERE id_orden_gasto_indirecto = {dato};",
                CriterioBusquedaOrdenGastoIndirecto.OrdenProduccion =>
                    $"SELECT * FROM adv__orden_gasto_indirecto WHERE id_orden_produccion = {dato};",
                CriterioBusquedaOrdenGastoIndirecto.Concepto =>
                    $"SELECT * FROM adv__orden_gasto_indirecto WHERE concepto LIKE '%{dato}%';",
                CriterioBusquedaOrdenGastoIndirecto.FechaRegistro =>
                    $"SELECT * FROM adv__orden_gasto_indirecto WHERE DATE(fecha_registro) = '{dato}';",
                _ => throw new ArgumentOutOfRangeException(nameof(criterio), criterio, null)
            };
        }

        public override OrdenGastoIndirecto ObtenerObjetoDataReader(MySqlDataReader lectorDatos) {
            return new OrdenGastoIndirecto {
                Id = lectorDatos.GetInt64("id_orden_gasto_indirecto"),
                IdOrdenProduccion = lectorDatos.GetInt64("id_orden_produccion"),
                Concepto = lectorDatos.GetString("concepto"),
                Monto = lectorDatos.GetDecimal("monto"),
                FechaRegistro = lectorDatos.GetDateTime("fecha_registro"),
                Observaciones = lectorDatos.IsDBNull(lectorDatos.GetOrdinal("observaciones")) ?
                    null : lectorDatos.GetString("observaciones")
            };
        }

        public override string ComandoExiste(string dato) {
            return $"""
                SELECT COUNT(1) 
                FROM adv__orden_gasto_indirecto 
                WHERE id_orden_gasto_indirecto = {dato};
                """;
        }
    }
}