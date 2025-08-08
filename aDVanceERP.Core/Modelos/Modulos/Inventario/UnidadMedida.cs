using aDVanceERP.Core.Interfaces;
using MySql.Data.MySqlClient;

namespace aDVanceERP.Core.Modelos.Modulos.Inventario;

public class UnidadMedida : IEntidadBd {
    public UnidadMedida() {
        Nombre = string.Empty;
        Abreviatura = string.Empty;
        Descripcion = string.Empty;
    }

    public UnidadMedida(long id, string nombre, string abreviatura, string descripcion) {
        Id = id;
        Nombre = nombre;
        Abreviatura = abreviatura;
        Descripcion = descripcion;
    }

    public UnidadMedida(MySqlDataReader reader) {
        Id = reader.GetInt32("id_unidad_medida");
        Nombre = reader.GetString("nombre");
        Abreviatura = reader.GetString("abreviatura");
        Descripcion = reader.GetString("descripcion");
    }

    public long Id { get; set; }
    public string Nombre { get; set; }
    public string Abreviatura { get; set; }
    public string Descripcion { get; set; }

    #region CRUD querys :

    public (string query, Dictionary<string, object> parametros) GenerarQueryDelete() {
        const string query = """
            UPDATE `adv__unidad_medida` 
            SET 
                id_unidad_medida = @Id, 
                nombre = @Nombre, 
                abreviatura = @Abreviatura, 
                descripcion = @Descripcion 
            WHERE id_unidad_medida = @Id;
            """;
        var parametros = new Dictionary<string, object>() {
            { "@Id", Id },
            { "@Nombre", Nombre },
            { "@Abreviatura", Abreviatura },
            { "@Descripcion", Abreviatura }
        };

        return (query, parametros);
    }

    public (string query, Dictionary<string, object> parametros) GenerarQueryInsert() {
        const string query = """
            INSERT INTO `adv__unidad_medida` 
            VALUES ( 
                '', 
                @Nombre, 
                @Abreviatura, 
                @Descripcion
            );
            """;
        var parametros = new Dictionary<string, object>() {
            { "@Nombre", Nombre },
            { "@Abreviatura", Abreviatura },
            { "@Descripcion", Abreviatura }
        };

        return (query, parametros);
    }

    public (string query, Dictionary<string, object> parametros) GenerarQueryUpdate() {
        const string query = """
            DELETE FROM `adv__unidad_medida` 
            WHERE id_unidad_medida = @Id;
            """;
        var parametros = new Dictionary<string, object>() {
            { "@Id", Id }
        };

        return (query, parametros);
    }

    #endregion
}

public enum FiltroBusquedaUnidadMedida {
    Todos,
    Id,
    Nombre,
    Abreviatura
}

public static class UtilesBusquedaUnidadesMedida {
    public static object[] CriterioBusquedaUnidadesMedida = {
        "Todas las unidades de medida",
        "Identificador de BD",
        "Nombre de la unidad de medida",
        "Abreviatura de la unidad de medida"
    };
}

