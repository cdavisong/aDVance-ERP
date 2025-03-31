using aDVanceERP.Core.Excepciones;
using MySql.Data.MySqlClient;

using System.Globalization;

namespace aDVanceERP.Core.Utiles.Datos {
    public static class UtilesCompra {
        // Método auxiliar para ejecutar consultas y devolver un valor decimal
        private static decimal EjecutarConsultaDecimal(string query, params MySqlParameter[] parameters) {
            decimal resultado = 0;

            using (var conexion = new MySqlConnection(UtilesConfServidores.ObtenerStringConfServidorMySQL())) {
                try {
                    conexion.Open();

                    using (var comando = new MySqlCommand(query, conexion)) {
                        if (parameters != null) {
                            comando.Parameters.AddRange(parameters);
                        }

                        object result = comando.ExecuteScalar();

                        if (result != null && result != DBNull.Value) {
                            resultado = Convert.ToDecimal(result);
                        }
                    }
                } catch (MySqlException) {
                    throw new ExcepcionConexionServidorMySQL();
                } catch (Exception ex) {
                    throw new Exception("Error inesperado al ejecutar la consulta.", ex);
                }
            }

            return resultado;
        }

        // Método auxiliar para ejecutar consultas y devolver un valor entero
        private static int EjecutarConsultaEntero(string query, params MySqlParameter[] parameters) {
            int resultado = 0;

            using (var conexion = new MySqlConnection(UtilesConfServidores.ObtenerStringConfServidorMySQL())) {
                try {
                    conexion.Open();

                    using (var comando = new MySqlCommand(query, conexion)) {
                        if (parameters != null) {
                            comando.Parameters.AddRange(parameters);
                        }

                        object result = comando.ExecuteScalar();

                        if (result != null && result != DBNull.Value) {
                            resultado = Convert.ToInt32(result);
                        }
                    }
                } catch (MySqlException) {
                    throw new ExcepcionConexionServidorMySQL();
                } catch (Exception ex) {
                    throw new Exception("Error inesperado al ejecutar la consulta.", ex);
                }
            }

            return resultado;
        }

        // Método auxiliar para ejecutar consultas y devolver una lista de strings
        private static List<string> EjecutarConsultaLista(string query, params MySqlParameter[] parameters) {
            var resultado = new List<string>();

            using (var conexion = new MySqlConnection(UtilesConfServidores.ObtenerStringConfServidorMySQL())) {
                try {
                    conexion.Open();

                    using (var comando = new MySqlCommand(query, conexion)) {
                        if (parameters != null) {
                            comando.Parameters.AddRange(parameters);
                        }

                        using (var reader = comando.ExecuteReader()) {
                            while (reader.Read()) {
                                string fila = string.Empty;
                                for (int i = 0; i < reader.FieldCount; i++) {
                                    // Verificar si el valor es decimal y formatearlo correctamente
                                    if (reader.GetFieldType(i) == typeof(decimal)) {
                                        decimal valorDecimal = reader.GetDecimal(i);
                                        fila += valorDecimal.ToString("N2", CultureInfo.InvariantCulture) + ":";
                                    } else {
                                        fila += reader[i]?.ToString() + ":";
                                    }
                                }
                                resultado.Add(fila.TrimEnd(':'));
                            }
                        }
                    }
                } catch (MySqlException) {
                    throw new ExcepcionConexionServidorMySQL();
                } catch (Exception ex) {
                    throw new Exception("Error inesperado al ejecutar la consulta.", ex);
                }
            }

            return resultado;
        }

        public static int ObtenerCantidadProductosCompra(long idCompra) {
            const string query = """
                                 SELECT
                                    SUM(cantidad) AS total_productos
                                 FROM adv__detalle_compra_articulo
                                 WHERE id_compra = @IdCompra;
                                 """;
            var parametros = new[] {
                new MySqlParameter("@IdCompra", idCompra)
            };

            return EjecutarConsultaEntero(query, parametros);
        }

        public static IEnumerable<string> ObtenerArticulosPorCompra(long idCompra) {
            const string query = """
                                 SELECT
                                    a.nombre,
                                    d.cantidad
                                 FROM adv__detalle_compra_articulo d
                                 JOIN adv__articulo a ON d.id_articulo = a.id_articulo
                                 WHERE d.id_compra = @IdCompra;
                                 """;
            var parametros = new[]            {
                new MySqlParameter("@IdCompra", idCompra)
            };

            return EjecutarConsultaLista(query, parametros);
        }

        public static decimal ObtenerValorBrutoCompraDia(DateTime fecha) {
            const string query = """
                                 SELECT 
                                    SUM(total) AS total_dinero 
                                    FROM adv__compra 
                                    WHERE DATE(fecha) = @Fecha;
                                 """;
            var parametros = new[] {
                new MySqlParameter("@Fecha", fecha.ToString("yyyy-MM-dd"))
            };

            return EjecutarConsultaDecimal(query, parametros);
        }
    }
}
