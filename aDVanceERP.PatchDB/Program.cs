using aDVanceERP.Core.Excepciones;
using aDVanceERP.Core.Utiles;

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
                ExecuteStep(CrearTablasNuevas, "Creación de estructura modular");
                ExecuteStep(ModificarTablasExistentes, "Actualización de esquema");
                ExecuteStep(PopularDatosTablasNuevas, "Población de datos iniciales");

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

        private static void CrearTablasNuevas() {
            using (var conexion = new MySqlConnection(UtilesConfServidores.ObtenerStringConfServidorMySQL())) {
                try {
                    conexion.Open();
                } catch (Exception) {
                    throw new ExcepcionConexionServidorMySQL();
                }

                List<string> querys =
                [
                    """
                    CREATE TABLE IF NOT EXISTS adv__tipo_materia_prima (
                        id_tipo_materia_prima INT(11) NOT NULL AUTO_INCREMENT,
                        nombre VARCHAR(100) NOT NULL,
                        descripcion TEXT,
                        PRIMARY KEY (id_tipo_materia_prima)
                    ) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;
                    """,
                    """"
                    CREATE TABLE IF NOT EXISTS adv__conversion_unidad (
                      id_conversion int(11) NOT NULL,
                      id_unidad_origen int(11) NOT NULL,
                      id_unidad_destino int(11) NOT NULL,
                      factor_conversion decimal(15,6) NOT NULL,
                      id_producto int(11) DEFAULT 0 COMMENT '0 para conversiones genéricas',
                      PRIMARY KEY (id_conversion),
                      UNIQUE KEY unica_conversion (id_unidad_origen, id_unidad_destino, id_producto)
                    ) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;
                    """"
                ];

                foreach (var query in querys)
                    using (var cmd = new MySqlCommand(query, conexion))
                        cmd.ExecuteNonQuery();
            }
        }

        private static void ModificarTablasExistentes() {
            using (var conexion = new MySqlConnection(UtilesConfServidores.ObtenerStringConfServidorMySQL())) {
                try {
                    conexion.Open();
                } catch (Exception) {
                    throw new ExcepcionConexionServidorMySQL();
                }

                List<string> querys =
                [
                    """
                    ALTER TABLE adv__producto 
                    ADD id_tipo_materia_prima INT(11) NOT NULL 
                    DEFAULT '1' 
                    AFTER id_proveedor;
                    """,
                    """"
                    ALTER TABLE adv__producto 
                    ADD UNIQUE INDEX nombre_unico (nombre);
                    """"
                ];

                foreach (var query in querys)
                    using (var cmd = new MySqlCommand(query, conexion))
                        cmd.ExecuteNonQuery();
            }
        }

        private static void PopularDatosTablasNuevas() {
            using (var conexion = new MySqlConnection(UtilesConfServidores.ObtenerStringConfServidorMySQL())) {
                try {
                    conexion.Open();
                } catch (Exception) {
                    throw new ExcepcionConexionServidorMySQL();
                }

                List<string> querys =
                [
                    """
                    INSERT INTO adv__tipo_materia_prima (nombre, descripcion)
                    VALUES 
                        ('Genérico', 'Tipo de material genérico para materias primas no clasificadas'),
                        ('Tela', 'Material principal para la confección de prendas'),
                        ('Hilo', 'Utilizado para costuras y acabados'),
                        ('Botón', 'Accesorio para cierre y decoración'),
                        ('Cremallera', 'Cierre deslizante para prendas'),
                        ('Elástico', 'Banda flexible para ajuste'),
                        ('Entretela', 'Refuerzo interno para cuellos y puños'),
                        ('Cinta', 'Usada para acabados y detalles'),
                        ('Velcro', 'Cierre de contacto para prendas y accesorios'),
                        ('Broche', 'Cierre metálico o plástico'),
                        ('Aguja', 'Herramienta para coser a mano o máquina');
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