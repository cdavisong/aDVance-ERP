using aDVanceERP.Core.Repositorios.BD;
using aDVanceERP.Modulos.Inventario.MVP.Modelos;
using MySql.Data.MySqlClient;
using System.Globalization;

namespace aDVanceERP.Modulos.Inventario.Repositorios;

public class RepoInventario : RepoEntidadBaseDatos<MVP.Modelos.Inventario, FiltroBusquedaInventario> {
    public RepoInventario() : base("adv__inventario", "id_inventario") { }

    protected override string GenerarComandoAdicionar(MVP.Modelos.Inventario objeto) {
        return $"""
            INSERT INTO adv__inventario (
                id_producto, 
                id_almacen, 
                cantidad
            ) 
            VALUES (
                '{objeto.IdProducto}', 
                '{objeto.IdAlmacen}', 
                '{objeto.Cantidad.ToString("N2", CultureInfo.InvariantCulture)}');
            """;
    }

    protected override string GenerarComandoEditar(MVP.Modelos.Inventario objeto) {
        return $"""
            UPDATE adv__inventario 
            SET 
                id_producto = {objeto.IdProducto}, 
                id_almacen = {objeto.IdAlmacen}, 
                cantidad = {objeto.Cantidad.ToString("N2", CultureInfo.InvariantCulture)},
                costo_promedio = {objeto.CostoPromedio.ToString("N4", CultureInfo.InvariantCulture)},
                valor_total = {objeto.ValorTotal.ToString("N4", CultureInfo.InvariantCulture)}
            WHERE id_inventario = {objeto.Id};
            """;
    }

    protected override string GenerarComandoEliminar(long id) {
        return $"DELETE FROM adv__inventario WHERE id_inventario={id};";
    }

    protected override string GenerarComandoObtener(FiltroBusquedaInventario criterio, string dato) {
        var comando = string.Empty;

        switch (criterio) {
            case FiltroBusquedaInventario.Id:
                comando = $"SELECT * FROM adv__inventario WHERE id_inventario='{dato}';";
                break;
            case FiltroBusquedaInventario.IdProducto:
                comando = $"SELECT * FROM adv__inventario WHERE id_producto='{dato}';";
                break;
            case FiltroBusquedaInventario.IdAlmacen:
                comando = $"SELECT * FROM adv__inventario WHERE id_almacen='{dato}';";
                break;
            default:
                comando = "SELECT * FROM adv__inventario;";
                break;
        }

        return comando;
    }

    protected override MVP.Modelos.Inventario MapearEntidad(MySqlDataReader lectorDatos) {
        return new MVP.Modelos.Inventario(
            lectorDatos.GetInt64(lectorDatos.GetOrdinal("id_inventario")),
            lectorDatos.GetInt64(lectorDatos.GetOrdinal("id_producto")),
            lectorDatos.GetInt64(lectorDatos.GetOrdinal("id_almacen")),
            lectorDatos.GetDecimal(lectorDatos.GetOrdinal("cantidad")),
            lectorDatos.GetDecimal(lectorDatos.GetOrdinal("costo_promedio")),
            lectorDatos.GetDecimal(lectorDatos.GetOrdinal("valor_total")),
            lectorDatos.GetDateTime(lectorDatos.GetOrdinal("ultima_actualizacion"))
        );
    }
}