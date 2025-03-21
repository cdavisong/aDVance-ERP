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
            ActualizarColumnasMontosADecimal();
            EliminarModuloVentasYPermisos();
            MigrarDatosMotivoATipoMovimiento();
            CorregirVentaIncorrecta();

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

            // Verificar si la columna ya existe antes de agregarla
            string verificarColumnaExistente = @"
            SELECT COUNT(*)
            FROM INFORMATION_SCHEMA.COLUMNS
            WHERE TABLE_SCHEMA = DATABASE()
            AND TABLE_NAME = 'adv__movimiento'
            AND COLUMN_NAME = 'id_tipo_movimiento';";

            using (MySqlCommand cmdVerificar = new MySqlCommand(verificarColumnaExistente, conexion)) {
                int cantidadColumnas = Convert.ToInt32(cmdVerificar.ExecuteScalar());

                if (cantidadColumnas == 0) {
                    // Si la columna no existe, se agrega
                    string agregarTipoMovimientoTablaMovimiento = @"
                    ALTER TABLE adv__movimiento
                    ADD COLUMN id_tipo_movimiento INT;";

                    using (MySqlCommand cmdAgregar = new MySqlCommand(agregarTipoMovimientoTablaMovimiento, conexion)) {
                        cmdAgregar.ExecuteNonQuery();
                    }
                }
            }
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

    static void CorregirVentaIncorrecta() {
        Console.Write("- Corrigiendo venta incorrecta...");

        using (var conexion = new MySqlConnection(UtilesConfServidores.ObtenerStringConfServidorMySQL())) {
            try {
                conexion.Open();
            } catch (Exception) {
                throw new ExcepcionConexionServidorMySQL();
            }

            // Paso 1: Actualizar el precio unitario en adv__detalle_venta_articulo
            string actualizarPrecioUnitario = @"
                    UPDATE adv__detalle_venta_articulo
                    SET precio_unitario = 7700.00
                    WHERE id_detalle_venta_articulo = 3;";

            using (MySqlCommand cmd = new MySqlCommand(actualizarPrecioUnitario, conexion))
                cmd.ExecuteNonQuery();

            // Paso 2: Actualizar el monto total en adv__venta
            string actualizarMontoVenta = @"
                    UPDATE adv__venta
                    SET total = 77000.00
                    WHERE id_venta = 3;";

            using (MySqlCommand cmd = new MySqlCommand(actualizarMontoVenta, conexion))
                cmd.ExecuteNonQuery();

            // Paso 2: Actualizar el monto del pago adv__pago
            string actualizarMontoPago = @"
                    UPDATE adv__pago
                    SET monto = 77000.00
                    WHERE id_venta = 3;";

            using (MySqlCommand cmd = new MySqlCommand(actualizarMontoPago, conexion))
                cmd.ExecuteNonQuery();

            // Paso 3: Insertar un nuevo movimiento en adv__movimiento
            string insertarMovimiento = @"
                    INSERT INTO adv__movimiento (id_articulo, id_almacen_origen, id_almacen_destino, fecha, cantidad_movida, id_tipo_movimiento)
                    SELECT dva.id_articulo, 9 AS id_almacen_origen, NULL AS id_almacen_destino, v.fecha, dva.cantidad, tm.id_tipo_movimiento
                    FROM adv__venta v
                    JOIN adv__detalle_venta_articulo dva ON v.id_venta = dva.id_venta
                    JOIN adv__tipo_movimiento tm ON tm.nombre = 'Venta'
                    WHERE v.id_venta = 3;";

            using (MySqlCommand cmd = new MySqlCommand(insertarMovimiento, conexion))
                cmd.ExecuteNonQuery();

            Console.Write(" Corrección completada.\n");
        }
    }

    static void EliminarModuloVentasYPermisos() {
        Console.Write("- Eliminando módulo MOD_VENTAS, sus permisos asociados y referencias en roles...");

        using (var conexion = new MySqlConnection(UtilesConfServidores.ObtenerStringConfServidorMySQL())) {
            try {
                conexion.Open();
            } catch (Exception) {
                throw new ExcepcionConexionServidorMySQL();
            }

            // Paso 1: Eliminar las referencias en adv__rol_permiso que apuntan a permisos relacionados con MOD_VENTAS
            string eliminarReferenciasRoles = @"
            DELETE FROM adv__rol_permiso
            WHERE id_permiso IN (
                SELECT id_permiso FROM adv__permiso WHERE nombre LIKE '%MOD_VENTAS%'
            );";

            using (MySqlCommand cmd = new MySqlCommand(eliminarReferenciasRoles, conexion)) {
                cmd.ExecuteNonQuery();
            }

            // Paso 2: Eliminar los permisos que contienen la frase 'MOD_VENTAS' en su nombre
            string eliminarPermisosVentas = @"
            DELETE FROM adv__permiso
            WHERE nombre LIKE '%MOD_VENTAS%';";

            using (MySqlCommand cmd = new MySqlCommand(eliminarPermisosVentas, conexion)) {
                cmd.ExecuteNonQuery();
            }

            // Paso 3: Eliminar el módulo MOD_VENTAS
            string eliminarModuloVentas = @"
            DELETE FROM adv__modulo
            WHERE nombre = 'MOD_VENTAS';";

            using (MySqlCommand cmd = new MySqlCommand(eliminarModuloVentas, conexion)) {
                cmd.ExecuteNonQuery();
            }

            Console.Write(" Módulo, permisos y referencias en roles eliminados correctamente.\n");
        }
    }
}