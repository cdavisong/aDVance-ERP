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

        public static string[] ObtenerNombresArticulos(long idAlmacen) {
            List<string> nombresArticulos = new List<string>();

            using (var conexion = new MySqlConnection(UtilesConfServidores.ObtenerStringConfServidorMySQL())) {
                try {
                    conexion.Open();
                } catch (Exception) {
                    throw new ExcepcionConexionServidorMySQL();
                }

                using (var comando = conexion.CreateCommand()) {
                    comando.CommandText = "SELECT a.nombre FROM mg__articulo a JOIN mg__articulo_almacen aa ON a.id_articulo = aa.id_articulo WHERE aa.id_almacen = @IdAlmacen;";
                    comando.Parameters.AddWithValue("@IdAlmacen", idAlmacen);

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
                            stockTotal = int.TryParse(lectorDatos.GetValue(lectorDatos.GetOrdinal("stock_total")).ToString(), out var valorStockTotal) ? valorStockTotal : 0;
                        }
                    }
                }
            }

            return stockTotal;
        }

        public static float ObtenerPrecioUnitarioArticulo(long idArticulo) {
            float precioUnitario = 0;

            using (var conexion = new MySqlConnection(UtilesConfServidores.ObtenerStringConfServidorMySQL())) {
                try {
                    conexion.Open();
                } catch (Exception) {
                    throw new ExcepcionConexionServidorMySQL();
                }

                using (var comando = conexion.CreateCommand()) {
                    comando.CommandText = "SELECT precio_cesion FROM mg__articulo WHERE id_articulo = @IdArticulo;";
                    comando.Parameters.AddWithValue("@IdArticulo", idArticulo);

                    using (var lectorDatos = comando.ExecuteReader()) {
                        if (lectorDatos.Read()) {
                            precioUnitario = lectorDatos.GetFloat(lectorDatos.GetOrdinal("precio_cesion"));
                        }
                    }
                }
            }

            return precioUnitario;
        }
    }
}
