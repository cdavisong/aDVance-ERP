using System.Globalization;
using aDVanceERP.Core.Excepciones;
using MySql.Data.MySqlClient;

namespace aDVanceERP.Core.Utiles.Datos; 

public static class UtilesCompra {
    // Método auxiliar para ejecutar consultas y devolver un valor decimal
    private static decimal EjecutarConsultaDecimal(string query, params MySqlParameter[] parameters) {
        decimal resultado = 0;

        using (var conexion = new MySqlConnection(UtilesConfServidores.ObtenerStringConfServidorMySQL())) {
            try {
                conexion.Open();

                using (var comando = new MySqlCommand(query, conexion)) {
                    if (parameters != null) comando.Parameters.AddRange(parameters);

                    var result = comando.ExecuteScalar();

                    if (result != null && result != DBNull.Value) resultado = Convert.ToDecimal(result);
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

    // Método auxiliar para ejecutar consultas y devolver un valor entero
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

    // Método auxiliar para ejecutar consultas y devolver una lista de strings
    private static List<string> EjecutarConsultaLista(string query, params MySqlParameter[] parameters) {
        var resultado = new List<string>();

        using (var conexion = new MySqlConnection(UtilesConfServidores.ObtenerStringConfServidorMySQL())) {
            try {
                conexion.Open();

                using (var comando = new MySqlCommand(query, conexion)) {
                    if (parameters != null) comando.Parameters.AddRange(parameters);

                    using (var reader = comando.ExecuteReader()) {
                        while (reader.Read()) {
                            var fila = string.Empty;
                            for (var i = 0; i < reader.FieldCount; i++)
                                // Verificar si el valor es decimal y formatearlo correctamente
                                if (reader.GetFieldType(i) == typeof(decimal)) {
                                    var valorDecimal = reader.GetDecimal(i);
                                    fila += valorDecimal.ToString("N2", CultureInfo.InvariantCulture) + "|";
                                }
                                else {
                                    fila += reader[i] + "|";
                                }

                            resultado.Add(fila.TrimEnd('|'));
                        }
                    }
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

    public static int ObtenerCantidadProductosCompra(long idCompra) {
        const string query = """
                             SELECT
                                SUM(cantidad) AS total_productos
                             FROM adv__detalle_compra_producto
                             WHERE id_compra = @IdCompra;
                             """;
        var parametros = new[] {
            new MySqlParameter("@IdCompra", idCompra)
        };

        return EjecutarConsultaEntero(query, parametros);
    }

    public static IEnumerable<string> ObtenerProductosPorCompra(long idCompra) {
        const string query = """
                             SELECT
                                a.nombre,
                                d.cantidad
                             FROM adv__detalle_compra_producto d
                             JOIN adv__producto a ON d.id_producto = a.id_producto
                             WHERE d.id_compra = @IdCompra;
                             """;
        var parametros = new[] {
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