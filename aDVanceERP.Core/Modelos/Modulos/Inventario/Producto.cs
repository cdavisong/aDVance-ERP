using aDVanceERP.Core.Interfaces.Comun;

using MySql.Data.MySqlClient;
using System.Globalization;

namespace aDVanceERP.Core.Modelos.Modulos.Inventario;

public class Producto : IEntidadBd {
    public Producto() {
        Categoria = CategoriaProducto.Mercancia;
        Nombre = "Producto genérico";
        Codigo = string.Empty;
    }

    public Producto(long id, CategoriaProducto categoria, string nombre, string codigo, long idDetalleProducto, long idProveedor,
        long idTipoMateriaPrima, bool esVendible, decimal precioCompra, decimal costoProduccionUnitario, decimal precioVentaBase) {
        Id = id;
        Categoria = categoria;
        Nombre = nombre;
        Codigo = codigo;
        IdDetalleProducto = idDetalleProducto;
        IdProveedor = idProveedor;
        IdTipoMateriaPrima = idTipoMateriaPrima;
        EsVendible = esVendible;
        PrecioCompra = precioCompra;
        CostoProduccionUnitario = costoProduccionUnitario;
        PrecioVentaBase = precioVentaBase;
    }

    public Producto(MySqlDataReader reader) {
        Id = reader.GetInt32("id_producto");
        Categoria = Enum.TryParse(reader.GetString("categoria"), true, out CategoriaProducto categoria) ? categoria : CategoriaProducto.Mercancia;
        Codigo = reader.GetString("codigo");
        Nombre = reader.GetString("nombre");
        IdDetalleProducto = reader.GetInt32("id_detalle_producto");
        IdProveedor = reader.GetInt32("id_proveedor");
        IdTipoMateriaPrima = reader.GetInt32("id_tipo_materia_prima");
        EsVendible = reader.GetBoolean("es_vendible");
        PrecioCompra = reader.GetDecimal("precio_compra");
        CostoProduccionUnitario = reader.GetDecimal("costo_produccion_unitario");
        PrecioVentaBase = reader.GetDecimal("precio_venta_base");
    }

    public long Id { get; set; }
    public CategoriaProducto Categoria { get; set; }
    public string Nombre { get; set; }
    public string Codigo { get; }
    public long IdDetalleProducto { get; set; }
    public long IdProveedor { get; set; }
    public long IdTipoMateriaPrima { get; set; } = 0; // Solo para materias primas
    public bool EsVendible { get; set; } = true;
    public decimal PrecioCompra { get; }
    public decimal CostoProduccionUnitario { get; } = 0.0m; // Solo para productos terminados
    public decimal PrecioVentaBase { get; }

    #region CRUD querys :

    public (string query, Dictionary<string, object> parametros) GenerarQueryUpdate() {
        const string query = """
            UPDATE `adv__producto` 
            SET 
                id_producto = @Id, 
                categoria = @Categoria, 
                codigo = @Codigo, 
                nombre = @Nombre, 
                id_detalle_producto = @IdDetalleProducto, 
                id_proveedor = @IdProveedor, 
                id_tipo_materia_prima = @IdTipoMateriaPrima, 
                es_vendible = @EsVendible, 
                precio_compra = @PrecioCompra, 
                costo_produccion_unitario = @CostoProduccionUnitario, 
                precio_venta_base = @PrecioVentaBase 
            WHERE id_producto = @Id;
            """;
        var parametros = new Dictionary<string, object>() {
            { "@Id", Id },
            { "@Categoria", Categoria.ToString() },
            { "@Codigo", Codigo },
            { "@Nombre", Nombre },
            { "@IdDetalleProducto", IdDetalleProducto },
            { "@IdProveedor", IdProveedor },
            { "@IdTipoMateriaPrima", IdTipoMateriaPrima },
            { "@EsVendible", EsVendible ? 1 : 0 },
            { "@PrecioCompra", PrecioCompra.ToString("N2", CultureInfo.InvariantCulture) },
            { "@CostoProduccionUnitario", CostoProduccionUnitario.ToString("N2", CultureInfo.InvariantCulture) },
            { "@PrecioVentaBase", PrecioVentaBase.ToString("N2", CultureInfo.InvariantCulture) }
        };

        return (query, parametros);
    }

    public (string query, Dictionary<string, object> parametros) GenerarQueryInsert() {
        const string query = """
            INSERT INTO `adv__producto` 
            VALUES ( 
                '',
                @Categoria, 
                @Codigo, 
                @Nombre, 
                @IdDetalleProducto, 
                @IdProveedor, 
                @IdTipoMateriaPrima, 
                @EsVendible, 
                @PrecioCompra, 
                @CostoProduccionUnitario, 
                @PrecioVentaBase
            );
            """;
        var parametros = new Dictionary<string, object>() {
            { "@Categoria", Categoria.ToString() },
            { "@Codigo", Codigo },
            { "@Nombre", Nombre },
            { "@IdDetalleProducto", IdDetalleProducto },
            { "@IdProveedor", IdProveedor },
            { "@IdTipoMateriaPrima", IdTipoMateriaPrima },
            { "@EsVendible", EsVendible ? 1 : 0 },
            { "@PrecioCompra", PrecioCompra.ToString("N2", CultureInfo.InvariantCulture) },
            { "@CostoProduccionUnitario", CostoProduccionUnitario.ToString("N2", CultureInfo.InvariantCulture) },
            { "@PrecioVentaBase", PrecioVentaBase.ToString("N2", CultureInfo.InvariantCulture) }
        };

        return (query, parametros);
    }

    public (string query, Dictionary<string, object> parametros) GenerarQueryDelete() {
        const string query = """
            DELETE FROM `adv__producto` 
            WHERE id_producto = @Id;
            """;
        var parametros = new Dictionary<string, object>() {
            { "@Id", Id }
        };

        return (query, parametros);
    }

    #endregion
}

public enum CriterioBusquedaProducto {
    Todos,
    Id,
    Codigo,
    Nombre,
    Descripcion
}

public static class UtilesBusquedaProducto {
    public static object[] CriterioBusquedaProducto = {
        "Todos los productos",
        "Identificador de BD",
        "Código del producto",
        "Nombre del producto",
        "Descripción del producto"
    };
}

