using aDVanceERP.Core.Interfaces;
using MySql.Data.MySqlClient;

namespace aDVanceERP.Core.Modelos.Modulos.Seguridad;

public class PermisoCuentaUsuario : IEntidadBd {
    public PermisoCuentaUsuario() { 
        Nombre = string.Empty;
    }

    public PermisoCuentaUsuario(long id, long idModuloAplicacion, string nombre) {
        Id = id;
        IdModuloAplicacion = idModuloAplicacion;
        Nombre = nombre;
    }

    public PermisoCuentaUsuario(MySqlDataReader reader) {
        Id = reader.GetInt32("id_permiso");
        IdModuloAplicacion = reader.GetInt32("id_modulo");
        Nombre = reader.GetString("nombre");
    }

    public long Id { get; set; }
    public long IdModuloAplicacion { get; }
    public string Nombre { get; }

    #region CRUD querys :

    public (string query, Dictionary<string, object> parametros) GenerarQueryUpdate() {
        const string query = """
            UPDATE `adv__permiso` 
            SET 
                id_permiso = @Id, 
                id_modulo = @IdModuloAplicacion, 
                nombre = @Nombre 
            WHERE id_permiso = @Id;
            """;
        var parametros = new Dictionary<string, object>() {
            { "@Id", Id },
            { "@IdModuloAplicacion", IdModuloAplicacion },
            { "@Nombre", Nombre }
        };

        return (query, parametros);
    }

    public (string query, Dictionary<string, object> parametros) GenerarQueryInsert() {
        const string query = """
            INSERT INTO `adv__permiso` 
            VALUES ( 
                '', 
                @IdModuloAplicacion, 
                @Nombre
            );
            """;
        var parametros = new Dictionary<string, object>() {
            { "@IdModuloAplicacion", IdModuloAplicacion },
            { "@Nombre", Nombre }
        };

        return (query, parametros);
    }

    public (string query, Dictionary<string, object> parametros) GenerarQueryDelete() {
        const string query = """
            DELETE FROM `adv__permiso` 
            WHERE id_permiso = @Id;
            """;
        var parametros = new Dictionary<string, object>() {
            { "@Id", Id }
        };

        return (query, parametros);
    }

    #endregion
}

public enum CriterioBusquedaPermiso {
    Todos,
    Id,
    Nombre
}

public static class UtilesBusquedaPermiso {
    public static string[] CriterioBusquedaBusquedaPermiso = {
        "Todos los permisos",
        "Identificador de BD",
        "Nombre del permiso"
    };
}