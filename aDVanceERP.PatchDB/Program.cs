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
                    CREATE TABLE IF NOT EXISTS adv__caja (
                        id_caja int(11) NOT NULL AUTO_INCREMENT,
                        estado enum('Inactiva','Abierta','Cerrada') NOT NULL DEFAULT 'Abierta',
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
                    """,
                    """
                    CREATE TABLE IF NOT EXISTS adv__detalle_producto (
                        id_detalle_producto int(11) NOT NULL AUTO_INCREMENT,
                        id_unidad_medida int(11) DEFAULT 0,
                        id_color_producto_primario int(11) DEFAULT 0,
                        id_color_producto_secundario int(11) DEFAULT 0,
                        id_tipo_producto int(11) DEFAULT 0,
                        id_diseno_producto int(11) DEFAULT 0,
                        descripcion text,
                        PRIMARY KEY (id_detalle_producto)
                    ) ENGINE=InnoDB;
                    """,
                    """
                    CREATE TABLE IF NOT EXISTS adv__unidad_medida (
                        id_unidad_medida int(11) NOT NULL AUTO_INCREMENT,
                        nombre varchar(50) NOT NULL,
                        abreviatura varchar(10) NOT NULL,
                        descripcion text,
                        PRIMARY KEY (id_unidad_medida)
                    ) ENGINE=InnoDB;
                    """,
                    """
                    CREATE TABLE IF NOT EXISTS adv__color_producto (
                        id_color_producto int(11) NOT NULL AUTO_INCREMENT,
                        nombre varchar(50) NOT NULL,
                        codigo_argb int(11) NOT NULL DEFAULT 0,
                        PRIMARY KEY (id_color_producto)
                    ) ENGINE=InnoDB;
                    """,
                    """
                    CREATE TABLE IF NOT EXISTS adv__tipo_producto (
                        id_tipo_producto int(11) NOT NULL AUTO_INCREMENT,
                        nombre varchar(50) NOT NULL,
                        descripcion text,
                        PRIMARY KEY (id_tipo_producto)
                    ) ENGINE=InnoDB;
                    """,
                    """
                    CREATE TABLE IF NOT EXISTS adv__diseno_producto (
                        id_diseno_producto int(11) NOT NULL AUTO_INCREMENT,
                        nombre varchar(50) NOT NULL,
                        descripcion text,
                        PRIMARY KEY (id_diseno_producto)
                    ) ENGINE=InnoDB;
                    """,
                    """                    
                    ALTER TABLE adv__producto 
                    ADD COLUMN id_detalle_producto INT(11) NULL AFTER nombre;

                    -- Insertar detalles para todos los productos existentes
                    INSERT INTO adv__detalle_producto (
                            id_detalle_producto, 
                            id_unidad_medida, 
                            id_color_producto_primario,
                            id_color_producto_secundario, 
                            id_tipo_producto, 
                            id_diseno_producto, 
                            descripcion
                        )
                    SELECT 
                        p.id_producto, 
                        0,  -- id_unidad_medida por defecto
                        0,  -- id_color_producto_primario por defecto
                        0,  -- id_color_producto_secundario por defecto
                        0,  -- id_tipo_producto por defecto
                        0,  -- id_diseno_producto por defecto
                        p.descripcion
                    FROM adv__producto p
                    WHERE p.descripcion IS NOT NULL;

                    -- Actualizar las referencias en adv__producto
                    UPDATE adv__producto p
                    SET p.id_detalle_producto = p.id_producto
                    WHERE p.descripcion IS NOT NULL;

                    -- Eliminar el campo descripcion
                    ALTER TABLE adv__producto DROP COLUMN descripcion;
                    """,
                    """
                    CREATE TABLE IF NOT EXISTS adv__actividad_produccion (
                        id_actividad_produccion INT(11) NOT NULL AUTO_INCREMENT,
                        nombre VARCHAR(100) NOT NULL,
                        descripcion TEXT,
                        costo DECIMAL(10,2) NOT NULL DEFAULT 0.00,
                        PRIMARY KEY (id_actividad_produccion)
                    ) ENGINE=InnoDB;
                    """,
                    """
                    CREATE TABLE IF NOT EXISTS adv__producto_mano_obra (
                        id_producto_mano_obra INT(11) NOT NULL AUTO_INCREMENT,
                        id_producto INT(11) NOT NULL,
                        id_actividad_produccion INT(11) NOT NULL,
                        PRIMARY KEY (id_producto_mano_obra)
                    ) ENGINE=InnoDB;
                    """,
                    """
                    CREATE TABLE IF NOT EXISTS adv__producto_materia_prima (
                        id_producto_materia_prima INT(11) NOT NULL AUTO_INCREMENT,
                        id_producto INT(11) NOT NULL,
                        id_materia_prima INT(11) NOT NULL,
                        cantidad DECIMAL(10,2) NOT NULL DEFAULT 0.00,
                        PRIMARY KEY (id_producto_materia_prima)
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
                    ADD categoria ENUM(
                        'Mercancia',
                        'ProductoTerminado',
                        'MateriaPrima'
                    ) NOT NULL 
                    DEFAULT 'Mercancia'
                    AFTER id_producto;
                    """,
                    """
                    ALTER TABLE adv__producto
                    ADD COLUMN es_vendible BOOLEAN NOT NULL 
                    DEFAULT TRUE
                    AFTER id_proveedor;
                    """
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
                    INSERT INTO `adv__unidad_medida` (`nombre`, `abreviatura`, `descripcion`) VALUES
                    ('Unidad', 'u', 'Elemento individual o pieza completa'),
                    ('Docena', 'dz', 'Conjunto de 12 unidades'),
                    ('Centímetro', 'cm', 'Para medir telas, cintas o longitudes pequeñas'),
                    ('Metro', 'm', 'Para medir telas, rollos o distancias mayores'),
                    ('Gramo', 'g', 'Para pigmentos, polvos o ingredientes cosméticos'),
                    ('Kilogramo', 'kg', 'Para materias primas a granel'),
                    ('Mililitro', 'ml', 'Para líquidos como pinturas, disolventes o lociones'),
                    ('Litro', 'L', 'Para mayores cantidades de líquidos'),
                    ('Pulgada', 'in', 'Medida anglosajona para telas o herramientas'),
                    ('Juego', 'jg', 'Conjunto de piezas que funcionan juntas'),
                    ('Paquete', 'pq', 'Para agrupaciones de productos'),
                    ('Caja', 'cj', 'Unidad de empaque estándar'),
                    ('Rollo', 'rll', 'Para materiales enrollados como cintas o telas'),
                    ('Tubo', 'tb', 'Para cremas, pinturas o productos en envase tubular'),
                    ('Frasco', 'fsc', 'Para productos en envases de vidrio o plástico'),
                    ('Bolsa', 'bls', 'Para productos a granel o empaques flexibles'),
                    ('Kit', 'kt', 'Conjunto de productos complementarios'),
                    ('Par', 'pr', 'Para artículos que van en pares'),
                    ('Pulgada cúbica', 'in³', 'Para medir volúmenes pequeños'),
                    ('Pie cúbico', 'ft³', 'Para medir volúmenes mayores'),
                    ('Onza', 'oz', 'Medida para líquidos y sólidos (28.35 gramos)'),
                    ('Onza líquida', 'fl oz', 'Específica para líquidos (29.57 ml)'),
                    ('Yarda', 'yd', 'Para telas y materiales textiles (0.9144 metros)'),
                    ('Galón', 'gal', 'Para líquidos a granel (3.785 litros)'),
                    ('Pulgada cuadrada', 'in²', 'Para medir superficies pequeñas'),
                    ('Pie cuadrado', 'ft²', 'Para medir superficies mayores'),
                    ('Metro cuadrado', 'm²', 'Para medir superficies en sistema métrico');
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
