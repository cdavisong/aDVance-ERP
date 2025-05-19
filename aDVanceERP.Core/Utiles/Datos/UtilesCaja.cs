using aDVanceERP.Core.Excepciones;
using MySql.Data.MySqlClient;

namespace aDVanceERP.Core.Utiles.Datos {
    public static class UtilesCaja {
        private static int EjecutarConsultaEntero(string query, params MySqlParameter[] parameters) {
            var resultado = 0;

            using (var conexion = new MySqlConnection(UtilesConfServidores.ObtenerStringConfServidorMySQL())) {
                try {
                    conexion.Open();

                    using (var comando = new MySqlCommand(query, conexion)) {
                        if (parameters != null) comando.Parameters.AddRange(parameters);

                        var result = comando.ExecuteScalar();

                        if (result != null && result != DBNull.Value) resultado = Convert.ToInt32(result);
                    }
                }
                catch (MySqlException) {
                    throw new ExcepcionConexionServidorMySQL();
                }
                catch (Exception ex) {
                    throw new Exception("Error inesperado al ejecutar la consulta.", ex);
                }
            }

            return resultado;
        }

        public static bool ExisteCajaActiva() {
            var query = $"""
                     SELECT COUNT(1)
                     FROM adv__caja
                     WHERE estado='Abierta';
                     """;

            return EjecutarConsultaEntero(query) > 0;
        }
    }
}
