using System.Globalization;
using aDVanceERP.Core.MVP.Modelos.Repositorios;
using aDVanceERP.Modulos.CompraVenta.MVP.Modelos.Repositorios.Plantillas;
using MySql.Data.MySqlClient;

namespace aDVanceERP.Modulos.CompraVenta.MVP.Modelos.Repositorios; 

public class DatosCompra : RepositorioDatosBase<Compra, CriterioBusquedaCompra>, IRepositorioCompra {
    public override string ComandoCantidad() {
        return "SELECT COUNT(id_compra) FROM adv__compra;";
    }

    public override string ComandoAdicionar(Compra objeto) {
        return $"""
                INSERT INTO adv__compra (fecha, id_almacen, id_proveedor, total)
                VALUES (
                    '{objeto.Fecha:yyyy-MM-dd HH:mm:ss}',
                    '{objeto.IdAlmacen}',
                    '{objeto.IdProveedor}',
                    '{objeto.Total.ToString(CultureInfo.InvariantCulture)}'
                );
                """;
    }

    public override string ComandoEditar(Compra objeto) {
        return $"""
                UPDATE adv__compra
                SET
                    fecha='{objeto.Fecha:yyyy-MM-dd HH:mm:ss}',
                    id_almacen='{objeto.IdAlmacen}',
                    id_proveedor='{objeto.IdProveedor}',
                    total='{objeto.Total.ToString(CultureInfo.InvariantCulture)}'
                WHERE id_compra={objeto.Id};
                """;
    }

    public override string ComandoEliminar(long id) {
        return $"""
                START TRANSACTION;

                UPDATE adv__producto_almacen aa
                JOIN adv__detalle_venta_producto dva ON aa.id_producto = dva.id_producto
                JOIN adv__venta v ON dva.id_venta = v.id_venta
                SET aa.stock = aa.stock + dva.cantidad
                WHERE dva.id_venta = {id} AND aa.id_almacen = v.id_almacen;

                DELETE m FROM adv__movimiento m
                JOIN adv__detalle_venta_producto dva ON m.id_producto = dva.id_producto
                JOIN adv__tipo_movimiento tm ON m.id_tipo_movimiento = tm.id_tipo_movimiento
                WHERE tm.nombre = 'Venta' AND tm.efecto = 'Descarga' AND dva.id_venta = {id};

                DELETE FROM adv__seguimiento_entrega 
                WHERE id_venta = {id};

                DELETE FROM adv__detalle_pago_transferencia 
                WHERE id_venta = {id};

                DELETE FROM adv__pago 
                WHERE id_venta = {id};

                DELETE FROM adv__detalle_venta_producto 
                WHERE id_venta = {id};

                DELETE FROM adv__venta 
                WHERE id_venta = {id};

                COMMIT;

                SELECT 1 AS Resultado;
                """;
    }

    public override string ComandoObtener(CriterioBusquedaCompra criterio, string dato) {
        var comando = string.Empty;

        switch (criterio) {
            case CriterioBusquedaCompra.Id:
                comando = $"""
                           SELECT *
                           FROM adv__compra
                           WHERE id_compra={dato};
                           """;
                break;
            case CriterioBusquedaCompra.NombreAlmacen:
                comando = $"""
                           SELECT c.*
                           FROM adv__compra c JOIN adv__almacen a ON c.id_almacen = a.id_almacen
                           WHERE LOWER(a.nombre) LIKE LOWER('%{dato}%');
                           """;
                break;
            case CriterioBusquedaCompra.RazonSocialProveedor:
                comando = $"""
                           SELECT c.*
                           FROM adv__compra c JOIN adv__proveedor p ON c.id_proveedor = p.id_proveedor
                           WHERE LOWER(p.razon_social) LIKE LOWER('%{dato}%');
                           """;
                break;
            case CriterioBusquedaCompra.Fecha:
                comando = $"""
                           SELECT *
                           FROM adv__compra
                           WHERE DATE(fecha) = '{dato}';
                           """;
                break;
            default:
                comando = """
                          SELECT *
                          FROM adv__compra;
                          """;
                break;
        }

        return comando;
    }

    public override Compra ObtenerObjetoDataReader(MySqlDataReader lectorDatos) {
        return new Compra(
            lectorDatos.GetInt32(lectorDatos.GetOrdinal("id_compra")),
            lectorDatos.GetDateTime(lectorDatos.GetOrdinal("fecha")),
            lectorDatos.GetInt32(lectorDatos.GetOrdinal("id_almacen")),
            lectorDatos.GetInt32(lectorDatos.GetOrdinal("id_proveedor")),
            lectorDatos.GetDecimal(lectorDatos.GetOrdinal("total"))
        );
    }

    public override string ComandoExiste(string dato) {
        return $"SELECT COUNT(1) FROM adv__compra WHERE id_compra = {dato};";
    }
}