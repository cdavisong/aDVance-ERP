using aDVanceERP.Core.Excepciones;

using MySql.Data.MySqlClient;

namespace aDVanceERP.Core.Utiles.Datos {
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
                    comando.CommandText = "SELECT SUM(cantidad) AS total_productos FROM adv__detalle_venta_articulo WHERE id_venta = @IdVenta;";
                    comando.Parameters.AddWithValue("@IdVenta", idVenta);

                    using (var lectorDatos = comando.ExecuteReader()) {
                        if (lectorDatos.Read()) {
                            cantidadTotal = int.TryParse(lectorDatos.GetValue(lectorDatos.GetOrdinal("total_productos"))?.ToString(), out var totalProductos) ? totalProductos : 0;
                        }
                    }
                }
            }

            return cantidadTotal;
        }

        public static List<string> ObtenerArticulosPorVenta(long idVenta) {
            var resultado = new List<string>();

            using (var conexion = new MySqlConnection(UtilesConfServidores.ObtenerStringConfServidorMySQL())) {
                try {
                    conexion.Open();
                } catch (Exception) {
                    throw new ExcepcionConexionServidorMySQL();
                }

                using (var comando = conexion.CreateCommand()) {
                    comando.CommandText = @"
                    SELECT a.nombre, d.cantidad
                    FROM adv__detalle_venta_articulo d
                    JOIN adv__articulo a ON d.id_articulo = a.id_articulo
                    WHERE d.id_venta = @IdVenta;";
                    comando.Parameters.AddWithValue("@IdVenta", idVenta);

                    using (var lectorDatos = comando.ExecuteReader()) {
                        while (lectorDatos.Read()) {
                            string nombreArticulo = lectorDatos["nombre"].ToString() ?? string.Empty;
                            string cantidad = lectorDatos["cantidad"].ToString() ?? string.Empty;
                            resultado.Add($"{nombreArticulo}:{cantidad}");
                        }
                    }
                }
            }

            return resultado;
        }

        public static List<string> ObtenerPagosPorVenta(long idVenta) {
            var resultado = new List<string>();

            using (var conexion = new MySqlConnection(UtilesConfServidores.ObtenerStringConfServidorMySQL())) {
                try {
                    conexion.Open();
                } catch (Exception) {
                    throw new ExcepcionConexionServidorMySQL();
                }

                using (var comando = conexion.CreateCommand()) {
                    comando.CommandText = @"
                    SELECT metodo_pago, monto
                    FROM adv__pago
                    WHERE id_venta = @IdVenta;";
                    comando.Parameters.AddWithValue("@IdVenta", idVenta);

                    using (var lectorDatos = comando.ExecuteReader()) {
                        while (lectorDatos.Read()) {
                            string metodoPago = lectorDatos["metodo_pago"].ToString();
                            string monto = lectorDatos["monto"].ToString();
                            resultado.Add($"{metodoPago}:{monto}");
                        }
                    }
                }
            }

            return resultado;
        }

        public static float ObtenerValorBrutoVentaDia(DateTime fecha) {
            float totalDineroBruto = 0f;

            using (var conexion = new MySqlConnection(UtilesConfServidores.ObtenerStringConfServidorMySQL())) {
                try {
                    conexion.Open();
                } catch (Exception) {
                    throw new ExcepcionConexionServidorMySQL();
                }

                using (var comando = conexion.CreateCommand()) {
                    comando.CommandText = "SELECT SUM(total) AS total_dinero FROM adv__venta WHERE DATE(fecha) = @Fecha;";
                    comando.Parameters.AddWithValue("@Fecha", fecha.ToString("yyyy-MM-dd"));

                    using (var lectorDatos = comando.ExecuteReader()) {
                        if (lectorDatos.Read()) {
                            totalDineroBruto = float.TryParse(lectorDatos.GetValue(lectorDatos.GetOrdinal("total_dinero"))?.ToString(), out var totalDinero) ? totalDinero : 0f;
                        }
                    }
                }
            }

            return totalDineroBruto;
        }
    }
}

