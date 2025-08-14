using aDVanceERP.Core.Repositorios.BD;
using aDVanceERP.Modulos.Inventario.MVP.Modelos;
using aDVanceERP.Modulos.Inventario.Repositorios.Plantillas;
using MySql.Data.MySqlClient;
using System.Globalization;

namespace aDVanceERP.Modulos.Inventario.Repositorios;

public class DatosProducto : RepoEntidadBaseDatos<Producto, FiltroBusquedaProducto>, IRepositorioProducto
{
    public override string ComandoCantidad()
    {
        return "SELECT COUNT(id_producto) FROM adv__producto;";
    }

    public override string GenerarComandoInsertar(Producto objeto)
    {
        return $"""
                INSERT INTO adv__producto (
                    codigo,
                    categoria,
                    nombre,
                    id_detalle_producto,
                    id_proveedor,
                    id_tipo_materia_prima,
                    es_vendible,
                    precio_compra,
                    costo_produccion_unitario,
                    precio_venta_base
                )
                VALUES (
                    '{objeto.Codigo}',
                    '{objeto.Categoria}',
                    '{objeto.Nombre}',
                    {objeto.IdDetalleProducto},
                    {objeto.IdProveedor},
                    {objeto.IdTipoMateriaPrima},
                    '{(objeto.EsVendible ? 1 : 0)}',
                    {objeto.PrecioCompra.ToString(CultureInfo.InvariantCulture)},
                    {objeto.CostoProduccionUnitario.ToString(CultureInfo.InvariantCulture)},
                    {objeto.PrecioVentaBase.ToString(CultureInfo.InvariantCulture)}
                );
                """;
    }

    public override string GenerarComandoActualizar(Producto objeto)
    {
        return $"""
                UPDATE adv__producto
                SET
                    codigo='{objeto.Codigo}',
                    categoria='{objeto.Categoria}',
                    nombre='{objeto.Nombre}',
                    id_detalle_producto={objeto.IdDetalleProducto},
                    id_proveedor={objeto.IdProveedor},
                    id_tipo_materia_prima={objeto.IdTipoMateriaPrima},
                    es_vendible='{(objeto.EsVendible ? 1 : 0)}',
                    precio_compra={objeto.PrecioCompra.ToString(CultureInfo.InvariantCulture)},
                    costo_produccion_unitario={objeto.CostoProduccionUnitario.ToString(CultureInfo.InvariantCulture)},
                    precio_venta_base={objeto.PrecioVentaBase.ToString(CultureInfo.InvariantCulture)}
                WHERE id_producto={objeto.Id};
                """;
    }

    public override string ComandoEliminar(long id)
    {
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

    public override string GenerarClausulaWhere(FiltroBusquedaProducto criterio, string dato)
    {
        if (string.IsNullOrEmpty(dato))
            dato = "Todos";

        string? comando;
        var datoMultiple = dato.Split(';');

        // Procesamiento de parámetros
        var todosLosAlmacenes = datoMultiple.Length > 1 && datoMultiple[0].Contains("Todos");
        var todasLasCategorias = datoMultiple.Length > 2 && datoMultiple[1].Equals("-1");
        var aplicarFiltroAlmacen = datoMultiple.Length > 1 && !todosLosAlmacenes;
        var aplicarFiltroCategoria = datoMultiple.Length > 2 && !todasLasCategorias;

        // Partes adicionales de la consulta
        const string comandoAdicionalSelect = ", ta.cantidad, a.nombre AS nombre_almacen";
        const string comandoAdicionalJoin = "JOIN adv__inventario ta ON t.id_producto = ta.id_producto JOIN adv__almacen a ON ta.id_almacen = a.id_almacen ";

        // Construcción de condiciones WHERE
        var condiciones = new List<string>();

        if (aplicarFiltroAlmacen)
            condiciones.Add($"a.nombre = '{datoMultiple[0]}'");

        if (aplicarFiltroCategoria)
            condiciones.Add($"t.categoria = '{(CategoriaProducto)int.Parse(datoMultiple[1])}'");

        string whereClause = condiciones.Count > 0 ? $"WHERE {string.Join(" AND ", condiciones)}" : "";

        switch (criterio)
        {
            case FiltroBusquedaProducto.Id:
                comando = $"SELECT *{(aplicarFiltroAlmacen ? comandoAdicionalSelect : string.Empty)} " +
                         $"FROM adv__producto t " +
                         $"{(aplicarFiltroAlmacen ? comandoAdicionalJoin : string.Empty)}" +
                         $"{(condiciones.Count > 0 ? whereClause + " AND " : "WHERE ")}" +
                         $"t.id_producto='{(datoMultiple.Length > (aplicarFiltroCategoria ? 2 : 1) ? datoMultiple[2] : dato)}';";
                break;
            case FiltroBusquedaProducto.Codigo:
                comando = $"SELECT *{(aplicarFiltroAlmacen ? comandoAdicionalSelect : string.Empty)} " +
                         $"FROM adv__producto t " +
                         $"{(aplicarFiltroAlmacen ? comandoAdicionalJoin : string.Empty)}" +
                         $"{(condiciones.Count > 0 ? whereClause + " AND " : "WHERE ")}" +
                         $"LOWER(t.codigo) LIKE LOWER('%{(datoMultiple.Length > (aplicarFiltroCategoria ? 2 : 1) ? datoMultiple[2] : dato)}%');";
                break;
            case FiltroBusquedaProducto.Nombre:
                comando = $"SELECT *{(aplicarFiltroAlmacen ? comandoAdicionalSelect : string.Empty)} " +
                         $"FROM adv__producto t " +
                         $"{(aplicarFiltroAlmacen ? comandoAdicionalJoin : string.Empty)}" +
                         $"{(condiciones.Count > 0 ? whereClause + " AND " : "WHERE ")}" +
                         $"LOWER(t.nombre) LIKE LOWER('%{(datoMultiple.Length > (aplicarFiltroCategoria ? 2 : 1) ? datoMultiple[2] : dato)}%');";
                break;
            case FiltroBusquedaProducto.Descripcion:
                comando = $"SELECT *{(aplicarFiltroAlmacen ? comandoAdicionalSelect : string.Empty)} " +
                         $"FROM adv__producto t " +
                         $"{(aplicarFiltroAlmacen ? comandoAdicionalJoin : string.Empty)}" +
                         $"JOIN adv__detalle_producto dp ON t.id_detalle_producto = dp.id_detalle_producto " +
                         $"{(condiciones.Count > 0 ? whereClause + " AND " : "WHERE ")}" +
                         $"LOWER(dp.descripcion) LIKE LOWER('%{(datoMultiple.Length > (aplicarFiltroCategoria ? 2 : 1) ? datoMultiple[2] : dato)}%');";
                break;
            default:
                comando = $"SELECT *{(aplicarFiltroAlmacen ? comandoAdicionalSelect : string.Empty)} " +
                         $"FROM adv__producto t " +
                         $"{(aplicarFiltroAlmacen ? comandoAdicionalJoin : string.Empty)}" +
                         $"{whereClause};";
                break;
        }

        return comando;
    }

    public override Producto MapearEntidad(MySqlDataReader lectorDatos)
    {
        return new Producto(
            id: lectorDatos.GetInt32(lectorDatos.GetOrdinal("id_producto")),
            categoria: (CategoriaProducto)Enum.Parse(typeof(CategoriaProducto), lectorDatos.GetValue(lectorDatos.GetOrdinal("categoria")).ToString()),
            nombre: lectorDatos.GetString(lectorDatos.GetOrdinal("nombre")),
            codigo: lectorDatos.GetString(lectorDatos.GetOrdinal("codigo")),
            idDetalleProducto: lectorDatos.GetInt32(lectorDatos.GetOrdinal("id_detalle_producto")),
            idTipoMateriaPrima: lectorDatos.GetInt32(lectorDatos.GetOrdinal("id_tipo_materia_prima")),
            idProveedor: lectorDatos.GetInt32(lectorDatos.GetOrdinal("id_proveedor")),
            esVendible: lectorDatos.GetBoolean(lectorDatos.GetOrdinal("es_vendible")),
            precioCompra: lectorDatos.GetDecimal(lectorDatos.GetOrdinal("precio_compra")),
            costoProduccionUnitario: lectorDatos.GetDecimal(lectorDatos.GetOrdinal("costo_produccion_unitario")),
            precioVentaBase: lectorDatos.GetDecimal(lectorDatos.GetOrdinal("precio_venta_base"))
        );
    }

    public override string ComandoExiste(string dato)
    {
        return $"""
            SELECT COUNT(1) 
            FROM adv__producto 
            WHERE codigo='{dato}';
            """;
    }
}