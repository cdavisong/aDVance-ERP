using aDVanceERP.Core.Interfaces.Comun;
using MySql.Data.MySqlClient;
using System.Globalization;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace aDVanceERP.Core.Modelos.Modulos.Seguridad;

public class SesionUsuario : IEntidadBd {
    public SesionUsuario() { 
        Token = string.Empty;
    }

    public SesionUsuario(long id, int idCuentaUsuario, string token, DateTime fechaInicio) {
        Id = id;
        IdCuentaUsuario = idCuentaUsuario;
        Token = token;
        FechaInicio = fechaInicio;
    }

    public SesionUsuario(MySqlDataReader reader) {
        Id = reader.GetInt32("id_sesion_usuario");
        IdCuentaUsuario = reader.GetInt32("id_cuenta_usuario");
        Token = reader.GetString("token");
        FechaInicio = reader.GetDateTime("fecha_inicio");
        FechaFin = reader.GetDateTime("fecha_fin");
    }

    public long Id { get; set; }
    public int IdCuentaUsuario { get; set; }
    public string Token { get; set; }
    public DateTime FechaInicio { get; set; }
    public DateTime FechaFin { get; set; }

    #region CRUD querys :

    public (string query, Dictionary<string, object> parametros) GenerarQueryUpdate() {
        const string query = """
            UPDATE `adv__sesion_usuario` 
            SET 
                id_sesion_usuario = @Id, 
                id_cuenta_usuario = @IdCuentaUsuario, 
                token = @Token, 
                fecha_inicio = @FechaInicio, 
                fecha_fin = @FechaFin 
            WHERE id_sesion_usuario = @Id;
            """;
        var parametros = new Dictionary<string, object>() {
            { "@Id", Id },
            { "@IdCuentaUsuario", IdCuentaUsuario },
            { "@Token", Token },
            { "@FechaInicio", FechaInicio.ToString("yyyy-MM-dd HH:mm:ss", CultureInfo.InvariantCulture) },
            { "@FechaFin", FechaFin.ToString("yyyy-MM-dd HH:mm:ss", CultureInfo.InvariantCulture) }
        };

        return (query, parametros);
    }

    public (string query, Dictionary<string, object> parametros) GenerarQueryInsert() {
        const string query = """
            INSERT INTO `adv__sesion_usuario` 
            VALUES ( 
                '', 
                @IdCuentaUsuario, 
                @Token, 
                @FechaInicio, 
                @FechaFin
            );
            """;
        var parametros = new Dictionary<string, object>() {
            { "@IdCuentaUsuario", IdCuentaUsuario },
            { "@Token", Token },
            { "@FechaInicio", FechaInicio.ToString("yyyy-MM-dd HH:mm:ss", CultureInfo.InvariantCulture) },
            { "@FechaFin", FechaFin.ToString("yyyy-MM-dd HH:mm:ss", CultureInfo.InvariantCulture) }
        };

        return (query, parametros);
    }

    public (string query, Dictionary<string, object> parametros) GenerarQueryDelete() {
        const string query = """
            DELETE FROM `adv__sesion_usuario` 
            WHERE id_sesion_usuario = @Id;
            """;
        var parametros = new Dictionary<string, object>() {
            { "@Id", Id }
        };

        return (query, parametros);
    }

    #endregion
}

public enum CriterioBusquedaSesionUsuario {
    Todos,
    NombreUsuario,
    SesionActiva
}

public static class UtilesBusquedaSesionUsuario {
    public static string[] CriterioBusquedaBusquedaSesionUsuario = {
        "Todas las sesiones",
        "Identificador de BD",
        "Nombre del usuario",
        "Sesión activa"
    };
}