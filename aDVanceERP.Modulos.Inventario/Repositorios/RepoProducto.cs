using System.Text;

using aDVanceERP.Core.MVP.Modelos.Repositorios;
using aDVanceERP.Modulos.Inventario.MVP.Modelos;

using MySql.Data.MySqlClient;

namespace aDVanceERP.Modulos.Inventario.Repositorios;

public class RepoProducto : RepositorioDatosEntidadBase<Producto, FbProducto> {
    public RepoProducto() : base("adv__producto", "id_producto") { }

    public override string[] FiltrosBusqueda => UtilesBusquedaProducto.FbProducto;

    protected override (string Query, Dictionary<string, object> Parametros) GenerarComandoInsertar(Producto entidad) {
        var query = $"""
            INSERT INTO {NombreTabla} (
                codigo,
                categoria,
                nombre,
                id_detalle_producto,
                id_proveedor,
                id_tipo_materia_prima,
                es_vendible,
                precio_compra_base,
                precio_venta_base
            )
            VALUES (
                @codigo,
                @categoria,
                @nombre,
                @id_detalle_producto,
                @id_proveedor,
                @id_tipo_materia_prima,
                @es_vendible,
                @precio_compra_base,
                @precio_venta_base
            );
            """;

        var parametros = new Dictionary<string, object>
        {
            { "@codigo", entidad.Codigo ?? string.Empty },
            { "@categoria", (int)entidad.Categoria },
            { "@nombre", entidad.Nombre ?? string.Empty },
            { "@id_detalle_producto", entidad.IdDetalleProducto },
            { "@id_proveedor", entidad.IdProveedor },
            { "@id_tipo_materia_prima", entidad.IdTipoMateriaPrima },
            { "@es_vendible", entidad.EsVendible ? 1 : 0 },
            { "@precio_compra_base", entidad.PrecioCompraBase },
            { "@precio_venta_base", entidad.PrecioVentaBase }
        };

        return (query, parametros);
    }

    protected override (string Query, Dictionary<string, object> Parametros) GenerarComandoActualizar(Producto entidad) {
        var query = $"""
            UPDATE {NombreTabla}
            SET
                codigo = @codigo,
                categoria = @categoria,
                nombre = @nombre,
                id_detalle_producto = @id_detalle_producto,
                id_proveedor = @id_proveedor,
                id_tipo_materia_prima = @id_tipo_materia_prima,
                es_vendible = @es_vendible,
                precio_compra_base = @precio_compra_base,
                precio_venta_base = @precio_venta_base
            WHERE {ColumnaId} = @id;
            """;

        var parametros = new Dictionary<string, object>
        {
            { "@codigo", entidad.Codigo ?? string.Empty },
            { "@categoria", (int)entidad.Categoria },
            { "@nombre", entidad.Nombre ?? string.Empty },
            { "@id_detalle_producto", entidad.IdDetalleProducto },
            { "@id_proveedor", entidad.IdProveedor },
            { "@id_tipo_materia_prima", entidad.IdTipoMateriaPrima },
            { "@es_vendible", entidad.EsVendible ? 1 : 0 },
            { "@precio_compra_base", entidad.PrecioCompraBase },
            { "@precio_venta_base", entidad.PrecioVentaBase },
            { "@id", entidad.Id }
        };

        return (query, parametros);
    }

    protected override (string WhereClause, Dictionary<string, object> Parametros) GenerarWhereClause(FbProducto filtroBusqueda, string? datosComplementarios) {
        var whereClause = new StringBuilder();
        var parametros = new Dictionary<string, object>();

        switch (filtroBusqueda) {
            case FbProducto.Id:
                whereClause.Append($"{ColumnaId} = @id");
                parametros.Add("@id", datosComplementarios);
                break;
            case FbProducto.Codigo:
                whereClause.Append("LOWER(codigo) LIKE LOWER(@codigo)");
                parametros.Add("@codigo", $"%{datosComplementarios}%");
                break;
            case FbProducto.Nombre:
                whereClause.Append("LOWER(nombre) LIKE LOWER(@nombre)");
                parametros.Add("@nombre", $"%{datosComplementarios}%");
                break;
            case FbProducto.Descripcion:
                whereClause.Append("id_detalle_producto IN (SELECT id_detalle_producto FROM adv__detalle_producto WHERE LOWER(descripcion) LIKE LOWER(@descripcion))");
                parametros.Add("@descripcion", $"%{datosComplementarios}%");
                break;
            default:
                whereClause.Append("1=1");
                break;
        }

        return (whereClause.ToString(), parametros);
    }

    protected override Producto MapearEntidad(MySqlDataReader lectorDatos) {
        return new Producto(
            lectorDatos.GetInt64(lectorDatos.GetOrdinal("id_producto")),
            (CategoriaProducto) Enum.Parse(typeof(CategoriaProducto), lectorDatos.GetValue(lectorDatos.GetOrdinal("categoria")).ToString() ?? "0"),
            lectorDatos.GetString(lectorDatos.GetOrdinal("nombre")),
            lectorDatos.GetString(lectorDatos.GetOrdinal("codigo")),
            lectorDatos.GetInt64(lectorDatos.GetOrdinal("id_detalle_producto")),
            lectorDatos.GetInt64(lectorDatos.GetOrdinal("id_proveedor")),
            lectorDatos.GetInt64(lectorDatos.GetOrdinal("id_tipo_materia_prima")),
            lectorDatos.GetBoolean(lectorDatos.GetOrdinal("es_vendible")),
            lectorDatos.GetDecimal(lectorDatos.GetOrdinal("precio_compra_base")),
            lectorDatos.GetDecimal(lectorDatos.GetOrdinal("precio_venta_base"))
        );
    }

    // Lógica especial: eliminar detalle de producto antes de eliminar el producto
    public override void Eliminar(Producto entidad, MySqlConnection? conexionBd = null) {
        var conexion = conexionBd ?? new MySqlConnection(ObtenerCadenaConexion());
        if (conexionBd == null || conexion.State != System.Data.ConnectionState.Open)
            conexion.Open();

        using (var transaccion = conexion.BeginTransaction()) {
            try {
                var parametros = new Dictionary<string, object> {
                    { "@id_detalle_producto", entidad.IdDetalleProducto },
                    { "@id", entidad.Id }
                };

                // 1. Eliminar detalle de producto relacionado
                var queryDetalle = @"DELETE FROM adv__detalle_producto WHERE id_detalle_producto = @id_detalle_producto;";
                EjecutarComandoNoQuery(conexion, queryDetalle, parametros, transaccion);

                // 2. Eliminar el producto
                base.Eliminar(entidad, conexion);

                transaccion.Commit();
            } catch {
                transaccion.Rollback();
                throw;
            } finally {
                if (conexionBd == null)
                    conexion.Close();
            }
        }
    }
}