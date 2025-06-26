using aDVanceERP.Core.Datos.Interfaces;
using MySql.Data.MySqlClient;

namespace aDVanceERP.Core.Datos.Repositorios;

public abstract class RepositorioDatosEntidadBase<En, Fb> : IDisposable
    where En : class, IEntidad, new()
    where Fb : Enum {
    protected RepositorioDatosEntidadBase(string nombreTabla, string columnaId) {
        CacheObjetos = new List<En>();
        NombreTabla = nombreTabla;
        ColumnaId = columnaId;
    }

    public List<En> CacheObjetos { get; }

    protected string NombreTabla { get; }

    protected string ColumnaId { get; }


    public int Cantidad(MySqlConnection conexionBd = null) {
        var query = $"SELECT COUNT(*) FROM {NombreTabla};";

        return CoreDatos.EjecutarConsultaEscalar<int>(conexionBd, query);
    }

    public virtual long Insertar(En entidad, MySqlConnection conexionBd = null) {
        var (query, parametros) = GenerarComandoInsertar(entidad);
        var id = CoreDatos.EjecutarComandoInsert(conexionBd, query, parametros);

        return id;
    }

    public virtual bool Actualizar(En entidad, MySqlConnection conexionBd = null) {
        var (query, parametros) = GenerarComandoActualizar(entidad);

        CoreDatos.EjecutarComandoNoQuery(conexionBd, query, parametros);

        return true;
    }

    public virtual bool Eliminar(long id, MySqlConnection conexionBd = null) {
        var (query, parametros) = GenerarComandoEliminar(id);

        CoreDatos.EjecutarComandoNoQuery(conexionBd, query, parametros);

        return true;
    }

    public En? ObtenerPorId(object id, MySqlConnection? conexionBd = null) {
        var query = $"SELECT * FROM {NombreTabla} WHERE {ColumnaId} = @id LIMIT 1";
        var parametros = new Dictionary<string, object> { { "@id", id } };

        return CoreDatos.EjecutarConsultaEscalar(conexionBd, query, parametros, MapearEntidad);
    }

    public (int cantidad, List<En> resultados) Obtener(Fb? filtroBusqueda, string? criterio, int limite = 0, int desplazamiento = 0, MySqlConnection conexionBd = null) {
        var (query, parametros) = GenerarComandoObtener(filtroBusqueda, criterio);
        var queryLimitOffset = query;
        var conexion = conexionBd ?? new MySqlConnection(CoreDatos.ConfServidorMySQL.ToString());

        // Agregar LIMIT y OFFSET si es necesario (antes del ;)
        if (limite > 0) {
            queryLimitOffset = queryLimitOffset.TrimEnd(';'); // Eliminar el ; si existe
            queryLimitOffset += $" LIMIT {limite}";

            if (desplazamiento > 0)
                queryLimitOffset += $" OFFSET {desplazamiento}";
            queryLimitOffset += ";"; // Agregar el ; al final
        }

        var cantidad = CoreDatos.EjecutarConsultaEscalar<int>(conexion, query.Replace("*", $"COUNT({ColumnaId})"), parametros);
        var resultados = CoreDatos.EjecutarConsulta(conexion, queryLimitOffset, parametros, MapearEntidad);

        if (conexionBd == null)
            conexion.Close();

        return (cantidad, resultados.ToList());
    }

    public bool Existe(object id, MySqlConnection? conexionBd = null) {
        var query = $"SELECT COUNT(1) FROM {NombreTabla} WHERE {ColumnaId} = @id";
        var parametros = new Dictionary<string, object> { { "@id", id } };

        var resultado = CoreDatos.EjecutarConsultaEscalar<long>(conexionBd, query, parametros);
        return resultado > 0;
    }


    public void Dispose() {
        Dispose(true);
        GC.SuppressFinalize(this);
    }

    public abstract (string query, Dictionary<string, object> parametros) GenerarComandoInsertar(En objeto);
    public abstract (string query, Dictionary<string, object> parametros) GenerarComandoActualizar(En objeto);
    public abstract (string query, Dictionary<string, object> parametros) GenerarComandoEliminar(long id);
    public abstract (string query, Dictionary<string, object> parametros) GenerarComandoObtener(Fb filtroBusqueda, string criterio);
    public abstract En MapearEntidad(MySqlDataReader lectorDatos);

    protected virtual void Dispose(bool disposing) {
        if (disposing) CacheObjetos?.Clear();
    }

    ~RepositorioDatosEntidadBase() {
        Dispose(false);
    }
}