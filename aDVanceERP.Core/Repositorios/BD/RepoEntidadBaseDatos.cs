using aDVanceERP.Core.Infraestructura.Globales;
using aDVanceERP.Core.Modelos.Comun.Interfaces;
using aDVanceERP.Core.Repositorios.Interfaces;
using MySql.Data.MySqlClient;

namespace aDVanceERP.Core.Repositorios.BD;

public abstract class RepoEntidadBaseDatos<En, Fb> : IRepoEntidadBaseDatos<En, Fb>
    where En : class, IEntidadBaseDatos, new()
    where Fb : Enum {
    private List<En> _cacheEntidades;

    protected RepoEntidadBaseDatos() {
        _cacheEntidades = new List<En>();

        NombreTabla = string.Empty;
        ColumnaId = string.Empty;
    }

    protected RepoEntidadBaseDatos(string nombreTabla, string columnaId) : this() {
        NombreTabla = nombreTabla;
        ColumnaId = columnaId;
    }

    protected string NombreTabla { get; }

    protected string ColumnaId { get; }

    public abstract string[] FiltrosBusqueda { get; }


    #region Obtención de datos y búsqueda de entidades

    public En? ObtenerPorId(object? id) {
        var consulta = $"SELECT * FROM {NombreTabla} WHERE {ColumnaId} = @id LIMIT 1";
        var parametros = new Dictionary<string, object> { { "@id", id } };

        return ContextoBaseDatos.EjecutarConsultaEscalar(consulta, parametros, MapearEntidad);
    }

    public IEnumerable<En> ObtenerTodos() {
        var consulta = $"SELECT * FROM {NombreTabla}";
        var resultados = ContextoBaseDatos.EjecutarConsulta(consulta, null, MapearEntidad);

        _cacheEntidades.Clear();
        _cacheEntidades.AddRange(resultados);

        return resultados;
    }

    public (int cantidad, IEnumerable<En> resultados) Buscar(string? consulta = "", int limite = 0, int desplazamiento = 0) {
        _cacheEntidades.Clear();

        consulta = string.IsNullOrEmpty(consulta) ? GenerarClausulaWhere(default, string.Empty) : consulta;

        // Agregar LIMIT y OFFSET si es necesario (antes del ;)
        if (limite > 0) {
            consulta = consulta.TrimEnd(';'); // Eliminar el ; si existe
            consulta += $" LIMIT {limite}";

            if (desplazamiento > 0)
                consulta += $" OFFSET {desplazamiento}";

            consulta += ";"; // Agregar el ; al final
        }

        var cantidad = ContextoBaseDatos.EjecutarConsultaEscalar<int>(consulta.Replace("*", $"COUNT(*)"));
        var resultados = ContextoBaseDatos.EjecutarConsulta(consulta, new Dictionary<string, object>(), MapearEntidad);

        return (cantidad, resultados);
    }

    public (int cantidad, IEnumerable<En> resultados) Buscar(Fb? filtroBusqueda, string? criterio, int limite = 0, int desplazamiento = 0) {
        var comando = GenerarClausulaWhere(filtroBusqueda, criterio);

        return Buscar(comando, limite, desplazamiento);
    }

    #endregion

    #region CRUD

    public virtual long Insertar(En entidad) {
        var (consulta, parametros) = GenerarComandoInsertar(entidad);
        var id = ContextoBaseDatos.EjecutarComandoInsert(consulta, parametros);

        // Asignar el ID generado
        var property = entidad.GetType().GetProperty("Id");
        if (property != null && property.CanWrite) {
            property.SetValue(entidad, id);
        }

        return id;
    }

    public virtual void Actualizar(En entidad) {
        var (consulta, parametros) = GenerarComandoActualizar(entidad);

        ContextoBaseDatos.EjecutarComandoNoQuery(consulta, parametros);
    }

    public virtual void Eliminar(long id) {
        var consulta = $"DELETE FROM {NombreTabla} WHERE {ColumnaId} = @id";
        var parametros = new Dictionary<string, object> { { "@id", id } };

        ContextoBaseDatos.EjecutarComandoNoQuery(consulta, parametros);
    }

    #endregion

    #region Utilidades

    public bool Existe(object id) {
        var consulta = $"SELECT COUNT(1) FROM {NombreTabla} WHERE {ColumnaId} = @id";
        var parametros = new Dictionary<string, object> { { "@id", id } };
        var resultado = ContextoBaseDatos.EjecutarConsultaEscalar<long>(consulta, parametros);

        return resultado > 0;
    }

    public virtual int Contar(Fb? filtroBusqueda = default, string? criterio = "") {
        var clausulaWhere = filtroBusqueda != null && !filtroBusqueda.ToString().Contains("Todos") ?
            $"WHERE {GenerarClausulaWhere(filtroBusqueda, criterio)}" :
            string.Empty;
        var consulta = $"SELECT COUNT(*) FROM {NombreTabla} {clausulaWhere}";

        return (int)ContextoBaseDatos.EjecutarConsultaEscalar<long>(consulta);
    }

    #endregion

    #region Métodos Protegidos para Heredar

    protected abstract En MapearEntidad(MySqlDataReader lectorDatos);
    protected abstract (string Consulta, Dictionary<string, object> Parametros) GenerarComandoInsertar(En entidad);
    protected abstract (string Consulta, Dictionary<string, object> Parametros) GenerarComandoActualizar(En entidad);
    protected abstract (string ClausulaWhere, Dictionary<string, object> Parametros) GenerarClausulaWhere(Fb? filtroBusqueda, string? criterio);

    #endregion

    public void Dispose() {
        Dispose(true);
        GC.SuppressFinalize(this);
    }

    protected virtual void Dispose(bool disposing) {
        if (disposing) _cacheEntidades?.Clear();
    }

    ~RepoEntidadBaseDatos() {
        Dispose(false);
    }
}