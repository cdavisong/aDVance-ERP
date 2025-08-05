using aDVanceERP.Core.Interfaces.Comun;

using MySql.Data.MySqlClient;

namespace aDVanceERP.Core.Modelos.Modulos.Seguridad;

public class CuentaUsuario : IEntidadBd {
    public CuentaUsuario() { 
        Nombre = string.Empty;
        PasswordHash = string.Empty;
        PasswordSalt = string.Empty;
    }

    public CuentaUsuario(long id, string nombre, string passwordHash, string passwordSalt, long idRolUsuario) {
        Id = id;
        Nombre = nombre;
        PasswordHash = passwordHash;
        PasswordSalt = passwordSalt;
        IdRolUsuario = idRolUsuario;
        Administrador = false;
        Aprobado = false;
    }

    public CuentaUsuario(MySqlDataReader reader) {
        Id = reader.GetInt32("id_cuenta_usuario");
        Nombre = reader.GetString("nombre");
        PasswordHash = reader.GetString("password_hash");
        PasswordSalt = reader.GetString("password_salt");
        IdRolUsuario = reader.GetInt32("id_rol_usuario");
        Administrador = reader.GetBoolean("administrador");
        Aprobado = reader.GetBoolean("aprobado");
    }

    public long Id { get; set; }
    public string Nombre { get; }
    public string PasswordHash { get; private set; }
    public string PasswordSalt { get; private set; }
    public long IdRolUsuario { get; set; }
    public bool Administrador { get; set; }
    public bool Aprobado { get; set; }

    #region CRUD querys :

    public (string query, Dictionary<string, object> parametros) GenerarQueryUpdate() {
        const string query = """
            UPDATE `adv__cuenta_usuario` 
            SET 
                id_cuenta_usuario = @Id, 
                nombre = @Nombre, 
                password_hash = @PasswordHash, 
                password_salt = @PasswordSalt, 
                id_rol_usuario = @IdRolUsuario, 
                administrador = @Administrador, 
                aprobado = @Aprobado 
            WHERE id_cuenta_usuario = @Id;
            """;
        var parametros = new Dictionary<string, object>() {
            { "@Id", Id },
            { "@Nombre", Nombre },
            { "@PasswordHash", PasswordHash },
            { "@PasswordSalt", PasswordSalt },
            { "@IdRolUsuario", IdRolUsuario },
            { "@Administardor", Administrador ? 1 : 0 },
            { "@Aprobado", Aprobado ? 1 : 0 }
        };

        return (query, parametros);
    }

    public (string query, Dictionary<string, object> parametros) GenerarQueryInsert() {
        const string query = """
            INSERT INTO `adv__cuenta_usuario` 
            VALUES ( 
                '', 
                @Nombre, 
                @PasswordHash, 
                @PasswordSalt, 
                @IdRolUsuario, 
                @Administrador, 
                @Aprobado
            );
            """;
        var parametros = new Dictionary<string, object>() {
            { "@Nombre", Nombre },
            { "@PasswordHash", PasswordHash },
            { "@PasswordSalt", PasswordSalt },
            { "@IdRolUsuario", IdRolUsuario },
            { "@Administardor", Administrador ? 1 : 0 },
            { "@Aprobado", Aprobado ? 1 : 0 }
        };

        return (query, parametros);
    }

    public (string query, Dictionary<string, object> parametros) GenerarQueryDelete() {
        const string query = """
            DELETE FROM `adv__cuenta_usuario` 
            WHERE id_cuenta_usuario = @Id;
            """;
        var parametros = new Dictionary<string, object>() {
            { "@Id", Id }
        };

        return (query, parametros);
    }

    #endregion
}

public enum CriterioBusquedaCuentaUsuario {
    Todos,
    Nombre,
    Rol
}

public static class UtilesBusquedaCuentaUsuario {
    public static string[] CriterioBusquedaBusquedaCuentaUsuario = {
        "Todos los usuarios",
        "Identificador de BD",
        "Nombre del usuario",
        "Rol de usuario"
    };
}