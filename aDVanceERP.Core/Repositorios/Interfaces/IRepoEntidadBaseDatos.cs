using aDVanceERP.Core.Modelos.Comun.Interfaces;

namespace aDVanceERP.Core.Repositorios.Interfaces;

public interface IRepoEntidadBaseDatos<En, Fb> : IRepoBase<En>
    where En : class, IEntidadBaseDatos, new()
    where Fb : Enum {
    #region Obtención de datos y búsqueda de entidades

    (int cantidad, IEnumerable<En> resultados) Buscar(string? consulta = "", int limite = 0, int desplazamiento = 0);
    (int cantidad, IEnumerable<En> resultados) Buscar(Fb? filtroBusqueda, string? criterio, int limite = 0, int desplazamiento = 0);

    #endregion

    #region CRUD

    long Insertar(En entidad);
    void Actualizar(En entidad);
    void Eliminar(long id);

    #endregion

    #region Utilidades

    bool Existe(object id);
    int Contar(Fb? filtroBusqueda = default, string? criterio = "");

    #endregion

}