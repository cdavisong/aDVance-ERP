using aDVanceERP.Core.Modelos.Comun.Interfaces;

namespace aDVanceERP.Core.MVP.Modelos.Repositorios.Plantillas; 

public interface IRepositorioDatos<En, C> : IDisposable
    where En : class, IEntidadBaseDatos, new()
    where C : Enum {
    List<En> CacheEntidades { get; }

    long Cantidad();
    long Adicionar(En objeto);
    bool Editar(En objeto, long nuevoId = 0);
    bool Eliminar(long id);
    (int cantidad, IEnumerable<En> resultados) Obtener(string? textoComando = "", int limite = 0, int desplazamiento = 0);
    (int cantidad, IEnumerable<En> resultados) Obtener(C? criterio, string? dato, int limite = 0, int desplazamiento = 0);
    bool Existe(string dato);
}