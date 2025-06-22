using aDVanceERP.Core.Repositorios;
using aDVanceERP.Modulos.Inventario.MVP.Modelos;

using MySql.Data.MySqlClient;

using System.Text;

namespace aDVanceERP.Modulos.Inventario.Repositorios; 

public class RepoMovimiento : RepositorioDatosEntidadBase<Movimiento, FbMovimiento> {
    public RepoMovimiento() : base("adv__movimiento", "id_movimiento") { }

    public override string[] FiltrosBusqueda => new[] {
        "Todos",
        "Id",
        "Producto",
        "AlmacenOrigen",
        "AlmacenDestino",
        "Fecha",
        "TipoMovimiento"
    };

    protected override (string Query, Dictionary<string, object> Parametros) GenerarComandoInsertar(Movimiento entidad) {
        var query = $"""
            INSERT INTO {NombreTabla} (
                id_producto,
                id_almacen_origen,
                id_almacen_destino,
                fecha,
                cantidad_movida,
                id_tipo_movimiento
            )
            VALUES (
                @id_producto,
                @id_almacen_origen,
                @id_almacen_destino,
                @fecha,
                @cantidad_movida,
                @id_tipo_movimiento
            );
            """;

        var parametros = new Dictionary<string, object>
        {
            { "@id_producto", entidad.IdProducto },
            { "@id_almacen_origen", entidad.IdAlmacenOrigen },
            { "@id_almacen_destino", entidad.IdAlmacenDestino },
            { "@fecha", entidad.Fecha },
            { "@cantidad_movida", entidad.CantidadMovida },
            { "@id_tipo_movimiento", entidad.IdTipoMovimiento }
        };

        return (query, parametros);
    }

    protected override (string Query, Dictionary<string, object> Parametros) GenerarComandoActualizar(Movimiento entidad) {
        var query = $"""
            UPDATE {NombreTabla}
            SET
                id_producto = @id_producto,
                id_almacen_origen = @id_almacen_origen,
                id_almacen_destino = @id_almacen_destino,
                fecha = @fecha,
                cantidad_movida = @cantidad_movida,
                id_tipo_movimiento = @id_tipo_movimiento
            WHERE {ColumnaId} = @id;
            """;

        var parametros = new Dictionary<string, object>
        {
            { "@id_producto", entidad.IdProducto },
            { "@id_almacen_origen", entidad.IdAlmacenOrigen },
            { "@id_almacen_destino", entidad.IdAlmacenDestino },
            { "@fecha", entidad.Fecha },
            { "@cantidad_movida", entidad.CantidadMovida },
            { "@id_tipo_movimiento", entidad.IdTipoMovimiento },
            { "@id", entidad.Id }
        };

        return (query, parametros);
    }

    protected override (string WhereClause, Dictionary<string, object> Parametros) GenerarWhereClause(FbMovimiento filtroBusqueda, string? datosComplementarios) {
        var whereClause = new StringBuilder();
        var parametros = new Dictionary<string, object>();

        switch (filtroBusqueda) {
            case FbMovimiento.Id:
                whereClause.Append($"{ColumnaId} = @id");
                parametros.Add("@id", datosComplementarios);
                break;
            case FbMovimiento.Producto:
                whereClause.Append("id_producto = (SELECT id_producto FROM adv__producto WHERE LOWER(nombre) LIKE LOWER(@nombre_producto))");
                parametros.Add("@nombre_producto", $"%{datosComplementarios}%");
                break;
            case FbMovimiento.AlmacenOrigen:
                whereClause.Append("id_almacen_origen = (SELECT id_almacen FROM adv__almacen WHERE LOWER(nombre) LIKE LOWER(@nombre_almacen_origen))");
                parametros.Add("@nombre_almacen_origen", $"%{datosComplementarios}%");
                break;
            case FbMovimiento.AlmacenDestino:
                whereClause.Append("id_almacen_destino = (SELECT id_almacen FROM adv__almacen WHERE LOWER(nombre) LIKE LOWER(@nombre_almacen_destino))");
                parametros.Add("@nombre_almacen_destino", $"%{datosComplementarios}%");
                break;
            case FbMovimiento.Fecha:
                whereClause.Append("DATE(fecha) = @fecha");
                parametros.Add("@fecha", datosComplementarios);
                break;
            case FbMovimiento.TipoMovimiento:
                whereClause.Append("id_tipo_movimiento = (SELECT id_tipo_movimiento FROM adv__tipo_movimiento WHERE LOWER(nombre) LIKE LOWER(@nombre_tipo_movimiento))");
                parametros.Add("@nombre_tipo_movimiento", $"%{datosComplementarios}%");
                break;
            default:
                whereClause.Append("1=1");
                break;
        }

        return (whereClause.ToString(), parametros);
    }

    protected override Movimiento MapearEntidad(MySqlDataReader lectorDatos) {
        return new Movimiento(
            lectorDatos.GetInt64(lectorDatos.GetOrdinal("id_movimiento")),
            lectorDatos.GetInt64(lectorDatos.GetOrdinal("id_producto")),
            lectorDatos.GetInt64(lectorDatos.GetOrdinal("id_almacen_origen")),
            lectorDatos.GetInt64(lectorDatos.GetOrdinal("id_almacen_destino")),
            lectorDatos.GetDateTime(lectorDatos.GetOrdinal("fecha")),
            lectorDatos.GetFloat(lectorDatos.GetOrdinal("cantidad_movida")),
            lectorDatos.GetInt64(lectorDatos.GetOrdinal("id_tipo_movimiento"))
        );
    }
}
