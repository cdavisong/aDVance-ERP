using aDVanceERP.Core.Excepciones;
using aDVanceERP.Core.Utiles;

using MySql.Data.MySqlClient;

namespace aDVanceERP.Core.Seguridad.Utiles {
    public static class UtilesRolUsuario {
        public static long ObtenerIdRolUsuario(string nombreRolUsuario) {
            var idContacto = 0;

            using (var conexion = new MySqlConnection(UtilesConfServidores.ObtenerStringConfServidorMySQL())) {
                try {
                    conexion.Open();
                } catch (Exception) {
                    throw new ExcepcionConexionServidorMySQL();
                }

                using (var comando = conexion.CreateCommand()) {
                    comando.CommandText = $"SELECT id_rol_usuario FROM adv__rol_usuario WHERE nombre='{nombreRolUsuario}';";

                    using (var lectorDatos = comando.ExecuteReader()) {
                        if (lectorDatos != null && lectorDatos.Read()) {
                            idContacto = lectorDatos.GetInt32(lectorDatos.GetOrdinal("id_rol_usuario"));
                        }
                    }
                }
            }

            return idContacto;
        }

        public static string? ObtenerNombreRolUsuario(long idRolUsuario) {
            var nombreRolUsuario = string.Empty;

            using (var conexion = new MySqlConnection(UtilesConfServidores.ObtenerStringConfServidorMySQL())) {
                try {
                    conexion.Open();
                } catch (Exception) {
                    throw new ExcepcionConexionServidorMySQL();
                }

                using (var comando = conexion.CreateCommand()) {
                    comando.CommandText = $"SELECT nombre FROM adv__rol_usuario WHERE id_rol_usuario='{idRolUsuario}';";

                    using (var lectorDatos = comando.ExecuteReader()) {
                        if (lectorDatos != null && lectorDatos.Read()) {
                            nombreRolUsuario = lectorDatos.GetString(lectorDatos.GetOrdinal("nombre"));
                        }
                    }
                }
            }

            return nombreRolUsuario;
        }

        public static string[] ObtenerNombresRolesUsuarios() {
            var nombresRolesUsuarios = new List<string>();

            using (var conexion = new MySqlConnection(UtilesConfServidores.ObtenerStringConfServidorMySQL())) {
                try {
                    conexion.Open();
                } catch (Exception) {
                    throw new ExcepcionConexionServidorMySQL();
                }

                using (var comando = conexion.CreateCommand()) {
                    comando.CommandText = "SELECT nombre FROM adv__rol_usuario;";

                    using (var lectorDatos = comando.ExecuteReader()) {
                        if (lectorDatos != null) {
                            while (lectorDatos.Read()) {
                                nombresRolesUsuarios.Add(lectorDatos.GetString(lectorDatos.GetOrdinal("nombre")));
                            }
                        }
                    }
                }
            }

            return nombresRolesUsuarios.ToArray();
        }

        public static uint CantidadUsuariosNombreRol(string nombreRol) {
            uint longitud = 0;

            using (var conexion = new MySqlConnection(UtilesConfServidores.ObtenerStringConfServidorMySQL())) {
                try {
                    conexion.Open();
                } catch (Exception) {
                    throw new ExcepcionConexionServidorMySQL();
                }

                using (var comando = conexion.CreateCommand()) {
                    comando.CommandText = $@"
                        SELECT COUNT(cu.id_cuenta_usuario) AS cant_usuarios_rol
                        FROM adv__cuenta_usuario cu 
                        JOIN adv__rol_usuario ru ON cu.id_rol_usuario = ru.id_rol_usuario 
                        WHERE ru.nombre = '{nombreRol}';";

                    using (var lectorDatos = comando.ExecuteReader()) {
                        if (lectorDatos != null && lectorDatos.Read()) {
                            longitud = lectorDatos.GetUInt32(lectorDatos.GetOrdinal("cant_usuarios_rol"));
                        }
                    }
                }
            }

            return longitud;
        }

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
