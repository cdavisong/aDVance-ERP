using aDVanceERP.Core.MVP.Modelos.Repositorios;
using aDVanceERP.Modulos.Taller.Modelos;

using MySql.Data.MySqlClient;

namespace aDVanceERP.Modulos.Taller.Repositorios;

public class RepoActividadProduccion : RepositorioDatosBase<ActividadProduccion, FiltroBusquedaActividadProduccion>
{
    public override string ComandoCantidad()
    {
        return """
            SELECT COUNT(id_actividad_produccion) 
            FROM adv__actividad_produccion;
            """;
    }

    public override string ComandoAdicionar(ActividadProduccion objeto)
    {
        return $"""
            INSERT INTO adv__actividad_produccion (
                nombre,
                descripcion,
                costo
            )
            VALUES (
                '{objeto.Nombre}',
                '{objeto.Descripcion}',
                {objeto.Costo}
            );
            """;
    }

    public override string ComandoEditar(ActividadProduccion objeto)
    {
        return $"""
            UPDATE adv__actividad_produccion
            SET
                nombre='{objeto.Nombre}',
                descripcion='{objeto.Descripcion}',
                costo={objeto.Costo}
            WHERE id_actividad_produccion={objeto.Id};
            """;
    }

    public override string ComandoEliminar(long id)
    {
        return $"""
            DELETE FROM adv__actividad_produccion 
            WHERE id_actividad_produccion = {id};
            """;
    }

    public override string ComandoObtener(FiltroBusquedaActividadProduccion criterio, string dato)
    {
        var comando = criterio switch
        {
            FiltroBusquedaActividadProduccion.Todos => "SELECT * FROM adv__actividad_produccion;",
            FiltroBusquedaActividadProduccion.Id => $"SELECT * FROM adv__actividad_produccion WHERE id_actividad_produccion = {dato};",
            FiltroBusquedaActividadProduccion.Nombre => $"SELECT * FROM adv__actividad_produccion WHERE nombre LIKE '%{dato}%';",
            FiltroBusquedaActividadProduccion.Descripcion => $"SELECT * FROM adv__actividad_produccion WHERE descripcion LIKE '%{dato}%';",
            _ => throw new ArgumentOutOfRangeException(nameof(criterio), criterio, null)
        };

        return comando;
    }

    public override ActividadProduccion ObtenerObjetoDataReader(MySqlDataReader lectorDatos)
    {
        return new ActividadProduccion(
            lectorDatos.GetInt64("id_actividad_produccion"),
            lectorDatos.GetString("nombre"),
            lectorDatos.GetString("descripcion"),
            lectorDatos.GetDecimal("costo")
        );
    }

    public override string ComandoExiste(string dato)
    {
        return $"""
            SELECT COUNT(1) 
            FROM adv__actividad_produccion 
            WHERE nombre = '{dato}';
            """;
    }
}