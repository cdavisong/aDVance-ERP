using aDVanceERP.Core.MVP.Modelos.Repositorios;
using aDVanceERP.Modulos.Inventario.MVP.Modelos.Repositorios.Plantillas;

using MySql.Data.MySqlClient;

namespace aDVanceERP.Modulos.Inventario.MVP.Modelos.Repositorios;

public class DatosDisenoProducto : RepositorioDatosBase<DisenoProducto, CriterioBusquedaDisenoProducto>, IRepositorioDisenoProducto {
    public override string ComandoCantidad() {
        return """
            SELECT COUNT(id_diseno_producto) 
            FROM adv__diseno_producto;
            """;
    }

    public override string ComandoAdicionar(DisenoProducto objeto) {
        return $"""
            INSERT INTO adv__diseno_producto (
                nombre,
                descripcion
            )
            VALUES (
                '{objeto.Nombre}',
                '{objeto.Descripcion}'
            );
            """;
    }

    public override string ComandoEditar(DisenoProducto objeto) {
        return $"""
            UPDATE adv__diseno_producto
            SET
                nombre = '{objeto.Nombre}',
                descripcion = '{objeto.Descripcion}'
            WHERE id_diseno_producto = {objeto.Id};
            """;
    }

    public override string ComandoEliminar(long id) {
        return $"""
            UPDATE adv__detalle_producto
            SET id_diseno_producto = 0
            WHERE id_diseno_producto = {id};

            DELETE FROM adv__diseno_producto 
            WHERE id_diseno_producto = {id};
            """;
    }
    
    public override string ComandoObtener(CriterioBusquedaDisenoProducto criterio, string dato) {
        var comando = criterio switch {
            CriterioBusquedaDisenoProducto.Todos => "SELECT * FROM adv__diseno_producto;",
            CriterioBusquedaDisenoProducto.Id => $"SELECT * FROM adv__diseno_producto WHERE id_diseno_producto = {dato};",
            CriterioBusquedaDisenoProducto.Nombre => $"SELECT * FROM adv__diseno_producto WHERE nombre LIKE '%{dato}%';",
            CriterioBusquedaDisenoProducto.Descripcion => $"SELECT * FROM adv__diseno_producto WHERE descripcion LIKE '%{dato}%';",
            _ => throw new ArgumentOutOfRangeException(nameof(criterio), criterio, null)
        };

        return comando;
    }

    public override DisenoProducto ObtenerObjetoDataReader(MySqlDataReader lectorDatos) {
        return new DisenoProducto {
            Id = lectorDatos.GetInt64("id_diseno_producto"),
            Nombre = lectorDatos.GetString("nombre"),
            Descripcion = lectorDatos.GetString("descripcion")
        };
    }

    public override string ComandoExiste(string dato) {
        return $"""
            SELECT COUNT(1) 
            FROM adv__diseno_producto 
            WHERE nombre = '{dato}';
            """;
    }
}

