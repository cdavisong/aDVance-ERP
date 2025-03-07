using aDVanceERP.Core.Excepciones;

using MySql.Data.MySqlClient;

namespace aDVanceERP.Core.Utiles.Datos {
    public static class UtilesArticulo {
        public static long ObtenerIdArticulo(string nombreArticulo) {
            var idArticulo = 0L;
            var connectionString = UtilesConfServidores.ObtenerStringConfServidorMySQL();
            var query = "SELECT id_articulo FROM adv__articulo WHERE nombre = @nombreArticulo;";

            using (var conexion = new MySqlConnection(connectionString)) {
                try {
                    conexion.Open();

                    using (var comando = new MySqlCommand(query, conexion)) {
                        comando.Parameters.AddWithValue("@nombreArticulo", nombreArticulo);

                        using (var lectorDatos = comando.ExecuteReader()) {
                            if (lectorDatos.Read()) {
                                idArticulo = lectorDatos.GetInt64("id_articulo");
                            }
                        }
                    }
                } catch (MySqlException) {
                    throw new ExcepcionConexionServidorMySQL();
                } catch (Exception ex) {
                    //TODO: Capturar cualquier otra excepción inesperada
                    throw new Exception("Error inesperado al obtener el ID del artículo.", ex);
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
                    comando.CommandText = $"SELECT nombre FROM adv__articulo WHERE id_articulo='{idArticulo}';";

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
                    comando.CommandText = "SELECT nombre FROM adv__articulo;";

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
                    comando.CommandText = "SELECT a.nombre FROM adv__articulo a JOIN adv__articulo_almacen aa ON a.id_articulo = aa.id_articulo WHERE aa.id_almacen = @IdAlmacen;";
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

        public static int ObtenerStockTotalArticulos() {
            var cantidadTotal = 0;
            var connectionString = UtilesConfServidores.ObtenerStringConfServidorMySQL();
            var query = @"
                SELECT SUM(aa.stock) AS total_articulos
                FROM adv__articulo_almacen aa
                INNER JOIN adv__articulo a ON aa.id_articulo = a.id_articulo;";

            using (var conexion = new MySqlConnection(connectionString)) {
                try {
                    conexion.Open();

                    using (var comando = new MySqlCommand(query, conexion)) {
                        object result = comando.ExecuteScalar();

                        if (result != null && result != DBNull.Value) {
                            cantidadTotal = Convert.ToInt32(result);
                        }
                    }
                } catch (MySqlException) {
                    throw new ExcepcionConexionServidorMySQL();
                } catch (Exception ex) {
                    //TODO: Capturar cualquier otra excepción inesperada
                    throw new Exception("Error inesperado al obtener la cantidad total de artículo.", ex);
                }
            }

            return cantidadTotal;
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
                    comando.CommandText = "SELECT SUM(stock) as stock_total FROM adv__articulo_almacen WHERE id_articulo = @IdArticulo;";
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

        public static int ObtenerStockArticulo(string nombreArticulo, string nombreAlmacen) {
            int stock = 0;

            using (var conexion = new MySqlConnection(UtilesConfServidores.ObtenerStringConfServidorMySQL())) {
                try {
                    conexion.Open();
                } catch (Exception) {
                    throw new ExcepcionConexionServidorMySQL();
                }

                using (var comando = conexion.CreateCommand()) {
                    comando.CommandText = "SELECT aa.stock " +
                                          "FROM adv__articulo_almacen aa " +
                                          "JOIN adv__articulo ar ON aa.id_articulo = ar.id_articulo " +
                                          "JOIN adv__almacen al ON aa.id_almacen = al.id_almacen " +
                                          "WHERE ar.nombre = @NombreArticulo AND al.nombre = @NombreAlmacen;";
                    comando.Parameters.AddWithValue("@NombreArticulo", nombreArticulo);
                    comando.Parameters.AddWithValue("@NombreAlmacen", nombreAlmacen);

                    using (var lectorDatos = comando.ExecuteReader()) {
                        if (lectorDatos.Read()) {
                            stock = int.TryParse(lectorDatos.GetValue(lectorDatos.GetOrdinal("stock")).ToString(), out var valorStockTotal) ? valorStockTotal : 0;
                        }
                    }
                }
            }

            return stock;
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
                    comando.CommandText = "SELECT precio_cesion FROM adv__articulo WHERE id_articulo = @IdArticulo;";
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

        public static decimal ObtenerMontoInvertidoEnArticulos(long idAlmacen = 0) {
            decimal montoInvertido = 0;

            using (var conexion = new MySqlConnection(UtilesConfServidores.ObtenerStringConfServidorMySQL())) {
                try {
                    conexion.Open();
                } catch (Exception) {
                    throw new ExcepcionConexionServidorMySQL();
                }

                using (var comando = conexion.CreateCommand()) {
                    comando.CommandText = @$"
                    SELECT SUM(ar.precio_adquisicion * aa.stock) AS monto_invertido
                    FROM adv__articulo ar 
                    JOIN adv__articulo_almacen aa ON ar.id_articulo = aa.id_articulo
                    JOIN adv__almacen al ON aa.id_almacen = al.id_almacen
                    {(idAlmacen != 0 ? "WHERE al.id_almacen = @IdAlmacen" : string.Empty)};";
                    comando.Parameters.AddWithValue("@IdAlmacen", idAlmacen);

                    using (var lectorDatos = comando.ExecuteReader()) {
                        if (lectorDatos.Read()) {
                            montoInvertido = decimal.TryParse(lectorDatos.GetValue(lectorDatos.GetOrdinal("monto_invertido"))?.ToString(), out var totalMonto) ? totalMonto : 0;
                        }
                    }
                }
            }

            return montoInvertido;
        }
    }
}
