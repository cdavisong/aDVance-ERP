using Manigest.Core.Excepciones;
using MySql.Data.MySqlClient;

namespace Manigest.Core.Utiles.Datos {
    public static class UtilesContacto {
        public static long ObtenerIdContacto(string nombreContacto) {
            var idContacto = 0;

            using (var conexion = new MySqlConnection(UtilesConfServidores.ObtenerStringConfServidorMySQL())) {
                try {
                    conexion.Open();
                } catch (Exception) {
                    throw new ExcepcionConexionServidorMySQL();
                }

                using (var comando = conexion.CreateCommand()) {
                    comando.CommandText = $"SELECT id_contacto FROM mg__contacto WHERE nombre='{nombreContacto}';";

                    using (var lectorDatos = comando.ExecuteReader()) {
                        if (lectorDatos != null && lectorDatos.Read()) {
                            idContacto = lectorDatos.GetInt32(lectorDatos.GetOrdinal("id_contacto"));
                        }
                    }
                }
            }

            return idContacto;
        }

        public static string? ObtenerNombreContacto(long idContacto) {
            var nombreContacto = string.Empty;

            using (var conexion = new MySqlConnection(UtilesConfServidores.ObtenerStringConfServidorMySQL())) {
                try {
                    conexion.Open();
                } catch (Exception) {
                    throw new ExcepcionConexionServidorMySQL();
                }

                using (var comando = conexion.CreateCommand()) {
                    comando.CommandText = $"SELECT nombre FROM mg__contacto WHERE id_contacto='{idContacto}';";

                    using (var lectorDatos = comando.ExecuteReader()) {
                        if (lectorDatos != null && lectorDatos.Read()) {
                            nombreContacto = lectorDatos.GetString(lectorDatos.GetOrdinal("nombre"));
                        }
                    }
                }
            }

            return nombreContacto;
        }

        public static string[] ObtenerNombresContactos() {
            var nombresContactos = new List<string>();

            using (var conexion = new MySqlConnection(UtilesConfServidores.ObtenerStringConfServidorMySQL())) {
                try {
                    conexion.Open();
                } catch (Exception) {
                    throw new ExcepcionConexionServidorMySQL();
                }

                using (var comando = conexion.CreateCommand()) {
                    comando.CommandText = "SELECT nombre FROM mg__contacto;";

                    using (var lectorDatos = comando.ExecuteReader()) {
                        if (lectorDatos != null) {
                            while (lectorDatos.Read()) {
                                nombresContactos.Add(lectorDatos.GetString(lectorDatos.GetOrdinal("nombre")));
                            }
                        }
                    }
                }
            }

            return nombresContactos.ToArray();
        }
    }
}
