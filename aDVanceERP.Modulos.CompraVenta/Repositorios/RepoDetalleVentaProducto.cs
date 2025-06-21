using System.Text;

using aDVanceERP.Core.MVP.Modelos.Repositorios;
using aDVanceERP.Modulos.CompraVenta.MVP.Modelos;
using MySql.Data.MySqlClient;

namespace aDVanceERP.Modulos.CompraVenta.Repositorios;

/// <summary>
public class RepoDetalleVentaProducto : RepositorioDatosEntidadBase<DetalleVentaProducto, FbDetalleVentaProducto> {
    public RepoDetalleVentaProducto() : base("adv__detalle_venta_producto", "id_detalle_venta_producto") {
    }

    public override string[] FiltrosBusqueda => new[] {
        "Todos",
        "Id",
        "IdVenta",
        "IdProducto"
    };

    protected override (string Query, Dictionary<string, object> Parametros) GenerarComandoInsertar(DetalleVentaProducto entidad) {
        var query = $"""
            INSERT INTO {NombreTabla} (
                id_venta,
                id_producto,
                precio_compra_vigente,
                precio_venta_final,
                cantidad
            )
            VALUES (
                @id_venta,
                @id_producto,
                @precio_compra_vigente,
                @precio_venta_final,
                @cantidad
            );
            """;

        var parametros = new Dictionary<string, object>
        {
            { "@id_venta", entidad.IdVenta },
            { "@id_producto", entidad.IdProducto },
            { "@precio_compra_vigente", entidad.PrecioCompraVigente },
            { "@precio_venta_final", entidad.PrecioVentaFinal },
            { "@cantidad", entidad.Cantidad }
        };

        return (query, parametros);
    }

    protected override (string Query, Dictionary<string, object> Parametros) GenerarComandoActualizar(DetalleVentaProducto entidad) {
        var query = $"""
            UPDATE {NombreTabla}
            SET
                id_venta = @id_venta,
                id_producto = @id_producto,
                precio_compra_vigente = @precio_compra_vigente,
                precio_venta_final = @precio_venta_final,
                cantidad = @cantidad
            WHERE {ColumnaId} = @id;
            """;

        var parametros = new Dictionary<string, object>
        {
            { "@id_venta", entidad.IdVenta },
            { "@id_producto", entidad.IdProducto },
            { "@precio_compra_vigente", entidad.PrecioCompraVigente },
            { "@precio_venta_final", entidad.PrecioVentaFinal },
            { "@cantidad", entidad.Cantidad },
            { "@id", entidad.Id }
        };

        return (query, parametros);
    }

    protected override (string WhereClause, Dictionary<string, object> Parametros) GenerarWhereClause(FbDetalleVentaProducto filtroBusqueda, string? datosComplementarios) {
        var whereClause = new StringBuilder();
        var parametros = new Dictionary<string, object>();

        switch (filtroBusqueda) {
            case FbDetalleVentaProducto.Id:
                whereClause.Append($"{ColumnaId} = @id");
                parametros.Add("@id", datosComplementarios);
                break;
            case FbDetalleVentaProducto.IdVenta:
                whereClause.Append("id_venta = @id_venta");
                parametros.Add("@id_venta", datosComplementarios);
                break;
            case FbDetalleVentaProducto.IdProducto:
                whereClause.Append("id_producto = @id_producto");
                parametros.Add("@id_producto", datosComplementarios);
                break;
            default:
                whereClause.Append("1=1");
                break;
        }

        return (whereClause.ToString(), parametros);
    }

    protected override DetalleVentaProducto MapearEntidad(MySqlDataReader lectorDatos) {
        return new DetalleVentaProducto(
            lectorDatos.GetInt64(lectorDatos.GetOrdinal("id_detalle_venta_producto")),
            lectorDatos.GetInt64(lectorDatos.GetOrdinal("id_venta")),
            lectorDatos.GetInt64(lectorDatos.GetOrdinal("id_producto")),
            lectorDatos.GetDecimal(lectorDatos.GetOrdinal("precio_compra_vigente")),
            lectorDatos.GetDecimal(lectorDatos.GetOrdinal("precio_venta_final")),
            lectorDatos.GetFloat(lectorDatos.GetOrdinal("cantidad"))
        );
    }
}
