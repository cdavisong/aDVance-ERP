using Manigest.Core.Excepciones;
using MySql.Data.MySqlClient;

namespace Manigest.Core.Utiles.Datos {
    public static class UtilesProveedor {
        public static long ObtenerIdProveedor(string nombreProveedor) {
            var idProveedor = 0;

            using (var conexion = new MySqlConnection(UtilesConfServidores.ObtenerStringConfServidorMySQL())) {
                try {
                    conexion.Open();
                } catch (Exception) {
                    throw new ExcepcionConexionServidorMySQL();
                }

                using (var comando = conexion.CreateCommand()) {
                    comando.CommandText = $"SELECT id_proveedor FROM mg__proveedor WHERE nombre='{nombreProveedor}';";

                    using (var lectorDatos = comando.ExecuteReader()) {
                        if (lectorDatos != null && lectorDatos.Read()) {
                            idProveedor = lectorDatos.GetInt32(lectorDatos.GetOrdinal("id_proveedor"));
                        }
                    }
                }
            }

            return idProveedor;
        }

        public static string? ObtenerRazonSocialProveedor(long idProveedor) {
            var razonSocialProveedor = string.Empty;

            using (var conexion = new MySqlConnection(UtilesConfServidores.ObtenerStringConfServidorMySQL())) {
                try {
                    conexion.Open();
                } catch (Exception) {
                    throw new ExcepcionConexionServidorMySQL();
                }

                using (var comando = conexion.CreateCommand()) {
                    comando.CommandText = $"SELECT razon_social FROM mg__proveedor WHERE id_proveedor='{idProveedor}';";

                    using (var lectorDatos = comando.ExecuteReader()) {
                        if (lectorDatos != null && lectorDatos.Read()) {
                            razonSocialProveedor = lectorDatos.GetString(lectorDatos.GetOrdinal("razon_social"));
                        }
                    }
                }
            }

            return razonSocialProveedor;
        }

        public static string[] ObtenerRazonesSocialesProveedores() {
            var nombresProveedores = new List<string>();

            using (var conexion = new MySqlConnection(UtilesConfServidores.ObtenerStringConfServidorMySQL())) {
                try {
                    conexion.Open();
                } catch (Exception) {
                    throw new ExcepcionConexionServidorMySQL();
                }

                using (var comando = conexion.CreateCommand()) {
                    comando.CommandText = "SELECT razon_social FROM mg__proveedor;";

                    using (var lectorDatos = comando.ExecuteReader()) {
                        if (lectorDatos != null) {
                            while (lectorDatos.Read()) {
                                nombresProveedores.Add(lectorDatos.GetString(lectorDatos.GetOrdinal("razon_social")));
                            }
                        }
                    }
                }
            }

            return nombresProveedores.ToArray();
        }
    }
}
