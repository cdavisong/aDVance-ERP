using aDVanceERP.Core.Datos;

using MySql.Data.MySqlClient;

namespace aDVanceERP.Core.Utiles.Datos {
    public class UtilesOrdenProduccion {
        /// <summary>
        /// Obtiene los nombres de todas las materias primas utilizadas en órdenes de producción
        /// </summary>
        public static List<string> ObtenerNombresMateriasPrimasUtilizadas() {
            var nombres = new List<string>();
            var query = """
            SELECT DISTINCT p.nombre
            FROM adv__orden_material om
            JOIN adv__producto p ON om.id_producto = p.id_producto
            WHERE p.categoria = 'MateriaPrima'
            ORDER BY p.nombre;
            """;

            using (var conexion = new MySqlConnection(CoreDatos.ConfServidorMySQL.ToString())) {
                conexion.Open();
                using (var cmd = new MySqlCommand(query, conexion))
                using (var reader = cmd.ExecuteReader()) {
                    while (reader.Read()) {
                        nombres.Add(reader.GetString(0));
                    }
                }
            }

            return nombres;
        }

        /// <summary>
        /// Obtiene los nombres de todas las actividades de producción utilizadas en órdenes (sin repetir)
        /// </summary>
        public static List<string> ObtenerNombresActividadesUtilizadas() {
            var nombres = new List<string>();
            var query = """
            SELECT DISTINCT ap.nombre
            FROM adv__orden_actividad oa
            JOIN adv__actividad_produccion ap ON oa.id_actividad_produccion = ap.id_actividad_produccion
            WHERE ap.activo = 1
            ORDER BY ap.nombre;
            """;

            using (var conexion = new MySqlConnection(CoreDatos.ConfServidorMySQL.ToString())) {
                conexion.Open();
                using (var cmd = new MySqlCommand(query, conexion))
                using (var reader = cmd.ExecuteReader()) {
                    while (reader.Read()) {
                        nombres.Add(reader.GetString(0));
                    }
                }
            }

            return nombres;
        }

        /// <summary>
        /// Obtiene los conceptos de gastos indirectos utilizados en órdenes de producción (sin repetir)
        /// </summary>
        public static List<string> ObtenerConceptosGastosIndirectosUtilizados() {
            var conceptos = new List<string>();
            var query = """
            SELECT DISTINCT concepto
            FROM adv__orden_gasto_indirecto
            WHERE concepto IS NOT NULL AND concepto != ''
            ORDER BY concepto;
            """;

            using (var conexion = new MySqlConnection(CoreDatos.ConfServidorMySQL.ToString())) {
                conexion.Open();
                using (var cmd = new MySqlCommand(query, conexion))
                using (var reader = cmd.ExecuteReader()) {
                    while (reader.Read()) {
                        conceptos.Add(reader.GetString(0));
                    }
                }
            }

            return conceptos;
        }
    }
}