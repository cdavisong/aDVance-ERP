using aDVanceERP.Core.Modelos.Comun.Interfaces;

namespace aDVanceERP.Core.Repositorios.Interfaces;

public interface IRepoEntidadBaseDatos<En, Fb> : IDisposable
    where En : class, IEntidadBaseDatos, new()
    where Fb : Enum {
    List<En> CacheEntidades { get; }

    long Cantidad();
    long Adicionar(En objeto);
    bool Editar(En objeto, long nuevoId = 0);
    bool Eliminar(long id);
    (int cantidad, IEnumerable<En> resultados) Obtener(string? consulta = "", int limite = 0, int desplazamiento = 0);
    (int cantidad, IEnumerable<En> resultados) Obtener(Fb? filtroBusqueda, string? criterio, int limite = 0, int desplazamiento = 0);
    bool Existe(string dato);
}