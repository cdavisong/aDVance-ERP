using aDVanceERP.Core.Controladores.Comun;
using aDVanceERP.Core.Excepciones;
using aDVanceERP.Core.Modelos.Modulos.Seguridad;
using aDVanceERP.Core.Repositorios.Comun;

using MySql.Data.MySqlClient;

namespace aDVanceERP.Core.Seguridad.MVP.Modelos.Repositorios;

public class DatosPermisoRolUsuario : RepoBase<RolPermisoUsuario, CriterioBusquedaPermisoRolUsuario> {
    public override string ComandoAdicionar(RolPermisoUsuario objeto) {
        return $"INSERT INTO adv__rol_permiso (id_rol_usuario, id_permiso) VALUES ('{objeto.IdRolUsuario}', '{objeto.IdPermiso}');";
    }

    public override string ComandoCantidad() {
        return "SELECT COUNT(id_rol_permiso) FROM adv__rol_permiso;";
    }

    public override string ComandoEditar(RolPermisoUsuario objeto) {
        return $"UPDATE adv__rol_permiso SET id_rol_usuario = '{objeto.IdRolUsuario}', id_permiso = '{objeto.IdPermiso}' WHERE id_rol_permiso = {objeto.Id};";
    }

    public override string ComandoEliminar(long id) {
        return $"DELETE FROM adv__rol_permiso WHERE id_rol_permiso = {id};";
    }

    public override string ComandoExiste(string dato) {
        return $"SELECT COUNT(1) FROM adv__rol_permiso WHERE id_rol_permiso = '{dato}';";
    }

    public override string GenerarQueryObtener(CriterioBusquedaPermisoRolUsuario criterio, string dato) {
        string comando;
        switch (criterio) {
            case CriterioBusquedaPermisoRolUsuario.Id:
                comando = $"SELECT * FROM adv__rol_permiso WHERE id_rol_permiso = {dato};";
                break;
            default:
                comando = "SELECT * FROM adv__rol_usuario;";
                break;
        }

        return comando;
    }

    public override RolPermisoUsuario MapearEntidad(MySqlDataReader lectorDatos) {
        return new RolPermisoUsuario(
            lectorDatos.GetInt64("id_rol_permiso"),
            lectorDatos.GetInt64("id_rol_usuario"),
            lectorDatos.GetInt64("id_permiso")
        );
    }

    public void EliminarPorRol(long idRolUsuario) {
        using (var conexion = new MySqlConnection(ConexionServidorMySQL.ConfServidorMySQL.ToString())) {
            try {
                conexion.Open();
            }
            catch (Exception) {
                throw new ExcepcionConexionServidorMySQL();
            }

            using (var comando = conexion.CreateCommand()) {
                comando.CommandText = "DELETE FROM adv__rol_permiso WHERE id_rol_usuario = @idRolUsuario";
                comando.Parameters.AddWithValue("@idRolUsuario", idRolUsuario);
                comando.ExecuteNonQuery();
            }
        }
    }
}