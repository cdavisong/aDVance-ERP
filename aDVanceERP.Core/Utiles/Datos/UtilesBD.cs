using aDVanceERP.Core.Controladores.DB;
using aDVanceERP.Core.Excepciones;
using MySql.Data.MySqlClient;

namespace aDVanceERP.Core.Utiles.Datos; 

public static class UtilesBD {
    public static long ObtenerUltimoIdTabla(string nombreEntidad) {
        var ultimoId = 0;

        using (var conexion = new MySqlConnection(ConectorDB.ConfServidorMySQL.ToString())) {
            try {
                conexion.Open();
            }
            catch (Exception) {
                throw new ExcepcionConexionServidorMySQL();
            }

            using (var comando = conexion.CreateCommand()) {
                comando.CommandText =
                    $"SELECT id_{nombreEntidad} FROM adv__{nombreEntidad} ORDER BY id_{nombreEntidad} DESC LIMIT 1;";

                using (var lectorDatos = comando.ExecuteReader()) {
                    if (lectorDatos != null && lectorDatos.Read())
                        ultimoId = lectorDatos.GetInt32(lectorDatos.GetOrdinal($"id_{nombreEntidad}"));
                }
            }
        }

        return ultimoId;
    }
}