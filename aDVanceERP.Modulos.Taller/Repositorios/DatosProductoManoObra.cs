using aDVanceERP.Core.MVP.Modelos.Repositorios;
using aDVanceERP.Modulos.Taller.Modelos;

using MySql.Data.MySqlClient;

namespace aDVanceERP.Modulos.Taller.Repositorios;

public class DatosProductoManoObra : RepositorioDatosBase<ProductoManoObra, CriterioBusquedaProductoManoObra>
{
    public override string ComandoCantidad()
    {
        return """
            SELECT COUNT(id_producto_mano_obra) 
            FROM adv__producto_mano_obra;
            """;
    }

    public override string ComandoAdicionar(ProductoManoObra objeto)
    {
        return $"""
            INSERT INTO adv__producto_mano_obra (
                id_producto,
                id_actividad_produccion
            )
            VALUES (
                {objeto.IdProducto},
                {objeto.IdActividadProduccion}
            );
            """;
    }

    public override string ComandoEditar(ProductoManoObra objeto)
    {
        return $"""
            UPDATE adv__producto_mano_obra
            SET
                id_producto = {objeto.IdProducto},
                id_actividad_produccion = {objeto.IdActividadProduccion}
            WHERE id_producto_mano_obra = {objeto.Id};
            """;
    }

    public override string ComandoEliminar(long id)
    {
        return $"""
            DELETE FROM adv__producto_mano_obra 
            WHERE id_producto_mano_obra = {id};
            """;
    }

    public override string ComandoObtener(CriterioBusquedaProductoManoObra criterio, string dato)
    {
        var comando = criterio switch
        {
            CriterioBusquedaProductoManoObra.Todos => "SELECT * FROM adv__producto_mano_obra;",
            CriterioBusquedaProductoManoObra.Id => $"SELECT * FROM adv__producto_mano_obra WHERE id_producto_mano_obra = {dato};",
            CriterioBusquedaProductoManoObra.IdProducto => $"SELECT * FROM adv__producto_mano_obra WHERE id_producto = {dato};",
            CriterioBusquedaProductoManoObra.IdActividadProduccion => $"SELECT * FROM adv__producto_mano_obra WHERE id_actividad_produccion = {dato};",
            _ => throw new ArgumentOutOfRangeException(nameof(criterio), criterio, null)
        };

        return comando;
    }

    public override ProductoManoObra ObtenerObjetoDataReader(MySqlDataReader lectorDatos)
    {
        return new ProductoManoObra
        {
            Id = lectorDatos.GetInt64("id_producto_mano_obra"),
            IdProducto = lectorDatos.GetInt64("id_producto"),
            IdActividadProduccion = lectorDatos.GetInt64("id_actividad_produccion")
        };
    }

    public override string ComandoExiste(string dato)
    {
        return $"""
            SELECT COUNT(1) 
            FROM adv__producto_mano_obra 
            WHERE id_producto_mano_obra = {dato};
            """;
    }
}