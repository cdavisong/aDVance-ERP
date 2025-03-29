using aDVanceERP.Core.Excepciones;

using MySql.Data.MySqlClient;

using System.Globalization;

namespace aDVanceERP.Core.Utiles.Datos {
    public static class UtilesArticulo {
        // Método auxiliar para ejecutar consultas y devolver un valor escalar
        private static async Task<T> EjecutarConsultaEscalar<T>(string query, Func<MySqlDataReader, T> mapper, params MySqlParameter[] parameters) {
            using (var conexion = new MySqlConnection(UtilesConfServidores.ObtenerStringConfServidorMySQL())) {
                try {
                    await conexion.OpenAsync().ConfigureAwait(false);

                    using (var comando = new MySqlCommand(query, conexion)) {
                        if (parameters != null) {
                            comando.Parameters.AddRange(parameters);
                        }

                        using (var lectorDatos = await comando.ExecuteReaderAsync().ConfigureAwait(false)) {
                            if (await lectorDatos.ReadAsync().ConfigureAwait(false)) {
                                return mapper((MySqlDataReader) lectorDatos);
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
        private static async Task<List<T>> EjecutarConsultaLista<T>(string query, Func<MySqlDataReader, T> mapper, params MySqlParameter[] parameters) {
            var resultados = new List<T>();

            using (var conexion = new MySqlConnection(UtilesConfServidores.ObtenerStringConfServidorMySQL())) {
                try {
                    await conexion.OpenAsync().ConfigureAwait(false);

                    using (var comando = new MySqlCommand(query, conexion)) {
                        if (parameters != null) {
                            comando.Parameters.AddRange(parameters);
                        }

                        using (var lectorDatos = await comando.ExecuteReaderAsync().ConfigureAwait(false)) {
                            while (await lectorDatos.ReadAsync().ConfigureAwait(false)) {
                                resultados.Add(mapper((MySqlDataReader) lectorDatos));
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

        public static async Task<long> ObtenerIdArticulo(string nombreArticulo) {
            string query = "SELECT id_articulo FROM adv__articulo WHERE nombre = @nombreArticulo;";
            var parametros = new MySqlParameter[]
            {
                new MySqlParameter("@nombreArticulo", nombreArticulo)
            };

            return await EjecutarConsultaEscalar(query, lector => lector.GetInt64(lector.GetOrdinal("id_articulo")), parametros);
        }

        public static async Task<string?> ObtenerNombreArticulo(long idArticulo) {
            string query = "SELECT nombre FROM adv__articulo WHERE id_articulo = @idArticulo;";
            var parametros = new MySqlParameter[]
            {
                new MySqlParameter("@idArticulo", idArticulo)
            };

            return await EjecutarConsultaEscalar(query, lector => lector.GetString(lector.GetOrdinal("nombre")), parametros);
        }

        public static async Task<string[]> ObtenerNombresArticulos() {
            string query = "SELECT nombre FROM adv__articulo;";
            var nombres = await EjecutarConsultaLista(query, lector => lector.GetString(lector.GetOrdinal("nombre")));
            return nombres.ToArray();
        }

        public static async Task<string[]> ObtenerNombresArticulos(long idAlmacen) {
            string query = "SELECT a.nombre FROM adv__articulo a JOIN adv__articulo_almacen aa ON a.id_articulo = aa.id_articulo WHERE aa.id_almacen = @IdAlmacen;";
            var parametros = new MySqlParameter[] {
                new MySqlParameter("@IdAlmacen", idAlmacen)
            };

            var nombres = await EjecutarConsultaLista(query, lector => lector.GetString(lector.GetOrdinal("nombre")), parametros);
            return nombres.ToArray();
        }

        public static async Task<int> ObtenerStockTotalArticulos() {
            string query = "SELECT SUM(aa.stock) AS total_articulos FROM adv__articulo_almacen aa INNER JOIN adv__articulo a ON aa.id_articulo = a.id_articulo;";
            return await EjecutarConsultaEscalar(query, lector => lector.GetInt32(lector.GetOrdinal("total_articulos")));
        }

        public static async Task<int> ObtenerStockTotalArticulo(long idArticulo) {
            // Usamos COALESCE para devolver 0 si SUM(stock) es NULL
            string query = "SELECT COALESCE(SUM(stock), 0) as stock_total FROM adv__articulo_almacen WHERE id_articulo = @IdArticulo;";
            var parametros = new MySqlParameter[] {
                new MySqlParameter("@IdArticulo", idArticulo)
            };

            return await EjecutarConsultaEscalar(query, lector => lector.GetInt32(lector.GetOrdinal("stock_total")), parametros);
        }

        public static async Task<int> ObtenerStockArticulo(string nombreArticulo, string? nombreAlmacen) {
            string query = @"
                SELECT aa.stock 
                FROM adv__articulo_almacen aa 
                JOIN adv__articulo ar ON aa.id_articulo = ar.id_articulo 
                JOIN adv__almacen al ON aa.id_almacen = al.id_almacen 
                WHERE ar.nombre = @NombreArticulo AND al.nombre = @NombreAlmacen;";
            var parametros = new MySqlParameter[]            {
                new MySqlParameter("@NombreArticulo", nombreArticulo),
                new MySqlParameter("@NombreAlmacen", nombreAlmacen)
            };

            return await EjecutarConsultaEscalar(query, lector => lector.GetInt32(lector.GetOrdinal("stock")), parametros);
        }

        public static async Task<decimal> ObtenerPrecioUnitarioArticulo(long idArticulo) {
            string query = "SELECT precio_venta_base FROM adv__articulo WHERE id_articulo = @IdArticulo;";
            var parametros = new MySqlParameter[]
            {
                new MySqlParameter("@IdArticulo", idArticulo)
            };

            return await EjecutarConsultaEscalar(query, lector => lector.GetDecimal(lector.GetOrdinal("precio_cesion")), parametros);
        }

        public static async Task<decimal> ObtenerMontoInvertidoEnArticulos(long idAlmacen = 0) {
            string query = @$"
                SELECT SUM(ar.precio_compra_base * aa.stock) AS monto_invertido
                FROM adv__articulo ar 
                JOIN adv__articulo_almacen aa ON ar.id_articulo = aa.id_articulo
                JOIN adv__almacen al ON aa.id_almacen = al.id_almacen
                {(idAlmacen != 0 ? "WHERE al.id_almacen = @IdAlmacen" : string.Empty)};";
            var parametros = new[] {
                new MySqlParameter("@IdAlmacen", idAlmacen)
            };

            return await EjecutarConsultaEscalar(query, lector => lector.IsDBNull(lector.GetOrdinal("monto_invertido")) ? 0 : lector.GetDecimal(lector.GetOrdinal("monto_invertido")), parametros);
        }

        public static async Task<bool> PuedeEliminarArticulo(long idArticulo) {
            string queryVentas = "SELECT COUNT(*) FROM adv__detalle_venta_articulo WHERE id_articulo = @IdArticulo;";
            string queryMovimientos = "SELECT COUNT(*) FROM adv__movimiento WHERE id_articulo = @IdArticulo;";
            var parametros = new MySqlParameter[]
            {
                new MySqlParameter("@IdArticulo", idArticulo)
            };

            int cantidadVentas = await EjecutarConsultaEscalar(queryVentas, lector => lector.GetInt32(0), parametros);
            int cantidadMovimientos = await EjecutarConsultaEscalar(queryMovimientos, lector => lector.GetInt32(0), parametros);

            return cantidadVentas == 0 && cantidadMovimientos == 0;
        }
    }
}