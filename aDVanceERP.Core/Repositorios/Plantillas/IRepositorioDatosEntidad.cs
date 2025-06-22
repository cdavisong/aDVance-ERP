using aDVanceERP.Core.MVP.Modelos.Plantillas;
using aDVanceERP.Core.Repositorios;

using MySql.Data.MySqlClient;

namespace aDVanceERP.Core.Repositorios.Plantillas; 

public interface IRepositorioDatosEntidad<En, Fb> : IDisposable
    where En : class, IEntidad, new()
    where Fb : Enum {
    // CRUD
    En? ObtenerPorId(object id, MySqlConnection? conexionBd = null);
    List<En> ObtenerTodos(MySqlConnection? conexionBd = null);
    (List<En> resultados, int totalFilas) Buscar(Fb? criterio, string? dato, int limite = 0, int desplazamiento = 0, MySqlConnection? conexionBd = null);
    List<En> BuscarAvanzado(Func<ConsultaBuilder, ConsultaBuilder> construirConsulta, MySqlConnection? conexionBd = null);

    long Insertar(En entidad, MySqlConnection? conexionBd = null);
    void InsertarRango(List<En> entidades, MySqlConnection? conexionBd = null);
    void Actualizar(En entidad, MySqlConnection? conexionBd = null);
    void ActualizarRango(List<En> entidades, MySqlConnection? conexionBd = null);
    void Eliminar(object id, MySqlConnection? conexionBd = null);
    void Eliminar(En entidad, MySqlConnection? conexionBd = null);
    void EliminarRango(List<En> entidades, MySqlConnection? conexionBd = null);

    // Utilidades
    bool Existe(object id, MySqlConnection? conexionBd = null);
    int Contar(Fb? criterio = default, string? datosComplementarios = "", MySqlConnection? conexionBd = null);
}