using aDVanceERP.Core.Datos;
using aDVanceERP.Core.Excepciones;
using MySql.Data.MySqlClient;

namespace aDVanceERP.Core.Utiles.Datos {
    public static class UtilesUnidadMedida {
        private static async Task<T?> EjecutarConsultaAsync<T>(string query, Func<MySqlDataReader, T> procesarResultado, params MySqlParameter[] parametros) {
            using var conexion = new MySqlConnection(CoreDatos.ConfServidorMySQL.ToString());
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
            using var conexion = new MySqlConnection(CoreDatos.ConfServidorMySQL.ToString());
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

        public static async Task<long> ObtenerIdUnidadMedida(string? nombreUnidadMedida) {
            const string query = "SELECT id_unidad_medida FROM adv__unidad_medida WHERE nombre = @NombreUnidadMedida;";
            var result = await EjecutarConsultaAsync(query, lector => lector.GetInt32("id_unidad_medida"),
                new MySqlParameter("@NombreUnidadMedida", $"{nombreUnidadMedida}"));
            return result != 0 ? result : 0;
        }

        public static string? ObtenerNombreUnidadMedida(long idUnidadMedida) {
            const string query = "SELECT nombre FROM adv__unidad_medida WHERE id_unidad_medida = @IdUnidadMedida;";
            return EjecutarConsulta(query, lector => lector.GetString("nombre"),
                new MySqlParameter("@IdUnidadMedida", idUnidadMedida));
        }

        public static object[] ObtenerNombresUnidadesMedida() {
            var query = "SELECT nombre FROM adv__unidad_medida;";
            return EjecutarConsulta(query, lector => {
                var nombres = new List<string>();
                do {
                    nombres.Add(lector.GetString("nombre"));
                } while (lector.Read());
                return nombres.ToArray();
            }) ?? Array.Empty<object>();
        }

        public static string[] ObtenerDescripcionesUnidadesMedida() {
            var query = "SELECT descripcion FROM adv__unidad_medida;";
            return EjecutarConsulta(query, lector => {
                var nombres = new List<string>();
                do {
                    nombres.Add(lector.GetString("descripcion"));
                } while (lector.Read());
                return nombres.ToArray();
            }) ?? Array.Empty<string>();
        }
    }
}
