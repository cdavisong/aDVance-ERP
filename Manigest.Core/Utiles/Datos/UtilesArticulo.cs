using Manigest.Core.Excepciones;
using MySql.Data.MySqlClient;

namespace Manigest.Core.Utiles.Datos {
    public static class UtilesArticulo {
        public static long ObtenerIdArticulo(string nombreArticulo) {
            var idArticulo = 0;

            using (var conexion = new MySqlConnection(UtilesConfServidores.ObtenerStringConfServidorMySQL())) {
                try {
                    conexion.Open();
                } catch (Exception) {
                    throw new ExcepcionConexionServidorMySQL();
                }

                using (var comando = conexion.CreateCommand()) {
                    comando.CommandText = $"SELECT id_articulo FROM mg__articulo WHERE nombre='{nombreArticulo}';";

                    using (var lectorDatos = comando.ExecuteReader()) {
                        if (lectorDatos != null && lectorDatos.Read()) {
                            idArticulo = lectorDatos.GetInt32(lectorDatos.GetOrdinal("id_articulo"));
                        }
                    }
                }
            }

            return idArticulo;
        }

        public static string? ObtenerNombreArticulo(long idArticulo) {
            var nombreArticulo = string.Empty;

            using (var conexion = new MySqlConnection(UtilesConfServidores.ObtenerStringConfServidorMySQL())) {
                try {
                    conexion.Open();
                } catch (Exception) {
                    throw new ExcepcionConexionServidorMySQL();
                }

                using (var comando = conexion.CreateCommand()) {
                    comando.CommandText = $"SELECT nombre FROM mg__articulo WHERE id_articulo='{idArticulo}';";

                    using (var lectorDatos = comando.ExecuteReader()) {
                        if (lectorDatos != null && lectorDatos.Read()) {
                            nombreArticulo = lectorDatos.GetString(lectorDatos.GetOrdinal("nombre"));
                        }
                    }
                }
            }

            return nombreArticulo;
        }
        public static string[] ObtenerNombresArticulos() {
            List<string> nombresArticulos = new List<string>();

            using (var conexion = new MySqlConnection(UtilesConfServidores.ObtenerStringConfServidorMySQL())) {
                try {
                    conexion.Open();
                } catch (Exception) {
                    throw new ExcepcionConexionServidorMySQL();
                }

                using (var comando = conexion.CreateCommand()) {
                    comando.CommandText = "SELECT nombre FROM mg__articulo;";

                    using (var lectorDatos = comando.ExecuteReader()) {
                        while (lectorDatos.Read()) {
                            nombresArticulos.Add(lectorDatos.GetString(lectorDatos.GetOrdinal("nombre")));
                        }
                    }
                }
            }

            return nombresArticulos.ToArray();
        }

        public static int ObtenerStockTotalArticulo(long idArticulo) {
            int stockTotal = 0;

            using (var conexion = new MySqlConnection(UtilesConfServidores.ObtenerStringConfServidorMySQL())) {
                try {
                    conexion.Open();
                } catch (Exception) {
                    throw new ExcepcionConexionServidorMySQL();
                }

                using (var comando = conexion.CreateCommand()) {
                    comando.CommandText = "SELECT SUM(stock) as stock_total FROM mg__articulo_almacen WHERE id_articulo = @IdArticulo;";
                    comando.Parameters.AddWithValue("@IdArticulo", idArticulo);

                    using (var lectorDatos = comando.ExecuteReader()) {
                        if (lectorDatos.Read()) {
                            stockTotal = lectorDatos.GetInt32(lectorDatos.GetOrdinal("stock_total"));
                        }
                    }
                }
            }

            return stockTotal;
        }
    }
}
