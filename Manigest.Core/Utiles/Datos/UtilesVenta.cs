using Manigest.Core.Excepciones;
using MySql.Data.MySqlClient;

namespace Manigest.Core.Utiles.Datos {
    public static class UtilesVenta {
        public static int ObtenerCantidadProductosVenta(long idVenta) {
            int cantidadTotal = 0;

            using (var conexion = new MySqlConnection(UtilesConfServidores.ObtenerStringConfServidorMySQL())) {
                try {
                    conexion.Open();
                } catch (Exception) {
                    throw new ExcepcionConexionServidorMySQL();
                }

                using (var comando = conexion.CreateCommand()) {
                    comando.CommandText = "SELECT SUM(cantidad) AS total_productos FROM mg__detalle_venta_articulo WHERE id_venta = @IdVenta;";
                    comando.Parameters.AddWithValue("@IdVenta", idVenta);

                    using (var lectorDatos = comando.ExecuteReader()) {
                        if (lectorDatos.Read()) {
                            cantidadTotal = lectorDatos.GetInt32(lectorDatos.GetOrdinal("total_productos"));
                        }
                    }
                }
            }

            return cantidadTotal;
        }
    }
}
