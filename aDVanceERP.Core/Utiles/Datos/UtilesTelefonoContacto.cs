using aDVanceERP.Core.Excepciones;
using MySql.Data.MySqlClient;

namespace aDVanceERP.Core.Utiles.Datos; 

public static class UtilesTelefonoContacto {
    public static string? ObtenerTelefonoContacto(long idContacto, bool categoriaMovil) {
        var telefonoContacto = string.Empty;

        using (var conexion = new MySqlConnection(UtilesConfServidores.ObtenerStringConfServidorMySQL())) {
            try {
                conexion.Open();
            }
            catch (Exception) {
                throw new ExcepcionConexionServidorMySQL();
            }

            using (var comando = conexion.CreateCommand()) {
                comando.CommandText =
                    $"SELECT numero FROM adv__telefono_contacto WHERE id_contacto='{idContacto}' AND categoria='{(categoriaMovil ? "Movil" : "Fijo")}';";

                using (var lectorDatos = comando.ExecuteReader()) {
                    if (lectorDatos != null && lectorDatos.Read())
                        telefonoContacto = lectorDatos.GetString(lectorDatos.GetOrdinal("numero"));
                }
            }
        }

        return telefonoContacto;
    }
}