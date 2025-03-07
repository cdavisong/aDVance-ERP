using aDVanceERP.Core.Excepciones;

using MySql.Data.MySqlClient;

namespace aDVanceERP.Core.Utiles.Datos {
    public static class UtilesVenta {
        public static int ObtenerTotalArticulosVendidosHoy() {
            var cantidadTotal = 0;
            var connectionString = UtilesConfServidores.ObtenerStringConfServidorMySQL();
            var query = @"
                SELECT SUM(dva.cantidad) AS total_vendido_hoy
                FROM adv__detalle_venta_articulo dva
                INNER JOIN adv__venta v ON dva.id_venta = v.id_venta
                WHERE DATE(v.fecha) = CURDATE();";

            using (var conexion = new MySqlConnection(connectionString)) {
                try {
                    conexion.Open();

                    using (var comando = new MySqlCommand(query, conexion)) {
                        object result = comando.ExecuteScalar();

                        if (result != null && result != DBNull.Value) {
                            cantidadTotal = Convert.ToInt32(result);
                        }
                    }
                } catch (MySqlException) {
                    throw new ExcepcionConexionServidorMySQL();
                } catch (Exception ex) {
                    //TODO: Capturar cualquier otra excepción inesperada
                    throw new Exception("Error inesperado al obtener la cantidad total de artículo.", ex);
                }
            }

            return cantidadTotal;
        }

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
                            string metodoPago = lectorDatos["metodo_pago"]?.ToString() ?? string.Empty;
                            string monto = lectorDatos["monto"]?.ToString() ?? string.Empty;
                            resultado.Add($"{metodoPago}:{monto}");
                        }
                    }
                }
            }

            return resultado;
        }

        public static decimal ObtenerValorBrutoVentaDia(DateTime fecha) {
            decimal totalDineroBruto = 0;

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
                            totalDineroBruto = decimal.TryParse(lectorDatos.GetValue(lectorDatos.GetOrdinal("total_dinero"))?.ToString(), out var totalDinero) ? totalDinero : 0;
                        }
                    }
                }
            }

            return totalDineroBruto;
        }

        public static decimal ObtenerValorGananciaTotalNegocio() {
            decimal gananciaTotal = 0;
            var connectionString = UtilesConfServidores.ObtenerStringConfServidorMySQL();

            string query = @"
                SELECT SUM((dva.precio_unitario - a.precio_adquisicion) * dva.cantidad) AS ganancia_total
                FROM adv__detalle_venta_articulo dva
                JOIN adv__venta v ON dva.id_venta = v.id_venta
                JOIN adv__articulo a ON dva.id_articulo = a.id_articulo;";

            using (var conexion = new MySqlConnection(connectionString)) {
                try {
                    conexion.Open();

                    using (var comando = new MySqlCommand(query, conexion)) {
                        object result = comando.ExecuteScalar();

                        if (result != null && result != DBNull.Value) {
                            gananciaTotal = Convert.ToDecimal(result);
                        }
                    }
                } catch (MySqlException) {
                    throw new ExcepcionConexionServidorMySQL();
                } catch (Exception ex) {
                    //TODO: Capturar cualquier otra excepción inesperada
                    throw new Exception("Error inesperado al calcular la ganancia total del negocio.", ex);
                }
            }

            return gananciaTotal;
        }
    }
}

