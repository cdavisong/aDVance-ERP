using aDVanceERP.Core.Excepciones;
using aDVanceERP.Core.Utiles;

using MySql.Data.MySqlClient;

namespace aDVanceERP.PatchDB;

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
            //ExecuteStep(CrearTablasNuevas, "Creación de estructura modular");
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

    private static void CrearTablasNuevas() {
        using (var conexion = new MySqlConnection(UtilesConfServidores.ObtenerStringConfServidorMySQL())) {
            try {
                conexion.Open();
            } catch (Exception) {
                throw new ExcepcionConexionServidorMySQL();
            }

            // Crear tabla adv__tipo_movimiento
            //const string crearTablaTipoMovimiento = @"
            //        CREATE TABLE IF NOT EXISTS adv__tipo_movimiento (
            //            id_tipo_movimiento INT PRIMARY KEY AUTO_INCREMENT,
            //            nombre VARCHAR(50) NOT NULL,
            //            efecto ENUM('Carga', 'Descarga', 'Transferencia') NOT NULL
            //        );";

            //using (var cmd = new MySqlCommand(crearTablaTipoMovimiento, conexion)) {
            //    cmd.ExecuteNonQuery();
            //}
        }
    }

    private static void ModificarTablasExistentes() {
        using (var conexion = new MySqlConnection(UtilesConfServidores.ObtenerStringConfServidorMySQL())) {
            try {
                conexion.Open();
            } catch (Exception) {
                throw new ExcepcionConexionServidorMySQL();
            }

            // Actualizar registros de pago donde fecha_confirmacion es NULL
            const string query1 = @"
                UPDATE adv__pago
                SET fecha_confirmacion = NOW()
                WHERE fecha_confirmacion IS NULL;";

            using (var cmd = new MySqlCommand(query1, conexion)) {
                cmd.ExecuteNonQuery();
            }

            // Actualizar registros de pago donde el estado es Confirmado
            const string query2 = @"
                UPDATE adv__pago
                SET estado = 'Confirmado'
                WHERE estado = 'Completado';";

            using (var cmd = new MySqlCommand(query2, conexion)) {
                cmd.ExecuteNonQuery();
            }

            const string query3 = @"
                UPDATE adv__venta
                SET direccion_entrega = ''
                WHERE direccion_entrega IS NULL;";

            using (var cmd = new MySqlCommand(query3, conexion)) {
                cmd.ExecuteNonQuery();
            }

            const string query4 = @"
                UPDATE adv__venta
                SET estado_entrega = 'Completada'
                WHERE id_tipo_entrega = 1;";

            using (var cmd = new MySqlCommand(query4, conexion)) {
                cmd.ExecuteNonQuery();
            }
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