using aDVanceERP.Core.Excepciones;
using MySql.Data.MySqlClient;

namespace aDVanceERP.Core.Utiles.Datos {
    public static class UtilesDetalleProducto {
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

        public static async Task<long> ObtenerIdDetalleProducto(long idProducto) {
            const string query = "SELECT dp.id_detalle_producto FROM adv__detalle_producto dp JOIN adv__producto p ON dp.id_detalle_producto=p.id_detalle_producto WHERE p.id_producto=@IdProducto;";
            var result = await EjecutarConsultaAsync(query, lector => lector.GetInt32("id_detalle_producto"),
                new MySqlParameter("@IdProducto", $"%{idProducto}%"));
            return result != 0 ? result : 0;
        }
    }

}
