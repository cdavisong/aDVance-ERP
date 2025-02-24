using aDVanceERP.Core.Excepciones;

using MySql.Data.MySqlClient;

namespace aDVanceERP.Core.Utiles.Datos {
    public static class UtilesCliente {
        public static long ObtenerIdCliente(string razonSocialCliente) {
            var idCliente = 0;

            using (var conexion = new MySqlConnection(UtilesConfServidores.ObtenerStringConfServidorMySQL())) {
                try {
                    conexion.Open();
                } catch (Exception) {
                    throw new ExcepcionConexionServidorMySQL();
                }

                using (var comando = conexion.CreateCommand()) {
                    comando.CommandText = $"SELECT id_cliente FROM adv__cliente WHERE razon_social='{razonSocialCliente}';";

                    using (var lectorDatos = comando.ExecuteReader()) {
                        if (lectorDatos != null && lectorDatos.Read()) {
                            idCliente = lectorDatos.GetInt32(lectorDatos.GetOrdinal("id_cliente"));
                        }
                    }
                }
            }

            return idCliente;
        }

        public static string? ObtenerRazonSocialCliente(long idCliente) {
            var razonSocialCliente = string.Empty;

            using (var conexion = new MySqlConnection(UtilesConfServidores.ObtenerStringConfServidorMySQL())) {
                try {
                    conexion.Open();
                } catch (Exception) {
                    throw new ExcepcionConexionServidorMySQL();
                }

                using (var comando = conexion.CreateCommand()) {
                    comando.CommandText = $"SELECT razon_social FROM adv__cliente WHERE id_cliente='{idCliente}';";

                    using (var lectorDatos = comando.ExecuteReader()) {
                        if (lectorDatos != null && lectorDatos.Read()) {
                            razonSocialCliente = lectorDatos.GetString(lectorDatos.GetOrdinal("razon_social"));
                        }
                    }
                }
            }

            return razonSocialCliente;
        }

        public static string[] ObtenerRazonesSocialesClientes() {
            var razonesSocialesClientes = new List<string>();

            using (var conexion = new MySqlConnection(UtilesConfServidores.ObtenerStringConfServidorMySQL())) {
                try {
                    conexion.Open();
                } catch (Exception) {
                    throw new ExcepcionConexionServidorMySQL();
                }

                using (var comando = conexion.CreateCommand()) {
                    comando.CommandText = "SELECT razon_social FROM adv__cliente;";

                    using (var lectorDatos = comando.ExecuteReader()) {
                        if (lectorDatos != null) {
                            while (lectorDatos.Read()) {
                                razonesSocialesClientes.Add(lectorDatos.GetString(lectorDatos.GetOrdinal("razon_social")));
                            }
                        }
                    }
                }
            }

            return razonesSocialesClientes.ToArray();
        }
    }
}
