using aDVanceERP.Core.Datos;
using aDVanceERP.Core.Excepciones;

using MySql.Data.MySqlClient;

namespace aDVanceERP.PatchDB {
    internal class Program {
        private static void Main(string[] args) {
            Console.CursorVisible = false;
            Console.Title = "aDVance ERP º Sistema de Parches";
            var version = "desconocida";

            if (File.Exists(@".\app.ver"))
                using (var fs = new FileStream(@".\app.ver", FileMode.Open)) {
                    using (var sr = new StreamReader(fs)) {
                        version = sr.ReadToEnd().Trim();
                    }
                }

            // Logo en ASCII con colores básicos
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.WriteLine(@"
                █████╗ ██████╗ ██╗   ██╗ █████╗ ███╗   ██╗ ██████╗███████╗
               ██╔══██╗██╔══██╗██║   ██║██╔══██╗████╗  ██║██╔════╝██╔════╝
               ███████║██║  ██║██║   ██║███████║██╔██╗ ██║██║     █████╗  
               ██╔══██║██║  ██║╚██╗ ██╔╝██╔══██║██║╚██╗██║██║     ██╔══╝  
               ██║  ██║██████╔╝ ╚████╔╝ ██║  ██║██║ ╚████║╚██████╗███████╗
               ╚═╝  ╚═╝╚═════╝   ╚═══╝  ╚═╝  ╚═╝╚═╝  ╚═══╝ ╚═════╝╚══════╝");
            Console.ResetColor();
            Console.WriteLine("               E R P  -  S I S T E M A  D E  P A R C H E S");
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.WriteLine($"               versión {version}\n");

            try {
                ExecuteStep(EliminarTablasObsoletas, "Eliminación de tablas obsoletas");
                ExecuteStep(CrearTablasProduccion, "Creación de tablas de producción");
                ExecuteStep(AgregarIndices, "Agregar índices optimizados");
                ExecuteStep(ModificarTablasExistentes, "Actualización de esquema");

                RenderStatus("Parche aDVance ERP aplicado correctamente", ConsoleColor.Green);
            } catch (Exception ex) {
                RenderStatus($"Error crítico: {ex.Message}", ConsoleColor.Red);
            }

            Console.CursorVisible = true;
            Console.WriteLine("\n");
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.Write("Presione cualquier tecla para salir...");
            Console.ReadKey();
        }

        private static void EliminarTablasObsoletas() {
            using (var conexion = new MySqlConnection(CoreDatos.ConfServidorMySQL.ToString())) {
                try {
                    conexion.Open();
                } catch (Exception) {
                    throw new ExcepcionConexionServidorMySQL();
                }

                List<string> querys =
                [
                    "DROP TABLE IF EXISTS adv__costo_directo_produccion;",
                    "DROP TABLE IF EXISTS adv__actividad_produccion;"
                ];

                foreach (var query in querys) {
                    using (var cmd = new MySqlCommand(query, conexion)) {
                        try {
                            cmd.ExecuteNonQuery();
                        } catch (MySqlException ex) {
                            // Ignorar errores si las tablas no existen
                            if (!ex.Message.Contains("Unknown table")) throw;
                        }
                    }
                }
            }
        }

        private static void CrearTablasProduccion() {
            using (var conexion = new MySqlConnection(CoreDatos.ConfServidorMySQL.ToString())) {
                try {
                    conexion.Open();
                } catch (Exception) {
                    throw new ExcepcionConexionServidorMySQL();
                }

                List<string> querys =
                [
                    """
                    CREATE TABLE IF NOT EXISTS adv__orden_produccion (
                        id_orden_produccion INT(11) NOT NULL AUTO_INCREMENT,
                        numero_orden VARCHAR(20) NOT NULL,
                        fecha_apertura DATETIME NOT NULL DEFAULT CURRENT_TIMESTAMP(),
                        fecha_cierre DATETIME NULL,
                        id_producto INT(11) NOT NULL COMMENT 'Producto terminado',
                        cantidad DECIMAL(10,2) NOT NULL,
                        estado ENUM('Abierta','En Proceso','Cerrada','Cancelada') NOT NULL DEFAULT 'Abierta',
                        observaciones TEXT NULL,
                        costo_total DECIMAL(10,2) NOT NULL DEFAULT 0.00,
                        precio_unitario DECIMAL(10,2) NOT NULL DEFAULT 0.00,
                        margen_ganancia DECIMAL(5,2) NOT NULL DEFAULT 0.00,
                        PRIMARY KEY (id_orden_produccion),
                        UNIQUE KEY numero_orden (numero_orden)
                    ) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;
                    """,
                    """
                    CREATE TABLE IF NOT EXISTS adv__actividad_produccion (
                        id_actividad_produccion INT(11) NOT NULL AUTO_INCREMENT,
                        nombre VARCHAR(100) NOT NULL COMMENT 'Ej: Corte, Costura, Planchado',
                        tipo_costo ENUM('PorHora','Fijo') NOT NULL DEFAULT 'PorHora',
                        costo DECIMAL(10,2) NOT NULL COMMENT 'Costo por hora o costo fijo',
                        descripcion TEXT NULL,
                        activo TINYINT(1) NOT NULL DEFAULT 1,
                        PRIMARY KEY (id_actividad_produccion)
                    ) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;
                    """,
                    """
                    CREATE TABLE IF NOT EXISTS adv__orden_actividad (
                        id_orden_actividad INT(11) NOT NULL AUTO_INCREMENT,
                        id_orden_produccion INT(11) NOT NULL,
                        id_actividad_produccion INT(11) NOT NULL,
                        cantidad DECIMAL(10,2) NOT NULL COMMENT 'Horas o unidades según tipo',
                        costo_total DECIMAL(10,2) NOT NULL,
                        fecha_registro DATETIME NOT NULL DEFAULT CURRENT_TIMESTAMP(),
                        observaciones VARCHAR(255) NULL,
                        PRIMARY KEY (id_orden_actividad)
                    ) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;
                    """,
                    """
                    CREATE TABLE IF NOT EXISTS adv__orden_material (
                        id_orden_material INT(11) NOT NULL AUTO_INCREMENT,
                        id_orden_produccion INT(11) NOT NULL,
                        id_producto INT(11) NOT NULL COMMENT 'Materia prima consumida',
                        cantidad DECIMAL(10,2) NOT NULL,
                        costo_unitario DECIMAL(10,2) NOT NULL,
                        costo_total DECIMAL(10,2) NOT NULL,
                        fecha_registro DATETIME NOT NULL DEFAULT CURRENT_TIMESTAMP(),
                        PRIMARY KEY (id_orden_material)
                    ) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;
                    """,
                    """
                    CREATE TABLE IF NOT EXISTS adv__orden_gasto_indirecto (
                        id_orden_gasto_indirecto INT(11) NOT NULL AUTO_INCREMENT,
                        id_orden_produccion INT(11) NOT NULL,
                        concepto VARCHAR(100) NOT NULL,
                        monto DECIMAL(10,2) NOT NULL,
                        fecha_registro DATETIME NOT NULL DEFAULT CURRENT_TIMESTAMP(),
                        observaciones VARCHAR(255) NULL,
                        PRIMARY KEY (id_orden_gasto_indirecto)
                    ) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;
                    """
                ];

                foreach (var query in querys)
                    using (var cmd = new MySqlCommand(query, conexion))
                        cmd.ExecuteNonQuery();
            }
        }

        private static void AgregarIndices() {
            using (var conexion = new MySqlConnection(CoreDatos.ConfServidorMySQL.ToString())) {
                try {
                    conexion.Open();
                } catch (Exception) {
                    throw new ExcepcionConexionServidorMySQL();
                }

                List<string> querys =
                [
                    // Índices para orden_produccion
                    "ALTER TABLE adv__orden_produccion ADD INDEX idx_estado (estado);",
                    "ALTER TABLE adv__orden_produccion ADD INDEX idx_fecha_apertura (fecha_apertura);",
                    "ALTER TABLE adv__orden_produccion ADD INDEX idx_producto (id_producto);",
                    
                    // Índices para orden_actividad
                    "ALTER TABLE adv__orden_actividad ADD INDEX idx_orden_actividad (id_orden_produccion, id_actividad_produccion);",
                    
                    // Índices para orden_material
                    "ALTER TABLE adv__orden_material ADD INDEX idx_orden_material (id_orden_produccion, id_producto);",
                    
                    // Índices para producto
                    "ALTER TABLE adv__producto ADD INDEX idx_categoria (categoria);",
                    "ALTER TABLE adv__producto ADD INDEX idx_codigo (codigo);",
                    "ALTER TABLE adv__producto ADD INDEX idx_es_vendible (es_vendible);"
                ];

                foreach (var query in querys)
                    using (var cmd = new MySqlCommand(query, conexion))
                        cmd.ExecuteNonQuery();
            }
        }

        private static void ModificarTablasExistentes() {
            using (var conexion = new MySqlConnection(CoreDatos.ConfServidorMySQL.ToString())) {
                try {
                    conexion.Open();
                } catch (Exception) {
                    throw new ExcepcionConexionServidorMySQL();
                }

                List<string> querys =
                [
                    // Modificaciones existentes
                    """
                    ALTER TABLE adv__producto 
                    ADD id_tipo_materia_prima INT(11) NOT NULL 
                    DEFAULT '1' 
                    AFTER id_proveedor;
                    """,
                    """
                    ALTER TABLE adv__producto 
                    ADD UNIQUE INDEX nombre_unico (nombre);
                    """
                ];

                foreach (var query in querys)
                    using (var cmd = new MySqlCommand(query, conexion))
                        cmd.ExecuteNonQuery();
            }
        }

        #region Funciones de Interfaz

        private static void ExecuteStep(Action step, string title) {
            RenderProgressBar(title, ConsoleColor.White);
            try {
                step.Invoke();
                Console.SetCursorPosition(60, Console.CursorTop);
                Console.ForegroundColor = ConsoleColor.Gray;
                Console.Write("[");
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write("COMPLETADO");
                Console.ForegroundColor = ConsoleColor.Gray;
                Console.WriteLine("]");
            } catch (Exception ex) {
                Console.SetCursorPosition(60, Console.CursorTop);
                Console.ForegroundColor = ConsoleColor.Gray;
                Console.Write("[");
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write("FALLIDO");
                Console.ForegroundColor = ConsoleColor.Gray;
                Console.WriteLine("]");
                throw;
            }

            Console.ResetColor();
        }

        private static void RenderStatus(string message, ConsoleColor color) {
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine($"\n[{DateTime.Now:HH:mm:ss}]");
            Console.ForegroundColor = color;
            Console.Write(" » ");
            Console.ForegroundColor = color;
            Console.Write(message, color);
            Console.WriteLine("\n");
            Console.ResetColor();
        }

        private static void RenderProgressBar(string text, ConsoleColor color) {
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.Write($" [{DateTime.Now:HH:mm:ss}]");
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.Write(" -");
            Console.ForegroundColor = color;
            Console.Write($" {text,-40}");
            Console.ResetColor();
        }

        #endregion
    }
}