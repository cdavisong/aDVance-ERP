using aDVanceERP.Core.MVP.Modelos.Repositorios;
using aDVanceERP.Modulos.Inventario.MVP.Modelos.Repositorios.Plantillas;

using MySql.Data.MySqlClient;

namespace aDVanceERP.Modulos.Inventario.MVP.Modelos.Repositorios;

public class DatosTipoProducto : RepositorioDatosBase<TipoProducto, CriterioBusquedaTipoProducto>, IRepositorioTipoProducto {
    public override string ComandoCantidad() {
        return """
            SELECT COUNT(id_tipo_producto) 
            FROM adv__tipo_producto;
            """;
    }

    public override string ComandoAdicionar(TipoProducto objeto) {
        return $"""
            INSERT INTO adv__tipo_producto (
                nombre,
                descripcion
            )
            VALUES (
                '{objeto.Nombre}',
                '{objeto.Descripcion}'
            );
            """;
    }

    public override string ComandoEditar(TipoProducto objeto) {
        return $"""
            UPDATE adv__tipo_producto
            SET
                nombre = '{objeto.Nombre}',
                descripcion = '{objeto.Descripcion}'
            WHERE id_tipo_producto = {objeto.Id};
            """;
    }

    public override string ComandoEliminar(long id) {
        return $"""
            UPDATE adv__detalle_producto
            SET id_tipo_producto = 0
            WHERE id_tipo_producto = {id};

            DELETE FROM adv__tipo_producto 
            WHERE id_tipo_producto = {id};
            """;
    }

    public override string ComandoObtener(CriterioBusquedaTipoProducto criterio, string dato) {
        return criterio switch {
            CriterioBusquedaTipoProducto.Todos => "SELECT * FROM adv__tipo_producto;",
            CriterioBusquedaTipoProducto.Id => $"SELECT * FROM adv__tipo_producto WHERE id_tipo_producto = {dato};",
            CriterioBusquedaTipoProducto.Nombre => $"""
                SELECT * FROM adv__tipo_producto 
                WHERE nombre LIKE '%{dato}%';
                """,
            _ => throw new ArgumentOutOfRangeException(nameof(criterio), criterio, null)
        };
    }

    public override TipoProducto ObtenerObjetoDataReader(MySqlDataReader lectorDatos) {
        return new TipoProducto(
            lectorDatos.GetInt64("id_tipo_producto"),
            lectorDatos.GetString("nombre"),
            lectorDatos.GetString("descripcion")
        );
    }

    public override string ComandoExiste(string dato) {
        return $"""
            SELECT COUNT(1) 
            FROM adv__tipo_producto 
            WHERE nombre = '{dato}';
            """;
    }
}

