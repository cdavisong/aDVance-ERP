using aDVanceERP.Core.Interfaces;
using MySql.Data.MySqlClient;

namespace aDVanceERP.Core.Modelos.Modulos.Seguridad;

public class RolUsuario : IEntidadBd {
    public RolUsuario() { 
        Nombre = string.Empty;
    }

    public RolUsuario(long id, string nombre) {
        Id = id;
        Nombre = nombre;
    }

    public RolUsuario(MySqlDataReader reader) {
        Id = reader.GetInt32("id_rol_usuario");
        Nombre = reader.GetString("nombre");
    }

    public long Id { get; set; }
    public string Nombre { get; }

    #region CRUD querys :

    public (string query, Dictionary<string, object> parametros) GenerarQueryUpdate() {
        const string query = """
            UPDATE `adv__rol_usuario` 
            SET 
                id_rol_usuario = @Id, 
                nombre = @Nombre 
            WHERE id_rol_usuario = @Id;
            """;
        var parametros = new Dictionary<string, object>() {
            { "@Id", Id },
            { "@Nombre", Nombre }
        };

        return (query, parametros);
    }

    public (string query, Dictionary<string, object> parametros) GenerarQueryInsert() {
        const string query = """
            INSERT INTO `adv__rol_usuario` 
            VALUES ( 
                '', 
                @Nombre
            );
            """;
        var parametros = new Dictionary<string, object>() {
            { "@Nombre", Nombre }
        };

        return (query, parametros);
    }

    public (string query, Dictionary<string, object> parametros) GenerarQueryDelete() {
        const string query = """
            DELETE FROM `adv__rol_usuario` 
            WHERE id_rol_usuario = @Id;
            """;
        var parametros = new Dictionary<string, object>() {
            { "@Id", Id }
        };

        return (query, parametros);
    }

    #endregion
}

public enum CriterioBusquedaRolUsuario {
    Todos,
    Id,
    Nombre
}

public static class UtilesBusquedaRolUsuario {
    public static string[] CriterioBusquedaBusquedaRolUsuario = {
        "Todos los roles",
        "Identificador de BD",
        "Nombre del rol"
    };
}