using aDVanceERP.Core.MVP.Modelos.Repositorios;
using aDVanceERP.Core.Seguridad.MVP.Modelos;

using MySql.Data.MySqlClient;
using System.Text;

namespace aDVanceERP.Core.Seguridad.Repositorios;

public class RepoPermisoRolCuentaUsuario : RepositorioDatosEntidadBase<PermisoRolUsuario, FbPermisoRolCuentaUsuario> {
    public RepoPermisoRolCuentaUsuario() : base("adv__rol_permiso", "id_rol_permiso") {
    }

    public override string[] FiltrosBusqueda => UtilesBusquedaPermisoRolCuentaUsuario.FbPermisoRolCuentaUsuario;

    protected override (string Query, Dictionary<string, object> Parametros) GenerarComandoInsertar(PermisoRolUsuario entidad) {
        var query = $"""
                INSERT INTO {NombreTabla} (
                    id_rol_usuario, 
                    id_permiso
                )
                VALUES (
                    @id_rol_usuario, 
                    @id_permiso
                );
                """;

        var parametros = new Dictionary<string, object>
        {
            { "@id_rol_usuario", entidad.IdRolUsuario },
            { "@id_permiso", entidad.IdPermiso }
        };

        return (query, parametros);
    }

    protected override (string Query, Dictionary<string, object> Parametros) GenerarComandoActualizar(PermisoRolUsuario entidad) {
        var query =
           $"""
            UPDATE {NombreTabla} 
            SET 
                id_rol_usuario = @id_rol_usuario, 
                id_permiso = @id_permiso
            WHERE {ColumnaId} = @id;
            """;

        var parametros = new Dictionary<string, object> {
            { "@id_rol_usuario", entidad.IdRolUsuario },
            { "@id_permiso", entidad.IdPermiso },
            { "@id", entidad.Id }
        };

        return (query, parametros);
    }

    protected override (string WhereClause, Dictionary<string, object> Parametros) GenerarWhereClause(FbPermisoRolCuentaUsuario filtroBusqueda, string? datosComplementarios) {
        var whereClause = new StringBuilder();
        var parametros = new Dictionary<string, object>();

        switch (filtroBusqueda) {
            case FbPermisoRolCuentaUsuario.Id:
                whereClause.Append($"{ColumnaId} = @id");
                parametros.Add("@id", $"{datosComplementarios}");
                break;
            default:
                whereClause.Append("1=1");
                break;
        }

        return (whereClause.ToString(), parametros);
    }

    protected override PermisoRolUsuario MapearEntidad(MySqlDataReader lectorDatos) {
        return new PermisoRolUsuario(
            lectorDatos.GetInt64("id_rol_permiso"),
            lectorDatos.GetInt64("id_rol_usuario"),
            lectorDatos.GetInt64("id_permiso")
        );
    }
}