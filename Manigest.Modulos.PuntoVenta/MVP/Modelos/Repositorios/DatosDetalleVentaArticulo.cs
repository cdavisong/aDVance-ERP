using Manigest.Core.MVP.Modelos.Repositorios;
using Manigest.Modulos.PuntoVenta.MVP.Modelos.Repositorios.Plantillas;
using MySql.Data.MySqlClient;

namespace Manigest.Modulos.PuntoVenta.MVP.Modelos.Repositorios {
    public class DatosDetalleVentaArticulo : RepositorioDatosBase<DetalleVentaArticulo, CriterioDetalleVentaArticulo>, IRepositorioDetalleVentaArticulo {
        public override string ComandoCantidad() {
            return "SELECT COUNT(id_detalle_venta_articulo) FROM mg__detalle_venta_articulo;";
        }

        public override string ComandoAdicionar(DetalleVentaArticulo objeto) {
            return $"INSERT INTO mg__detalle_venta_articulo (id_venta, id_articulo, precio_unitario, cantidad) VALUES ({objeto.IdVenta}, {objeto.IdArticulo}, {objeto.PrecioUnitario}, {objeto.Cantidad});";
        }

        public override string ComandoEditar(DetalleVentaArticulo objeto) {
            return $"UPDATE mg__detalle_venta_articulo SET id_venta={objeto.IdVenta}, id_articulo={objeto.IdArticulo}, precio_unitario={objeto.PrecioUnitario}, cantidad={objeto.Cantidad} WHERE id_detalle_venta_articulo={objeto.Id};";
        }

        public override string ComandoEliminar(long id) {
            return $"DELETE FROM mg__detalle_venta_articulo WHERE id_detalle_venta_articulo={id};";
        }

        public override string ComandoObtener(CriterioDetalleVentaArticulo criterio, string dato) {
            var comando = string.Empty;

            switch (criterio) {
                case CriterioDetalleVentaArticulo.Id:
                    comando = $"SELECT * FROM mg__detalle_venta_articulo WHERE id_detalle_venta_articulo={dato};";
                    break;
                case CriterioDetalleVentaArticulo.IdVenta:
                    comando = $"SELECT * FROM mg__detalle_venta_articulo WHERE id_venta={dato};";
                    break;
                case CriterioDetalleVentaArticulo.IdArticulo:
                    comando = $"SELECT * FROM mg__detalle_venta_articulo WHERE id_articulo={dato};";
                    break;
                default:
                    comando = "SELECT * FROM mg__detalle_venta_articulo;";
                    break;
            }

            return comando;
        }

        public override string ComandoExiste(string dato) {
            return $"SELECT COUNT(1) FROM mg__detalle_venta_articulo WHERE id_detalle_venta_articulo = {dato};";
        }

        public override DetalleVentaArticulo ObtenerObjetoDataReader(MySqlDataReader lectorDatos) {
            return new DetalleVentaArticulo(
                id: lectorDatos.GetInt32(lectorDatos.GetOrdinal("id_detalle_venta_articulo")),
                idVenta: lectorDatos.GetInt32(lectorDatos.GetOrdinal("id_venta")),
                idArticulo: lectorDatos.GetInt32(lectorDatos.GetOrdinal("id_articulo")),
                precioUnitario: lectorDatos.GetFloat(lectorDatos.GetOrdinal("precio_unitario")),
                cantidad: lectorDatos.GetInt32(lectorDatos.GetOrdinal("cantidad"))
            );
        }
    }
}
