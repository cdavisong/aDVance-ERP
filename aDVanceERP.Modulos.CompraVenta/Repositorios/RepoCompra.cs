using System.Globalization;
using System.Text;

using aDVanceERP.Core.MVP.Modelos.Repositorios;
using aDVanceERP.Modulos.CompraVenta.MVP.Modelos;

using MySql.Data.MySqlClient;

namespace aDVanceERP.Modulos.CompraVenta.Repositorios;

public class RepoCompra : RepositorioDatosEntidadBase<Compra, FbCompra> {
    public RepoCompra() : base("adv__compra", "id_compra") { }

    public override string[] FiltrosBusqueda => UtilesBusquedaCompra.FbCompra;

    protected override (string Query, Dictionary<string, object> Parametros) GenerarComandoInsertar(Compra entidad) {
        var query = $"""
            INSERT INTO {NombreTabla} (
                fecha,
                id_almacen,
                id_proveedor,
                total
            )
            VALUES (
                @fecha,
                @id_almacen,
                @id_proveedor,
                @total
            );
            """;

        var parametros = new Dictionary<string, object>
        {
            { "@fecha", entidad.Fecha },
            { "@id_almacen", entidad.IdAlmacen },
            { "@id_proveedor", entidad.IdProveedor },
            { "@total", entidad.Total }
        };

        return (query, parametros);
    }

    protected override (string Query, Dictionary<string, object> Parametros) GenerarComandoActualizar(Compra entidad) {
        var query = $"""
            UPDATE {NombreTabla}
            SET
                fecha = @fecha,
                id_almacen = @id_almacen,
                id_proveedor = @id_proveedor,
                total = @total
            WHERE {ColumnaId} = @id;
            """;

        var parametros = new Dictionary<string, object>
        {
            { "@fecha", entidad.Fecha },
            { "@id_almacen", entidad.IdAlmacen },
            { "@id_proveedor", entidad.IdProveedor },
            { "@total", entidad.Total },
            { "@id", entidad.Id }
        };

        return (query, parametros);
    }

    protected override (string WhereClause, Dictionary<string, object> Parametros) GenerarWhereClause(FbCompra filtroBusqueda, string? datosComplementarios) {
        var whereClause = new StringBuilder();
        var parametros = new Dictionary<string, object>();

        switch (filtroBusqueda) {
            case FbCompra.Id:
                whereClause.Append($"{ColumnaId} = @id");
                parametros.Add("@id", datosComplementarios);
                break;
            case FbCompra.NombreAlmacen:
                whereClause.Append("id_almacen = (SELECT id_almacen FROM adv__almacen WHERE LOWER(nombre) LIKE LOWER(@nombre_almacen))");
                parametros.Add("@nombre_almacen", $"%{datosComplementarios}%");
                break;
            case FbCompra.RazonSocialProveedor:
                whereClause.Append("id_proveedor = (SELECT id_proveedor FROM adv__proveedor WHERE LOWER(razon_social) LIKE LOWER(@razon_social))");
                parametros.Add("@razon_social", $"%{datosComplementarios}%");
                break;
            case FbCompra.Fecha:
                whereClause.Append("DATE(fecha) = @fecha");
                parametros.Add("@fecha", datosComplementarios);
                break;
            default:
                whereClause.Append("1=1");
                break;
        }

        return (whereClause.ToString(), parametros);
    }

    protected override Compra MapearEntidad(MySqlDataReader lectorDatos) {
        return new Compra(
            lectorDatos.GetInt64(lectorDatos.GetOrdinal("id_compra")),
            lectorDatos.GetDateTime(lectorDatos.GetOrdinal("fecha")),
            lectorDatos.GetInt64(lectorDatos.GetOrdinal("id_almacen")),
            lectorDatos.GetInt64(lectorDatos.GetOrdinal("id_proveedor")),
            lectorDatos.GetDecimal(lectorDatos.GetOrdinal("total"))
        );
    }

    // Sobrescribe para lógica de eliminación transaccional especial
    public override void Eliminar(Compra entidad, MySqlConnection? conexionBd = null) {
        var conexion = conexionBd ?? new MySqlConnection(ObtenerCadenaConexion());

        using (var transaccion = conexion.BeginTransaction()) {
            try {
                // 1. Restaurar el stock restando las cantidades compradas
                var queryStock = @"
                    UPDATE adv__producto_almacen pa
                    JOIN adv__detalle_compra_producto dcp ON pa.id_producto = dcp.id_producto
                    JOIN adv__compra c ON dcp.id_compra = c.id_compra
                    SET pa.stock = pa.stock - dcp.cantidad
                    WHERE dcp.id_compra = @id AND pa.id_almacen = c.id_almacen;";
                var parametros = new Dictionary<string, object> { { "@id", entidad.Id } };
                EjecutarComandoNoQuery(conexion, queryStock, parametros, transaccion);

                // 2. Eliminar los movimientos de inventario asociados a la compra
                var queryMov = @"
                    DELETE m FROM adv__movimiento m
                    JOIN adv__detalle_compra_producto dcp ON m.id_producto = dcp.id_producto
                    JOIN adv__tipo_movimiento tm ON m.id_tipo_movimiento = tm.id_tipo_movimiento
                    WHERE tm.nombre = 'Compra' AND tm.efecto = 'Carga' AND dcp.id_compra = @id;";
                EjecutarComandoNoQuery(conexion, queryMov, parametros, transaccion);

                // 3. Eliminar los detalles de productos comprados
                var queryDet = @"DELETE FROM adv__detalle_compra_producto WHERE id_compra = @id;";
                EjecutarComandoNoQuery(conexion, queryDet, parametros, transaccion);

                // 4. Finalmente eliminar el registro principal de la compra
                base.Eliminar(entidad, conexion);

                transaccion.Commit();
            } catch {
                transaccion.Rollback();
                throw;
            } finally {
                conexion.Close();
            }
        }
    }
}
