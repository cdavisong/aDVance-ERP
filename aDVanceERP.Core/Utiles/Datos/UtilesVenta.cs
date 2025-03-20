using aDVanceERP.Core.Excepciones;

using MySql.Data.MySqlClient;

namespace aDVanceERP.Core.Utiles.Datos {
    public class DatosEstadisticosVentas {
        public Dictionary<DateTime, decimal> VentasPorHora { get; set; } = new();
        public Dictionary<DateTime, decimal> VentasPorDia { get; set; } = new();
        public Dictionary<DateTime, decimal> VentasPorMes { get; set; } = new();
    }

    public static class UtilesVenta {
        private static DatosEstadisticosVentas _datos = new();

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
                        } else {
                            // Si no hay datos, la ganancia es 0
                            gananciaTotal = 0;
                        }
                    }
                } catch (MySqlException ex) {
                    // Log del error
                    Console.WriteLine("Error de MySQL: " + ex.Message);
                    throw new ExcepcionConexionServidorMySQL();
                } catch (Exception ex) {
                    // Log del error
                    Console.WriteLine("Error inesperado: " + ex.Message);
                    throw new Exception("Error inesperado al calcular la ganancia total del negocio.", ex);
                }
            }

            return gananciaTotal;
        }

        public static DatosEstadisticosVentas ObtenerDatosEstadisticosVentas(DateTime fecha) {
            // Inicializar los datos si es necesario
            if (_datos == null) {
                _datos = new DatosEstadisticosVentas();
            }

            // Obtener los datos de ventas
            ObtenerVentasPorHora(fecha);
            ObtenerVentasPorDia(fecha);
            ObtenerVentasPorMes(fecha);

            // Rellenar los períodos vacíos
            RellenarPeriodosVacios(_datos, fecha);

            // Ordenar los resultados
            _datos.VentasPorHora = _datos.VentasPorHora.OrderBy(v => v.Key).ToDictionary(v => v.Key, v => v.Value);
            _datos.VentasPorDia = _datos.VentasPorDia.OrderBy(v => v.Key).ToDictionary(v => v.Key, v => v.Value);
            _datos.VentasPorMes = _datos.VentasPorMes.OrderBy(v => v.Key).ToDictionary(v => v.Key, v => v.Value);

            return _datos;
        }

        private static void ObtenerVentasPorHora(DateTime fechaHora) {
            var connectionString = UtilesConfServidores.ObtenerStringConfServidorMySQL();

            string query = @"
                SELECT HOUR(v.fecha) AS Hora, 
                       SUM(d.precio_unitario * d.cantidad) AS Total
                FROM adv__venta v
                INNER JOIN adv__detalle_venta_articulo d ON v.id_venta = d.id_venta
                WHERE DATE(v.fecha) = @fecha
                GROUP BY HOUR(v.fecha)";

            using (var conexion = new MySqlConnection(connectionString)) {
                try {
                    conexion.Open();

                    using (var comando = new MySqlCommand(query, conexion)) {
                        comando.Parameters.AddWithValue("@fecha", fechaHora.Date.ToString("yyyy-MM-dd")); // Usamos la fecha sin la hora

                        _datos.VentasPorHora.Clear();

                        using (var reader = comando.ExecuteReader()) {
                            while (reader.Read()) {
                                DateTime hora = fechaHora.Date.AddHours(reader.GetInt32(0)); // Añadimos la hora a la fecha base
                                _datos.VentasPorHora.Add(hora, reader.GetDecimal(1));
                            }
                        }
                    }
                } catch (MySqlException ex) {
                    throw new ExcepcionConexionServidorMySQL();
                }
            }
        }

        private static void ObtenerVentasPorDia(DateTime fechaHora) {
            var connectionString = UtilesConfServidores.ObtenerStringConfServidorMySQL();

            string query = @"
                SELECT DAY(v.fecha) AS Dia, 
                       SUM(d.precio_unitario * d.cantidad) AS Total
                FROM adv__venta v
                INNER JOIN adv__detalle_venta_articulo d ON v.id_venta = d.id_venta
                WHERE MONTH(v.fecha) = @mes AND YEAR(v.fecha) = @anio
                GROUP BY DAY(v.fecha)";

            using (var conexion = new MySqlConnection(connectionString)) {
                try {
                    conexion.Open();

                    using (var comando = new MySqlCommand(query, conexion)) {
                        comando.Parameters.AddWithValue("@mes", fechaHora.Month); // Mes de la fecha proporcionada
                        comando.Parameters.AddWithValue("@anio", fechaHora.Year); // Año de la fecha proporcionada

                        _datos.VentasPorDia.Clear();

                        using (var reader = comando.ExecuteReader()) {
                            while (reader.Read()) {
                                DateTime dia = new DateTime(fechaHora.Year, fechaHora.Month, reader.GetInt32(0)); // Fecha completa
                                _datos.VentasPorDia.Add(dia, reader.GetDecimal(1));
                            }
                        }
                    }
                } catch (MySqlException ex) {
                    throw new ExcepcionConexionServidorMySQL();
                }
            }
        }

        private static void ObtenerVentasPorMes(DateTime fechaHora) {
            var connectionString = UtilesConfServidores.ObtenerStringConfServidorMySQL();

            string query = @"
                SELECT MONTH(v.fecha) AS Mes, 
                       SUM(d.precio_unitario * d.cantidad) AS Total
                FROM adv__venta v
                INNER JOIN adv__detalle_venta_articulo d ON v.id_venta = d.id_venta
                WHERE YEAR(v.fecha) = @anio
                GROUP BY MONTH(v.fecha)";

            using (var conexion = new MySqlConnection(connectionString)) {
                try {
                    conexion.Open();

                    using (var comando = new MySqlCommand(query, conexion)) {
                        comando.Parameters.AddWithValue("@anio", fechaHora.Year); // Año de la fecha proporcionada

                        _datos.VentasPorMes.Clear();

                        using (var reader = comando.ExecuteReader()) {
                            while (reader.Read()) {
                                DateTime mes = new DateTime(fechaHora.Year, reader.GetInt32(0), 1); // Primer día del mes
                                _datos.VentasPorMes.Add(mes, reader.GetDecimal(1));
                            }
                        }
                    }
                } catch (MySqlException ex) {
                    throw new ExcepcionConexionServidorMySQL();
                }
            }
        }

        private static void RellenarPeriodosVacios(DatosEstadisticosVentas datos, DateTime fecha) {
            // Rellenar horas (0-23)
            for (int hora = 0; hora < 24; hora++) {
                DateTime horaFecha = fecha.Date.AddHours(hora);
                if (!datos.VentasPorHora.ContainsKey(horaFecha)) {
                    datos.VentasPorHora.Add(horaFecha, 0);
                }
            }

            // Rellenar días del mes
            int diasEnMes = DateTime.DaysInMonth(fecha.Year, fecha.Month);
            for (int dia = 1; dia <= diasEnMes; dia++) {
                DateTime diaFecha = new DateTime(fecha.Year, fecha.Month, dia);
                if (!datos.VentasPorDia.ContainsKey(diaFecha)) {
                    datos.VentasPorDia.Add(diaFecha, 0);
                }
            }

            // Rellenar meses del año
            for (int mes = 1; mes <= 12; mes++) {
                DateTime mesFecha = new DateTime(fecha.Year, mes, 1);
                if (!datos.VentasPorMes.ContainsKey(mesFecha)) {
                    datos.VentasPorMes.Add(mesFecha, 0);
                }
            }
        }
    }
}

