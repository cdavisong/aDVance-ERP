using aDVanceERP.Core.MVP.Modelos.Repositorios;
using aDVanceERP.Modulos.Inventario.MVP.Modelos.Repositorios.Plantillas;

using MySql.Data.MySqlClient;

namespace aDVanceERP.Modulos.Inventario.MVP.Modelos.Repositorios;

public class DatosDetalleProducto : RepositorioDatosBase<DetalleProducto, CriterioBusquedaDetalleProducto>, IRepositorioDetalleProducto {
    public override string ComandoCantidad() {
        return """
                    SELECT COUNT(id_detalle_producto) 
                    FROM adv__detalle_producto;
                    """;
    }

    public override string ComandoAdicionar(DetalleProducto objeto) {
        return $"""
                    INSERT INTO adv__detalle_producto (
                        id_unidad_medida,
                        id_color_producto_primario,
                        id_color_producto_secundario,
                        id_tipo_producto,
                        id_diseno_producto,
                        descripcion
                    )
                    VALUES (
                        '{objeto.IdUnidadMedida}',
                        '{objeto.IdColorProductoPrimario}',
                        '{objeto.IdColorProductoSecundario}',
                        {objeto.IdTipoProducto},
                        {objeto.IdDisenoProducto},
                        '{objeto.Descripcion}'
                    );
                    """;
    }

    public override string ComandoEditar(DetalleProducto objeto) {
        return $"""
                    UPDATE adv__detalle_producto
                    SET
                        id_unidad_medida='{objeto.IdUnidadMedida}',
                        id_color_producto_primario='{objeto.IdColorProductoPrimario}',
                        id_color_producto_secundario='{objeto.IdColorProductoSecundario}',
                        id_tipo_producto={objeto.IdTipoProducto},
                        id_diseno_producto={objeto.IdDisenoProducto},
                        descripcion='{objeto.Descripcion}'
                    WHERE id_detalle_producto={objeto.Id};
                    """;
    }

    public override string ComandoEliminar(long id) {
        return $"""
                    DELETE FROM adv__detalle_producto 
                    WHERE id_detalle_producto = {id};
                    """;
    }

    public override string ComandoObtener(CriterioBusquedaDetalleProducto criterio, string dato) {
        var comando = criterio switch {
            CriterioBusquedaDetalleProducto.Todos => "SELECT * FROM adv__detalle_producto;",
            CriterioBusquedaDetalleProducto.Id => $"SELECT * FROM adv__detalle_producto WHERE id_detalle_producto = {dato};",
            CriterioBusquedaDetalleProducto.UnidadMedida => $@"
                            SELECT dp.*
                            FROM adv__detalle_producto dp
                            JOIN adv__unidad_medida um ON dp.id_unidad_medida = um.id_unidad_medida
                            WHERE um.nombre = '{dato}';
                        ",
            CriterioBusquedaDetalleProducto.ColorPrimario => $@"
                            SELECT dp.*
                            FROM adv__detalle_producto dp
                            JOIN adv__color_producto cp ON dp.id_color_producto_primario = cp.id_color_producto
                            WHERE cp.nombre = '{dato}';
                        ",
            CriterioBusquedaDetalleProducto.ColorSecundario => $@"
                            SELECT dp.*
                            FROM adv__detalle_producto dp
                            JOIN adv__color_producto cs ON dp.id_color_producto_secundario = cs.id_color_producto
                            WHERE cs.nombre = '{dato}';
                        ",
            CriterioBusquedaDetalleProducto.TipoProducto => $@"
                            SELECT dp.* 
                            FROM adv__detalle_producto dp
                            JOIN adv__tipo_producto tp ON dp.id_tipo_producto = tp.id_tipo_producto
                            WHERE tp.nombre = '{dato}';
                        ",
            CriterioBusquedaDetalleProducto.DisenoProducto => $@"
                            SELECT dp.* 
                            FROM adv__detalle_producto dp
                            JOIN adv__diseno_producto d ON dp.id_diseno_producto = d.id_diseno_producto
                            WHERE d.nombre = '{dato}';
                        ",
            _ => throw new ArgumentOutOfRangeException(nameof(criterio), criterio, null)
        };

        return comando;
    }

    public override DetalleProducto ObtenerObjetoDataReader(MySqlDataReader lectorDatos) {
        return new DetalleProducto(
            id: lectorDatos.GetInt64(lectorDatos.GetOrdinal("id_detalle_producto")),
            idUnidadMedida: lectorDatos.GetInt64(lectorDatos.GetOrdinal("unidad_medida")),
            idColorProductoPrimario: lectorDatos.GetInt64(lectorDatos.GetOrdinal("id_color_producto_primario")),
            idColorProductoSecundario: lectorDatos.GetInt64(lectorDatos.GetOrdinal("id_color_producto_secundario")),
            idTipoProducto: lectorDatos.GetInt64(lectorDatos.GetOrdinal("id_tipo_producto")),
            idDiseñoProducto: lectorDatos.GetInt64(lectorDatos.GetOrdinal("id_diseno_producto")),
            descripcion: lectorDatos.GetString(lectorDatos.GetOrdinal("descripcion")) ?? "No hay descripción disponible"
        );
    }

    public override string ComandoExiste(string dato) {
        return $"""
                SELECT COUNT(1) 
                FROM adv__detalle_producto 
                WHERE id_detalle_producto={dato};
                """;
    }
}
