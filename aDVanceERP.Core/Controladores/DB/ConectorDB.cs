using aDVanceERP.Core.Modelos.DB;

using MySql.Data.MySqlClient;

namespace aDVanceERP.Core.Controladores.DB;

public static class ConectorDB {
    static ConectorDB() {
        ConfServidorMySQL = CargarArchivoConfiguracionServidorMySQL() ?? new();
    }

    #region Configuración de la conexión con la base de datos

    public static ConfServidorMySQL ConfServidorMySQL { get; }
    public static bool ConfiguracionServidorMySQLCargada = false;

    public static ConfServidorMySQL CargarArchivoConfiguracionServidorMySQL() {
        var ruta = @".\settings\mysqlsrv.config";

        if (!File.Exists(ruta)) {
            Directory.CreateDirectory(@".\settings");
            File.WriteAllText(ruta, "127.0.0.1;advanceerp;admin;admin");
        }

        var datos = File.ReadAllText(ruta);
        var partes = datos.Split(';');

        if (partes.Length < 4)
            throw new InvalidOperationException("El archivo de configuración del servidor MySQL no contiene los datos necesarios.");

        var configuracion = new ConfServidorMySQL(partes[0], partes[1], partes[2], partes[3]);
        ConfiguracionServidorMySQLCargada = true;

        return configuracion;
    }

    public static void GuardarArchivoConfiguracionServidorMySQL(ConfServidorMySQL configuracion) {
        var ruta = @".\settings\mysqlsrv.config";

        Directory.CreateDirectory(@".\settings");
        File.WriteAllText(ruta, $"{ConfServidorMySQL.Servidor};{ConfServidorMySQL.BaseDatos};{ConfServidorMySQL.Usuario};{ConfServidorMySQL.Password}");

        ConfiguracionServidorMySQLCargada = false;
    }

    #endregion

    #region Métodos de Ejecución de Consultas

    public static IEnumerable<T> EjecutarConsulta<T>(
        MySqlConnection? conexionBd,
        string query,
        Dictionary<string, object>? parametros,
        Func<MySqlDataReader, T> mapeador) {
        var conexion = conexionBd ?? new MySqlConnection(ConfServidorMySQL.ToString());

        if (conexionBd == null || conexion.State != System.Data.ConnectionState.Open)
            conexion.Open();

        using (var comando = new MySqlCommand(query, conexion)) {
            if (parametros != null) {
                foreach (var param in parametros) {
                    comando.Parameters.AddWithValue(param.Key, param.Value);
                }
            }

            using (var lector = comando.ExecuteReader()) {
                while (lector.Read()) {
                    yield return mapeador(lector);
                }
            }
        }

        if (conexionBd == null)
            conexion.Close();
    }


    public static T EjecutarConsultaEscalar<T>(
        MySqlConnection? conexionBd,
        string query,
        Dictionary<string, object>? parametros = null,
        Func<MySqlDataReader, T>? mapeador = null) {
        var conexion = conexionBd ?? new MySqlConnection(ConfServidorMySQL.ToString());

        if (conexionBd == null || conexion.State != System.Data.ConnectionState.Open)
            conexion.Open();

        using (var comando = new MySqlCommand(query, conexion)) {
            if (parametros != null) {
                foreach (var param in parametros) {
                    comando.Parameters.AddWithValue(param.Key, param.Value);
                }
            }

            if (mapeador != null) {
                using (var lector = comando.ExecuteReader()) {
                    if (lector.Read()) {
                        return mapeador(lector);
                    }
                }
                return default!;
            }

            var resultado = comando.ExecuteScalar();

            if (conexionBd == null)
                conexion.Close();

            return (T) Convert.ChangeType(resultado, typeof(T));
        }
    }

    public static void EjecutarComandoNoQuery(
        MySqlConnection? conexionBd,
        string query,
        Dictionary<string, object>? parametros,
        MySqlTransaction? transaccion = null) {
        var conexion = conexionBd ?? new MySqlConnection(ConfServidorMySQL.ToString());

        if (conexionBd == null || conexion.State != System.Data.ConnectionState.Open)
            conexion.Open();

        using (var comando = new MySqlCommand(query, conexion, transaccion)) {
            if (parametros != null) {
                foreach (var param in parametros) {
                    comando.Parameters.AddWithValue(param.Key, param.Value);
                }
            }

            comando.ExecuteNonQuery();
        }

        if (conexionBd == null)
            conexion.Close();
    }

    public static long EjecutarComandoInsert(
        MySqlConnection? conexionBd,
        string query,
        Dictionary<string, object> parametros,
        MySqlTransaction? transaccion = null) {
        var conexion = conexionBd ?? new MySqlConnection(ConfServidorMySQL.ToString());

        if (conexionBd == null || conexion.State != System.Data.ConnectionState.Open)
            conexion.Open();

        using (var comando = new MySqlCommand(query, conexion, transaccion)) {
            foreach (var param in parametros) {
                comando.Parameters.AddWithValue(param.Key, param.Value);
            }

            comando.ExecuteNonQuery();
            var ultimoId = comando.LastInsertedId;

            if (conexionBd == null)
                conexion.Close();


            return ultimoId;
        }
    }

    #endregion
}
