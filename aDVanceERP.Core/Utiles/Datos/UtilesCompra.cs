using aDVanceERP.Core.Excepciones;
using MySql.Data.MySqlClient;

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

        public static decimal ObtenerValorBrutoCompraDia(DateTime fecha) {
            string query = "SELECT SUM(total) AS total_dinero FROM adv__compra WHERE DATE(fecha) = @Fecha;";
            var parametros = new MySqlParameter[]
            {
                new MySqlParameter("@Fecha", fecha.ToString("yyyy-MM-dd"))
            };

            return EjecutarConsultaDecimal(query, parametros);
        }
    }
}
