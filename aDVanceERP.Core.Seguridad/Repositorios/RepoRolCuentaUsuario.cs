using aDVanceERP.Core.Repositorios;
using aDVanceERP.Core.Seguridad.MVP.Modelos;

using MySql.Data.MySqlClient;

using System.Text;

namespace aDVanceERP.Core.Seguridad.Repositorios;

public class RepoRolCuentaUsuario : RepositorioDatosEntidadBase<RolUsuario, FbRolCuentaUsuario> {
    public RepoRolCuentaUsuario() : base("adv__rol_usuario", "id_rol_usuario") {
    }

    public override string[] FiltrosBusqueda => UtilesBusquedaRolCuentaUsuario.FbRolCuentaUsuario;

    protected override (string Query, Dictionary<string, object> Parametros) GenerarComandoInsertar(RolUsuario entidad) {
        var query = $"""
                INSERT INTO {NombreTabla} (
                    nombre
                )
                VALUES (
                    @nombre
                );
                """;

        var parametros = new Dictionary<string, object>
        {
            { "@nombre", entidad.Nombre }
        };

        return (query, parametros);
    }

    protected override (string Query, Dictionary<string, object> Parametros) GenerarComandoActualizar(RolUsuario entidad) {
        var query =
           $"""
            UPDATE {NombreTabla} 
            SET 
                nombre = @nombre
            WHERE {ColumnaId} = @id;
            """;

        var parametros = new Dictionary<string, object> {
            { "@nombre", entidad.Nombre },
            { "@id", entidad.Id }
        };

        return (query, parametros);
    }

    protected override (string WhereClause, Dictionary<string, object> Parametros) GenerarWhereClause(FbRolCuentaUsuario filtroBusqueda, string? datosComplementarios) {
        var whereClause = new StringBuilder();
        var parametros = new Dictionary<string, object>();

        switch (filtroBusqueda) {
            case FbRolCuentaUsuario.Id:
                whereClause.Append($"{ColumnaId} = @id");
                parametros.Add("@id", $"{datosComplementarios}");
                break;
            case FbRolCuentaUsuario.Nombre:
                whereClause.Append("LOWER(nombre) LIKE LOWER(@nombre)");
                parametros.Add("@nombre", $"%{datosComplementarios}%");
                break;
            default:
                whereClause.Append("1=1");
                break;

        }

        return (whereClause.ToString(), parametros);
    }
    protected override RolUsuario MapearEntidad(MySqlDataReader lectorDatos) {
        return new RolUsuario(
            lectorDatos.GetInt64("id_rol_usuario"),
            lectorDatos.GetString("nombre")
        );
    }
}