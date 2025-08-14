using aDVanceERP.Core.Repositorios.BD;
using aDVanceERP.Modulos.Inventario.MVP.Modelos;
using aDVanceERP.Modulos.Inventario.Repositorios.Plantillas;
using MySql.Data.MySqlClient;

namespace aDVanceERP.Modulos.Inventario.Repositorios;

public class DatosTipoMateriaPrima : RepoEntidadBaseDatos<TipoMateriaPrima, FiltroBusquedaTipoMateriaPrima>, IRepositorioTipoMateriaPrima
{
    public override string ComandoCantidad()
    {
        return """
            SELECT COUNT(id_tipo_materia_prima) 
            FROM adv__tipo_materia_prima;
            """;
    }

    public override string GenerarComandoInsertar(TipoMateriaPrima objeto)
    {
        return $"""
            INSERT INTO adv__tipo_materia_prima (
                nombre,
                descripcion
            )
            VALUES (
                '{objeto.Nombre}',
                '{objeto.Descripcion}'
            );
            """;
    }

    public override string GenerarComandoActualizar(TipoMateriaPrima objeto)
    {
        return $"""
            UPDATE adv__tipo_materia_prima
            SET
                nombre = '{objeto.Nombre}',
                descripcion = '{objeto.Descripcion}'
            WHERE id_tipo_materia_prima = {objeto.Id};
            """;
    }

    public override string ComandoEliminar(long id)
    {
        return $"""
            UPDATE adv__producto
            SET id_tipo_materia_prima = 0
            WHERE id_tipo_materia_prima = {id};

            DELETE FROM adv__tipo_materia_prima 
            WHERE id_tipo_materia_prima = {id};
            """;
    }

    public override string GenerarClausulaWhere(FiltroBusquedaTipoMateriaPrima criterio, string dato)
    {
        return criterio switch
        {
            FiltroBusquedaTipoMateriaPrima.Todos => "SELECT * FROM adv__tipo_materia_prima;",
            FiltroBusquedaTipoMateriaPrima.Id => $"SELECT * FROM adv__tipo_materia_prima WHERE id_tipo_materia_prima = {dato};",
            FiltroBusquedaTipoMateriaPrima.Nombre => $"""
                SELECT * FROM adv__tipo_materia_prima 
                WHERE nombre LIKE '%{dato}%';
                """,
            _ => throw new ArgumentOutOfRangeException(nameof(criterio), criterio, null)
        };
    }

    public override TipoMateriaPrima MapearEntidad(MySqlDataReader lectorDatos)
    {
        return new TipoMateriaPrima(
            lectorDatos.GetInt64("id_tipo_materia_prima"),
            lectorDatos.GetString("nombre"),
            lectorDatos.GetString("descripcion")
        );
    }

    public override string ComandoExiste(string dato)
    {
        return $"""
            SELECT COUNT(1) 
            FROM adv__tipo_materia_prima 
            WHERE nombre = '{dato}';
            """;
    }
}
