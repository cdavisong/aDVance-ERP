using aDVanceERP.Core.Interfaces;
using MySql.Data.MySqlClient;
using System.Globalization;

namespace aDVanceERP.Core.Modelos.Modulos.Inventario;

public class Inventario : IEntidadBd {
    public Inventario() {
        UltimaActualizacion = DateTime.Now;
    }

    public Inventario(long idInventario, long idProducto, long idAlmacen, decimal cantidad, decimal costoPromedio, decimal valorTotal) {
        Id = idInventario;
        IdProducto = idProducto;
        IdAlmacen = idAlmacen;
        Cantidad = cantidad;
        CostoPromedio = costoPromedio;
        ValorTotal = valorTotal;
        UltimaActualizacion = DateTime.Now;
    }

    public Inventario(MySqlDataReader reader) {
        Id = reader.GetInt32("id_inventario");
        IdProducto = reader.GetInt32("id_producto");
        IdAlmacen = reader.GetInt32("id_almacen");
        Cantidad = reader.GetDecimal("cantidad");
        CostoPromedio = reader.GetDecimal("costo_promedio");
        ValorTotal = reader.GetDecimal("valor_total");
        UltimaActualizacion = reader.GetDateTime("ultima_actualizacion");
    }

    public long Id { get; set; }
    public long IdProducto { get; set; }
    public long IdAlmacen { get; set; }
    public decimal Cantidad { get; set; }
    public decimal CostoPromedio { get; set; }
    public decimal ValorTotal { get; set; }
    public DateTime UltimaActualizacion { get; set; }

    #region CRUD querys :

    public (string query, Dictionary<string, object> parametros) GenerarQueryUpdate() {
        const string query = """
            UPDATE `adv__inventario` 
            SET 
                id_inventario = @Id, 
                id_producto = @IdProducto, 
                id_almacen = @IdAlmacen, 
                cantidad = @Cantidad, 
                costo_promedio = @CostoPromedio, 
                valor_total = @ValorTotal, 
                ultima_actualizacion = @UltimaActualizacion
            WHERE id_inventario= @Id;
            """;
        var parametros = new Dictionary<string, object>() {
            { "@Id", Id },
            { "@IdProducto", IdProducto },
            { "@IdAlmacen", IdAlmacen },
            { "@Cantidad", Cantidad.ToString("N2", CultureInfo.InvariantCulture) },
            { "@CostoPromedio", CostoPromedio.ToString("N2", CultureInfo.InvariantCulture) },
            { "@ValorTotal", ValorTotal.ToString("N2", CultureInfo.InvariantCulture) },
            { "@UltimaActualizacion", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss", CultureInfo.InvariantCulture) }
        };

        return (query, parametros);
    }

    public (string query, Dictionary<string, object> parametros) GenerarQueryInsert() {
        const string query = """
            INSERT INTO `adv__inventario` 
            VALUES ( 
                '',
                @IdProducto, 
                @IdAlmacen, 
                @Cantidad, 
                @CostoPromedio, 
                @ValorTotal, 
                @UltimaActualizacion
            );
            """;
        var parametros = new Dictionary<string, object>() {
            { "@IdProducto", IdProducto },
            { "@IdAlmacen", IdAlmacen },
            { "@Cantidad", Cantidad.ToString("N2", CultureInfo.InvariantCulture) },
            { "@CostoPromedio", CostoPromedio.ToString("N2", CultureInfo.InvariantCulture) },
            { "@ValorTotal", ValorTotal.ToString("N2", CultureInfo.InvariantCulture) },
            { "@UltimaActualizacion", UltimaActualizacion.ToString("yyyy-MM-dd HH:mm:ss", CultureInfo.InvariantCulture) }
        };

        return (query, parametros);
    }

    public (string query, Dictionary<string, object> parametros) GenerarQueryDelete() {
        const string query = """
            DELETE FROM `adv__inventario` 
            WHERE id_inventario= @Id;
            """;
        var parametros = new Dictionary<string, object>() {
            { "@Id", Id }
        };

        return (query, parametros);
    }

    #endregion
}

public enum CriterioBusquedaInventario {
    Todos,
    Id,
    IdProducto,
    IdAlmacen
}