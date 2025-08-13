using aDVanceERP.Core.MVP.Modelos.Repositorios.Plantillas;

using MySql.Data.MySqlClient;

namespace aDVanceERP.Core.MVP.Modelos.Repositorios;

public class DatosUnidadMedida : RepositorioDatosBase<UnidadMedida, FiltroBusquedaUnidadMedida>, IRepositorioUnidadMedida {
    public override string ComandoCantidad() {
        return "SELECT COUNT(id_unidad_medida) FROM adv__unidad_medida;";
    }

    public override string ComandoAdicionar(UnidadMedida objeto) {
        return $"""
                INSERT INTO adv__unidad_medida (
                    nombre,
                    abreviatura,
                    descripcion
                )
                VALUES (
                    '{objeto.Nombre}',
                    '{objeto.Abreviatura}',
                    '{objeto.Descripcion}'
                );
                """;
    }

    public override string ComandoEditar(UnidadMedida objeto) {
        return $"""
                UPDATE adv__unidad_medida
                SET
                    nombre = '{objeto.Nombre}',
                    abreviatura = '{objeto.Abreviatura}',
                    descripcion = '{objeto.Descripcion}'
                WHERE id_unidad_medida = {objeto.Id};
                """;
    }

    public override string ComandoEliminar(long id) {
        return $"""
                UPDATE adv__detalle_producto
                SET id_unidad_medida = 0
                WHERE id_unidad_medida = {id};

                DELETE FROM adv__unidad_medida 
                WHERE id_unidad_medida = {id};
                """;
    }
    
    public override string ComandoObtener(FiltroBusquedaUnidadMedida criterio, string dato) {
        var comando = criterio switch {
            FiltroBusquedaUnidadMedida.Todos => "SELECT * FROM adv__unidad_medida;",
            FiltroBusquedaUnidadMedida.Id => $"SELECT * FROM adv__unidad_medida WHERE id_unidad_medida = {dato};",
            FiltroBusquedaUnidadMedida.Nombre => $"SELECT * FROM adv__unidad_medida WHERE nombre LIKE '%{dato}%';",
            FiltroBusquedaUnidadMedida.Abreviatura => $"SELECT * FROM adv__unidad_medida WHERE abreviatura LIKE '%{dato}%';",
            _ => throw new ArgumentOutOfRangeException(nameof(criterio), criterio, null)
        };

        return comando;
    }

    public override UnidadMedida MapearEntidadBaseDatos(MySqlDataReader lectorDatos) {
        return new UnidadMedida(
            lectorDatos.GetInt64("id_unidad_medida"),
            lectorDatos.GetString("nombre"),
            lectorDatos.GetString("abreviatura"),
            lectorDatos.GetString("descripcion")
        );
    } 

    public override string ComandoExiste(string dato) {
        return $"""
                SELECT COUNT(1) 
                FROM adv__unidad_medida 
                WHERE nombre = '{dato}' OR abreviatura = '{dato}';
                """;
    }
}

