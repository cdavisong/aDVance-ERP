using aDVanceERP.Core.MVP.Modelos.Repositorios;
using aDVanceERP.Modulos.Inventario.MVP.Modelos;

using MySql.Data.MySqlClient;

using System.Text;

namespace aDVanceERP.Modulos.Inventario.Repositorios; 

public class RepoProductoAlmacen : RepositorioDatosEntidadBase<ProductoAlmacen, FbProductoAlmacen> {
    public RepoProductoAlmacen() : base("adv__producto_almacen", "id_producto_almacen") { }

    public override string[] FiltrosBusqueda => new[] {
        "Todos",
        "Id",
        "IdProducto",
        "IdAlmacen"
    };

    protected override (string Query, Dictionary<string, object> Parametros) GenerarComandoInsertar(ProductoAlmacen entidad) {
        var query = $"""
            INSERT INTO {NombreTabla} (
                id_producto,
                id_almacen,
                stock
            )
            VALUES (
                @id_producto,
                @id_almacen,
                @stock
            );
            """;

        var parametros = new Dictionary<string, object>
        {
            { "@id_producto", entidad.IdProducto },
            { "@id_almacen", entidad.IdAlmacen },
            { "@stock", entidad.Stock }
        };

        return (query, parametros);
    }

    protected override (string Query, Dictionary<string, object> Parametros) GenerarComandoActualizar(ProductoAlmacen entidad) {
        var query = $"""
            UPDATE {NombreTabla}
            SET
                id_producto = @id_producto,
                id_almacen = @id_almacen,
                stock = @stock
            WHERE {ColumnaId} = @id;
            """;

        var parametros = new Dictionary<string, object>
        {
            { "@id_producto", entidad.IdProducto },
            { "@id_almacen", entidad.IdAlmacen },
            { "@stock", entidad.Stock },
            { "@id", entidad.Id }
        };

        return (query, parametros);
    }

    protected override (string WhereClause, Dictionary<string, object> Parametros) GenerarWhereClause(FbProductoAlmacen filtroBusqueda, string? datosComplementarios) {
        var whereClause = new StringBuilder();
        var parametros = new Dictionary<string, object>();

        switch (filtroBusqueda) {
            case FbProductoAlmacen.Id:
                whereClause.Append($"{ColumnaId} = @id");
                parametros.Add("@id", datosComplementarios);
                break;
            case FbProductoAlmacen.IdProducto:
                whereClause.Append("id_producto = @id_producto");
                parametros.Add("@id_producto", datosComplementarios);
                break;
            case FbProductoAlmacen.IdAlmacen:
                whereClause.Append("id_almacen = @id_almacen");
                parametros.Add("@id_almacen", datosComplementarios);
                break;
            default:
                whereClause.Append("1=1");
                break;
        }

        return (whereClause.ToString(), parametros);
    }

    protected override ProductoAlmacen MapearEntidad(MySqlDataReader lectorDatos) {
        return new ProductoAlmacen(
            lectorDatos.GetInt64(lectorDatos.GetOrdinal("id_producto_almacen")),
            lectorDatos.GetInt64(lectorDatos.GetOrdinal("id_producto")),
            lectorDatos.GetInt64(lectorDatos.GetOrdinal("id_almacen")),
            lectorDatos.GetFloat(lectorDatos.GetOrdinal("stock"))
        );
    }
}
