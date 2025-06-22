using System.Text;

using aDVanceERP.Core.Repositorios;
using aDVanceERP.Modulos.CompraVenta.MVP.Modelos;

using MySql.Data.MySqlClient;

namespace aDVanceERP.Modulos.CompraVenta.Repositorios;

public class RepoDetalleCompraProducto : RepositorioDatosEntidadBase<DetalleCompraProducto, FbCompraProducto> {
    public RepoDetalleCompraProducto() : base("adv__detalle_compra_producto", "id_detalle_compra_producto") {
    }

    public override string[] FiltrosBusqueda => new[] {
        "Todos",
        "Id",
        "IdCompra",
        "IdProducto"
    };

    protected override (string Query, Dictionary<string, object> Parametros) GenerarComandoInsertar(DetalleCompraProducto entidad) {
        var query = $"""
            INSERT INTO {NombreTabla} (
                id_compra,
                id_producto,
                cantidad,
                precio_compra
            )
            VALUES (
                @id_compra,
                @id_producto,
                @cantidad,
                @precio_compra
            );
            """;

        var parametros = new Dictionary<string, object> {
            { "@id_compra", entidad.IdCompra },
            { "@id_producto", entidad.IdProducto },
            { "@cantidad", entidad.Cantidad },
            { "@precio_compra", entidad.PrecioCompra }
        };

        return (query, parametros);
    }

    protected override (string Query, Dictionary<string, object> Parametros) GenerarComandoActualizar(DetalleCompraProducto entidad) {
        var query = $"""
            UPDATE {NombreTabla}
            SET
                id_compra = @id_compra,
                id_producto = @id_producto,
                cantidad = @cantidad,
                precio_compra = @precio_compra
            WHERE {ColumnaId} = @id;
            """;

        var parametros = new Dictionary<string, object> {
            { "@id_compra", entidad.IdCompra },
            { "@id_producto", entidad.IdProducto },
            { "@cantidad", entidad.Cantidad },
            { "@precio_compra", entidad.PrecioCompra },
            { "@id", entidad.Id }
        };

        return (query, parametros);
    }

    protected override (string WhereClause, Dictionary<string, object> Parametros) GenerarWhereClause(FbCompraProducto filtroBusqueda, string? datosComplementarios) {
        var whereClause = new StringBuilder();
        var parametros = new Dictionary<string, object>();

        switch (filtroBusqueda) {
            case FbCompraProducto.Id:
                whereClause.Append($"{ColumnaId} = @id");
                parametros.Add("@id", datosComplementarios);
                break;
            case FbCompraProducto.IdCompra:
                whereClause.Append("id_compra = @id_compra");
                parametros.Add("@id_compra", datosComplementarios);
                break;
            case FbCompraProducto.IdProducto:
                whereClause.Append("id_producto = @id_producto");
                parametros.Add("@id_producto", datosComplementarios);
                break;
            default:
                whereClause.Append("1=1");
                break;
        }

        return (whereClause.ToString(), parametros);
    }

    protected override DetalleCompraProducto MapearEntidad(MySqlDataReader lectorDatos) {
        return new DetalleCompraProducto(
            lectorDatos.GetInt32(lectorDatos.GetOrdinal("id_detalle_compra_producto")),
            lectorDatos.GetInt32(lectorDatos.GetOrdinal("id_compra")),
            lectorDatos.GetInt32(lectorDatos.GetOrdinal("id_producto")),
            lectorDatos.GetFloat(lectorDatos.GetOrdinal("cantidad")),
            lectorDatos.GetDecimal(lectorDatos.GetOrdinal("precio_compra"))
        );
    }
}
