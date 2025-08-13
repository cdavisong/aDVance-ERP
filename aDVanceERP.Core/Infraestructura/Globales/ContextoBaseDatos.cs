using aDVanceERP.Core.Infraestructura.Extensiones;
using aDVanceERP.Core.Modelos.BD;

using MySql.Data.MySqlClient;

namespace aDVanceERP.Core.Infraestructura.Globales;

public static class ContextoBaseDatos {
    private static MySqlConnection? _conexion = null;

    static ContextoBaseDatos() {
        EsConfiguracionCargada = false;
        Configuracion = ConfiguracionBaseDatos.Default;
    }

    public static bool EsConfiguracionCargada { get; set; }

    public static ConfiguracionBaseDatos Configuracion { get; }

    public static MySqlConnection Conexion {
        get {
            if (!EsConfiguracionCargada) {
                throw new InvalidOperationException("La configuración de la base de datos no ha sido cargada.");
            }
            if (_conexion == null) {
                _conexion = new MySqlConnection(Configuracion.ToStringConexion());
            }

            return _conexion;
        }
    }

    public static bool AbrirConexion() {
        if (!EsConfiguracionCargada) {
            throw new InvalidOperationException("La configuración de la base de datos no ha sido cargada.");
        }
        try {
            if (Conexion.State == System.Data.ConnectionState.Open) {
                return true; // La conexión ya está abierta
            } else
                Conexion.Open();

            return true;
        } catch (MySqlException ex) {
            throw new InvalidOperationException("Error al abrir la conexión a la base de datos.", ex);
        }
    }

    public static void CerrarConexion() {
        if (_conexion != null && _conexion.State == System.Data.ConnectionState.Open) {
            _conexion.Close();
        }
    }

    #region Métodos de ejecución de consultas en la base de datos

    public static MySqlCommand CrearComando(string consulta) {
        if (!EsConfiguracionCargada) {
            throw new InvalidOperationException("La configuración de la base de datos no ha sido cargada.");
        }

        AbrirConexion();

        var comando = new MySqlCommand(consulta, Conexion);

        return comando;
    }

    public static MySqlCommand CrearComando(string consulta, Dictionary<string, object>? parametros) {
        var comando = CrearComando(consulta);

        if (parametros != null) {
            foreach (var parametro in parametros) {
                comando.Parameters.AddWithValue(parametro.Key, parametro.Value);
            }
        }

        return comando;
    }

    public static IEnumerable<T> EjecutarConsulta<T>(string consulta, Dictionary<string, object>? parametros, Func<MySqlDataReader, T> mapeador) {
        if (!EsConfiguracionCargada) {
            throw new InvalidOperationException("La configuración de la base de datos no ha sido cargada.");
        }

        using var comando = CrearComando(consulta, parametros);
        using var lectorDatos = comando.ExecuteReader();

        var resultados = new List<T>();

        while (lectorDatos.Read())
            yield return mapeador(lectorDatos);

        CerrarConexion();
    }

    public static T EjecutarConsultaEscalar<T>(string consulta, Dictionary<string, object>? parametros = null, Func<MySqlDataReader, T>? mapeador = null) {
        if (!EsConfiguracionCargada) {
            throw new InvalidOperationException("La configuración de la base de datos no ha sido cargada.");
        }

        using var comando = CrearComando(consulta, parametros);
        var resultado = comando.ExecuteScalar();

        if (resultado == null || resultado == DBNull.Value) {
            return default!;
        }

        if (mapeador != null && resultado is MySqlDataReader lectorDatos) {
            return mapeador(lectorDatos);
        }

        CerrarConexion();

        return (T) Convert.ChangeType(resultado, typeof(T));
    }

    public static void EjecutarComandoNoQuery(string consulta, Dictionary<string, object>? parametros, MySqlTransaction? transaccion = null) {
        if (!EsConfiguracionCargada) {
            throw new InvalidOperationException("La configuración de la base de datos no ha sido cargada.");
        }

        using var comando = CrearComando(consulta, parametros);

        if (transaccion != null)
            comando.Transaction = transaccion;

        comando.ExecuteNonQuery();

        if (transaccion == null)
            CerrarConexion();
    }

    public static long EjecutarComandoInsert(string consulta, Dictionary<string, object> parametros, MySqlTransaction? transaccion = null) {
        if (!EsConfiguracionCargada) {
            throw new InvalidOperationException("La configuración de la base de datos no ha sido cargada.");
        }

        using var comando = CrearComando(consulta, parametros);

        if (transaccion != null)
            comando.Transaction = transaccion;

        comando.ExecuteNonQuery();

        var idInsertado = comando.LastInsertedId;

        if (transaccion == null)
            CerrarConexion();

        return idInsertado;
    }

    #endregion

    public static void ActualizarConfiguracion(ConfiguracionBaseDatos configuracion) {
        if (configuracion == null) {
            throw new ArgumentNullException(nameof(configuracion), "La configuración de la base de datos no puede ser nula.");
        }

        Configuracion.Servidor = configuracion.Servidor;
        Configuracion.BaseDatos = configuracion.BaseDatos;
        Configuracion.Usuario = configuracion.Usuario;
        Configuracion.Password = configuracion.Password;
        Configuracion.RecordarConfiguracion = configuracion.RecordarConfiguracion;

        // Crear una nueva conexión para verificar que la configuración es válida:
        using (var connection = new MySqlConnection(Configuracion.ToStringConexion())) {
            try {
                connection.Open();
                // Si la conexión se abre correctamente, la configuración es válida.
            } catch (MySqlException ex) {
                throw new InvalidOperationException("Error al conectar a la base de datos con la nueva configuración.", ex);
            }
        }

        EsConfiguracionCargada = true;
    }
}