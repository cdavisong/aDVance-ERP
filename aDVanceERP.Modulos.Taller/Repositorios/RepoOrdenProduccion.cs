using aDVanceERP.Core.MVP.Modelos.Repositorios;
using aDVanceERP.Modulos.Taller.Modelos;

using MySql.Data.MySqlClient;
using System.Globalization;

namespace aDVanceERP.Modulos.Taller.Repositorios {
    public class RepoOrdenProduccion : RepositorioDatosBase<OrdenProduccion, CriterioBusquedaOrdenProduccion> {
        public override string ComandoCantidad() {
            return """
                SELECT COUNT(id_orden_produccion) 
                FROM adv__orden_produccion;
                """;
        }

        public override string ComandoAdicionar(OrdenProduccion objeto) {
            return $"""
                INSERT INTO adv__orden_produccion (
                    numero_orden,
                    id_producto,
                    cantidad,
                    estado,
                    observaciones,
                    margen_ganancia
                )
                VALUES (
                    '{objeto.NumeroOrden}',
                    {objeto.IdProducto},
                    {objeto.Cantidad.ToString(CultureInfo.InvariantCulture)},
                    '{objeto.Estado}',
                    '{objeto.Observaciones?.Replace("'", "''") ?? string.Empty}',
                    {objeto.MargenGanancia.ToString(CultureInfo.InvariantCulture)}
                );
                """;
        }

        public override string ComandoEditar(OrdenProduccion objeto) {
            return $"""
                UPDATE adv__orden_produccion
                SET
                    numero_orden = '{objeto.NumeroOrden}',
                    id_producto = {objeto.IdProducto},
                    cantidad = {objeto.Cantidad.ToString(CultureInfo.InvariantCulture)},
                    estado = '{objeto.Estado}',
                    observaciones = '{objeto.Observaciones?.Replace("'", "''") ?? string.Empty}',
                    fecha_cierre = {(objeto.FechaCierre.HasValue ? $"'{objeto.FechaCierre.Value:yyyy-MM-dd HH:mm:ss}'" : "NULL")},
                    costo_total = {objeto.CostoTotal.ToString(CultureInfo.InvariantCulture)},
                    precio_unitario = {objeto.PrecioUnitario.ToString(CultureInfo.InvariantCulture)},
                    margen_ganancia = {objeto.MargenGanancia.ToString(CultureInfo.InvariantCulture)}
                WHERE id_orden_produccion = {objeto.Id};
                """;
        }

        public override string ComandoEliminar(long id) {
            return $"""
                -- Primero eliminamos los registros relacionados
                DELETE FROM adv__orden_actividad WHERE id_orden_produccion = {id};
                DELETE FROM adv__orden_material WHERE id_orden_produccion = {id};
                DELETE FROM adv__orden_gasto_indirecto WHERE id_orden_produccion = {id};
                
                -- Finalmente eliminamos la orden
                DELETE FROM adv__orden_produccion WHERE id_orden_produccion = {id};
                """;
        }

        public override string ComandoObtener(CriterioBusquedaOrdenProduccion criterio, string dato) {
            return criterio switch {
                CriterioBusquedaOrdenProduccion.Todas =>
                    "SELECT * FROM adv__orden_produccion;",
                CriterioBusquedaOrdenProduccion.NumeroOrden =>
                    $"SELECT * FROM adv__orden_produccion WHERE numero_orden LIKE '%{dato}%';",
                CriterioBusquedaOrdenProduccion.Producto =>
                    $"SELECT * FROM adv__orden_produccion WHERE id_producto = {dato};",
                CriterioBusquedaOrdenProduccion.Estado =>
                    $"SELECT * FROM adv__orden_produccion WHERE estado = '{dato}';",
                CriterioBusquedaOrdenProduccion.FechaApertura =>
                    $"SELECT * FROM adv__orden_produccion WHERE DATE(fecha_apertura) = '{dato}';",
                CriterioBusquedaOrdenProduccion.FechaCierre =>
                    $"SELECT * FROM adv__orden_produccion WHERE DATE(fecha_cierre) = '{dato}';",
                _ => throw new ArgumentOutOfRangeException(nameof(criterio), criterio, null)
            };
        }

        public override OrdenProduccion ObtenerObjetoDataReader(MySqlDataReader lectorDatos) {
            return new OrdenProduccion {
                Id = lectorDatos.GetInt64("id_orden_produccion"),
                NumeroOrden = lectorDatos.GetString("numero_orden"),
                FechaApertura = lectorDatos.GetDateTime("fecha_apertura"),
                FechaCierre = lectorDatos.IsDBNull(lectorDatos.GetOrdinal("fecha_cierre")) ?
                    null : lectorDatos.GetDateTime("fecha_cierre"),
                IdProducto = lectorDatos.GetInt64("id_producto"),
                Cantidad = lectorDatos.GetDecimal("cantidad"),
                Estado = (EstadoOrdenProduccion) Enum.Parse(
                    typeof(EstadoOrdenProduccion),
                    lectorDatos.GetString("estado")),
                Observaciones = lectorDatos.IsDBNull(lectorDatos.GetOrdinal("observaciones")) ?
                    null : lectorDatos.GetString("observaciones"),
                CostoTotal = lectorDatos.GetDecimal("costo_total"),
                PrecioUnitario = lectorDatos.GetDecimal("precio_unitario"),
                MargenGanancia = lectorDatos.GetDecimal("margen_ganancia")
            };
        }

        public override string ComandoExiste(string dato) {
            return $"""
                SELECT COUNT(1) 
                FROM adv__orden_produccion 
                WHERE numero_orden = '{dato}';
                """;
        }
    }
}