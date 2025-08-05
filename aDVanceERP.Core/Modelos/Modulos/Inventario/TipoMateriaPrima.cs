using aDVanceERP.Core.Interfaces.Comun;

using MySql.Data.MySqlClient;

namespace aDVanceERP.Core.Modelos.Modulos.Inventario;

public class TipoMateriaPrima : IEntidadBd {
    public TipoMateriaPrima() {
        Nombre = string.Empty;
        Descripcion = string.Empty;
    }

    public TipoMateriaPrima(long id, string nombre, string descripcion) {
        Id = id;
        Nombre = nombre;
        Descripcion = descripcion;
    }

    public TipoMateriaPrima(MySqlDataReader reader) {
        Id = reader.GetInt32("id_tipo_materia_prima");
        Nombre = reader.GetString("nombre");
        Descripcion = reader.GetString("descripcion");
    }

    public long Id { get; set; }
    public string Nombre { get; set; }
    public string Descripcion { get; set; }

    #region CRUD querys :

    public (string query, Dictionary<string, object> parametros) GenerarQueryUpdate() {
        const string query = """
            UPDATE `adv__tipo_materia_prima` 
            SET 
                id_tipo_materia_prima = @Id, 
                nombre = @Nombre, 
                descripcion = @Descripcion 
            WHERE id_tipo_materia_prima = @Id;
            """;
        var parametros = new Dictionary<string, object>() {
            { "@Id", Id },
            { "@Nombre", Nombre },
            { "@Descripcion", Descripcion }
        };

        return (query, parametros);
    }

    public (string query, Dictionary<string, object> parametros) GenerarQueryInsert() {
        const string query = """
            INSERT INTO `adv__tipo_materia_prima` 
            VALUES ( 
                '', 
                @Nombre, 
                @Descripcion
            );
            """;
        var parametros = new Dictionary<string, object>() {
            { "@Nombre", Nombre },
            { "@Descripcion", Descripcion }
        };

        return (query, parametros);
    }

    public (string query, Dictionary<string, object> parametros) GenerarQueryDelete() {
        const string query = """
            DELETE FROM `adv__tipo_materia_prima` 
            WHERE id_tipo_materia_prima = @Id;
            """;
        var parametros = new Dictionary<string, object>() {
            { "@Id", Id }
        };

        return (query, parametros);
    }

    #endregion
}

public enum CriterioBusquedaTipoMateriaPrima {
    Todos,
    Id,
    Nombre
}

public static class UtilesBusquedaTiposMateriasPrimas {
    public static object[] CriterioBusquedaTiposProducto = {
        "Todos los tipos de materias primas",
        "Identificador de BD",
        "Nombre del tipo de materia prima"
    };
}