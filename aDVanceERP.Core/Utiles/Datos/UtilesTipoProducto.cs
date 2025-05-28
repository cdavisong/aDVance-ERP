using aDVanceERP.Core.Excepciones;

using MySql.Data.MySqlClient;

namespace aDVanceERP.Core.Utiles.Datos {
    public static class UtilesTipoProducto {
        private static async Task<T?> EjecutarConsultaAsync<T>(string query, Func<MySqlDataReader, T> procesarResultado, params MySqlParameter[] parametros) {
            using var conexion = new MySqlConnection(UtilesConfServidores.ObtenerStringConfServidorMySQL());
            try {
                await conexion.OpenAsync().ConfigureAwait(false);
            } catch (MySqlException) {
                throw new ExcepcionConexionServidorMySQL();
            }

            using var comando = new MySqlCommand(query, conexion);
            comando.Parameters.AddRange(parametros);

            using var lectorDatos = await comando.ExecuteReaderAsync().ConfigureAwait(false);
            return lectorDatos != null && await lectorDatos.ReadAsync().ConfigureAwait(false)
                ? procesarResultado((MySqlDataReader) lectorDatos)
                : default;
        }

        private static T? EjecutarConsulta<T>(string query, Func<MySqlDataReader, T> procesarResultado, params MySqlParameter[] parametros) {
            using var conexion = new MySqlConnection(UtilesConfServidores.ObtenerStringConfServidorMySQL());
            try {
                conexion.Open();
            } catch (MySqlException) {
                throw new ExcepcionConexionServidorMySQL();
            }

            using var comando = new MySqlCommand(query, conexion);
            comando.Parameters.AddRange(parametros);

            using var lectorDatos = comando.ExecuteReader();
            return lectorDatos != null && lectorDatos.Read()
                ? procesarResultado(lectorDatos)
                : default;
        }

        public static async Task<long> ObtenerIdTipoProducto(string? nombreTipoProducto) {
            const string query = "SELECT id_tipo_producto FROM adv__tipo_producto WHERE LOWER(nombre) LIKE LOWER(@NombreTipoProducto);";
            var result = await EjecutarConsultaAsync(query, lector => lector.GetInt32("id_tipo_producto"),
                new MySqlParameter("@NombreTipoProducto", $"%{nombreTipoProducto}%"));
            return result != 0 ? result : 0;
        }

        public static string? ObtenerNombreTipoProducto(long idTipoProducto) {
            const string query = "SELECT nombre FROM adv__tipo_producto WHERE id_tipo_producto = @IdTipoProducto;";
            return EjecutarConsulta(query, lector => lector.GetString("nombre"),
                new MySqlParameter("@IdTipoProducto", idTipoProducto));
        }

        public static object[] ObtenerNombresTiposProductos() {
            var query = "SELECT nombre FROM adv__tipo_producto;";
            return EjecutarConsulta(query, lector => {
                var nombres = new List<string>();
                do {
                    nombres.Add(lector.GetString("nombre"));
                } while (lector.Read());
                return nombres.ToArray();
            }) ?? Array.Empty<object>();
        }
    }
}
