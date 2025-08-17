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

    public En? ObtenerPorId(object? id) {
        var consulta = $"SELECT * FROM {NombreTabla} WHERE {ColumnaId} = @id LIMIT 1";
        var parametros = new Dictionary<string, object> {
            { "@id", id }
        };

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

        consulta = string.IsNullOrEmpty(consulta) ? ComandoObtener(default, string.Empty) : consulta;

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
        var comando = ComandoObtener(filtroBusqueda, criterio);

        return Buscar(comando, limite, desplazamiento);
    }

    #endregion

    public virtual long Cantidad() {
        return ContextoBaseDatos.EjecutarConsultaEscalar<long>(ComandoCantidad(), new Dictionary<string, object>());
    }

    public virtual long Adicionar(En objeto) {
        return ContextoBaseDatos.EjecutarComandoInsert(ComandoAdicionar(objeto), new Dictionary<string, object>());
    }

    public virtual bool Editar(En objeto, long nuevoId = 0) {
        ContextoBaseDatos.EjecutarComandoNoQuery(ComandoEditar(objeto), new Dictionary<string, object>());
        return true;
    }

    public virtual bool Eliminar(long id) {
        ContextoBaseDatos.EjecutarComandoNoQuery(ComandoEliminar(id), new Dictionary<string, object>());
        return true;
    }

    public bool Existe(string dato) {
        return ContextoBaseDatos.EjecutarConsultaEscalar<bool>(ComandoExiste(dato), new Dictionary<string, object>());
    }

    public void Dispose() {
        Dispose(true);
        GC.SuppressFinalize(this);
    }

    public abstract string ComandoCantidad();
    public abstract string ComandoAdicionar(En objeto);
    public abstract string ComandoEditar(En objeto);
    public abstract string ComandoEliminar(long id);
    public abstract string ComandoObtener(Fb criterio, string dato);
    public abstract string ComandoExiste(string dato);
    public abstract En MapearEntidad(MySqlDataReader lectorDatos);

    protected virtual void Dispose(bool disposing) {
        if (disposing) _cacheEntidades?.Clear();
    }

    ~RepoEntidadBaseDatos() {
        Dispose(false);
    }
}