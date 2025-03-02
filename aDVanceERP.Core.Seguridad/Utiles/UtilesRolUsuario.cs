using aDVanceERP.Core.Excepciones;
using aDVanceERP.Core.Utiles;

using MySql.Data.MySqlClient;

namespace aDVanceERP.Core.Seguridad.Utiles {
    public static class UtilesRolUsuario {
        public static int VerificarOCrearRolAdministrador() {
            int rolId = 0;

            using (var conexion = new MySqlConnection(UtilesConfServidores.ObtenerStringConfServidorMySQL())) {
                try {
                    conexion.Open();
                } catch (Exception) {
                    throw new ExcepcionConexionServidorMySQL();
                }

                using (var comando = new MySqlCommand("SELECT id_rol_usuario FROM adv__rol_usuario WHERE nombre = 'Administrador'", conexion)) {
                    rolId = Convert.ToInt32(comando.ExecuteScalar());
                }

                if (rolId == 0) {
                    using (var comando = new MySqlCommand("INSERT INTO adv__rol_usuario (nombre, nivel_acceso) VALUES (@nombre, @nivelAcceso); SELECT LAST_INSERT_ID();", conexion)) {
                        comando.Parameters.AddWithValue("@nombre", "Administrador");
                        comando.Parameters.AddWithValue("@nivelAcceso", 100);
                        rolId = Convert.ToInt32(comando.ExecuteScalar());
                    }
                }
            }

            return rolId;
        }
    }
}
