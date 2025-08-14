using aDVanceERP.Core.Infraestructura.Globales;
using aDVanceERP.Core.Modelos.Comun.Interfaces;
using aDVanceERP.Core.Repositorios.Interfaces;
using MySql.Data.MySqlClient;

namespace aDVanceERP.Core.MVP.Modelos.Repositorios;

public abstract class RepositorioDatosBase<En, Fb> : IRepoEntidadBaseDatos<En, Fb>
    where En : class, IEntidadBaseDatos, new()
    where Fb : Enum {
    protected RepositorioDatosBase() {
        CacheEntidades = new List<En>();
    }

    public List<En> CacheEntidades { get; }

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

    public (int cantidad, IEnumerable<En> resultados) Obtener(string? consulta = "", int limite = 0, int desplazamiento = 0) {
        CacheEntidades.Clear();

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
        var resultados = ContextoBaseDatos.EjecutarConsulta(consulta, new Dictionary<string, object>(), MapearEntidadBaseDatos);

        return (cantidad, resultados);
    }

    public (int cantidad, IEnumerable<En> resultados) Obtener(Fb? filtroBusqueda, string? criterio, int limite = 0, int desplazamiento = 0) {
        var comando = ComandoObtener(filtroBusqueda, criterio);

        return Obtener(comando, limite, desplazamiento);
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
    public abstract En MapearEntidadBaseDatos(MySqlDataReader lectorDatos);

    protected virtual void Dispose(bool disposing) {
        if (disposing) CacheEntidades?.Clear();
    }

    ~RepositorioDatosBase() {
        Dispose(false);
    }
}