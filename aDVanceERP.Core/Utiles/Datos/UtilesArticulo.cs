using aDVanceERP.Core.Excepciones;

using MySql.Data.MySqlClient;

namespace aDVanceERP.Core.Utiles.Datos {
    public static class UtilesArticulo {
        // Método auxiliar para ejecutar consultas y devolver un valor escalar
        private static T EjecutarConsultaEscalar<T>(string query, Func<MySqlDataReader, T> mapper, params MySqlParameter[] parameters) {
            using (var conexion = new MySqlConnection(UtilesConfServidores.ObtenerStringConfServidorMySQL())) {
                try {
                    conexion.Open();

                    using (var comando = new MySqlCommand(query, conexion)) {
                        if (parameters != null) {
                            comando.Parameters.AddRange(parameters);
                        }

                        using (var lectorDatos = comando.ExecuteReader()) {
                            if (lectorDatos.Read()) {
                                return mapper(lectorDatos);
                            }
                        }
                    }
                } catch (MySqlException) {
                    throw new ExcepcionConexionServidorMySQL();
                } catch (Exception ex) {
                    throw new Exception("Error inesperado al ejecutar la consulta.", ex);
                }
            }

            return default(T);
        }

        // Método auxiliar para ejecutar consultas y devolver una lista
        private static List<T> EjecutarConsultaLista<T>(string query, Func<MySqlDataReader, T> mapper, params MySqlParameter[] parameters) {
            var resultados = new List<T>();

            using (var conexion = new MySqlConnection(UtilesConfServidores.ObtenerStringConfServidorMySQL())) {
                try {
                    conexion.Open();

                    using (var comando = new MySqlCommand(query, conexion)) {
                        if (parameters != null) {
                            comando.Parameters.AddRange(parameters);
                        }

                        using (var lectorDatos = comando.ExecuteReader()) {
                            while (lectorDatos.Read()) {
                                resultados.Add(mapper(lectorDatos));
                            }
                        }
                    }
                } catch (MySqlException) {
                    throw new ExcepcionConexionServidorMySQL();
                } catch (Exception ex) {
                    throw new Exception("Error inesperado al ejecutar la consulta.", ex);
                }
            }

            return resultados;
        }

        public static long ObtenerIdArticulo(string nombreArticulo) {
            string query = "SELECT id_articulo FROM adv__articulo WHERE nombre = @nombreArticulo;";
            var parametros = new MySqlParameter[]
            {
                new MySqlParameter("@nombreArticulo", nombreArticulo)
            };

            return EjecutarConsultaEscalar(query, lector => lector.GetInt64(lector.GetOrdinal("id_articulo")), parametros);
        }

        public static string ObtenerNombreArticulo(long idArticulo) {
            string query = "SELECT nombre FROM adv__articulo WHERE id_articulo = @idArticulo;";
            var parametros = new MySqlParameter[]
            {
                new MySqlParameter("@idArticulo", idArticulo)
            };

            return EjecutarConsultaEscalar(query, lector => lector.GetString(lector.GetOrdinal("nombre")), parametros);
        }

        public static string[] ObtenerNombresArticulos() {
            string query = "SELECT nombre FROM adv__articulo;";
            var nombres = EjecutarConsultaLista(query, lector => lector.GetString(lector.GetOrdinal("nombre")));
            return nombres.ToArray();
        }

        public static string[] ObtenerNombresArticulos(long idAlmacen) {
            string query = "SELECT a.nombre FROM adv__articulo a JOIN adv__articulo_almacen aa ON a.id_articulo = aa.id_articulo WHERE aa.id_almacen = @IdAlmacen;";
            var parametros = new MySqlParameter[] {
                new MySqlParameter("@IdAlmacen", idAlmacen)
            };

            var nombres = EjecutarConsultaLista(query, lector => lector.GetString(lector.GetOrdinal("nombre")), parametros);
            return nombres.ToArray();
        }

        public static int ObtenerStockTotalArticulos() {
            string query = "SELECT SUM(aa.stock) AS total_articulos FROM adv__articulo_almacen aa INNER JOIN adv__articulo a ON aa.id_articulo = a.id_articulo;";
            return EjecutarConsultaEscalar(query, lector => lector.GetInt32(lector.GetOrdinal("total_articulos")));
        }

        public static int ObtenerStockTotalArticulo(long idArticulo) {
            // Usamos COALESCE para devolver 0 si SUM(stock) es NULL
            string query = "SELECT COALESCE(SUM(stock), 0) as stock_total FROM adv__articulo_almacen WHERE id_articulo = @IdArticulo;";
            var parametros = new MySqlParameter[] {
                new MySqlParameter("@IdArticulo", idArticulo)
            };

            return EjecutarConsultaEscalar(query, lector => lector.GetInt32(lector.GetOrdinal("stock_total")), parametros);
        }

        public static int ObtenerStockArticulo(string nombreArticulo, string nombreAlmacen) {
            string query = @"
                SELECT aa.stock 
                FROM adv__articulo_almacen aa 
                JOIN adv__articulo ar ON aa.id_articulo = ar.id_articulo 
                JOIN adv__almacen al ON aa.id_almacen = al.id_almacen 
                WHERE ar.nombre = @NombreArticulo AND al.nombre = @NombreAlmacen;";
            var parametros = new MySqlParameter[] {
                new MySqlParameter("@NombreArticulo", nombreArticulo),
                new MySqlParameter("@NombreAlmacen", nombreAlmacen)
            };

            return EjecutarConsultaEscalar(query, lector => lector.GetInt32(lector.GetOrdinal("stock")), parametros);
        }

        public static decimal ObtenerPrecioUnitarioArticulo(long idArticulo) {
            string query = "SELECT precio_cesion FROM adv__articulo WHERE id_articulo = @IdArticulo;";
            var parametros = new MySqlParameter[]
            {
                new MySqlParameter("@IdArticulo", idArticulo)
            };

            return EjecutarConsultaEscalar(query, lector => lector.GetDecimal(lector.GetOrdinal("precio_cesion")), parametros);
        }

        public static decimal ObtenerMontoInvertidoEnArticulos(long idAlmacen = 0) {
            string query = @$"
                SELECT SUM(ar.precio_adquisicion * aa.stock) AS monto_invertido
                FROM adv__articulo ar 
                JOIN adv__articulo_almacen aa ON ar.id_articulo = aa.id_articulo
                JOIN adv__almacen al ON aa.id_almacen = al.id_almacen
                {(idAlmacen != 0 ? "WHERE al.id_almacen = @IdAlmacen" : string.Empty)};";
            var parametros = new MySqlParameter[]
            {
                new MySqlParameter("@IdAlmacen", idAlmacen)
            };

            return EjecutarConsultaEscalar(query, lector => lector.GetDecimal(lector.GetOrdinal("monto_invertido")), parametros);
        }

        public static bool PuedeEliminarArticulo(long idArticulo) {
            string queryVentas = "SELECT COUNT(*) FROM adv__detalle_venta_articulo WHERE id_articulo = @IdArticulo;";
            string queryMovimientos = "SELECT COUNT(*) FROM adv__movimiento WHERE id_articulo = @IdArticulo;";
            var parametros = new MySqlParameter[]
            {
                new MySqlParameter("@IdArticulo", idArticulo)
            };

            int cantidadVentas = EjecutarConsultaEscalar(queryVentas, lector => lector.GetInt32(0), parametros);
            int cantidadMovimientos = EjecutarConsultaEscalar(queryMovimientos, lector => lector.GetInt32(0), parametros);

            return cantidadVentas == 0 && cantidadMovimientos == 0;
        }
    }
}