using aDVanceERP.Core.Extension.MVP.Modelos;
using aDVanceERP.Core.Repositorios;

using MySql.Data.MySqlClient;

namespace aDVanceERP.Core.Extension.Repositorios; 


public class RepoModuloAplicacion : RepositorioDatosEntidadBase<ModuloAplicacion, FbModuloAplicacion> {
    public RepoModuloAplicacion()
        : base("adv__modulo_aplicacion", "id_modulo_aplicacion") {
    }

    public override string[] FiltrosBusqueda => new[] {
        "Id de Módulo",
        "Nombre de Módulo"
    };

    protected override (string Query, Dictionary<string, object> Parametros) GenerarComandoInsertar(ModuloAplicacion entidad) {
        var query = $"""
            INSERT INTO {NombreTabla} (
                nombre,
                version
            )
            VALUES (
                @nombre,
                @version
            );
            """;

        var parametros = new Dictionary<string, object>
        {
            { "@nombre", entidad.Nombre ?? string.Empty },
            { "@version", entidad.Version ?? string.Empty }
        };

        return (query, parametros);
    }

    protected override (string Query, Dictionary<string, object> Parametros) GenerarComandoActualizar(ModuloAplicacion entidad) {
        var query = $"""
            UPDATE {NombreTabla}
            SET
                nombre = @nombre,
                version = @version
            WHERE {ColumnaId} = @id;
            """;

        var parametros = new Dictionary<string, object>
        {
            { "@nombre", entidad.Nombre ?? string.Empty },
            { "@version", entidad.Version ?? string.Empty },
            { "@id", entidad.Id }
        };

        return (query, parametros);
    }

    protected override (string WhereClause, Dictionary<string, object> Parametros) GenerarWhereClause(FbModuloAplicacion filtroBusqueda, string? datosComplementarios) {
        var parametros = new Dictionary<string, object>();
        string where = string.Empty;

        switch (filtroBusqueda) {
            case FbModuloAplicacion.Id:
                where = "id_modulo_aplicacion = @id";
                parametros.Add("@id", long.TryParse(datosComplementarios, out var id) ? id : 0);
                break;
            case FbModuloAplicacion.Nombre:
                where = "LOWER(nombre) LIKE LOWER(@nombre)";
                parametros.Add("@nombre", $"%{datosComplementarios}%");
                break;
            default:
                where = "1=1";
                break;
        }

        return (where, parametros);
    }

    protected override ModuloAplicacion MapearEntidad(MySqlDataReader lectorDatos) {
        return new ModuloAplicacion(
            lectorDatos.GetInt64(lectorDatos.GetOrdinal("id_modulo_aplicacion")),
            lectorDatos.GetString(lectorDatos.GetOrdinal("nombre")),
            lectorDatos.GetString(lectorDatos.GetOrdinal("version"))
        );
    }
}
