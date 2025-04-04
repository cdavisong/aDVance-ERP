using System.Globalization;
using aDVanceERP.Core.MVP.Modelos.Repositorios;
using aDVanceERP.Modulos.CompraVenta.MVP.Modelos.Repositorios.Plantillas;
using MySql.Data.MySqlClient;

namespace aDVanceERP.Modulos.CompraVenta.MVP.Modelos.Repositorios; 

public class DatosDetalleVentaArticulo : RepositorioDatosBase<DetalleVentaArticulo, CriterioDetalleVentaArticulo>,
    IRepositorioDetalleVentaArticulo {
    public override string ComandoCantidad() {
        return """
               SELECT COUNT(id_detalle_venta_articulo)
               FROM adv__detalle_venta_articulo;
               """;
    }

    public override string ComandoAdicionar(DetalleVentaArticulo objeto) {
        return $"""
                INSERT INTO adv__detalle_venta_articulo (
                    id_venta,
                    id_articulo,
                    precio_compra_vigente,
                    precio_venta_final,
                    cantidad
                )
                VALUES (
                    {objeto.IdVenta},
                    {objeto.IdArticulo},
                    {objeto.PrecioCompraVigente.ToString(CultureInfo.InvariantCulture)},
                    {objeto.PrecioVentaFinal.ToString(CultureInfo.InvariantCulture)},
                    {objeto.Cantidad}
                );
                """;
    }

    public override string ComandoEditar(DetalleVentaArticulo objeto) {
        return $"""
                UPDATE adv__detalle_venta_articulo
                SET
                    id_venta={objeto.IdVenta},
                    id_articulo={objeto.IdArticulo},
                    precio_compra_vigente={objeto.PrecioCompraVigente.ToString(CultureInfo.InvariantCulture)},
                    precio_venta_final={objeto.PrecioVentaFinal.ToString(CultureInfo.InvariantCulture)},
                    cantidad={objeto.Cantidad}
                WHERE id_detalle_venta_articulo={objeto.Id};
                """;
    }

    public override string ComandoEliminar(long id) {
        return $"""
                DELETE
                FROM adv__detalle_venta_articulo
                WHERE id_detalle_venta_articulo={id};
                """;
    }

    public override string ComandoObtener(CriterioDetalleVentaArticulo criterio, string dato) {
        var comando = string.Empty;

        switch (criterio) {
            case CriterioDetalleVentaArticulo.Id:
                comando = $"""
                           SELECT *
                           FROM adv__detalle_venta_articulo
                           WHERE id_detalle_venta_articulo={dato};
                           """;
                break;
            case CriterioDetalleVentaArticulo.IdVenta:
                comando = $"""
                           SELECT *
                           FROM adv__detalle_venta_articulo
                           WHERE id_venta={dato};
                           """;
                break;
            case CriterioDetalleVentaArticulo.IdArticulo:
                comando = $"""
                           SELECT *
                           FROM adv__detalle_venta_articulo
                           WHERE id_articulo={dato};
                           """;
                break;
            default:
                comando = """
                          SELECT *
                          FROM adv__detalle_venta_articulo;
                          """;
                break;
        }

        return comando;
    }

    public override DetalleVentaArticulo ObtenerObjetoDataReader(MySqlDataReader lectorDatos) {
        return new DetalleVentaArticulo(
            lectorDatos.GetInt32(lectorDatos.GetOrdinal("id_detalle_venta_articulo")),
            lectorDatos.GetInt32(lectorDatos.GetOrdinal("id_venta")),
            lectorDatos.GetInt32(lectorDatos.GetOrdinal("id_articulo")),
            lectorDatos.GetDecimal(lectorDatos.GetOrdinal("precio_compra_vigente")),
            lectorDatos.GetDecimal(lectorDatos.GetOrdinal("precio_venta_final")),
            lectorDatos.GetInt32(lectorDatos.GetOrdinal("cantidad"))
        );
    }

    public override string ComandoExiste(string dato) {
        return $"""
                SELECT COUNT(1)
                FROM adv__detalle_venta_articulo
                WHERE id_detalle_venta_articulo = {dato};
                """;
    }
}