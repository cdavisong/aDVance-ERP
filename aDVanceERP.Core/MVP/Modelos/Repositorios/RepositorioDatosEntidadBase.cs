using aDVanceERP.Core.Excepciones;
using aDVanceERP.Core.MVP.Modelos.Plantillas;
using aDVanceERP.Core.MVP.Modelos.Repositorios.Plantillas;
using aDVanceERP.Core.Utiles;
using MySql.Data.MySqlClient;

namespace aDVanceERP.Core.MVP.Modelos.Repositorios; 

public abstract class RepositorioDatosEntidadBase<En, Fb> : IRepositorioDatosEntidad<En, Fb>
    where En : class, IEntidad, new()
    where Fb : Enum {
    private List<En> _entidadesCache = new List<En>();

    protected RepositorioDatosEntidadBase(string nombreTabla, string columnaId) {
        NombreTabla = nombreTabla;
        ColumnaId = columnaId;
    }

    protected string NombreTabla { get; }

    protected string ColumnaId { get; }

    public abstract string[] FiltrosBusqueda { get; }

    public En? ObtenerPorId(object id, MySqlConnection? conexionBd = null) {
        var query = $"SELECT * FROM {NombreTabla} WHERE {ColumnaId} = @id LIMIT 1";
        var parametros = new Dictionary<string, object> { { "@id", id } };

        return EjecutarConsultaEscalar(conexionBd, query, parametros, MapearEntidad);
    }

    public List<En> ObtenerTodos(MySqlConnection? conexionBd = null) {
        var query = $"SELECT * FROM {NombreTabla}";
        var resultados = EjecutarConsulta(conexionBd, query, null, MapearEntidad);

        return resultados.ToList();
    }

    public (List<En> resultados, int totalFilas) Buscar(Fb? filtroBusqueda, string? datosComplementarios, int limite = 0, int desplazamiento = 0, MySqlConnection? conexionBd = null) {
        var (whereClause, parametros) = GenerarWhereClause(filtroBusqueda, datosComplementarios);
        var query = $"""
                SELECT SQL_CALC_FOUND_ROWS * FROM {NombreTabla} 
                WHERE {whereClause}
                """;

        // Agregar LIMIT y OFFSET si es necesario (antes del ;)
        if (limite > 0) {
            query = query.TrimEnd(';'); // Eliminar el ; si existe
            query += $" LIMIT {limite}";
            if (desplazamiento > 0) query += $" OFFSET {desplazamiento}";
            query += ";"; // Agregar el ; al final
        }
        
        var conexion = conexionBd ?? new MySqlConnection(ObtenerCadenaConexion());
        var resultados = EjecutarConsulta(conexion, query, parametros, MapearEntidad);

        query = """
            SELECT FOUND_ROWS() AS TotalFilas;
            """;

        var totalFilas = EjecutarConsultaEscalar<int>(conexion, query);

        conexion.Close();

        return (resultados.ToList(), totalFilas);
    }

    public List<En> BuscarAvanzado(Func<ConsultaBuilder, ConsultaBuilder> construirConsulta, MySqlConnection? conexionBd = null) {
        var builder = new ConsultaBuilder(NombreTabla);
        builder = construirConsulta(builder);

        var resultados = EjecutarConsulta(conexionBd, builder.Query, builder.Parametros, MapearEntidad);

        return resultados.ToList();
    }

    public virtual long Insertar(En entidad, MySqlConnection? conexionBd = null) {
        var (query, parametros) = GenerarComandoInsertar(entidad);
        var id = EjecutarComandoInsert(conexionBd, query, parametros);

        // Asignar el ID generado
        var property = entidad.GetType().GetProperty("Id");
        
        if (property != null && property.CanWrite)
            property.SetValue(entidad, id);
        
        return id;
    }

    public void InsertarRango(List<En> entidades, MySqlConnection? conexionBd = null) {
        var conexion = conexionBd ?? new MySqlConnection(ObtenerCadenaConexion());

        using (var transaccion = conexion.BeginTransaction()) {
            try {
                foreach (var entidad in entidades) {
                    var (query, parametros) = GenerarComandoInsertar(entidad);
                    var id = EjecutarComandoInsert(conexion, query, parametros, transaccion);

                    var property = entidad.GetType().GetProperty("Id");
                    
                    if (property != null && property.CanWrite)
                        property.SetValue(entidad, id);
                }
                transaccion.Commit();
            } catch {
                transaccion.Rollback();
                throw;
            }
        }
    }

    public virtual void Actualizar(En entidad, MySqlConnection? conexionBd = null) {
        var (query, parametros) = GenerarComandoActualizar(entidad);

        EjecutarComandoNoQuery(conexionBd, query, parametros);
    }

    public void ActualizarRango(List<En> entidades, MySqlConnection? conexionBd = null) {
        var conexion = conexionBd ?? new MySqlConnection(ObtenerCadenaConexion());

        using (var transaccion = conexion.BeginTransaction()) {
            try {
                foreach (var entidad in entidades) {
                    var (query, parametros) = GenerarComandoActualizar(entidad);
                    EjecutarComandoNoQuery(conexion, query, parametros, transaccion);
                }
                transaccion.Commit();
            } catch {
                transaccion.Rollback();
                throw;
            }
        }
    }

    public void Eliminar(object id, MySqlConnection? conexionBd = null) {
        var query = $"DELETE FROM {NombreTabla} WHERE {ColumnaId} = @id";
        var parametros = new Dictionary<string, object> { { "@id", id } };

        EjecutarComandoNoQuery(conexionBd, query, parametros);
    }

    public void Eliminar(En entidad, MySqlConnection? conexionBd = null) {
        var property = entidad.GetType().GetProperty("Id");
        if (property != null) {
            var id = property.GetValue(entidad);
            Eliminar(id, conexionBd);
        }
    }

    public void EliminarRango(List<En> entidades, MySqlConnection? conexionBd = null) {
        var conexion = conexionBd ?? new MySqlConnection(ObtenerCadenaConexion());

        using (var transaccion = conexion.BeginTransaction()) {
            try {
                foreach (var entidad in entidades) {
                    Eliminar(entidad, conexionBd);
                }
                transaccion.Commit();
            } catch {
                transaccion.Rollback();
                throw;
            }
        }
    }

    public bool Existe(object id, MySqlConnection? conexionBd = null) {
        var query = $"SELECT COUNT(1) FROM {NombreTabla} WHERE {ColumnaId} = @id";
        var parametros = new Dictionary<string, object> { { "@id", id } };

        var resultado = EjecutarConsultaEscalar<long>(conexionBd, query, parametros);
        return resultado > 0;
    }

    public int Contar(Fb? filtroBusqueda = default, MySqlConnection? conexionBd = null) {
        var whereClause = filtroBusqueda?.ToString().Contains("Todos") ?? false ?
            $"WHERE {GenerarWhereClause(filtroBusqueda, string.Empty)}" :
            string.Empty;

        var query = $"SELECT COUNT(*) FROM {NombreTabla} {whereClause}";
        return EjecutarConsultaEscalar<int>(conexionBd, query);
    }

    #region Métodos Protegidos para Heredar

    protected abstract En MapearEntidad(MySqlDataReader lectorDatos);
    protected abstract (string Query, Dictionary<string, object> Parametros) GenerarComandoInsertar(En entidad);
    protected abstract (string Query, Dictionary<string, object> Parametros) GenerarComandoActualizar(En entidad);
    protected abstract (string WhereClause, Dictionary<string, object> Parametros) GenerarWhereClause(Fb filtroBusqueda, string? datosComplementarios);

    #endregion

    #region Métodos de Ejecución de Consultas

    protected string ObtenerCadenaConexion() {
        return UtilesConfServidores.ObtenerStringConfServidorMySQL();
    }

    protected IEnumerable<T> EjecutarConsulta<T>(
        MySqlConnection? conexionBd,
        string query,
        Dictionary<string, object>? parametros,
        Func<MySqlDataReader, T> mapeador) {
        var conexion = conexionBd ?? new MySqlConnection(ObtenerCadenaConexion());

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


    protected T EjecutarConsultaEscalar<T>(
        MySqlConnection? conexionBd,
        string query,
        Dictionary<string, object>? parametros = null,
        Func<MySqlDataReader, T>? mapeador = null) {
        var conexion = conexionBd ?? new MySqlConnection(ObtenerCadenaConexion());

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

    protected void EjecutarComandoNoQuery(
        MySqlConnection? conexionBd,
        string query,
        Dictionary<string, object>? parametros,
        MySqlTransaction? transaccion = null) {
        var conexion = conexionBd ?? new MySqlConnection(ObtenerCadenaConexion());

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

    protected long EjecutarComandoInsert(
        MySqlConnection? conexionBd,
        string query,
        Dictionary<string, object> parametros,
        MySqlTransaction? transaccion = null) {
        var conexion = conexionBd ?? new MySqlConnection(ObtenerCadenaConexion());

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

    #region IDisposable

    private bool _disposedValue;

    ~RepositorioDatosEntidadBase() {
        Dispose(false);
    }

    protected virtual void Dispose(bool disposing) {
        if (!_disposedValue) {
            if (disposing) {
                _entidadesCache.Clear();
            }
            _disposedValue = true;
        }
    }

    public void Dispose() {
        Dispose(disposing: true);
        GC.SuppressFinalize(this);
    }

    #endregion
}