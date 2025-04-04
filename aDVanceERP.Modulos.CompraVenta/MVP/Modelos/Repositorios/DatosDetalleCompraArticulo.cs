using System.Globalization;
using aDVanceERP.Core.MVP.Modelos.Repositorios;
using aDVanceERP.Modulos.CompraVenta.MVP.Modelos.Repositorios.Plantillas;
using MySql.Data.MySqlClient;

namespace aDVanceERP.Modulos.CompraVenta.MVP.Modelos.Repositorios;

public class DatosDetalleCompraArticulo : RepositorioDatosBase<DetalleCompraArticulo, CriterioDetalleCompraArticulo>,
    IRepositorioDetalleCompraArticulo {
    public override string ComandoCantidad() {
        return """
               SELECT COUNT(id_detalle_compra_articulo)
               FROM adv__detalle_compra_articulo;
               """;
    }

    public override string ComandoAdicionar(DetalleCompraArticulo objeto) {
        return $"""
                INSERT INTO adv__detalle_compra_articulo (
                    id_compra,
                    id_articulo,
                    cantidad,
                    precio_compra
                )
                VALUES (
                    {objeto.IdCompra},
                    {objeto.IdArticulo},
                    {objeto.Cantidad},
                    {objeto.PrecioCompra.ToString(CultureInfo.InvariantCulture)}
                );          
                """;
    }

    public override string ComandoEditar(DetalleCompraArticulo objeto) {
        return $"""
                UPDATE adv__detalle_compra_articulo
                SET
                    id_compra={objeto.IdCompra},
                    id_articulo={objeto.IdArticulo},
                    cantidad={objeto.Cantidad},
                    precio_compra={objeto.PrecioCompra.ToString(CultureInfo.InvariantCulture)}
                WHERE id_detalle_compra_articulo={objeto.Id};
                """;
    }

    public override string ComandoEliminar(long id) {
        return $"""
                DELETE
                FROM adv__detalle_compra_articulo
                WHERE id_detalle_compra_articulo={id};
                """;
    }

    public override string ComandoObtener(CriterioDetalleCompraArticulo criterio, string dato) {
        var comando = string.Empty;

        switch (criterio) {
            case CriterioDetalleCompraArticulo.Todos:
                comando = """
                          SELECT *
                          FROM adv__detalle_compra_articulo;
                          """;
                break;
            case CriterioDetalleCompraArticulo.Id:
                comando = $"""
                           SELECT *
                           FROM adv__detalle_compra_articulo
                           WHERE id_detalle_compra_articulo={dato};
                           """;
                break;
            case CriterioDetalleCompraArticulo.IdCompra:
                comando = $"""
                           SELECT *
                                FROM adv__detalle_compra_articulo
                                WHERE id_compra={dato};
                           """;
                break;
            case CriterioDetalleCompraArticulo.IdArticulo:
                comando = $"""
                           SELECT *
                           FROM adv__detalle_compra_articulo
                           WHERE id_articulo={dato};
                           """;
                break;
            default:
                comando = """
                          SELECT *
                          FROM adv__detalle_compra_articulo;
                          """;
                break;
        }

        return comando;
    }

    public override DetalleCompraArticulo ObtenerObjetoDataReader(MySqlDataReader lectorDatos) {
        return new DetalleCompraArticulo(
            lectorDatos.GetInt32(lectorDatos.GetOrdinal("id_detalle_compra_articulo")),
            lectorDatos.GetInt32(lectorDatos.GetOrdinal("id_compra")),
            lectorDatos.GetInt32(lectorDatos.GetOrdinal("id_articulo")),
            lectorDatos.GetInt32(lectorDatos.GetOrdinal("cantidad")),
            lectorDatos.GetDecimal(lectorDatos.GetOrdinal("precio_compra"))
        );
    }

    public override string ComandoExiste(string dato) {
        return $"""
                SELECT COUNT(1)
                FROM adv__detalle_compra_articulo
                WHERE id_detalle_compra_articulo = {dato};
                """;
    }
}