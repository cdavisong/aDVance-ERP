using aDVanceERP.Core.Repositorios.BD;
using aDVanceERP.Core.Seguridad.MVP.Modelos.Repositorios.Plantillas;
using MySql.Data.MySqlClient;

namespace aDVanceERP.Core.Seguridad.MVP.Modelos.Repositorios;

public class DatosRolUsuario : RepoEntidadBaseDatos<RolUsuario, FiltroBusquedaRolUsuario>, IRepositorioRolUsuario {
    public override string ComandoCantidad() {
        return "SELECT COUNT(id_rol_usuario) FROM adv__rol_usuario;";
    }

    public override string GenerarComandoInsertar(RolUsuario objeto) {
        return $"INSERT INTO adv__rol_usuario (nombre) VALUES ('{objeto.Nombre}');";
    }

    public override string GenerarComandoActualizar(RolUsuario objeto) {
        return $"UPDATE adv__rol_usuario SET nombre = '{objeto.Nombre}' WHERE id_rol_usuario = {objeto.Id};";
    }

    public override string ComandoEliminar(long id) {
        return $"DELETE FROM adv__rol_usuario WHERE id_rol_usuario = {id};";
    }

    public override string GenerarClausulaWhere(FiltroBusquedaRolUsuario criterio, string dato) {
        string comando;
        switch (criterio) {
            case FiltroBusquedaRolUsuario.Id:
                comando = $"SELECT * FROM adv__rol_usuario WHERE id_rol_usuario = {dato};";
                break;
            case FiltroBusquedaRolUsuario.Nombre:
                comando = $"SELECT * FROM adv__rol_usuario WHERE LOWER(nombre) LIKE LOWER('%{dato}%');";
                break;
            default:
                comando = "SELECT * FROM adv__rol_usuario;";
                break;
        }

        return comando;
    }

    public override RolUsuario MapearEntidad(MySqlDataReader lectorDatos) {
        return new RolUsuario(
            lectorDatos.GetInt64("id_rol_usuario"),
            lectorDatos.GetString("nombre")
        );
    }

    public override string ComandoExiste(string dato) {
        return $"SELECT COUNT(*) FROM adv__rol_usuario WHERE nombre = '{dato}';";
    }
}