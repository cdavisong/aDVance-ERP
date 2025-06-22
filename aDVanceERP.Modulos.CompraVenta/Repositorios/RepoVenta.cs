using System.Text;

using aDVanceERP.Core.Repositorios;
using aDVanceERP.Modulos.CompraVenta.MVP.Modelos;

using MySql.Data.MySqlClient;

namespace aDVanceERP.Modulos.CompraVenta.Repositorios;

public class RepoVenta : RepositorioDatosEntidadBase<Venta, FbVenta> {
    public RepoVenta() : base("adv__venta", "id_venta") { }

    public override string[] FiltrosBusqueda => UtilesBusquedaVenta.FbVenta;

    protected override (string Query, Dictionary<string, object> Parametros) GenerarComandoInsertar(Venta entidad) {
        var query = $"""
            INSERT INTO {NombreTabla} (
                fecha,
                id_almacen,
                id_cliente,
                id_tipo_entrega,
                direccion_entrega,
                estado_entrega,
                total
            )
            VALUES (
                @fecha,
                @id_almacen,
                @id_cliente,
                @id_tipo_entrega,
                @direccion_entrega,
                @estado_entrega,
                @total
            );
            """;

        var parametros = new Dictionary<string, object>
        {
            { "@fecha", entidad.Fecha },
            { "@id_almacen", entidad.IdAlmacen },
            { "@id_cliente", entidad.IdCliente },
            { "@id_tipo_entrega", entidad.IdTipoEntrega },
            { "@direccion_entrega", entidad.DireccionEntrega ?? string.Empty },
            { "@estado_entrega", entidad.EstadoEntrega ?? string.Empty },
            { "@total", entidad.Total }
        };

        return (query, parametros);
    }

    protected override (string Query, Dictionary<string, object> Parametros) GenerarComandoActualizar(Venta entidad) {
        var query = $"""
            UPDATE {NombreTabla}
            SET
                fecha = @fecha,
                id_almacen = @id_almacen,
                id_cliente = @id_cliente,
                id_tipo_entrega = @id_tipo_entrega,
                direccion_entrega = @direccion_entrega,
                estado_entrega = @estado_entrega,
                total = @total
            WHERE {ColumnaId} = @id;
            """;

        var parametros = new Dictionary<string, object>
        {
            { "@fecha", entidad.Fecha },
            { "@id_almacen", entidad.IdAlmacen },
            { "@id_cliente", entidad.IdCliente },
            { "@id_tipo_entrega", entidad.IdTipoEntrega },
            { "@direccion_entrega", entidad.DireccionEntrega ?? string.Empty },
            { "@estado_entrega", entidad.EstadoEntrega ?? string.Empty },
            { "@total", entidad.Total },
            { "@id", entidad.Id }
        };

        return (query, parametros);
    }

    protected override (string WhereClause, Dictionary<string, object> Parametros) GenerarWhereClause(FbVenta filtroBusqueda, string? datosComplementarios) {
        var whereClause = new StringBuilder();
        var parametros = new Dictionary<string, object>();

        switch (filtroBusqueda) {
            case FbVenta.Id:
                whereClause.Append($"{ColumnaId} = @id");
                parametros.Add("@id", datosComplementarios);
                break;
            case FbVenta.NombreAlmacen:
                whereClause.Append("id_almacen = (SELECT id_almacen FROM adv__almacen WHERE LOWER(nombre) LIKE LOWER(@nombre_almacen))");
                parametros.Add("@nombre_almacen", $"%{datosComplementarios}%");
                break;
            case FbVenta.RazonSocialCliente:
                whereClause.Append("id_cliente = (SELECT id_cliente FROM adv__cliente WHERE LOWER(razon_social) LIKE LOWER(@razon_social))");
                parametros.Add("@razon_social", $"%{datosComplementarios}%");
                break;
            case FbVenta.Fecha:
                whereClause.Append("DATE(fecha) = @fecha");
                parametros.Add("@fecha", datosComplementarios);
                break;
            default:
                whereClause.Append("1=1");
                break;
        }

        return (whereClause.ToString(), parametros);
    }

    protected override Venta MapearEntidad(MySqlDataReader lectorDatos) {
        return new Venta(
            lectorDatos.GetInt64(lectorDatos.GetOrdinal("id_venta")),
            lectorDatos.GetDateTime(lectorDatos.GetOrdinal("fecha")),
            lectorDatos.GetInt64(lectorDatos.GetOrdinal("id_almacen")),
            lectorDatos.GetInt64(lectorDatos.GetOrdinal("id_cliente")),
            lectorDatos.GetInt64(lectorDatos.GetOrdinal("id_tipo_entrega")),
            lectorDatos.GetString(lectorDatos.GetOrdinal("direccion_entrega")),
            lectorDatos.GetString(lectorDatos.GetOrdinal("estado_entrega")),
            lectorDatos.GetDecimal(lectorDatos.GetOrdinal("total"))
        );
    }

    public override void Eliminar(Venta entidad, MySqlConnection? conexionBd = null) {
        var conexion = conexionBd ?? new MySqlConnection(ObtenerCadenaConexion());

        using (var transaccion = conexion.BeginTransaction()) {
            try {
                // 1. Restaurar el stock sumando las cantidades vendidas
                var queryStock = @"
                    UPDATE adv__producto_almacen pa
                    JOIN adv__detalle_venta_producto dvp ON pa.id_producto = dvp.id_producto
                    JOIN adv__venta v ON dvp.id_venta = v.id_venta
                    SET pa.stock = pa.stock + dvp.cantidad
                    WHERE dvp.id_venta = @id AND pa.id_almacen = v.id_almacen;";
                var parametros = new Dictionary<string, object> { { "@id", entidad.Id } };
                EjecutarComandoNoQuery(conexion, queryStock, parametros, transaccion);

                // 2. Eliminar los movimientos de inventario asociados a la venta
                var queryMov = @"
                    DELETE m FROM adv__movimiento m
                    JOIN adv__detalle_venta_producto dvp ON m.id_producto = dvp.id_producto
                    JOIN adv__tipo_movimiento tm ON m.id_tipo_movimiento = tm.id_tipo_movimiento
                    WHERE tm.nombre = 'Venta' AND tm.efecto = 'Descarga' AND dvp.id_venta = @id;";
                EjecutarComandoNoQuery(conexion, queryMov, parametros, transaccion);

                // 3. Eliminar registros relacionados en tablas dependientes
                var querySeguimiento = @"DELETE FROM adv__seguimiento_entrega WHERE id_venta = @id;";
                EjecutarComandoNoQuery(conexion, querySeguimiento, parametros, transaccion);

                var queryPagoTransf = @"DELETE FROM adv__detalle_pago_transferencia WHERE id_venta = @id;";
                EjecutarComandoNoQuery(conexion, queryPagoTransf, parametros, transaccion);

                var queryPago = @"DELETE FROM adv__pago WHERE id_venta = @id;";
                EjecutarComandoNoQuery(conexion, queryPago, parametros, transaccion);

                // 4. Eliminar los detalles de productos vendidos
                var queryDet = @"DELETE FROM adv__detalle_venta_producto WHERE id_venta = @id;";
                EjecutarComandoNoQuery(conexion, queryDet, parametros, transaccion);

                // 5. Finalmente eliminar el registro principal de la venta
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
