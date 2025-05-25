using aDVanceERP.Core.MVP.Modelos.Repositorios;
using aDVanceERP.Modulos.Inventario.MVP.Modelos.Repositorios.Plantillas;

using MySql.Data.MySqlClient;

namespace aDVanceERP.Modulos.Inventario.MVP.Modelos.Repositorios;

public class DatosColorProducto : RepositorioDatosBase<ColorProducto, CriterioBusquedaColorProducto>, IRepositorioColorProducto {
    public override string ComandoCantidad() {
       return """
            SELECT COUNT(id_color_producto) 
            FROM adv__color_producto;
            """;
    }

    public override string ComandoAdicionar(ColorProducto objeto) {
        return $"""
            INSERT INTO adv__color_producto (
                nombre,
                codigo_argb
            )
            VALUES (
                '{objeto.Nombre}',
                {objeto.CodigoArgb}
            );
            """;
    }    

    public override string ComandoEditar(ColorProducto objeto) {
        return $"""
            UPDATE adv__color_producto
            SET
                nombre='{objeto.Nombre}',
                codigo_argb={objeto.CodigoArgb}
            WHERE id_color_producto={objeto.Id};
            """;
    }

    public override string ComandoEliminar(long id) {
        return $"""
            UPDATE adv__detalle_producto
            SET id_color_producto = 0
            WHERE id_color_producto = {id};

            DELETE FROM adv__color_producto 
            WHERE id_color_producto = {id};
            """;
    }

    public override string ComandoObtener(CriterioBusquedaColorProducto criterio, string dato) {
        var comando = criterio switch {
            CriterioBusquedaColorProducto.Todos => "SELECT * FROM adv__color_producto;",
            CriterioBusquedaColorProducto.Id => $"SELECT * FROM adv__color_producto WHERE id_color_producto = {dato};",
            CriterioBusquedaColorProducto.Nombre => $"SELECT * FROM adv__color_producto WHERE nombre LIKE '%{dato}%';",
            _ => throw new ArgumentOutOfRangeException(nameof(criterio), criterio, null)
        };

        return comando;
    }

    public override ColorProducto ObtenerObjetoDataReader(MySqlDataReader lectorDatos) {
        return new ColorProducto(
            lectorDatos.GetInt64("id_color_producto"),
            lectorDatos.GetString("nombre"),
            lectorDatos.GetInt32("codigo_argb")
        );
    }

    public override string ComandoExiste(string dato) {
        return $"""
            SELECT COUNT(1)
            FROM adv__color_producto 
            WHERE nombre = '{dato}';
            """;
    }
}

