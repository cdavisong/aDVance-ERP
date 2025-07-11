using aDVanceERP.Core.Datos;
using aDVanceERP.Core.Excepciones;

using MySql.Data.MySqlClient;

namespace aDVanceERP.Core.Utiles.Datos {
    public static class UtilesActividadProduccion {
        // Método auxiliar para ejecutar consultas y devolver una lista
        private static async Task<List<T>> EjecutarConsultaLista<T>(string query, Func<MySqlDataReader, T> mapper,
            params MySqlParameter[]? parameters) {
            var resultados = new List<T>();

            await using (var conexion = new MySqlConnection(CoreDatos.ConfServidorMySQL.ToString())) {
                try {
                    await conexion.OpenAsync().ConfigureAwait(false);

                    await using (var comando = new MySqlCommand(query, conexion)) {
                        if (parameters != null) comando.Parameters.AddRange(parameters);

                        await using (var lectorDatos = await comando.ExecuteReaderAsync().ConfigureAwait(false)) {
                            while (await lectorDatos.ReadAsync().ConfigureAwait(false))
                                if (!lectorDatos.IsDBNull(0))
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

        public static async Task<string[]> ObtenerNombresActividadesProduccion(bool incluirDescripcion = false) {
            var parametros = new List<MySqlParameter>();

            string query = """
            SELECT ap.nombre
            """;

            if (incluirDescripcion) {
                query += ", ap.descripcion";
            }

            query += """

            FROM adv__actividad_produccion ap
            """;

            var nombres = await EjecutarConsultaLista(query, lector =>
            {
                var nombre = lector.GetString(lector.GetOrdinal("nombre"));
                var descripcion = incluirDescripcion ?
                    (lector.IsDBNull(lector.GetOrdinal("descripcion")) ?
                        string.Empty :
                        lector.GetString(lector.GetOrdinal("descripcion"))) :
                    string.Empty;

                return $"{nombre}{(incluirDescripcion ? $"|{descripcion}" : string.Empty)}";
            }, parametros.ToArray());

            return nombres.ToArray();
        }
    }
}