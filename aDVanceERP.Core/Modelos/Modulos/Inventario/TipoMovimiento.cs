using aDVanceERP.Core.Interfaces.Comun;

using MySql.Data.MySqlClient;

namespace aDVanceERP.Core.Modelos.Modulos.Inventario;

public class TipoMovimiento : IEntidadBd {
    public TipoMovimiento() {
        Nombre = string.Empty;
        Efecto = EfectoMovimiento.Ninguno;
    }

    public TipoMovimiento(long id, string nombre, EfectoMovimiento efecto) {
        Id = id;
        Nombre = nombre;
        Efecto = efecto;
    }

    public TipoMovimiento(MySqlDataReader reader) {
        Id = reader.GetInt32("id_tipo_movimiento");
        Nombre = reader.GetString("nombre");
        Efecto = Enum.TryParse(reader.GetString("efecto"), true, out EfectoMovimiento efecto) ? efecto : EfectoMovimiento.Ninguno;
    }

    public long Id { get; set; }
    public string Nombre { get; set; }
    public EfectoMovimiento Efecto { get; set; }

    #region CRUD querys :

    public (string query, Dictionary<string, object> parametros) GenerarQueryUpdate() {
        const string query = """
            UPDATE `adv__tipo_movimiento` 
            SET 
                id_tipo_movimiento = @Id, 
                nombre = @Nombre, 
                efecto = @Efecto 
            WHERE id_tipo_movimiento = @Id;
            """;
        var parametros = new Dictionary<string, object>() {
            { "@Id", Id },
            { "@Nombre", Nombre },
            { "@Efecto", Efecto.ToString() }
        };

        return (query, parametros);
    }

    public (string query, Dictionary<string, object> parametros) GenerarQueryInsert() {
        const string query = """
            INSERT INTO `adv__tipo_movimiento` 
            VALUES ( 
                '', 
                @Nombre, 
                @Efecto
            );
            """;
        var parametros = new Dictionary<string, object>() {
            { "@Nombre", Nombre },
            { "@Efecto", Efecto.ToString() }
        };

        return (query, parametros);
    }

    public (string query, Dictionary<string, object> parametros) GenerarQueryDelete() {
        const string query = """
            DELETE FROM `adv__tipo_movimiento` 
            WHERE id_tipo_movimiento = @Id;
            """;
        var parametros = new Dictionary<string, object>() {
            { "@Id", Id }
        };

        return (query, parametros);
    }

    #endregion
}

public enum CriterioBusquedaTipoMovimiento {
    Todos,
    Id,
    Nombre
}

public static class UtilesBusquedaTipoMovimiento {
    public static string[] CriterioBusquedaTipoMovimiento = {
        "Todos los tipos de movimiento",
        "Identificador de BD",
        "Nombre del movimiento"
    };
}