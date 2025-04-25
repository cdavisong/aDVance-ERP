using aDVanceERP.Core.Excepciones;
using MySql.Data.MySqlClient;

namespace aDVanceERP.Core.Utiles.Datos {
    public static class UtilesEntrega {
        // Método auxiliar para ejecutar consultas y devolver un valor escalar
        private static async Task<T?> EjecutarConsultaEscalar<T>(string query, Func<MySqlDataReader, T> mapper,
            params MySqlParameter[]? parameters) {
            await using (var conexion = new MySqlConnection(UtilesConfServidores.ObtenerStringConfServidorMySQL())) {
                try {
                    await conexion.OpenAsync().ConfigureAwait(false);

                    await using var comando = new MySqlCommand(query, conexion);

                    if (parameters != null) comando.Parameters.AddRange(parameters);

                    await using var lectorDatos = await comando.ExecuteReaderAsync().ConfigureAwait(false);

                    if (await lectorDatos.ReadAsync().ConfigureAwait(false)) return mapper((MySqlDataReader) lectorDatos);
                } catch (MySqlException) {
                    throw new ExcepcionConexionServidorMySQL();
                } catch (Exception ex) {
                    throw new Exception("Error inesperado al ejecutar la consulta.", ex);
                }
            }

            return default;
        }

        // Método auxiliar para ejecutar consultas y devolver una lista
        private static async Task<List<T>> EjecutarConsultaLista<T>(string query, Func<MySqlDataReader, T> mapper,
            params MySqlParameter[]? parameters) {
            var resultados = new List<T>();

            await using (var conexion = new MySqlConnection(UtilesConfServidores.ObtenerStringConfServidorMySQL())) {
                try {
                    await conexion.OpenAsync().ConfigureAwait(false);

                    await using (var comando = new MySqlCommand(query, conexion)) {
                        if (parameters != null) comando.Parameters.AddRange(parameters);

                        await using (var lectorDatos = await comando.ExecuteReaderAsync().ConfigureAwait(false)) {
                            while (await lectorDatos.ReadAsync().ConfigureAwait(false))
                                resultados.Add(mapper((MySqlDataReader) lectorDatos));
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

        public static async Task<long> ObtenerIdTipoEntrega(string? nombreTipoEntrega) {
            const string query = """
                             SELECT
                                id_tipo_entrega
                             FROM adv__tipo_entrega
                             WHERE nombre = @nombreTipoEntrega;
                             """;
            var parametros = new[] {
            new MySqlParameter("@nombreTipoEntrega", nombreTipoEntrega)
        };

            return await EjecutarConsultaEscalar(query, lector => lector.GetInt64("id_tipo_entrega"), parametros);
        }

        public static async Task<string?> ObtenerNombreTipoEntrega(long idTipoEntrega) {
            const string query = """
                             SELECT
                                nombre
                             FROM adv__tipo_entrega
                             WHERE id_tipo_entrega = @idTipoEntrega;
                             """;
            var parametros = new[] {
            new MySqlParameter("@idTipoEntrega", idTipoEntrega)
        };

            return await EjecutarConsultaEscalar(query, lector => lector.GetString(lector.GetOrdinal("nombre")),
                parametros);
        }

        public static async Task<IEnumerable<string>> ObtenerNombreDescripcionTiposEntrega(bool incluirPresencial = true) {
            const string queryBase = """
                           SELECT
                              nombre,
                              descripcion
                           FROM adv__tipo_entrega
                           """;

            // Añadir condición WHERE si no se incluye Presencial
            var query = incluirPresencial
                ? queryBase
                : queryBase + " WHERE nombre != 'Presencial'";

            return await EjecutarConsultaLista(query + ";", Mapper).ConfigureAwait(false);

            static string Mapper(MySqlDataReader reader) {
                var nombre = reader.GetString("nombre");
                var descripcion = reader.GetString("descripcion");

                return $"{nombre}|{descripcion}";
            }
        }
    }
}
