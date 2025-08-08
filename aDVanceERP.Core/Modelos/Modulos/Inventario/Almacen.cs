using aDVanceERP.Core.Interfaces;
using MySql.Data.MySqlClient;

namespace aDVanceERP.Core.Modelos.Modulos.Inventario;

public class Almacen : IEntidadBd {
    public Almacen() { 
        Nombre = string.Empty;
        Direccion = string.Empty;
        Notas = "No hay notas disponibles";
    }

    public Almacen(long idAlmacen, string nombre, string direccion, bool autorizoVenta, string notas) {
        Id = idAlmacen;
        Nombre = nombre;
        Direccion = direccion;
        AutorizoVenta = autorizoVenta;
        Notas = notas ?? "No hay notas disponibles";
    }

    public Almacen(MySqlDataReader reader) {
        Id = reader.GetInt32("id_almacen");
        Nombre = reader.GetString("nombre");
        Direccion = reader.GetString("direccion");
        AutorizoVenta = reader.GetBoolean("autorizo_venta");
        Notas = reader.GetString("notas");
    }

    public long Id { get; set; }
    public string? Nombre { get; }
    public string? Direccion { get; }
    public bool AutorizoVenta { get; }
    public string? Notas { get; set; }

    #region CRUD querys :

    public (string query, Dictionary<string, object> parametros) GenerarQueryUpdate() {
        const string query = """
            UPDATE `adv__almacen` 
            SET 
                id_almacen = @Id, 
                nombre = @Nombre, 
                direccion = @Direccion, 
                autorizo_venta = @AutorizoVenta, 
                notas = @Notas 
            WHERE id_almacen = @Id;
            """;
        var parametros = new Dictionary<string, object>() {
            { "@Id", Id },
            { "@Nombre", Nombre },
            { "@Direccion", Direccion },
            { "@AutorizoVenta", AutorizoVenta ? 1 : 0 },
            { "@Notas", Notas }
        };

        return (query, parametros);
    }

    public (string query, Dictionary<string, object> parametros) GenerarQueryInsert() {
        const string query = """
            INSERT INTO `adv__almacen` 
            VALUES ( 
                '',
                @Nombre, 
                @Direccion, 
                @AutorizoVenta, 
                @Notas
            );
            """;
        var parametros = new Dictionary<string, object>() {
            { "@Nombre", Nombre },
            { "@Direccion", Direccion },
            { "@AutorizoVenta", AutorizoVenta ? 1 : 0 },
            { "@Notas", Notas }
        };

        return (query, parametros);
    }

    public (string query, Dictionary<string, object> parametros) GenerarQueryDelete() {
        const string query = """
            DELETE FROM `adv__almacen` 
            WHERE id_almacen = @Id;
            """;
        var parametros = new Dictionary<string, object>() {
            { "@Id", Id }
        };

        return (query, parametros);
    }

    #endregion
}

public enum CriterioBusquedaAlmacen {
    Todos,
    Id,
    Nombre
}

public static class UtilesBusquedaAlmacen {
    public static object[] CriterioBusquedaAlmacen = {
        "Todos los almacenes",
        "Identificador de BD",
        "Nombre del almacén"
    };
}