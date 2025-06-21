using aDVanceERP.Core.MVP.Modelos.Repositorios;
using aDVanceERP.Modulos.Inventario.MVP.Modelos;

using MySql.Data.MySqlClient;

using System.Text;

namespace aDVanceERP.Modulos.Inventario.Repositorios;

public class RepoDetalleProducto : RepositorioDatosEntidadBase<DetalleProducto, FbDetalleProducto> {
    public RepoDetalleProducto() : base("adv__detalle_producto", "id_detalle_producto") { }

    public override string[] FiltrosBusqueda => UtilesBusquedaDetallesProducto.FbDetalleProducto;

    protected override (string Query, Dictionary<string, object> Parametros) GenerarComandoInsertar(DetalleProducto entidad) {
        var query = $"""
            INSERT INTO {NombreTabla} (
                id_unidad_medida,
                descripcion
            )
            VALUES (
                @id_unidad_medida,
                @descripcion
            );
            """;

        var parametros = new Dictionary<string, object>
        {
            { "@id_unidad_medida", entidad.IdUnidadMedida },
            { "@descripcion", entidad.Descripcion ?? string.Empty }
        };

        return (query, parametros);
    }

    protected override (string Query, Dictionary<string, object> Parametros) GenerarComandoActualizar(DetalleProducto entidad) {
        var query = $"""
            UPDATE {NombreTabla}
            SET
                id_unidad_medida = @id_unidad_medida,
                descripcion = @descripcion
            WHERE {ColumnaId} = @id;
            """;

        var parametros = new Dictionary<string, object>
        {
            { "@id_unidad_medida", entidad.IdUnidadMedida },
            { "@descripcion", entidad.Descripcion ?? string.Empty },
            { "@id", entidad.Id }
        };

        return (query, parametros);
    }

    protected override (string WhereClause, Dictionary<string, object> Parametros) GenerarWhereClause(FbDetalleProducto filtroBusqueda, string? datosComplementarios) {
        var whereClause = new StringBuilder();
        var parametros = new Dictionary<string, object>();

        switch (filtroBusqueda) {
            case FbDetalleProducto.Id:
                whereClause.Append($"{ColumnaId} = @id");
                parametros.Add("@id", datosComplementarios);
                break;
            case FbDetalleProducto.UnidadMedida:
                whereClause.Append("id_unidad_medida = (SELECT id_unidad_medida FROM adv__unidad_medida WHERE nombre = @nombre_unidad)");
                parametros.Add("@nombre_unidad", datosComplementarios);
                break;
            case FbDetalleProducto.Descripcion:
                whereClause.Append("LOWER(descripcion) LIKE LOWER(@descripcion)");
                parametros.Add("@descripcion", $"%{datosComplementarios}%");
                break;
            default:
                whereClause.Append("1=1");
                break;
        }

        return (whereClause.ToString(), parametros);
    }

    protected override DetalleProducto MapearEntidad(MySqlDataReader lectorDatos) {
        return new DetalleProducto(
            id: lectorDatos.GetInt64(lectorDatos.GetOrdinal("id_detalle_producto")),
            idUnidadMedida: lectorDatos.GetInt64(lectorDatos.GetOrdinal("id_unidad_medida")),
            descripcion: lectorDatos.IsDBNull(lectorDatos.GetOrdinal("descripcion"))
                ? "No hay descripción disponible"
                : lectorDatos.GetString(lectorDatos.GetOrdinal("descripcion"))
        );
    }
}
