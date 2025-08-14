using aDVanceERP.Core.Repositorios.BD;
using aDVanceERP.Modulos.Taller.Modelos;

using MySql.Data.MySqlClient;
using System.Globalization;

namespace aDVanceERP.Modulos.Taller.Repositorios
{
    public class RepoOrdenGastoIndirecto : RepoEntidadBaseDatos<OrdenGastoIndirecto, FiltroBusquedaOrdenGastoIndirecto> {
        public override string ComandoCantidad() {
            return """
                SELECT COUNT(id_orden_gasto_indirecto) 
                FROM adv__orden_gasto_indirecto;
                """;
        }

        public override string GenerarComandoInsertar(OrdenGastoIndirecto objeto) {
            return $"""
                INSERT INTO adv__orden_gasto_indirecto (
                    id_orden_produccion,
                    concepto,
                    cantidad,
                    monto,
                    total,
                    fecha_registro
                )
                VALUES (
                    {objeto.IdOrdenProduccion},
                    '{objeto.Concepto}',
                    {objeto.Cantidad.ToString(CultureInfo.InvariantCulture)},
                    {objeto.Monto.ToString(CultureInfo.InvariantCulture)},
                    {objeto.Total.ToString(CultureInfo.InvariantCulture)},
                    '{objeto.FechaRegistro.ToString("yyyy-MM-dd HH:mm:ss", CultureInfo.InvariantCulture)}'
                );
                """;
        }

        public override string GenerarComandoActualizar(OrdenGastoIndirecto objeto) {
            return $"""
                UPDATE adv__orden_gasto_indirecto
                SET
                    id_orden_produccion = {objeto.IdOrdenProduccion},
                    concepto = '{objeto.Concepto}',
                    cantidad = {objeto.Cantidad.ToString(CultureInfo.InvariantCulture)},
                    monto = {objeto.Monto.ToString(CultureInfo.InvariantCulture)},
                    total = {objeto.Total.ToString(CultureInfo.InvariantCulture)},
                    fecha_registro = '{objeto.FechaRegistro.ToString("yyyy-MM-dd HH:mm:ss", CultureInfo.InvariantCulture)}'
                WHERE id_orden_gasto_indirecto = {objeto.Id};
                """;
        }

        public override string ComandoEliminar(long id) {
            return $"""
                DELETE FROM adv__orden_gasto_indirecto 
                WHERE id_orden_gasto_indirecto = {id};
                """;
        }

        public override string GenerarClausulaWhere(FiltroBusquedaOrdenGastoIndirecto criterio, string dato) {
            var datoSplit = dato.Split(';');

            return criterio switch {
                FiltroBusquedaOrdenGastoIndirecto.Todos =>
                    "SELECT * FROM adv__orden_gasto_indirecto;",
                FiltroBusquedaOrdenGastoIndirecto.Id =>
                    $"SELECT * FROM adv__orden_gasto_indirecto WHERE id_orden_gasto_indirecto = {dato};",
                FiltroBusquedaOrdenGastoIndirecto.OrdenProduccion =>
                    $"SELECT * FROM adv__orden_gasto_indirecto WHERE id_orden_produccion = {dato};",
                FiltroBusquedaOrdenGastoIndirecto.Concepto =>
                    datoSplit.Length > 1
                        ? $"SELECT * FROM adv__orden_gasto_indirecto WHERE id_orden_produccion = {datoSplit[0]} AND concepto = '{datoSplit[1]}'"
                        : $"SELECT * FROM adv__orden_gasto_indirecto WHERE concepto LIKE '%{dato}%';",
                FiltroBusquedaOrdenGastoIndirecto.FechaRegistro =>
                    $"SELECT * FROM adv__orden_gasto_indirecto WHERE DATE(fecha_registro) = '{dato}';",
                _ => throw new ArgumentOutOfRangeException(nameof(criterio), criterio, null)
            };
        }

        public override OrdenGastoIndirecto MapearEntidad(MySqlDataReader lectorDatos) {
            return new OrdenGastoIndirecto {
                Id = lectorDatos.GetInt64("id_orden_gasto_indirecto"),
                IdOrdenProduccion = lectorDatos.GetInt64("id_orden_produccion"),
                Concepto = lectorDatos.GetString("concepto"),
                Cantidad = lectorDatos.GetDecimal("cantidad"),
                Monto = lectorDatos.GetDecimal("monto"),
                Total = lectorDatos.GetDecimal("total"),
                FechaRegistro = lectorDatos.GetDateTime("fecha_registro")
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