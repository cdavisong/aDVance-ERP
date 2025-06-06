using aDVanceERP.Core.MVP.Modelos.Repositorios;
using aDVanceERP.Modulos.Inventario.MVP.Modelos.Repositorios.Plantillas;
using MySql.Data.MySqlClient;
using System.Globalization;

namespace aDVanceERP.Modulos.Inventario.MVP.Modelos.Repositorios; 

public class DatosProductoAlmacen : RepositorioDatosBase<ProductoAlmacen, CriterioBusquedaProductoAlmacen>,
    IRepositorioProductoAlmacen {
    public override string ComandoCantidad() {
        return "SELECT COUNT(id_producto_almacen) FROM adv__producto_almacen;";
    }

    public override string ComandoAdicionar(ProductoAlmacen objeto) {
        return
            $"INSERT INTO adv__producto_almacen (id_producto, id_almacen, stock) VALUES ('{objeto.IdProducto}', '{objeto.IdAlmacen}', '{objeto.Stock.ToString("0.00", CultureInfo.InvariantCulture)}');";
    }

    public override string ComandoEditar(ProductoAlmacen objeto) {
        return $"UPDATE adv__producto_almacen SET id_producto='{objeto.IdProducto}', id_almacen='{objeto.IdAlmacen}', stock='{objeto.Stock.ToString("0.00", CultureInfo.InvariantCulture)}' WHERE id_producto_almacen={objeto.Id};";
    }

    public override string ComandoEliminar(long id) {
        return $"DELETE FROM adv__producto_almacen WHERE id_producto_almacen={id};";
    }

    public override string ComandoExiste(string dato) {
        return $"SELECT * FROM adv__producto_almacen WHERE id_producto_almacen='{dato}';";
    }

    public override string ComandoObtener(CriterioBusquedaProductoAlmacen criterio, string dato) {
        var comando = string.Empty;

        switch (criterio) {
            case CriterioBusquedaProductoAlmacen.Id:
                comando = $"SELECT * FROM adv__producto_almacen WHERE id_producto_almacen='{dato}';";
                break;
            case CriterioBusquedaProductoAlmacen.IdProducto:
                comando = $"SELECT * FROM adv__producto_almacen WHERE id_producto='{dato}';";
                break;
            case CriterioBusquedaProductoAlmacen.IdAlmacen:
                comando = $"SELECT * FROM adv__producto_almacen WHERE id_almacen='{dato}';";
                break;
            default:
                comando = "SELECT * FROM adv__producto_almacen;";
                break;
        }

        return comando;
    }

    public override ProductoAlmacen ObtenerObjetoDataReader(MySqlDataReader lectorDatos) {
        return new ProductoAlmacen(
            lectorDatos.GetInt32(lectorDatos.GetOrdinal("id_producto_almacen")),
            lectorDatos.GetInt32(lectorDatos.GetOrdinal("id_producto")),
            lectorDatos.GetInt32(lectorDatos.GetOrdinal("id_almacen")),
            lectorDatos.GetFloat(lectorDatos.GetOrdinal("stock"))
        );
    }
}