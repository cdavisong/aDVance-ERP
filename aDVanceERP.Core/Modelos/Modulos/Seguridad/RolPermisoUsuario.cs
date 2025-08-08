
using aDVanceERP.Core.Interfaces;
using MySql.Data.MySqlClient;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace aDVanceERP.Core.Modelos.Modulos.Seguridad;

public class RolPermisoUsuario : IEntidadBd {
    public RolPermisoUsuario() { 
    }

    public RolPermisoUsuario(long id, long idRolUsuario, long idPermiso) {
        Id = id;
        IdRolUsuario = idRolUsuario;
        IdPermiso = idPermiso;
    }

    public RolPermisoUsuario(MySqlDataReader reader) {
        Id = reader.GetInt32("id_rol_permiso");
        IdRolUsuario = reader.GetInt32("id_rol_usuario");
        IdPermiso = reader.GetInt32("id_permiso");
    }

    public long Id { get; set; }
    public long IdRolUsuario { get; }
    public long IdPermiso { get; }

    #region CRUD querys :

    public (string query, Dictionary<string, object> parametros) GenerarQueryUpdate() {
        const string query = """
            UPDATE `adv__rol_permiso` 
            SET 
                id_rol_permiso = @Id, 
                id_rol_usuario = @IdRolUsuario, 
                id_permiso = @IdPermiso 
            WHERE id_rol_permiso = @Id;
            """;
        var parametros = new Dictionary<string, object>() {
            { "@Id", Id },
            { "@IdRolUsuario", IdRolUsuario },
            { "@IdPermiso", IdPermiso }
        };

        return (query, parametros);
    }

    public (string query, Dictionary<string, object> parametros) GenerarQueryInsert() {
        const string query = """
            INSERT INTO `adv__rol_permiso` 
            VALUES ( 
                '', 
                @IdRolUsuario, 
                @IdPermiso
            );
            """;
        var parametros = new Dictionary<string, object>() {
            { "@IdRolUsuario", IdRolUsuario },
            { "@IdPermiso", IdPermiso }
        };

        return (query, parametros);
    }

    public (string query, Dictionary<string, object> parametros) GenerarQueryDelete() {
        const string query = """
            DELETE FROM `adv__rol_permiso` 
            WHERE id_rol_permiso = @Id;
            """;
        var parametros = new Dictionary<string, object>() {
            { "@Id", Id }
        };

        return (query, parametros);
    }

    #endregion
}

public enum CriterioBusquedaPermisoRolUsuario {
    Todos,
    Id
}