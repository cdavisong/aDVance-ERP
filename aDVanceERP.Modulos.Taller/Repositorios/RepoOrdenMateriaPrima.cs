using aDVanceERP.Core.MVP.Modelos.Repositorios;
using aDVanceERP.Modulos.Taller.Modelos;

using MySql.Data.MySqlClient;
using System.Globalization;

namespace aDVanceERP.Modulos.Taller.Repositorios {
    public class RepoOrdenMateriaPrima : RepositorioDatosBase<OrdenMateriaPrima, CriterioBusquedaOrdenMateriaPrima> {
        public override string ComandoCantidad() {
            return """
                SELECT COUNT(id_orden_material) 
                FROM adv__orden_material;
                """;
        }

        public override string ComandoAdicionar(OrdenMateriaPrima objeto) {
            return $"""
                INSERT INTO adv__orden_material (
                    id_orden_produccion,
                    id_producto,
                    cantidad,
                    costo_unitario,
                    total,
                    fecha_registro
                )
                VALUES (
                    {objeto.IdOrdenProduccion},
                    {objeto.IdProducto},
                    {objeto.Cantidad.ToString(CultureInfo.InvariantCulture)},
                    {objeto.CostoUnitario.ToString(CultureInfo.InvariantCulture)},
                    {objeto.Total.ToString(CultureInfo.InvariantCulture)},
                    '{objeto.FechaRegistro.ToString("yyyy-MM-dd HH:mm:ss", CultureInfo.InvariantCulture)}'
                );
                """;
        }

        public override string ComandoEditar(OrdenMateriaPrima objeto) {
            return $"""
                UPDATE adv__orden_material
                SET
                    id_orden_produccion = {objeto.IdOrdenProduccion},
                    id_producto = {objeto.IdProducto},
                    cantidad = {objeto.Cantidad.ToString(CultureInfo.InvariantCulture)},
                    costo_unitario = {objeto.CostoUnitario.ToString(CultureInfo.InvariantCulture)},
                    total = {objeto.Total.ToString(CultureInfo.InvariantCulture)},
                    fecha_registro = '{objeto.FechaRegistro.ToString("yyyy-MM-dd HH:mm:ss", CultureInfo.InvariantCulture)}'
                WHERE id_orden_material = {objeto.Id};
                """;
        }

        public override string ComandoEliminar(long id) {
            return $"""
                DELETE FROM adv__orden_material 
                WHERE id_orden_material = {id};
                """;
        }

        public override string ComandoObtener(CriterioBusquedaOrdenMateriaPrima criterio, string dato) {
            var datoSplit = dato.Split(';');

            return criterio switch {
                CriterioBusquedaOrdenMateriaPrima.Todos =>
                    "SELECT * FROM adv__orden_material;",
                CriterioBusquedaOrdenMateriaPrima.Id =>
                    $"SELECT * FROM adv__orden_material WHERE id_orden_material = {dato};",
                CriterioBusquedaOrdenMateriaPrima.OrdenProduccion =>
                    $"SELECT * FROM adv__orden_material WHERE id_orden_produccion = {dato};",
                CriterioBusquedaOrdenMateriaPrima.Producto =>
                    datoSplit.Length > 1
                        ? $"SELECT * FROM adv__orden_material WHERE id_orden_produccion = {datoSplit[0]} AND id_producto = {datoSplit[1]}"
                        : $"SELECT * FROM adv__orden_material WHERE id_producto = {dato};",
                CriterioBusquedaOrdenMateriaPrima.FechaRegistro =>
                    $"SELECT * FROM adv__orden_material WHERE DATE(fecha_registro) = '{dato}';",
                _ => throw new ArgumentOutOfRangeException(nameof(criterio), criterio, null)
            };
        }

        public override OrdenMateriaPrima ObtenerObjetoDataReader(MySqlDataReader lectorDatos) {
            return new OrdenMateriaPrima {
                Id = lectorDatos.GetInt64("id_orden_material"),
                IdOrdenProduccion = lectorDatos.GetInt64("id_orden_produccion"),
                IdProducto = lectorDatos.GetInt64("id_producto"),
                Cantidad = lectorDatos.GetDecimal("cantidad"),
                CostoUnitario = lectorDatos.GetDecimal("costo_unitario"),
                Total = lectorDatos.GetDecimal("total"),
                FechaRegistro = lectorDatos.GetDateTime("fecha_registro")
            };
        }

        public override string ComandoExiste(string dato) {
            return $"""
                SELECT COUNT(1) 
                FROM adv__orden_material 
                WHERE id_orden_material = {dato};
                """;
        }
    }
}