using aDVanceERP.Core.MVP.Modelos;

using MySql.Data.MySqlClient;

using System.Text;

namespace aDVanceERP.Core.Repositorios;

public class RepoUnidadMedida : RepositorioDatosEntidadBase<UnidadMedida, FbUnidadMedida> {
    public RepoUnidadMedida() : base("adv__unidad_medida", "id_unidad_medida") {
    }

    public override string[] FiltrosBusqueda => (string[]) UtilesBusquedaUnidadesMedida.FbUnidadesMedida;

    protected override (string Query, Dictionary<string, object> Parametros) GenerarComandoInsertar(UnidadMedida entidad) {
        var query = $"""
                INSERT INTO {NombreTabla} (
                    nombre,
                    abreviatura,
                    descripcion
                )
                VALUES (
                    @nombre,
                    @abreviatura,
                    @descripcion
                );
                """;

        var parametros = new Dictionary<string, object>
        {
            { "@nombre", entidad.Nombre },
            { "@abreviatura", entidad.Abreviatura },
            { "@descripcion", entidad.Descripcion }
        };

        return (query, parametros);
    }

    protected override (string Query, Dictionary<string, object> Parametros) GenerarComandoActualizar(UnidadMedida entidad) {
        var query = $"""
                UPDATE {NombreTabla}
                SET
                    nombre = @nombre,
                    abreviatura = @abreviatura,
                    descripcion = @descripcion
                WHERE {ColumnaId} = @id;
                """;

        var parametros = new Dictionary<string, object>
        {
            { "@nombre", entidad.Nombre },
            { "@abreviatura", entidad.Abreviatura },
            { "@descripcion", entidad.Descripcion },
            { "@id", entidad.Id }
        };

        return (query, parametros);
    }

    protected override (string WhereClause, Dictionary<string, object> Parametros) GenerarWhereClause(FbUnidadMedida filtroBusqueda, string? datosComplementarios) {
        var whereClause = new StringBuilder();
        var parametros = new Dictionary<string, object>();

        switch (filtroBusqueda) {
            case FbUnidadMedida.Id:
                whereClause.Append($"{ColumnaId} = @id");
                parametros.Add("@id", $"{datosComplementarios}");
                break;
            case FbUnidadMedida.Nombre:
                whereClause.Append("LOWER(nombre) LIKE LOWER(@nombre)");
                parametros.Add("@nombre", $"%{datosComplementarios}%");
                break;
            case FbUnidadMedida.Abreviatura:
                whereClause.Append("LOWER(abreviatura) LIKE LOWER(@abreviatura)");
                parametros.Add("@abreviatura", $"%{datosComplementarios}%");
                break;
            default:
                whereClause.Append("1=1");
                break;

        }

        return (whereClause.ToString(), parametros);
    }

    protected override UnidadMedida MapearEntidad(MySqlDataReader lectorDatos) {
        return new UnidadMedida(
            lectorDatos.GetInt64("id_unidad_medida"),
            lectorDatos.GetString("nombre"),
            lectorDatos.GetString("abreviatura"),
            lectorDatos.GetString("descripcion")
        );
    }
}

