using aDVanceERP.Core.MVP.Modelos.Repositorios;
using aDVanceERP.Modulos.Inventario.MVP.Modelos;
using MySql.Data.MySqlClient;
using System.Globalization;

namespace aDVanceERP.Modulos.Inventario.Repositorios;

public class RepoInventario : RepositorioDatosBase<MVP.Modelos.Inventario, CriterioBusquedaInventario> {
    public override string ComandoCantidad() {
        return "SELECT COUNT(id_inventario) FROM adv__inventario;";
    }

    public override string ComandoAdicionar(MVP.Modelos.Inventario objeto) {
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

    public override string ComandoEditar(MVP.Modelos.Inventario objeto) {
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

    public override string ComandoEliminar(long id) {
        return $"DELETE FROM adv__inventario WHERE id_inventario={id};";
    }

    public override string ComandoExiste(string dato) {
        return $"SELECT * FROM adv__inventario WHERE id_inventario='{dato}';";
    }

    public override string ComandoObtener(CriterioBusquedaInventario criterio, string dato) {
        var comando = string.Empty;

        switch (criterio) {
            case CriterioBusquedaInventario.Id:
                comando = $"SELECT * FROM adv__inventario WHERE id_inventario='{dato}';";
                break;
            case CriterioBusquedaInventario.IdProducto:
                comando = $"SELECT * FROM adv__inventario WHERE id_producto='{dato}';";
                break;
            case CriterioBusquedaInventario.IdAlmacen:
                comando = $"SELECT * FROM adv__inventario WHERE id_almacen='{dato}';";
                break;
            default:
                comando = "SELECT * FROM adv__inventario;";
                break;
        }

        return comando;
    }

    public override MVP.Modelos.Inventario ObtenerObjetoDataReader(MySqlDataReader lectorDatos) {
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