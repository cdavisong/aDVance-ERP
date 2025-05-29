using aDVanceERP.Core.MVP.Modelos.Repositorios;
using aDVanceERP.Modulos.Inventario.MVP.Modelos.Repositorios.Plantillas;
using MySql.Data.MySqlClient;

namespace aDVanceERP.Modulos.Inventario.MVP.Modelos.Repositorios;

public class DatosProducto : RepositorioDatosBase<Producto, CriterioBusquedaProducto>, IRepositorioProducto {
    public override string ComandoCantidad() {
        return "SELECT COUNT(id_producto) FROM adv__producto;";
    }

    public override string ComandoAdicionar(Producto objeto) {
        return $"""
                INSERT INTO adv__producto (
                    codigo,
                    categoria,
                    nombre,
                    id_detalle_producto,
                    id_proveedor,
                    es_vendible,
                    precio_compra_base,
                    precio_venta_base
                )
                VALUES (
                    '{objeto.Codigo}',
                    '{objeto.Categoria.ToString()}',
                    '{objeto.Nombre}',
                    '{objeto.IdDetalleProducto}',
                    '{objeto.IdProveedor}',
                    {(objeto.EsVendible ? 1 : 0)},
                    '{objeto.PrecioCompraBase}',
                    '{objeto.PrecioVentaBase}'
                );
                """;
    }

    public override string ComandoEditar(Producto objeto) {
        return $"""
                UPDATE adv__producto
                SET
                    codigo='{objeto.Codigo}',
                    categoria='{objeto.Categoria.ToString()}',
                    nombre='{objeto.Nombre}',
                    id_detalle_producto='{objeto.IdDetalleProducto}',
                    id_proveedor='{objeto.IdProveedor}',
                    es_vendible={(objeto.EsVendible ? 1 : 0)},
                    precio_compra_base='{objeto.PrecioCompraBase}',
                    precio_venta_base='{objeto.PrecioVentaBase}'
                WHERE id_producto={objeto.Id};
                """;
    }

    public override string ComandoEliminar(long id) {
        return $"""
            DELETE FROM adv__detalle_producto
            WHERE id_detalle_producto = (
                SELECT id_detalle_producto 
                FROM adv__producto 
                WHERE id_producto={id}
            );

            DELETE FROM adv__producto 
            WHERE id_producto={id};
            """;
    }

    public override string ComandoObtener(CriterioBusquedaProducto criterio, string dato) {
        if (string.IsNullOrEmpty(dato))
            dato = "Todos";

        string? comando;
        var datoMultiple = dato.Split(';');
        var todosLosAlmacenes = datoMultiple.Length > 1 && datoMultiple[0].Contains("Todos");
        var aplicarFiltroAlmacen = datoMultiple.Length > 1 && !todosLosAlmacenes;
        const string comandoAdicionalSelect = ", ta.stock, a.nombre AS nombre_almacen";
        const string comandoAdicionalJoin =
            "JOIN adv__producto_almacen ta ON t.id_producto = ta.id_producto JOIN adv__almacen a ON ta.id_almacen = a.id_almacen ";
        var comandoAdicionalWhere = $"AND a.nombre = '{datoMultiple[0]}'";

        switch (criterio) {
            case CriterioBusquedaProducto.Id:
                comando =
                    $"SELECT t.*{(aplicarFiltroAlmacen ? comandoAdicionalSelect : string.Empty)} FROM adv__producto t {(aplicarFiltroAlmacen ? comandoAdicionalJoin : string.Empty)}WHERE t.id_producto='{(datoMultiple.Length > 0 ? datoMultiple[1] : dato)}' {(aplicarFiltroAlmacen ? comandoAdicionalWhere : string.Empty)};";
                break;
            case CriterioBusquedaProducto.Codigo:
                comando =
                    $"SELECT t.*{(aplicarFiltroAlmacen ? comandoAdicionalSelect : string.Empty)} FROM adv__producto t {(aplicarFiltroAlmacen ? comandoAdicionalJoin : string.Empty)}WHERE LOWER(t.codigo) LIKE LOWER('%{(datoMultiple.Length > 0 ? datoMultiple[1] : dato)}%') {(aplicarFiltroAlmacen ? comandoAdicionalWhere : string.Empty)};";
                break;
            case CriterioBusquedaProducto.Nombre:
                comando =
                    $"SELECT t.*{(aplicarFiltroAlmacen ? comandoAdicionalSelect : string.Empty)} FROM adv__producto t {(aplicarFiltroAlmacen ? comandoAdicionalJoin : string.Empty)}WHERE LOWER(t.nombre) LIKE LOWER('%{(datoMultiple.Length > 0 ? datoMultiple[1] : dato)}%') {(aplicarFiltroAlmacen ? comandoAdicionalWhere : string.Empty)};";
                break;
            default:
                comando =
                    $"SELECT t.*{(aplicarFiltroAlmacen ? comandoAdicionalSelect : string.Empty)} FROM adv__producto t {(aplicarFiltroAlmacen ? comandoAdicionalJoin : string.Empty)}{(aplicarFiltroAlmacen ? comandoAdicionalWhere : string.Empty).Replace("AND", "WHERE")};";
                break;
        }

        return comando;
    }

    public override Producto ObtenerObjetoDataReader(MySqlDataReader lectorDatos) {
        return new Producto(
            id: lectorDatos.GetInt32(lectorDatos.GetOrdinal("id_producto")),
            categoria: (CategoriaProducto)Enum.Parse(typeof(CategoriaProducto), lectorDatos.GetValue(lectorDatos.GetOrdinal("categoria")).ToString()),
            nombre: lectorDatos.GetString(lectorDatos.GetOrdinal("nombre")),
            codigo: lectorDatos.GetString(lectorDatos.GetOrdinal("codigo")),            
            idDetalleProducto: lectorDatos.GetInt32(lectorDatos.GetOrdinal("id_detalle_producto")),
            idProveedor: lectorDatos.GetInt32(lectorDatos.GetOrdinal("id_proveedor")),
            esVendible: lectorDatos.GetBoolean(lectorDatos.GetOrdinal("es_vendible")),
            precioCompraBase: lectorDatos.GetDecimal(lectorDatos.GetOrdinal("precio_compra_base")),
            precioVentaBase: lectorDatos.GetDecimal(lectorDatos.GetOrdinal("precio_venta_base"))
        );
    }

    public override string ComandoExiste(string dato) {
        return $"""
            SELECT COUNT(1) 
            FROM adv__producto 
            WHERE codigo='{dato}';
            """;
    }
}