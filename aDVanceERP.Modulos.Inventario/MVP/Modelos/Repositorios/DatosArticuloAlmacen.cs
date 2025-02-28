using aDVanceERP.Core.MVP.Modelos.Repositorios;
using aDVanceERP.Modulos.Inventario.MVP.Modelos.Repositorios.Plantillas;

using MySql.Data.MySqlClient;

namespace aDVanceERP.Modulos.Inventario.MVP.Modelos.Repositorios {
    public class DatosArticuloAlmacen : RepositorioDatosBase<ArticuloAlmacen, CriterioBusquedaArticuloAlmacen>, IRepositorioArticuloAlmacen {
        public override string ComandoCantidad() {
            return "SELECT COUNT(id_articulo_almacen) FROM adv__articulo_almacen;";
        }

        public override string ComandoAdicionar(ArticuloAlmacen objeto) {
            return $"INSERT INTO adv__articulo_almacen (id_articulo, id_almacen, stock) VALUES ('{objeto.IdArticulo}', '{objeto.IdAlmacen}', '{objeto.Stock}');";
        }

        public override string ComandoEditar(ArticuloAlmacen objeto) {
            return $"UPDATE adv__articulo_almacen SET id_articulo='{objeto.IdArticulo}', id_almacen='{objeto.IdAlmacen}', stock='{objeto.Stock}' WHERE id_articulo_almacen={objeto.Id};";
        }

        public override string ComandoEliminar(long id) {
            return $"DELETE FROM adv__articulo_almacen WHERE id_articulo_almacen={id};";
        }

        public override string ComandoExiste(string dato) {
            return $"SELECT * FROM adv__articulo_almacen WHERE id_articulo_almacen='{dato}';";
        }

        public override string ComandoObtener(CriterioBusquedaArticuloAlmacen criterio, string dato) {
            var comando = string.Empty;

            switch (criterio) {
                case CriterioBusquedaArticuloAlmacen.Id:
                    comando = $"SELECT * FROM adv__articulo_almacen WHERE id_articulo_almacen='{dato}';";
                    break;
                case CriterioBusquedaArticuloAlmacen.IdArticulo:
                    comando = $"SELECT * FROM adv__articulo_almacen WHERE id_articulo='{dato}';";
                    break;
                case CriterioBusquedaArticuloAlmacen.IdAlmacen:
                    comando = $"SELECT * FROM adv__articulo_almacen WHERE id_almacen='{dato}';";
                    break;
                default:
                    comando = "SELECT * FROM adv__articulo_almacen;";
                    break;
            }

            return comando;
        }

        public override ArticuloAlmacen ObtenerObjetoDataReader(MySqlDataReader lectorDatos) {
            return new ArticuloAlmacen(
                idArticuloAlmacen: lectorDatos.GetInt32(lectorDatos.GetOrdinal("id_articulo_almacen")),
                idArticulo: lectorDatos.GetInt32(lectorDatos.GetOrdinal("id_articulo")),
                idAlmacen: lectorDatos.GetInt32(lectorDatos.GetOrdinal("id_almacen")),
                stock: lectorDatos.GetInt32(lectorDatos.GetOrdinal("stock"))
            );
        }
    }
}
