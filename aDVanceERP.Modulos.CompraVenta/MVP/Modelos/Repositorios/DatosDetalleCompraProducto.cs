using System.Globalization;
using aDVanceERP.Core.Repositorios.BD;
using aDVanceERP.Modulos.CompraVenta.MVP.Modelos.Repositorios.Plantillas;
using MySql.Data.MySqlClient;

namespace aDVanceERP.Modulos.CompraVenta.MVP.Modelos.Repositorios;

public class DatosDetalleCompraProducto : RepoEntidadBaseDatos<DetalleCompraProducto, CriterioDetalleCompraProducto>,
    IRepositorioDetalleCompraProducto {
    public override string ComandoCantidad() {
        return """
               SELECT COUNT(id_detalle_compra_producto)
               FROM adv__detalle_compra_producto;
               """;
    }

    public override string GenerarComandoInsertar(DetalleCompraProducto objeto) {
        return $"""
                INSERT INTO adv__detalle_compra_producto (
                    id_compra,
                    id_producto,
                    cantidad,
                    precio_compra
                )
                VALUES (
                    {objeto.IdCompra},
                    {objeto.IdProducto},
                    '{objeto.Cantidad.ToString("N2", CultureInfo.InvariantCulture)}',
                    {objeto.PrecioCompra.ToString(CultureInfo.InvariantCulture)}
                );          
                """;
    }

    public override string GenerarComandoActualizar(DetalleCompraProducto objeto) {
        return $"""
                UPDATE adv__detalle_compra_producto
                SET
                    id_compra={objeto.IdCompra},
                    id_producto={objeto.IdProducto},
                    cantidad='{objeto.Cantidad.ToString("N2", CultureInfo.InvariantCulture)}',
                    precio_compra={objeto.PrecioCompra.ToString(CultureInfo.InvariantCulture)}
                WHERE id_detalle_compra_producto={objeto.Id};
                """;
    }

    public override string ComandoEliminar(long id) {
        return $"""
                DELETE
                FROM adv__detalle_compra_producto
                WHERE id_detalle_compra_producto={id};
                """;
    }

    public override string GenerarClausulaWhere(CriterioDetalleCompraProducto criterio, string dato) {
        var comando = string.Empty;

        switch (criterio) {
            case CriterioDetalleCompraProducto.Todos:
                comando = """
                          SELECT *
                          FROM adv__detalle_compra_producto;
                          """;
                break;
            case CriterioDetalleCompraProducto.Id:
                comando = $"""
                           SELECT *
                           FROM adv__detalle_compra_producto
                           WHERE id_detalle_compra_producto={dato};
                           """;
                break;
            case CriterioDetalleCompraProducto.IdCompra:
                comando = $"""
                           SELECT *
                                FROM adv__detalle_compra_producto
                                WHERE id_compra={dato};
                           """;
                break;
            case CriterioDetalleCompraProducto.IdProducto:
                comando = $"""
                           SELECT *
                           FROM adv__detalle_compra_producto
                           WHERE id_producto={dato};
                           """;
                break;
            default:
                comando = """
                          SELECT *
                          FROM adv__detalle_compra_producto;
                          """;
                break;
        }

        return comando;
    }

    public override DetalleCompraProducto MapearEntidad(MySqlDataReader lectorDatos) {
        return new DetalleCompraProducto(
            lectorDatos.GetInt32(lectorDatos.GetOrdinal("id_detalle_compra_producto")),
            lectorDatos.GetInt32(lectorDatos.GetOrdinal("id_compra")),
            lectorDatos.GetInt32(lectorDatos.GetOrdinal("id_producto")),
            lectorDatos.GetDecimal(lectorDatos.GetOrdinal("cantidad")),
            lectorDatos.GetDecimal(lectorDatos.GetOrdinal("precio_compra"))
        );
    }

    public override string ComandoExiste(string dato) {
        return $"""
                SELECT COUNT(1)
                FROM adv__detalle_compra_producto
                WHERE id_detalle_compra_producto = {dato};
                """;
    }
}