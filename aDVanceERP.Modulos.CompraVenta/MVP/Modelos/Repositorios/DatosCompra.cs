using aDVanceERP.Core.MVP.Modelos.Repositorios;
using aDVanceERP.Modulos.CompraVenta.MVP.Modelos.Repositorios.Plantillas;

using MySql.Data.MySqlClient;

using System.Globalization;

namespace aDVanceERP.Modulos.CompraVenta.MVP.Modelos.Repositorios {
    public class DatosCompra : RepositorioDatosBase<Compra, CriterioBusquedaCompra>, IRepositorioCompra {
        public override string ComandoCantidad() {
            return "SELECT COUNT(id_compra) FROM adv__compra;";
        }

        public override string ComandoAdicionar(Compra objeto) {
            return $"INSERT INTO adv__compra (fecha, id_almacen, id_proveedor, id_articulo, cantidad, total) VALUES ('{objeto.Fecha:yyyy-MM-dd HH:mm:ss}', {objeto.IdAlmacen}, {objeto.IdProveedor}, {objeto.IdArticulo}, {objeto.Cantidad}, {objeto.Total.ToString(CultureInfo.InvariantCulture)});";
        }

        public override string ComandoEditar(Compra objeto) {
            return $"UPDATE adv__compra SET fecha='{objeto.Fecha:yyyy-MM-dd HH:mm:ss}', id_almacen={objeto.IdAlmacen}, id_proveedor={objeto.IdProveedor}, id_articulo={objeto.IdArticulo}, cantidad={objeto.Cantidad}, total={objeto.Total.ToString(CultureInfo.InvariantCulture)} WHERE id_compra={objeto.Id};";
        }

        public override string ComandoEliminar(long id) {
            return $"DELETE FROM adv__compra WHERE id_compra={id};";
        }

        public override string ComandoObtener(CriterioBusquedaCompra criterio, string dato) {
            var comando = string.Empty;

            switch (criterio) {
                case CriterioBusquedaCompra.Id:
                    comando = $"SELECT * FROM adv__compra WHERE id_compra={dato};";
                    break;
                case CriterioBusquedaCompra.NombreAlmacen:
                    comando = $"SELECT c.* FROM adv__compra c JOIN adv__almacen a ON c.id_almacen = a.id_almacen WHERE LOWER(a.nombre) LIKE LOWER('%{dato}%');";
                    break;
                case CriterioBusquedaCompra.RazonSocialProveedor:
                    comando = $"SELECT c.* FROM adv__compra c JOIN adv__proveedor p ON c.id_proveedor = p.id_proveedor WHERE LOWER(p.razon_social) LIKE LOWER('%{dato}%');";
                    break;
                case CriterioBusquedaCompra.NombreArticulo:
                    comando = $"SELECT c.* FROM adv__compra c JOIN adv__articulo ar ON c.id_articulo = ar.id_articulo WHERE LOWER(ar.nombre) LIKE LOWER('%{dato}%');";
                    break;
                case CriterioBusquedaCompra.Fecha:
                    comando = $"SELECT * FROM adv__compra WHERE DATE(fecha) = '{dato}';";
                    break;
                default:
                    comando = "SELECT * FROM adv__compra;";
                    break;
            }

            return comando;
        }

        public override Compra ObtenerObjetoDataReader(MySqlDataReader lectorDatos) {
            return new Compra(
                id: lectorDatos.GetInt32(lectorDatos.GetOrdinal("id_compra")),
                fecha: lectorDatos.GetDateTime(lectorDatos.GetOrdinal("fecha")),
                idAlmacen: lectorDatos.GetInt32(lectorDatos.GetOrdinal("id_almacen")),
                idProveedor: lectorDatos.GetInt32(lectorDatos.GetOrdinal("id_proveedor")),
                idArticulo: lectorDatos.GetInt32(lectorDatos.GetOrdinal("id_articulo")),
                cantidad: lectorDatos.GetInt32(lectorDatos.GetOrdinal("cantidad")),
                total: lectorDatos.GetDecimal(lectorDatos.GetOrdinal("total"))
            );
        }

        public override string ComandoExiste(string dato) {
            return $"SELECT COUNT(1) FROM adv__compra WHERE id_compra = {dato};";
        }
    }
}