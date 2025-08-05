using aDVanceERP.Core.Modelos.Modulos.Seguridad;
using aDVanceERP.Core.Repositorios.Comun;

using MySql.Data.MySqlClient;

namespace aDVanceERP.Core.Seguridad.MVP.Modelos.Repositorios;

public class DatosSesionUsuario : RepoBase<SesionUsuario, CriterioBusquedaSesionUsuario> {
    public DatosSesionUsuario() : base("adv__sesion_usuario") {
    }

    public override string ComandoCantidad() {
        return "SELECT COUNT(id_sesion_usuario) FROM adv__sesion_usuario;";
    }

    public override string ComandoAdicionar(SesionUsuario objeto) {
        return
            $"INSERT INTO adv__sesion_usuario (id_cuenta_usuario, token, fecha_inicio, fecha_fin) VALUES ({objeto.IdCuentaUsuario}, '{objeto.Token}', '{objeto.FechaInicio:yyyy-MM-dd HH:mm:ss}', '{objeto.FechaFin:yyyy-MM-dd HH:mm:ss}');";
    }

    public override string ComandoEditar(SesionUsuario objeto) {
        return
            $"UPDATE adv__sesion_usuario SET id_cuenta_usuario = {objeto.IdCuentaUsuario}, token = '{objeto.Token}', fecha_inicio = '{objeto.FechaInicio:yyyy-MM-dd HH:mm:ss}', fecha_fin = '{objeto.FechaFin:yyyy-MM-dd HH:mm:ss}' WHERE id_sesion_usuario = {objeto.Id};";
    }

    public override string ComandoEliminar(long id) {
        return $"DELETE FROM adv__sesion_usuario WHERE id_sesion_usuario = {id};";
    }

    public override string GenerarQueryObtener(CriterioBusquedaSesionUsuario criterio, string dato) {
        string comando;
        switch (criterio) {
            case CriterioBusquedaSesionUsuario.NombreUsuario:
                comando =
                    $"SELECT * FROM adv__sesion_usuario su JOIN adv__cuenta_usuario cu ON su.id_cuenta_usuario = cu.id_cuenta_usuario WHERE LOWER(cu.nombre) LIKE LOWER('%{dato}%');";
                break;
            case CriterioBusquedaSesionUsuario.SesionActiva:
                comando = "SELECT * FROM adv__sesion_usuario WHERE fecha_fin IS NULL;";
                break;
            default:
                comando = "SELECT * FROM adv__sesion_usuario;";
                break;
        }

        return comando;
    }

    public override SesionUsuario MapearEntidad(MySqlDataReader lectorDatos) {
        return new SesionUsuario(
            lectorDatos.GetInt64("id_sesion_usuario"),
            lectorDatos.GetInt32("id_cuenta_usuario"),
            lectorDatos.GetString("token"),
            lectorDatos.GetDateTime("fecha_inicio")) {
            FechaFin = lectorDatos.IsDBNull(lectorDatos.GetOrdinal("fecha_fin"))
                ? DateTime.MinValue
                : lectorDatos.GetDateTime("fecha_fin")
        };
    }

    public override string ComandoExiste(string dato) {
        return $"SELECT COUNT(1) FROM adv__sesion_usuario WHERE token = '{dato}';";
    }
}