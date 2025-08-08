using MySql.Data.MySqlClient;

namespace aDVanceERP.Core.Interfaces;

public interface IRepoBase<En, Fb> : IDisposable
    where En : class, IEntidadBd, new()
    where Fb : Enum {
    List<En> CacheObjetos { get; }

    bool Existe(object id, MySqlConnection? conexionBd = null);
    long Cantidad(MySqlConnection? conexionBd = null);
    long Insertar(En entidad, MySqlConnection? conexionBd = null);
    void Actualizar(En entidad, MySqlConnection? conexionBd = null);
    void Eliminar(En entidad, MySqlConnection? conexionBd = null);

    En? ObtenerPorId(object id, MySqlConnection? conexionBd = null);
    (int cantidad, List<En> resultados) Obtener(Fb? filtroBusqueda, string? criterio, int limite = 0, int desplazamiento = 0, MySqlConnection? conexionBd = null)

    (string query, Dictionary<string, object> parametros) GenerarQueryObtener(Fb filtroBusqueda, string criterio);
    En MapearEntidad(MySqlDataReader lectorDatos);;
}
