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
                    CREATE TABLE IF NOT EXISTS adv__caja (
                        id_caja int(11) NOT NULL AUTO_INCREMENT,
                        estado enum('Inactiva','Abierta','Cerrada') NOT NULL DEFAULT 'Inactiva',
                        fecha_apertura datetime DEFAULT NULL,
                        saldo_inicial decimal(10,2) NOT NULL DEFAULT 0.00,
                        saldo_actual decimal(10,2) NOT NULL DEFAULT 0.00,
                        fecha_cierre datetime DEFAULT NULL,
                        id_cuenta_usuario int(11) DEFAULT 0,
                        PRIMARY KEY (id_caja)
                    ) ENGINE=InnoDB;
                    """,
                    """
                    CREATE TABLE IF NOT EXISTS adv__movimiento_caja (
                        id_movimiento_caja int(11) NOT NULL AUTO_INCREMENT,
                        id_caja int(11) NOT NULL,
                        fecha datetime DEFAULT NULL,
                        monto decimal(10,2) NOT NULL DEFAULT 0.00,
                        tipo enum('Ingreso','Egreso') NOT NULL DEFAULT 'Ingreso',
                        concepto varchar(255) NOT NULL,
                        id_pago int(11) DEFAULT 0,
                        id_usuario int(11) DEFAULT 0,
                        observaciones text,
                        PRIMARY KEY (id_movimiento_caja)
                    ) ENGINE=InnoDB;
                    """
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
                    RENAME TABLE advanceerp.adv__articulo 
                    TO advanceerp.adv__producto;
                    """,
                    """
                    ALTER TABLE adv__producto 
                    CHANGE id_articulo id_producto INT(11) NOT NULL AUTO_INCREMENT;
                    """,
                    """
                    RENAME TABLE advanceerp.adv__articulo_almacen 
                    TO advanceerp.adv__producto_almacen;
                    """,
                    """
                    ALTER TABLE adv__producto_almacen 
                    CHANGE id_articulo_almacen id_producto_almacen INT(11) NOT NULL AUTO_INCREMENT, 
                    CHANGE id_articulo id_producto INT(11) NOT NULL;
                    """,
                    """
                    RENAME TABLE advanceerp.adv__detalle_compra_articulo 
                    TO advanceerp.adv__detalle_compra_producto;
                    """,
                    """
                    ALTER TABLE adv__detalle_compra_producto 
                    CHANGE id_detalle_compra_articulo id_detalle_compra_producto INT(11) NOT NULL AUTO_INCREMENT, 
                    CHANGE id_articulo id_producto INT(11) NOT NULL;
                    """,
                    """
                    RENAME TABLE advanceerp.adv__detalle_venta_articulo 
                    TO advanceerp.adv__detalle_venta_producto;
                    """,
                    """
                    ALTER TABLE adv__detalle_venta_producto 
                    CHANGE id_detalle_venta_articulo id_detalle_venta_producto BIGINT(20) NOT NULL AUTO_INCREMENT, 
                    CHANGE id_articulo id_producto INT(11) NOT NULL;
                    """,
                    """
                    ALTER TABLE adv__movimiento 
                    CHANGE id_articulo id_producto INT(11) NOT NULL;
                    """,
                    """
                    ALTER TABLE adv__producto 
                    ADD tipo ENUM(
                        'Mercancia',
                        'ProductoTerminado',
                        'MateriaPrima'
                    ) NOT NULL 
                    DEFAULT 'Mercancia'
                    AFTER id_producto
                    ;
                    """,
                    """

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
