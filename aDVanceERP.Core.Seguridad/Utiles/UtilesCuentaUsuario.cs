using aDVanceERP.Core.Excepciones;
using aDVanceERP.Core.Utiles;
using aDVanceERP.Core.Seguridad.MVP.Modelos;

using MySql.Data.MySqlClient;

using System.Security;

namespace aDVanceERP.Core.Seguridad.Utiles {
    public static class UtilesCuentaUsuario {
        public static CuentaUsuario? UsuarioAutenticado { get; set; } = new();
        public static string[]? PermisosUsuario {  get; set; } 

        public static bool EsTablaCuentasUsuarioVacia() {
            bool tablaVacia = false;

            using (var conexion = new MySqlConnection(UtilesConfServidores.ObtenerStringConfServidorMySQL())) {
                try {
                    conexion.Open();
                } catch (Exception) {
                    throw new ExcepcionConexionServidorMySQL();
                }

                using (var comando = new MySqlCommand("SELECT COUNT(*) AS user_count FROM adv__cuenta_usuario", conexion)) {
                    using (var lectorDatos = comando.ExecuteReader()) {
                        if (lectorDatos.Read()) {
                            int userCount = lectorDatos.GetInt32("user_count");
                            tablaVacia = userCount == 0;
                        }
                    }
                }
            }

            return tablaVacia;
        }        

        public static void CrearUsuarioAdministrador(string nombreUsuario, SecureString password) {
            var passwordSeguro = UtilesPassword.HashPassword(password);
            var passwordSalt = passwordSeguro.salt;
            var passwordHash = passwordSeguro.hash;

            using (var conexion = new MySqlConnection(UtilesConfServidores.ObtenerStringConfServidorMySQL())) {
                try {
                    conexion.Open();
                } catch (Exception) {
                    throw new ExcepcionConexionServidorMySQL();
                }

                var idRolAdministrador = UtilesRolUsuario.VerificarOCrearRolAdministrador();

                using (var comando = new MySqlCommand("INSERT INTO adv__cuenta_usuario (nombre, password_hash, password_salt, id_rol_usuario, administrador, aprobado) VALUES (@nombre, @passwordHash, @passwordSalt, @idRolUsuario, @administrador, @aprobado)", conexion)) {
                    comando.Parameters.AddWithValue("@nombre", nombreUsuario);
                    comando.Parameters.AddWithValue("@passwordHash", passwordHash);
                    comando.Parameters.AddWithValue("@passwordSalt", passwordSalt);
                    comando.Parameters.AddWithValue("@idRolUsuario", idRolAdministrador);
                    comando.Parameters.AddWithValue("@administrador", true);
                    comando.Parameters.AddWithValue("@aprobado", true);

                    comando.ExecuteNonQuery();
                }
            }
        }
    }
}
