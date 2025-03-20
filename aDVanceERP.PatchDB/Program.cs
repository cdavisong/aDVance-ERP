using aDVanceERP.Core.Excepciones;
using aDVanceERP.Core.Utiles;

using MySql.Data.MySqlClient;

namespace aDVanceERP.PatchDB;

class Program {
    static void Main(string[] args) {
        var version = "desconocida";

        if (File.Exists(@".\app.ver"))
            using (var fs = new FileStream(@".\app.ver", FileMode.Open)) {
                using (var sr = new StreamReader(fs)) {
                    version = sr.ReadToEnd();
                }
            }

        Console.WriteLine("aDVance ERP");
        Console.WriteLine("--------------------------------------------------------------------");
        Console.WriteLine($"Iniciando parche BD versión {version}...\n");

        try {
            CrearTablasNuevas();
            ActualizarTablasExistentes();
            MigrarDatosMotivoATipoMovimiento();

            Console.WriteLine("\nParche aplicado correctamente.");
            Console.ReadLine();
        } catch (Exception ex) {
            Console.WriteLine("\nError al aplicar el parche: " + ex.Message);
        }
        Console.WriteLine("Presione cualquier tecla para salir.");
        Console.ReadLine();
    }

    static void CrearTablasNuevas() {
        Console.WriteLine("- Creando nuevas tablas...");

        using (var conexion = new MySqlConnection(UtilesConfServidores.ObtenerStringConfServidorMySQL())) {
            try {
                conexion.Open();
            } catch (Exception) {
                throw new ExcepcionConexionServidorMySQL();
            }

            // Crear tabla adv__tipo_movimiento
            string crearTablaTipoMovimiento = @"
                    CREATE TABLE IF NOT EXISTS adv__tipo_movimiento (
                        id_tipo_movimiento INT PRIMARY KEY AUTO_INCREMENT,
                        nombre VARCHAR(50) NOT NULL,
                        efecto ENUM('Carga', 'Descarga', 'Transferencia') NOT NULL
                    );";

            using (MySqlCommand cmd = new MySqlCommand(crearTablaTipoMovimiento, conexion))
                cmd.ExecuteNonQuery();

            // Crear tabla adv__compra
            string crearTablaCompra = @"
                CREATE TABLE IF NOT EXISTS adv__compra (
                    id_compra BIGINT PRIMARY KEY AUTO_INCREMENT,
                    fecha DATETIME NOT NULL,
                    id_almacen INT(11) NOT NULL,
                    id_proveedor INT(11) NOT NULL,
                    total DECIMAL NOT NULL
                );";

            using (MySqlCommand cmd = new MySqlCommand(crearTablaCompra, conexion))
                cmd.ExecuteNonQuery();

            Console.Write(" Tablas creadas correctamente.\n");

        }
    }

    static void ActualizarTablasExistentes() {
        Console.WriteLine("- Actualizando tablas existentes...");

        using (var conexion = new MySqlConnection(UtilesConfServidores.ObtenerStringConfServidorMySQL())) {
            try {
                conexion.Open();
            } catch (Exception) {
                throw new ExcepcionConexionServidorMySQL();
            }

            // Crear tabla adv__tipo_movimiento
            string agregarTipoMovimientoTablaMovimiento = @"
                    ALTER TABLE adv__movimiento
                    ADD COLUMN id_tipo_movimiento INT;";

            using (MySqlCommand cmd = new MySqlCommand(agregarTipoMovimientoTablaMovimiento, conexion))
                cmd.ExecuteNonQuery();
        }
    }

    static void MigrarDatosMotivoATipoMovimiento() {
        Console.Write("- Migrando datos de 'motivo' a 'tipo_movimiento'...");

        using (var conexion = new MySqlConnection(UtilesConfServidores.ObtenerStringConfServidorMySQL())) {
            try {
                conexion.Open();
            } catch (Exception) {
                throw new ExcepcionConexionServidorMySQL();
            }

            // Paso 1: Insertar los tipos de movimiento en adv__tipo_movimiento
            string insertarTiposMovimiento = @"
            INSERT INTO adv__tipo_movimiento (nombre, efecto)
            VALUES 
                ('Compra', 'Carga'),
                ('Venta', 'Descarga'),
                ('Baja por defecto', 'Descarga'),
                ('Uso interno', 'Transferencia');";

            using (MySqlCommand cmd = new MySqlCommand(insertarTiposMovimiento, conexion))
                cmd.ExecuteNonQuery();

            // Paso 2: Actualizar adv__movimiento con id_tipo_movimiento
            string actualizarMovimientos = @"
            UPDATE adv__movimiento m
            JOIN adv__tipo_movimiento tm ON m.motivo = tm.nombre
            SET m.id_tipo_movimiento = tm.id_tipo_movimiento;";

            using (MySqlCommand cmd = new MySqlCommand(actualizarMovimientos, conexion))
                cmd.ExecuteNonQuery();

            // Paso 3: Eliminar la columna 'motivo'
            string eliminarColumnaMotivo = @"ALTER TABLE adv__movimiento DROP COLUMN motivo;";
            using (MySqlCommand cmd = new MySqlCommand(eliminarColumnaMotivo, conexion))
                cmd.ExecuteNonQuery();

            Console.Write(" Migración completada.\n");
        }

        static void ActualizarColumnasMontosADecimal() {
            Console.Write("- Actualizando columnas de montos financieros a DECIMAL...");

            using (var conexion = new MySqlConnection(UtilesConfServidores.ObtenerStringConfServidorMySQL())) {
                try {
                    conexion.Open();
                } catch (Exception) {
                    throw new ExcepcionConexionServidorMySQL();
                }

                // Script para actualizar las columnas a DECIMAL
                string actualizarColumnas = @"
                    ALTER TABLE adv__venta MODIFY total DECIMAL(10, 2) NOT NULL;
                    ALTER TABLE adv__compra MODIFY total DECIMAL(10, 2) NOT NULL;
                    ALTER TABLE adv__articulo MODIFY precio_adquisicion DECIMAL(10, 2) NOT NULL;
                    ALTER TABLE adv__articulo MODIFY precio_cesion DECIMAL(10, 2) NOT NULL;
                    ALTER TABLE adv__detalle_venta_articulo MODIFY precio_unitario DECIMAL(10, 2) NOT NULL;
                    ALTER TABLE adv__pago MODIFY monto DECIMAL(10, 2) NOT NULL;";

                using (MySqlCommand cmd = new MySqlCommand(actualizarColumnas, conexion)) {
                    cmd.ExecuteNonQuery();
                }

                Console.Write(" Columnas actualizadas correctamente.\n");
            }
        }
    }
}