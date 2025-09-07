using aDVanceERP.Core.Infraestructura.Globales;
using aDVanceERP.Core.Modelos.Comun.Interfaces;
using aDVanceERP.Core.Repositorios.Interfaces;

using MySql.Data.MySqlClient;

namespace aDVanceERP.Core.Repositorios.BD;

public abstract class RepoEntidadBaseDatos<En, Fb> : IRepoEntidadBaseDatos<En, Fb>
    where En : class, IEntidadBaseDatos, new()
    where Fb : Enum {
    private List<En> _cacheEntidades;

    protected RepoEntidadBaseDatos(string nombreTabla, string columnaId) {
        _cacheEntidades = new List<En>();

        NombreTabla = nombreTabla;
        ColumnaId = columnaId;
    }

    protected string NombreTabla { get; }

    protected string ColumnaId { get; }

    #region Obtención de datos y búsqueda de entidades

    public En? ObtenerPorId(long id) {
        var consulta = $"SELECT * FROM {NombreTabla} WHERE {ColumnaId} = @id LIMIT 1";
        var parametros = new Dictionary<string, object> {
            { "@id", id }
        };

        return ContextoBaseDatos.EjecutarConsulta(consulta, parametros, MapearEntidad).FirstOrDefault();
    }

    public List<En> ObtenerTodos() {
        var consulta = $"SELECT * FROM {NombreTabla}";
        var resultados = ContextoBaseDatos.EjecutarConsulta(consulta, null, MapearEntidad).ToList();

        _cacheEntidades.Clear();
        _cacheEntidades.AddRange(resultados);

        return resultados;
    }

    public (int cantidad, List<En> resultados) Buscar(string? consulta = "", int limite = 0, int desplazamiento = 0) {
        _cacheEntidades.Clear();

        var consultaResultados = string.IsNullOrEmpty(consulta) ? GenerarComandoObtener(default, string.Empty) : consulta; 
        var consultaCantidad = consulta.Replace("*", $"COUNT(*)");

        // Agregar LIMIT y OFFSET si es necesario (antes del ;)
        if (limite > 0) {
            consultaResultados = consultaResultados.TrimEnd(';'); // Eliminar el ; si existe
            consultaResultados += $" LIMIT {limite}";

            if (desplazamiento > 0)
                consultaResultados += $" OFFSET {desplazamiento}";

            consultaResultados += ";"; // Agregar el ; al final
        }

        var conexion = ContextoBaseDatos.ObtenerConexion();
        var cantidad = ContextoBaseDatos.EjecutarConsultaEscalar<int>(consultaCantidad, null, conexion);
        var resultados = ContextoBaseDatos.EjecutarConsulta(consultaResultados, new Dictionary<string, object>(), MapearEntidad, conexion).ToList();

        // Cerrar la conexion
        ContextoBaseDatos.CerrarConexion(conexion);

        return (cantidad, resultados);
    }

    public (int cantidad, List<En> resultados) Buscar(Fb? filtroBusqueda, string? criterio, int limite = 0, int desplazamiento = 0) {
        var comando = GenerarComandoObtener(filtroBusqueda, criterio);

        return Buscar(comando, limite, desplazamiento);
    }

    #endregion

    #region CRUD

    public virtual long Adicionar(En objeto) {
        return ContextoBaseDatos.EjecutarComandoInsert(GenerarComandoAdicionar(objeto), new Dictionary<string, object>());
    }

    public virtual bool Editar(En objeto, long nuevoId = 0) {
        ContextoBaseDatos.EjecutarComandoNoQuery(GenerarComandoEditar(objeto), new Dictionary<string, object>());
        return true;
    }

    public virtual bool Eliminar(long id) {
        ContextoBaseDatos.EjecutarComandoNoQuery(GenerarComandoEliminar(id), new Dictionary<string, object>());
        return true;
    }

    #endregion

    #region Utilidades

    public long Cantidad() {
        var consulta = $"SELECT COUNT(*) FROM {NombreTabla}";

        return ContextoBaseDatos.EjecutarConsultaEscalar<long>(consulta, new Dictionary<string, object>());
    }

    public bool Existe(long id) {
        var consulta = $"SELECT COUNT(*) FROM {NombreTabla} WHERE {ColumnaId} = @id";
        var parametros = new Dictionary<string, object> {
            { "@id", id }
        };
        var cantidad = ContextoBaseDatos.EjecutarConsultaEscalar<int>(consulta, parametros);

        return cantidad > 0;
    }

    #endregion

    #region Métodos abstractos para heredar

    protected abstract string GenerarComandoAdicionar(En objeto);
    protected abstract string GenerarComandoEditar(En objeto);
    protected abstract string GenerarComandoEliminar(long id);
    protected abstract string GenerarComandoObtener(Fb filtroBusqueda, string criterio);
    protected abstract En MapearEntidad(MySqlDataReader lectorDatos);

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