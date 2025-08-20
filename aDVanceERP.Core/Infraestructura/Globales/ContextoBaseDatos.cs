using aDVanceERP.Core.Infraestructura.Extensiones;
using aDVanceERP.Core.Modelos.BD;

using MySql.Data.MySqlClient;

using System.Data;

namespace aDVanceERP.Core.Infraestructura.Globales;

public static class ContextoBaseDatos {
    private static readonly ConfiguracionBaseDatos _configuracion = ConfiguracionBaseDatos.Default;
    private static readonly object _lockObject = new();

    public static bool EsConfiguracionCargada { get; private set; }

    public static ConfiguracionBaseDatos Configuracion => _configuracion;

    public static bool AbrirConexion(MySqlConnection conexion) {
        if (!EsConfiguracionCargada)
            throw new InvalidOperationException("La configuración de la base de datos no ha sido cargada.");

        if (conexion.State == ConnectionState.Open)
            return true;

        try {
            conexion.Open();
            return true;
        } catch (MySqlException ex) {
            throw new InvalidOperationException("Error al abrir la conexión a la base de datos.", ex);
        }
    }

    public static void CerrarConexion(MySqlConnection conexion) {
        if (conexion?.State == ConnectionState.Open) {
            conexion.Close();
        }
    }

    #region Métodos optimizados de ejecución de consultas

    public static MySqlCommand CrearComando(string consulta, Dictionary<string, object>? parametros = null) {
        ValidarConfiguracionCargada();

        var conexion = new MySqlConnection(_configuracion.ToStringConexion());
        AbrirConexion(conexion);

        var comando = new MySqlCommand(consulta, conexion);

        if (parametros != null) {
            foreach (var parametro in parametros) {
                comando.Parameters.AddWithValue(parametro.Key, parametro.Value);
            }
        }

        return comando;
    }

    public static IEnumerable<T> EjecutarConsulta<T>(string consulta, Dictionary<string, object>? parametros, Func<MySqlDataReader, T> mapeador) {
        ValidarConfiguracionCargada();

        using var comando = CrearComando(consulta, parametros);
        using var lectorDatos = comando.ExecuteReader();

        while (lectorDatos.Read()) {
            yield return mapeador(lectorDatos);
        }

        CerrarConexion(comando.Connection);
    }

    public static async IAsyncEnumerable<T> EjecutarConsultaAsync<T>(string consulta, Dictionary<string, object>? parametros, Func<MySqlDataReader, T> mapeador) {
        ValidarConfiguracionCargada();

        using var comando = CrearComando(consulta, parametros);
        using var lectorDatos = await comando.ExecuteReaderAsync();

        while (await lectorDatos.ReadAsync()) {
            yield return mapeador((MySqlDataReader) lectorDatos);
        }

        CerrarConexion(comando.Connection);
    }

    public static T? EjecutarConsultaEscalar<T>(string consulta, Dictionary<string, object>? parametros = null) {
        ValidarConfiguracionCargada();

        using var comando = CrearComando(consulta, parametros);
        var resultado = comando.ExecuteScalar();

        CerrarConexion(comando.Connection);

        return resultado == null || resultado == DBNull.Value
            ? default
            : (T) Convert.ChangeType(resultado, typeof(T));
    }

    public static async Task<T?> EjecutarConsultaEscalarAsync<T>(string consulta, Dictionary<string, object>? parametros = null) {
        ValidarConfiguracionCargada();

        using var comando = CrearComando(consulta, parametros);
        var resultado = await comando.ExecuteScalarAsync();

        CerrarConexion(comando.Connection);

        return resultado == null || resultado == DBNull.Value
            ? default
            : (T) Convert.ChangeType(resultado, typeof(T));
    }

    public static int EjecutarComandoNoQuery(string consulta, Dictionary<string, object>? parametros, MySqlTransaction? transaccion = null) {
        ValidarConfiguracionCargada();

        using var comando = CrearComando(consulta, parametros);

        if (transaccion != null)
            comando.Transaction = transaccion;

        var filasAfectadas = comando.ExecuteNonQuery();
        CerrarConexion(comando.Connection);

        return filasAfectadas;
    }

    public static async Task<int> EjecutarComandoNoQueryAsync(string consulta, Dictionary<string, object>? parametros, MySqlTransaction? transaccion = null) {
        ValidarConfiguracionCargada();

        using var comando = CrearComando(consulta, parametros);

        if (transaccion != null)
            comando.Transaction = transaccion;

        var filasAfectadas = await comando.ExecuteNonQueryAsync();
        CerrarConexion(comando.Connection);

        return filasAfectadas;
    }

    public static long EjecutarComandoInsert(string consulta, Dictionary<string, object> parametros, MySqlTransaction? transaccion = null) {
        ValidarConfiguracionCargada();

        using var comando = CrearComando(consulta, parametros);

        if (transaccion != null)
            comando.Transaction = transaccion;

        comando.ExecuteNonQuery();
        var idInsertado = comando.LastInsertedId;

        CerrarConexion(comando.Connection);

        return idInsertado;
    }

    public static async Task<long> EjecutarComandoInsertAsync(string consulta, Dictionary<string, object> parametros, MySqlTransaction? transaccion = null) {
        ValidarConfiguracionCargada();

        using var comando = CrearComando(consulta, parametros);

        if (transaccion != null)
            comando.Transaction = transaccion;

        await comando.ExecuteNonQueryAsync();
        var idInsertado = comando.LastInsertedId;

        CerrarConexion(comando.Connection);

        return idInsertado;
    }

    #endregion

    public static void ActualizarConfiguracion(ConfiguracionBaseDatos configuracion) {
        if (configuracion == null)
            throw new ArgumentNullException(nameof(configuracion), "La configuración de la base de datos no puede ser nula.");

        lock (_lockObject) {
            _configuracion.Servidor = configuracion.Servidor;
            _configuracion.BaseDatos = configuracion.BaseDatos;
            _configuracion.Usuario = configuracion.Usuario;
            _configuracion.Password = configuracion.Password;
            _configuracion.RecordarConfiguracion = configuracion.RecordarConfiguracion;

            // Validar la nueva configuración
            ValidarConexion();

            EsConfiguracionCargada = true;
        }
    }

    private static void ValidarConfiguracionCargada() {
        if (!EsConfiguracionCargada)
            throw new InvalidOperationException("La configuración de la base de datos no ha sido cargada.");
    }

    private static void ValidarConexion() {
        using var connection = new MySqlConnection(_configuracion.ToStringConexion());
        try {
            connection.Open();
        } catch (MySqlException ex) {
            throw new InvalidOperationException("Error al conectar a la base de datos con la nueva configuración.", ex);
        }
    }

    // Método para obtener una conexión reutilizable (opcional, para transacciones)
    public static MySqlConnection ObtenerConexion() {
        ValidarConfiguracionCargada();

        var conexion = new MySqlConnection(_configuracion.ToStringConexion());
        AbrirConexion(conexion);

        return conexion;
    }
}