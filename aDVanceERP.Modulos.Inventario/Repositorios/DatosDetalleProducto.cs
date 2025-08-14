using aDVanceERP.Core.Repositorios.BD;
using aDVanceERP.Modulos.Inventario.MVP.Modelos;
using aDVanceERP.Modulos.Inventario.Repositorios.Plantillas;
using MySql.Data.MySqlClient;

namespace aDVanceERP.Modulos.Inventario.Repositorios;

public class DatosDetalleProducto : RepoEntidadBaseDatos<DetalleProducto, FiltroBusquedaDetalleProducto>, IRepositorioDetalleProducto
{
    public override string ComandoCantidad()
    {
        return """
                    SELECT COUNT(id_detalle_producto) 
                    FROM adv__detalle_producto;
                    """;
    }

    public override string GenerarComandoInsertar(DetalleProducto objeto)
    {
        return $"""
                    INSERT INTO adv__detalle_producto (
                        id_unidad_medida,
                        descripcion
                    )
                    VALUES (
                        '{objeto.IdUnidadMedida}',
                        '{objeto.Descripcion}'
                    );
                    """;
    }

    public override string GenerarComandoActualizar(DetalleProducto objeto)
    {
        return $"""
                    UPDATE adv__detalle_producto
                    SET
                        id_unidad_medida='{objeto.IdUnidadMedida}',
                        descripcion='{objeto.Descripcion}'
                    WHERE id_detalle_producto={objeto.Id};
                    """;
    }

    public override string ComandoEliminar(long id)
    {
        return $"""
                    DELETE FROM adv__detalle_producto 
                    WHERE id_detalle_producto = {id};
                    """;
    }

    public override string GenerarClausulaWhere(FiltroBusquedaDetalleProducto criterio, string dato)
    {
        var comando = criterio switch
        {
            FiltroBusquedaDetalleProducto.Todos => "SELECT * FROM adv__detalle_producto;",
            FiltroBusquedaDetalleProducto.Id => $"SELECT * FROM adv__detalle_producto WHERE id_detalle_producto = {dato};",
            FiltroBusquedaDetalleProducto.UnidadMedida => $@"
                            SELECT dp.*
                            FROM adv__detalle_producto dp
                            JOIN adv__unidad_medida um ON dp.id_unidad_medida = um.id_unidad_medida
                            WHERE um.nombre = '{dato}';
                        ",
            FiltroBusquedaDetalleProducto.Descripcion => $@"
                            SELECT dp.* 
                            FROM adv__detalle_producto dp
                            WHERE LOWER(dp.descripcion) LIKE LOWER('%{dato}%');
                        ",
            _ => throw new ArgumentOutOfRangeException(nameof(criterio), criterio, null)
        };

        return comando;
    }

    public override DetalleProducto MapearEntidad(MySqlDataReader lectorDatos)
    {
        return new DetalleProducto(
            id: lectorDatos.GetInt64(lectorDatos.GetOrdinal("id_detalle_producto")),
            idUnidadMedida: lectorDatos.GetInt64(lectorDatos.GetOrdinal("id_unidad_medida")),
            descripcion: lectorDatos.GetString(lectorDatos.GetOrdinal("descripcion")) ?? "No hay descripción disponible"
        );
    }

    public override string ComandoExiste(string dato)
    {
        return $"""
                SELECT COUNT(1) 
                FROM adv__detalle_producto 
                WHERE id_detalle_producto={dato};
                """;
    }
}
