using aDVanceERP.Core.MVP.Modelos.Repositorios;
using aDVanceERP.Core.Seguridad.MVP.Modelos.Repositorios.Plantillas;

using MySql.Data.MySqlClient;

namespace aDVanceERP.Core.Seguridad.MVP.Modelos.Repositorios {
    public class DatosSesionUsuario : RepositorioDatosBase<SesionUsuario, CriterioBusquedaSesionUsuario>, IRepositorioSesionUsuario {
        public override string ComandoCantidad() {
            return "SELECT COUNT(id_sesion_usuario) FROM adv__sesion_usuario;";
        }

        public override string ComandoAdicionar(SesionUsuario objeto) {
            return $"INSERT INTO adv__sesion_usuario (id_cuenta_usuario, token, fecha_inicio, fecha_fin) VALUES ({objeto.IdCuentaUsuario}, '{objeto.Token}', '{objeto.FechaInicio:yyyy-MM-dd HH:mm:ss}', {(objeto.FechaFin.HasValue ? $"'{objeto.FechaFin:yyyy-MM-dd HH:mm:ss}'" : "NULL")});";
        }

        public override string ComandoEditar(SesionUsuario objeto) {
            return $"UPDATE adv__sesion_usuario SET id_cuenta_usuario = {objeto.IdCuentaUsuario}, token = '{objeto.Token}', fecha_inicio = '{objeto.FechaInicio:yyyy-MM-dd HH:mm:ss}', fecha_fin = {(objeto.FechaFin.HasValue ? $"'{objeto.FechaFin:yyyy-MM-dd HH:mm:ss}'" : "NULL")} WHERE id_sesion_usuario = {objeto.Id};";
        }

        public override string ComandoEliminar(long id) {
            return $"DELETE FROM adv__sesion_usuario WHERE id_sesion_usuario = {id};";
        }

        public override string ComandoObtener(CriterioBusquedaSesionUsuario criterio, string dato) {
            string comando;
            switch (criterio) {
                case CriterioBusquedaSesionUsuario.NombreUsuario:
                    comando = $"SELECT * FROM adv__sesion_usuario su JOIN adv__cuenta_usuario cu ON su.id_cuenta_usuario = cu.id_cuenta_usuario WHERE LOWER(cu.nombre) LIKE LOWER('%{dato}%');";
                    break;
                case CriterioBusquedaSesionUsuario.SesionActiva:
                    comando = $"SELECT * FROM adv__sesion_usuario WHERE fecha_fin IS NULL;";
                    break;
                default:
                    comando = "SELECT * FROM adv__sesion_usuario;";
                    break;
            }
            return comando;
        }

        public override SesionUsuario ObtenerObjetoDataReader(MySqlDataReader lectorDatos) {
            return new SesionUsuario(
                id: lectorDatos.GetInt64("id_sesion_usuario"),
                idCuentaUsuario: lectorDatos.GetInt32("id_cuenta_usuario"),
                token: lectorDatos.GetString("token"),
                fechaInicio: lectorDatos.GetDateTime("fecha_inicio")) {
                FechaFin = lectorDatos.IsDBNull(lectorDatos.GetOrdinal("fecha_fin")) ? (DateTime?) null : lectorDatos.GetDateTime("fecha_fin")
            };
        }

        public override string ComandoExiste(string dato) {
            return $"SELECT COUNT(1) FROM adv__sesion_usuario WHERE token = '{dato}';";
        }
    }
}
