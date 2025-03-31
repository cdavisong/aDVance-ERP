using aDVanceERP.Core.Excepciones;

using MySql.Data.MySqlClient;

using System.Globalization;

namespace aDVanceERP.Core.Utiles.Datos {
    public class DatosEstadisticosVentas {
        public Dictionary<DateTime, decimal> VentasPorHora { get; set; } = new();
        public Dictionary<DateTime, decimal> VentasPorDia { get; set; } = new();
        public Dictionary<DateTime, decimal> VentasPorMes { get; set; } = new();
    }

    public static class UtilesVenta {
        private static DatosEstadisticosVentas _datos = new();

        // Método auxiliar para ejecutar consultas y devolver un valor decimal
        private static decimal EjecutarConsultaDecimal(string query, params MySqlParameter[] parameters) {
            decimal resultado = 0;

            using (var conexion = new MySqlConnection(UtilesConfServidores.ObtenerStringConfServidorMySQL())) {
                try {
                    conexion.Open();

                    using (var comando = new MySqlCommand(query, conexion)) {
                        if (parameters != null) {
                            comando.Parameters.AddRange(parameters);
                        }

                        object result = comando.ExecuteScalar();

                        if (result != null && result != DBNull.Value) {
                            resultado = Convert.ToDecimal(result);
                        }
                    }
                } catch (MySqlException) {
                    throw new ExcepcionConexionServidorMySQL();
                } catch (Exception ex) {
                    throw new Exception("Error inesperado al ejecutar la consulta.", ex);
                }
            }

            return resultado;
        }

        // Método auxiliar para ejecutar consultas y devolver un valor entero
        private static int EjecutarConsultaEntero(string query, params MySqlParameter[] parameters) {
            int resultado = 0;

            using (var conexion = new MySqlConnection(UtilesConfServidores.ObtenerStringConfServidorMySQL())) {
                try {
                    conexion.Open();

                    using (var comando = new MySqlCommand(query, conexion)) {
                        if (parameters != null) {
                            comando.Parameters.AddRange(parameters);
                        }

                        object result = comando.ExecuteScalar();

                        if (result != null && result != DBNull.Value) {
                            resultado = Convert.ToInt32(result);
                        }
                    }
                } catch (MySqlException) {
                    throw new ExcepcionConexionServidorMySQL();
                } catch (Exception ex) {
                    throw new Exception("Error inesperado al ejecutar la consulta.", ex);
                }
            }

            return resultado;
        }

        // Método auxiliar para ejecutar consultas y devolver una lista de strings
        private static List<string> EjecutarConsultaLista(string query, params MySqlParameter[] parameters) {
            var resultado = new List<string>();

            using (var conexion = new MySqlConnection(UtilesConfServidores.ObtenerStringConfServidorMySQL())) {
                try {
                    conexion.Open();

                    using (var comando = new MySqlCommand(query, conexion)) {
                        if (parameters != null) {
                            comando.Parameters.AddRange(parameters);
                        }

                        using (var reader = comando.ExecuteReader()) {
                            while (reader.Read()) {
                                string fila = string.Empty;
                                for (int i = 0; i < reader.FieldCount; i++) {
                                    // Verificar si el valor es decimal y formatearlo correctamente
                                    if (reader.GetFieldType(i) == typeof(decimal)) {
                                        decimal valorDecimal = reader.GetDecimal(i);
                                        fila += valorDecimal.ToString("N2", CultureInfo.InvariantCulture) + ":";
                                    } else {
                                        fila += reader[i]?.ToString() + ":";
                                    }
                                }
                                resultado.Add(fila.TrimEnd(':'));
                            }
                        }
                    }
                } catch (MySqlException) {
                    throw new ExcepcionConexionServidorMySQL();
                } catch (Exception ex) {
                    throw new Exception("Error inesperado al ejecutar la consulta.", ex);
                }
            }

            return resultado;
        }

        public static int ObtenerTotalArticulosVendidosHoy() {
            string query = @"
                SELECT SUM(dva.cantidad) AS total_vendido_hoy
                FROM adv__detalle_venta_articulo dva
                INNER JOIN adv__venta v ON dva.id_venta = v.id_venta
                WHERE DATE(v.fecha) = CURDATE();";

            return EjecutarConsultaEntero(query);
        }

        public static int ObtenerCantidadProductosVenta(long idVenta) {
            const string query = """
                                 SELECT 
                                    SUM(cantidad) AS total_productos 
                                 FROM adv__detalle_venta_articulo 
                                 WHERE id_venta = @IdVenta;
                                 """;
            var parametros = new[] {
                new MySqlParameter("@IdVenta", idVenta)
            };

            return EjecutarConsultaEntero(query, parametros);
        }

        public static IEnumerable<string> ObtenerArticulosPorVenta(long idVenta) {
            const string query = """
                                 SELECT 
                                    a.nombre, 
                                    d.cantidad
                                 FROM adv__detalle_venta_articulo d
                                 JOIN adv__articulo a ON d.id_articulo = a.id_articulo
                                 WHERE d.id_venta = @IdVenta;
                                 """;
            var parametros = new[]            {
                new MySqlParameter("@IdVenta", idVenta)
            };

            return EjecutarConsultaLista(query, parametros);
        }

        public static List<string> ObtenerPagosPorVenta(long idVenta) {
            string query = @"
                SELECT metodo_pago, monto
                FROM adv__pago
                WHERE id_venta = @IdVenta;";
            var parametros = new MySqlParameter[]            {
                new MySqlParameter("@IdVenta", idVenta)
            };

            return EjecutarConsultaLista(query, parametros);
        }

        public static decimal ObtenerValorBrutoVentaDia(DateTime fecha) {
            string query = "SELECT SUM(total) AS total_dinero FROM adv__venta WHERE DATE(fecha) = @Fecha;";
            var parametros = new MySqlParameter[]
            {
                new MySqlParameter("@Fecha", fecha.ToString("yyyy-MM-dd"))
            };

            return EjecutarConsultaDecimal(query, parametros);
        }

        public static decimal ObtenerValorGananciaTotalNegocio() {
            string query = @"
                SELECT SUM((dva.precio_unitario - a.precio_adquisicion) * dva.cantidad) AS ganancia_total
                FROM adv__detalle_venta_articulo dva
                JOIN adv__venta v ON dva.id_venta = v.id_venta
                JOIN adv__articulo a ON dva.id_articulo = a.id_articulo;";

            return EjecutarConsultaDecimal(query);
        }

        public static DatosEstadisticosVentas ObtenerDatosEstadisticosVentas(DateTime fecha) {
            if (_datos == null) {
                _datos = new DatosEstadisticosVentas();
            }

            ObtenerVentasPorHora(fecha);
            ObtenerVentasPorDia(fecha);
            ObtenerVentasPorMes(fecha);

            RellenarPeriodosVacios(_datos, fecha);

            _datos.VentasPorHora = _datos.VentasPorHora.OrderBy(v => v.Key).ToDictionary(v => v.Key, v => v.Value);
            _datos.VentasPorDia = _datos.VentasPorDia.OrderBy(v => v.Key).ToDictionary(v => v.Key, v => v.Value);
            _datos.VentasPorMes = _datos.VentasPorMes.OrderBy(v => v.Key).ToDictionary(v => v.Key, v => v.Value);

            return _datos;
        }

        private static void ObtenerVentasPorHora(DateTime fechaHora) {
            string query = @"
                SELECT HOUR(v.fecha) AS Hora, 
                       SUM(d.precio_unitario * d.cantidad) AS Total
                FROM adv__venta v
                INNER JOIN adv__detalle_venta_articulo d ON v.id_venta = d.id_venta
                WHERE DATE(v.fecha) = @fecha
                GROUP BY HOUR(v.fecha)";

            var parametros = new MySqlParameter[]
            {
                new MySqlParameter("@fecha", fechaHora.Date.ToString("yyyy-MM-dd"))
            };

            EjecutarConsultaEstadistica(query, parametros, _datos.VentasPorHora, fechaHora);
        }

        private static void ObtenerVentasPorDia(DateTime fechaHora) {
            string query = @"
                SELECT DAY(v.fecha) AS Dia, 
                       SUM(d.precio_unitario * d.cantidad) AS Total
                FROM adv__venta v
                INNER JOIN adv__detalle_venta_articulo d ON v.id_venta = d.id_venta
                WHERE MONTH(v.fecha) = @mes AND YEAR(v.fecha) = @anio
                GROUP BY DAY(v.fecha)";

            var parametros = new MySqlParameter[]
            {
                new MySqlParameter("@mes", fechaHora.Month),
                new MySqlParameter("@anio", fechaHora.Year)
            };

            EjecutarConsultaEstadistica(query, parametros, _datos.VentasPorDia, fechaHora);
        }

        private static void ObtenerVentasPorMes(DateTime fechaHora) {
            string query = @"
                SELECT MONTH(v.fecha) AS Mes, 
                       SUM(d.precio_unitario * d.cantidad) AS Total
                FROM adv__venta v
                INNER JOIN adv__detalle_venta_articulo d ON v.id_venta = d.id_venta
                WHERE YEAR(v.fecha) = @anio
                GROUP BY MONTH(v.fecha)";

            var parametros = new MySqlParameter[]
            {
                new MySqlParameter("@anio", fechaHora.Year)
            };

            EjecutarConsultaEstadistica(query, parametros, _datos.VentasPorMes, fechaHora);
        }

        private static void EjecutarConsultaEstadistica(string query, MySqlParameter[] parameters, Dictionary<DateTime, decimal> datos, DateTime fecha) {
            using (var conexion = new MySqlConnection(UtilesConfServidores.ObtenerStringConfServidorMySQL())) {
                try {
                    conexion.Open();

                    using (var comando = new MySqlCommand(query, conexion)) {
                        if (parameters != null) {
                            comando.Parameters.AddRange(parameters);
                        }

                        datos.Clear();

                        using (var reader = comando.ExecuteReader()) {
                            while (reader.Read()) {
                                DateTime fechaResultado = fecha.Date;
                                if (query.Contains("HOUR")) {
                                    fechaResultado = fechaResultado.AddHours(reader.GetInt32(0));
                                } else if (query.Contains("DAY")) {
                                    fechaResultado = new DateTime(fecha.Year, fecha.Month, reader.GetInt32(0));
                                } else if (query.Contains("MONTH")) {
                                    fechaResultado = new DateTime(fecha.Year, reader.GetInt32(0), 1);
                                }

                                datos.Add(fechaResultado, reader.GetDecimal(1));
                            }
                        }
                    }
                } catch (MySqlException) {
                    throw new ExcepcionConexionServidorMySQL();
                }
            }
        }

        private static void RellenarPeriodosVacios(DatosEstadisticosVentas datos, DateTime fecha) {
            for (int hora = 0; hora < 24; hora++) {
                DateTime horaFecha = fecha.Date.AddHours(hora);
                if (!datos.VentasPorHora.ContainsKey(horaFecha)) {
                    datos.VentasPorHora.Add(horaFecha, 0);
                }
            }

            int diasEnMes = DateTime.DaysInMonth(fecha.Year, fecha.Month);
            for (int dia = 1; dia <= diasEnMes; dia++) {
                DateTime diaFecha = new DateTime(fecha.Year, fecha.Month, dia);
                if (!datos.VentasPorDia.ContainsKey(diaFecha)) {
                    datos.VentasPorDia.Add(diaFecha, 0);
                }
            }

            for (int mes = 1; mes <= 12; mes++) {
                DateTime mesFecha = new DateTime(fecha.Year, mes, 1);
                if (!datos.VentasPorMes.ContainsKey(mesFecha)) {
                    datos.VentasPorMes.Add(mesFecha, 0);
                }
            }
        }
    }
}