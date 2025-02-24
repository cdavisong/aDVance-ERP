using aDVanceERP.Core.Excepciones;

using MySql.Data.MySqlClient;

namespace aDVanceERP.Core.Utiles.Datos {
    public static class UtilesAlmacen {
        public static long ObtenerIdAlmacen(string nombreAlmacen) {
            var idAlmacen = 0;

            using (var conexion = new MySqlConnection(UtilesConfServidores.ObtenerStringConfServidorMySQL())) {
                try {
                    conexion.Open();
                } catch (Exception) {
                    throw new ExcepcionConexionServidorMySQL();
                }

                using (var comando = conexion.CreateCommand()) {
                    comando.CommandText = $"SELECT id_almacen FROM adv__almacen WHERE LOWER(nombre) LIKE LOWER('%{nombreAlmacen}%');";

                    using (var lectorDatos = comando.ExecuteReader()) {
                        if (lectorDatos != null && lectorDatos.Read()) {
                            idAlmacen = lectorDatos.GetInt32(lectorDatos.GetOrdinal("id_almacen"));
                        }
                    }
                }
            }

            return idAlmacen;
        }

        public static string? ObtenerNombreAlmacen(long idAlmacen) {
            var nombreAlmacen = string.Empty;

            using (var conexion = new MySqlConnection(UtilesConfServidores.ObtenerStringConfServidorMySQL())) {
                try {
                    conexion.Open();
                } catch (Exception) {
                    throw new ExcepcionConexionServidorMySQL();
                }

                using (var comando = conexion.CreateCommand()) {
                    comando.CommandText = $"SELECT nombre FROM adv__almacen WHERE id_almacen='{idAlmacen}';";

                    using (var lectorDatos = comando.ExecuteReader()) {
                        if (lectorDatos != null && lectorDatos.Read()) {
                            nombreAlmacen = lectorDatos.GetString(lectorDatos.GetOrdinal("nombre"));
                        }
                    }
                }
            }

            return nombreAlmacen;
        }

        public static string[] ObtenerNombresAlmacenes(bool autorizoVenta = false) {
            var nombresAlmacenes = new List<string>();

            using (var conexion = new MySqlConnection(UtilesConfServidores.ObtenerStringConfServidorMySQL())) {
                try {
                    conexion.Open();
                } catch (Exception) {
                    throw new ExcepcionConexionServidorMySQL();
                }

                using (var comando = conexion.CreateCommand()) {
                    comando.CommandText = autorizoVenta
                        ? "SELECT nombre FROM adv__almacen WHERE autorizo_venta='1';"
                        : "SELECT nombre FROM adv__almacen;";

                    using (var lectorDatos = comando.ExecuteReader()) {
                        if (lectorDatos != null) {
                            while (lectorDatos.Read()) {
                                nombresAlmacenes.Add(lectorDatos.GetString(lectorDatos.GetOrdinal("nombre")));
                            }
                        }
                    }
                }
            }

            return nombresAlmacenes.ToArray();
        }
    }
}
