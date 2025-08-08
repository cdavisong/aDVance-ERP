using aDVanceERP.Core.Controladores.Comun;
using aDVanceERP.Core.Interfaces;

using MySql.Data.MySqlClient;

namespace aDVanceERP.Core.Repositorios.Comun;

public abstract class RepoBase<En, Fb> : IRepoBase<En, Fb>
    where En : class, IEntidadBd, new()
    where Fb : Enum {
    protected RepoBase(string nombreTabla, string columnaId) {
        CacheObjetos = new List<En>();
        NombreTabla = nombreTabla;
        ColumnaId = columnaId;
    }

    ~RepoBase() {
        Dispose(false);
    }

    public List<En> CacheObjetos { get; }
    protected string NombreTabla { get; }
    protected string ColumnaId { get; }

    public virtual long Cantidad(MySqlConnection? conexionBd = null) {
        var query = $"""
            SELECT COUNT(*) 
            FROM {NombreTabla};
            """;

        return EjecutarConsultaEscalar<long>(conexionBd, query);
    }

    public virtual long Insertar(En entidad, MySqlConnection? conexionBd = null) {
        var (query, parametros) = entidad.GenerarQueryInsert();
        var id = EjecutarComandoInsert(conexionBd, query, parametros);

        return id;
    }

    public virtual void Actualizar(En entidad, MySqlConnection? conexionBd = null) {
        var (query, parametros) = entidad.GenerarQueryUpdate();

        EjecutarComandoNoQuery(conexionBd, query, parametros);
    }

    public virtual void Eliminar(En entidad, MySqlConnection? conexionBd = null) {
        var (query, parametros) = entidad.GenerarQueryDelete();

        EjecutarComandoNoQuery(conexionBd, query, parametros);
    }

    public En? ObtenerPorId(object id, MySqlConnection? conexionBd = null) {
        var query = $"""
            SELECT * 
            FROM {NombreTabla} 
            WHERE {ColumnaId} = @Id 
            LIMIT 1
            """;
        var parametros = new Dictionary<string, object> { 
            { "@Id", id } 
        };

        return EjecutarConsultaEscalar(conexionBd, query, parametros, MapearEntidad);
    }

    public (int cantidad, List<En> resultados) Obtener(Fb? filtroBusqueda, string? criterio, int limite = 0, int desplazamiento = 0, MySqlConnection? conexionBd = null) {
        var (query, parametros) = GenerarQueryObtener(filtroBusqueda, criterio);
        var queryLimitOffset = query;
        var conexion = conexionBd ?? new MySqlConnection(ConexionServidorMySQL.ConfServidorMySQL.ToString());

        // Agregar LIMIT y OFFSET si es necesario (antes del ;)
        if (limite > 0) {
            queryLimitOffset = queryLimitOffset.TrimEnd(';'); // Eliminar el ; si existe
            queryLimitOffset += $" LIMIT {limite}";

            if (desplazamiento > 0)
                queryLimitOffset += $" OFFSET {desplazamiento}";
            queryLimitOffset += ";"; // Agregar el ; al final
        }

        var cantidad = EjecutarConsultaEscalar<int>(conexion, query.Replace("*", $"COUNT({ColumnaId})"), parametros);
        var resultados = EjecutarConsulta(conexion, queryLimitOffset, parametros, MapearEntidad);

        if (conexionBd == null)
            conexion.Close();

        return (cantidad, resultados.ToList());
    }


    public bool Existe(object id, MySqlConnection? conexionBd = null) {
        var query = $"""
            SELECT COUNT(1) 
            FROM {NombreTabla} 
            WHERE {ColumnaId} = @Id
            """;
        var parametros = new Dictionary<string, object> { 
            { "@Id", id } 
        };

        var resultado = EjecutarConsultaEscalar<long>(conexionBd, query, parametros);

        return resultado > 0;
    }

    public void Dispose() {
        Dispose(true);
        GC.SuppressFinalize(this);
    }

    public abstract (string query, Dictionary<string, object> parametros) GenerarQueryObtener(Fb filtroBusqueda, string criterio);
    public abstract En MapearEntidad(MySqlDataReader lectorDatos);

    protected virtual void Dispose(bool disposing) {
        if (disposing) CacheObjetos?.Clear();
    }

    #region Métodos de Ejecución de Consultas

    public static IEnumerable<T> EjecutarConsulta<T>(
        MySqlConnection? conexionBd,
        string query,
        Dictionary<string, object>? parametros,
        Func<MySqlDataReader, T> mapeador) {
        var conexion = conexionBd ?? new MySqlConnection(ConexionServidorMySQL.ConfServidorMySQL.ToString());

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
        var conexion = conexionBd ?? new MySqlConnection(ConexionServidorMySQL.ConfServidorMySQL.ToString());

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

            return (T)Convert.ChangeType(resultado, typeof(T));
        }
    }

    public static void EjecutarComandoNoQuery(
        MySqlConnection? conexionBd,
        string query,
        Dictionary<string, object>? parametros,
        MySqlTransaction? transaccion = null) {
        var conexion = conexionBd ?? new MySqlConnection(ConexionServidorMySQL.ConfServidorMySQL.ToString());

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
        var conexion = conexionBd ?? new MySqlConnection(ConexionServidorMySQL.ConfServidorMySQL.ToString());

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