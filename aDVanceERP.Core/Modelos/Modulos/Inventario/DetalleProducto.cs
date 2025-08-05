using aDVanceERP.Core.Interfaces.Comun;

using MySql.Data.MySqlClient;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace aDVanceERP.Core.Modelos.Modulos.Inventario;

public class DetalleProducto : IEntidadBd {
    public DetalleProducto() {
        Descripcion = "No hay descripción disponible";
    }

    public DetalleProducto(long id, long idUnidadMedida, string descripcion) {
        Id = id;
        IdUnidadMedida = idUnidadMedida;
        Descripcion = descripcion ?? "No hay descripción disponible";
    }

    public DetalleProducto(MySqlDataReader reader) {
        Id = reader.GetInt32("id_detalle_producto");
        IdUnidadMedida = reader.GetInt32("id_unidad_medida");
        Descripcion = reader.GetString("descripcion");
    }

    public long Id { get; set; }
    public long IdUnidadMedida { get; set; }
    public string? Descripcion { get; set; }

    #region CRUD querys :

    public (string query, Dictionary<string, object> parametros) GenerarQueryUpdate() {
        const string query = """
            UPDATE `adv__detalle_producto` 
            SET 
                id_detalle_producto = @Id, 
                id_unidad_medida = @IdUnidadMedida, 
                descripcion = @Descripcion' 
            WHERE id_detalle_producto = @Id;
            """;
        var parametros = new Dictionary<string, object>() {
            { "@Id", Id },
            { "@IdUnidadMedida", IdUnidadMedida },
            { "@Descripcion", Descripcion }
        };

        return (query, parametros);
    }

    public (string query, Dictionary<string, object> parametros) GenerarQueryInsert() {
        const string query = """
            INSERT INTO `adv__detalle_producto` 
            VALUES ( 
                '',
                @IdUnidadMedida, 
                @Descripcion
            );
            """;
        var parametros = new Dictionary<string, object>() {
            { "@IdUnidadMedida", IdUnidadMedida },
            { "@Descripcion", Descripcion }
        };

        return (query, parametros);
    }

    public (string query, Dictionary<string, object> parametros) GenerarQueryDelete() {
        const string query = """
            DELETE FROM `adv__detalle_producto` 
            WHERE id_detalle_producto = @Id;
            """;
        var parametros = new Dictionary<string, object>() {
            { "@Id", Id }
        };

        return (query, parametros);
    }

    #endregion
}

public enum CriterioBusquedaDetalleProducto {
    Todos,
    Id,
    UnidadMedida,
    Descripcion
}

public static class UtilesBusquedaDetallesProducto {
    public static object[] CriterioBusquedaDetallesProducto = {
        "Todos los detalles de productos",
        "Identificador de BD",
        "Unidad de medida del producto",
        "Descripción del producto"
    };
}
