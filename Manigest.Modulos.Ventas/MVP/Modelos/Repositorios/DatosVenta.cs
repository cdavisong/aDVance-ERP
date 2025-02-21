using Manigest.Core.MVP.Modelos.Repositorios;
using Manigest.Modulos.Ventas.MVP.Modelos.Repositorios.Plantillas;

using MySql.Data.MySqlClient;

namespace Manigest.Modulos.Ventas.MVP.Modelos.Repositorios {
    public class DatosVenta : RepositorioDatosBase<Venta, CriterioBusquedaVenta>, IRepositorioVenta {
        public override string ComandoCantidad() {
            return "SELECT COUNT(id_venta) FROM mg__venta;";
        }

        public override string ComandoAdicionar(Venta objeto) {
            return $"INSERT INTO mg__venta (fecha, id_almacen, id_cliente, total) VALUES ('{objeto.Fecha:yyyy-MM-dd HH:mm:ss}', {objeto.IdAlmacen}, {objeto.IdCliente}, {objeto.Total});";
        }

        public override string ComandoEditar(Venta objeto) {
            return $"UPDATE mg__venta SET fecha='{objeto.Fecha:yyyy-MM-dd HH:mm:ss}', id_almacen={objeto.IdAlmacen}, id_cliente={objeto.IdCliente}, total={objeto.Total} WHERE id_venta={objeto.Id};";
        }

        public override string ComandoEliminar(long id) {
            return $"DELETE FROM mg__venta WHERE id_venta={id};";
        }

        public override string ComandoObtener(CriterioBusquedaVenta criterio, string dato) {
            var comando = string.Empty;

            switch (criterio) {
                case CriterioBusquedaVenta.Id:
                    comando = $"SELECT * FROM mg__venta WHERE id_venta={dato};";
                    break;
                case CriterioBusquedaVenta.NombreAlmacen:
                    comando = $"SELECT v.* FROM mg__venta v JOIN mg__almacen a ON v.id_almacen = a.id_almacen WHERE LOWER(a.nombre) LIKE LOWER('%{dato}%');";
                    break;
                case CriterioBusquedaVenta.RazonSocialCliente:
                    comando = $"SELECT v.* FROM mg__venta v JOIN mg__cliente c ON v.id_cliente = c.id_cliente WHERE LOWER(c.razon_social) LIKE LOWER('%{dato}%');";
                    break;
                case CriterioBusquedaVenta.Fecha:
                    comando = $"SELECT * FROM mg__venta WHERE DATE(fecha) = '{dato}';";
                    break;
                default:
                    comando = "SELECT * FROM mg__venta;";
                    break;
            }

            return comando;
        }

        public override Venta ObtenerObjetoDataReader(MySqlDataReader lectorDatos) {
            return new Venta(
                id: lectorDatos.GetInt32(lectorDatos.GetOrdinal("id_venta")),
                fecha: lectorDatos.GetDateTime(lectorDatos.GetOrdinal("fecha")),
                idAlmacen: lectorDatos.GetInt32(lectorDatos.GetOrdinal("id_almacen")),
                idCliente: lectorDatos.GetInt32(lectorDatos.GetOrdinal("id_cliente")),
                total: lectorDatos.GetFloat(lectorDatos.GetOrdinal("total"))
            );
        }

        public override string ComandoExiste(string dato) {
            return $"SELECT COUNT(1) FROM mg__venta WHERE id_venta = {dato};";
        }
    }
}
