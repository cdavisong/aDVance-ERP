using aDVanceERP.Core.Datos.Modelos;
using MySql.Data.MySqlClient;

namespace aDVanceERP.Core.Datos.Interfaces;

public interface IRepositorioDatosEntidad<En> : IDisposable    
    where En : class, IEntidad, new() {
    // CRUD
    En? ObtenerPorId(object id, MySqlConnection? conexionBd = null);
    ColeccionEntidades<En> ObtenerTodos(MySqlConnection? conexionBd = null);
    ColeccionEntidades<En> Buscar(int indiceFiltro, object[] datosComplementarios, MySqlConnection? conexionBd = null);
    ColeccionEntidades<En> BuscarAvanzado(Func<ConsultaBuilder, ConsultaBuilder> construirConsulta, MySqlConnection? conexionBd = null);

    void Insertar(En entidad, MySqlConnection? conexionBd = null);
    void InsertarRango(ColeccionEntidades<En> entidades, MySqlConnection? conexionBd = null);
    void Actualizar(En entidad, MySqlConnection? conexionBd = null);
    void ActualizarRango(ColeccionEntidades<En> entidades, MySqlConnection? conexionBd = null);
    void Eliminar(object id, MySqlConnection? conexionBd = null);
    void Eliminar(En entidad, MySqlConnection? conexionBd = null);
    void EliminarRango(ColeccionEntidades<En> entidades, MySqlConnection? conexionBd = null);

    // Utilidades
    bool Existe(object id, MySqlConnection? conexionBd = null);
    int Contar(int indiceFiltro = -1, MySqlConnection? conexionBd = null);
    void SincronizarCambios();
}
