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
            ExecuteStep(CrearTablasNuevas, "Creación de estructura modular");
            ExecuteStep(ModificarTablasExistentes, "Actualización de esquema");
            ExecuteStep(ActualizarColumnasMontosADecimal, "Normalización financiera");
            ExecuteStep(MigrarDatosMotivoATipoMovimiento, "Reestructuración de movimientos");
            ExecuteStep(EliminarModuloVentasYPermisos, "Depuración de módulos obsoletos");
            ExecuteStep(EliminarVentasYMovimientosAsociados, "Reinicio de transacciones comerciales");
            ExecuteStep(MigrarPreciosCompraADetallesCompra, "Registro de compra inicial");

            RenderStatus("Parche aDVance ERP aplicado correctamente", ConsoleColor.Green);
        }
        catch (Exception ex) {
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
            }
            catch (Exception) {
                throw new ExcepcionConexionServidorMySQL();
            }

            // Crear tabla adv__tipo_movimiento
            const string crearTablaTipoMovimiento = @"
                    CREATE TABLE IF NOT EXISTS adv__tipo_movimiento (
                        id_tipo_movimiento INT PRIMARY KEY AUTO_INCREMENT,
                        nombre VARCHAR(50) NOT NULL,
                        efecto ENUM('Carga', 'Descarga', 'Transferencia') NOT NULL
                    );";

            using (var cmd = new MySqlCommand(crearTablaTipoMovimiento, conexion)) {
                cmd.ExecuteNonQuery();
            }

            // Crear tabla adv__compra
            const string crearTablaCompra = @"
                CREATE TABLE IF NOT EXISTS adv__compra (
                    id_compra INT(11) PRIMARY KEY AUTO_INCREMENT,
                    fecha DATETIME NOT NULL,
                    id_almacen INT(11) NOT NULL,
                    id_proveedor INT(11) NOT NULL,
                    total DECIMAL(10,2) NOT NULL                    
                );";

            using (var cmd = new MySqlCommand(crearTablaCompra, conexion)) {
                cmd.ExecuteNonQuery();
            }

            // Crear tabla adv__detalle_compra
            const string crearTablaDetalleCompra = @"
                CREATE TABLE IF NOT EXISTS adv__detalle_compra_articulo (
                   id_detalle_compra_articulo INT(11) PRIMARY KEY AUTO_INCREMENT,
                   id_compra INT(11) NOT NULL,
                   id_articulo INT(11) NOT NULL,
                   cantidad INT(11) NOT NULL,
                   precio_compra DECIMAL(10,2) NOT NULL
                );";

            using (var cmd = new MySqlCommand(crearTablaDetalleCompra, conexion)) {
                cmd.ExecuteNonQuery();
            }

            // Crear tabla adv__mensajero
            const string crearTablaMensajero = @"
                CREATE TABLE IF NOT EXISTS adv__mensajero (
                  id_mensajero INT(11) PRIMARY KEY AUTO_INCREMENT,
                  nombre VARCHAR(100) COLLATE latin1_general_ci NOT NULL,
                  activo TINYINT(1) NOT NULL DEFAULT 1,
                  id_contacto INT(11) NOT NULL
                );";

            using (var cmd = new MySqlCommand(crearTablaMensajero, conexion)) {
                cmd.ExecuteNonQuery();
            }

            // Crear tabla adv__tipo_entrega
            const string crearTablaTipoEntrega = @"
                CREATE TABLE IF NOT EXISTS adv__tipo_entrega (
                  id_tipo_entrega INT(11) PRIMARY KEY AUTO_INCREMENT,
                  nombre VARCHAR(50) COLLATE latin1_general_ci NOT NULL,
                  descripcion TEXT COLLATE latin1_general_ci DEFAULT NULL,
                  requiere_pago_previo TINYINT(1) NOT NULL DEFAULT 0
                );";

            using (var cmd = new MySqlCommand(crearTablaTipoEntrega, conexion)) {
                cmd.ExecuteNonQuery();
            }

            // Crear tabla adv__seguimiento_entrega
            const string crearTablaSeguimientoEntrega = @"
                CREATE TABLE IF NOT EXISTS adv__seguimiento_entrega (
                  id_seguimiento_entrega INT(11) PRIMARY KEY AUTO_INCREMENT,
                  id_venta INT(11) NOT NULL,
                  id_mensajero INT(11) DEFAULT NULL,
                  fecha_asignacion DATETIME DEFAULT NULL,
                  fecha_entrega DATETIME DEFAULT NULL,
                  fecha_pago DATETIME DEFAULT NULL,
                  observaciones TEXT COLLATE latin1_general_ci DEFAULT NULL
                );";

            using (var cmd = new MySqlCommand(crearTablaSeguimientoEntrega, conexion)) {
                cmd.ExecuteNonQuery();
            }
        }
    }

    private static void ModificarTablasExistentes() {
        using (var conexion = new MySqlConnection(UtilesConfServidores.ObtenerStringConfServidorMySQL())) {
            try {
                conexion.Open();
            }
            catch (Exception) {
                throw new ExcepcionConexionServidorMySQL();
            }

            // Agregar columna id_tipo_movimiento a la tabla adv__movimiento
            const string agregarTipoMovimientoTablaMovimiento = @"
                ALTER TABLE adv__movimiento 
                ADD COLUMN id_tipo_movimiento INT NOT NULL DEFAULT 0;";

            using (var cmd = new MySqlCommand(agregarTipoMovimientoTablaMovimiento, conexion)) {
                cmd.ExecuteNonQuery();
            }

            // Modificar columna precio_adquisicion a la tabla adv__articulo
            const string modificarPrecioAdquisicionTablaArticulo = @"
                ALTER TABLE adv__articulo 
                CHANGE precio_adquisicion precio_compra_base DECIMAL(10,2) NOT NULL;";

            using (var cmd = new MySqlCommand(modificarPrecioAdquisicionTablaArticulo, conexion)) {
                cmd.ExecuteNonQuery();
            }

            // Modificar columna precio_cesion a la tabla adv__articulo
            const string modificarPrecioCesionTablaArticulo = @"
                ALTER TABLE adv__articulo 
                CHANGE precio_cesion precio_venta_base DECIMAL(10,2) NOT NULL;";

            using (var cmd = new MySqlCommand(modificarPrecioCesionTablaArticulo, conexion)) {
                cmd.ExecuteNonQuery();
            }

            // Eliminar columna stock_minimo de la tabla adv__articulo
            const string eliminarStockMinimoTablaArticulo = @"
                ALTER TABLE adv__articulo 
                DROP COLUMN stock_minimo;";

            using (var cmd = new MySqlCommand(eliminarStockMinimoTablaArticulo, conexion)) {
                cmd.ExecuteNonQuery();
            }

            // Eliminar columna pedido_minimo de la tabla adv__articulo
            const string eliminarPedidoMinimoTablaArticulo = @"
                ALTER TABLE adv__articulo 
                DROP COLUMN pedido_minimo;";

            using (var cmd = new MySqlCommand(eliminarPedidoMinimoTablaArticulo, conexion)) {
                cmd.ExecuteNonQuery();
            }

            // Modificar columna precio_unitario a la tabla adv__detalle_venta_articulo
            const string modificarPrecioUnitarioTablaDetalleVentaArticulo = @"
                ALTER TABLE adv__detalle_venta_articulo 
                CHANGE precio_unitario precio_venta_final DECIMAL(10,2) NOT NULL;";

            using (var cmd = new MySqlCommand(modificarPrecioUnitarioTablaDetalleVentaArticulo, conexion)) {
                cmd.ExecuteNonQuery();
            }

            // Agregar columna precio_venta_vigente a la tabla adv__detalle_venta_articulo
            const string agregarPrecioVentaVigenteTablaDetalleVentaArticulo = @"
                ALTER TABLE adv__detalle_venta_articulo 
                ADD COLUMN precio_compra_vigente DECIMAL(10,2) NOT NULL AFTER id_articulo;";

            using (var cmd = new MySqlCommand(agregarPrecioVentaVigenteTablaDetalleVentaArticulo, conexion)) {
                cmd.ExecuteNonQuery();
            }

            // Insertar los tipos de entrega a la tabla adv__tipo_entrega
            const string insertarTiposTablaTipoEntrega = @"
                INSERT INTO adv__tipo_entrega (id_tipo_entrega, nombre, descripcion, requiere_pago_previo) VALUES
                (1, 'Presencial', 'Cliente recibe el producto en el local', 1),
                (2, 'Mensajería (con fondo)', 'Mensajero paga y lleva el producto al cliente', 0),
                (3, 'Mensajería (sin fondo)', 'Mensajero transporta el producto y luego se cobra', 0);";

            using (var cmd = new MySqlCommand(insertarTiposTablaTipoEntrega, conexion)) {
                cmd.ExecuteNonQuery();
            }

            // Modificar la tabla de adv__ventas para incluir el tipo de entrega
            const string agregarTipoDireccionEstadoEntregaTablaVenta = @"
                ALTER TABLE adv__venta
                ADD COLUMN id_tipo_entrega INT(11) NOT NULL DEFAULT 1 AFTER id_cliente,
                ADD COLUMN direccion_entrega VARCHAR(255) COLLATE latin1_general_ci DEFAULT NULL AFTER id_tipo_entrega,
                ADD COLUMN estado_entrega VARCHAR(50) COLLATE latin1_general_ci DEFAULT 'Pendiente' AFTER direccion_entrega;";

            using (var cmd = new MySqlCommand(agregarTipoDireccionEstadoEntregaTablaVenta, conexion)) {
                cmd.ExecuteNonQuery();
            }

            // Modificar la tabla adv__pago para manejar pagos diferidos
            const string agregarEstadoFechaConfirmacionTablaPago = @"
                ALTER TABLE adv__pago
                ADD COLUMN estado VARCHAR(20) COLLATE latin1_general_ci NOT NULL DEFAULT 'Completado',
                ADD COLUMN fecha_confirmacion DATETIME DEFAULT NULL AFTER monto;";

            using (var cmd = new MySqlCommand(agregarEstadoFechaConfirmacionTablaPago, conexion)) {
                cmd.ExecuteNonQuery();
            }

            // Eliminar los usuarios registrados
            const string eliminarUsuariosRegistrados = @"
                TRUNCATE TABLE `adv__cuenta_usuario`;
                ALTER TABLE `adv__cuenta_usuario` AUTO_INCREMENT = 1;";

            using (var cmd = new MySqlCommand(eliminarUsuariosRegistrados, conexion)) {
                cmd.ExecuteNonQuery();
            }

            // Eliminar los telefonos de contacto registrados
            const string eliminarTelefonosRegistrados = @"
                TRUNCATE TABLE `adv__telefono_contacto`;
                ALTER TABLE `adv__telefono_contacto` AUTO_INCREMENT = 1;";

            using (var cmd = new MySqlCommand(eliminarTelefonosRegistrados, conexion)) {
                cmd.ExecuteNonQuery();
            }
        }
    }

    private static void ActualizarColumnasMontosADecimal() {
        using (var conexion = new MySqlConnection(UtilesConfServidores.ObtenerStringConfServidorMySQL())) {
            try {
                conexion.Open();
            }
            catch (Exception) {
                throw new ExcepcionConexionServidorMySQL();
            }

            // Script para actualizar las columnas a DECIMAL
            const string actualizarColumnas = @"
                    ALTER TABLE adv__venta MODIFY total DECIMAL(10, 2) NOT NULL;
                    ALTER TABLE adv__compra MODIFY total DECIMAL(10, 2) NOT NULL;
                    ALTER TABLE adv__articulo MODIFY precio_compra_base DECIMAL(10, 2) NOT NULL;
                    ALTER TABLE adv__articulo MODIFY precio_venta_base DECIMAL(10, 2) NOT NULL;
                    ALTER TABLE adv__detalle_venta_articulo MODIFY precio_venta_final DECIMAL(10, 2) NOT NULL;
                    ALTER TABLE adv__pago MODIFY monto DECIMAL(10, 2) NOT NULL;";

            using (var cmd = new MySqlCommand(actualizarColumnas, conexion)) {
                cmd.ExecuteNonQuery();
            }
        }
    }

    private static void MigrarDatosMotivoATipoMovimiento() {
        using (var conexion = new MySqlConnection(UtilesConfServidores.ObtenerStringConfServidorMySQL())) {
            try {
                conexion.Open();
            }
            catch (Exception) {
                throw new ExcepcionConexionServidorMySQL();
            }

            // Paso 1: Insertar los tipos de movimiento en adv__tipo_movimiento
            const string insertarTiposMovimiento = @"
                INSERT INTO adv__tipo_movimiento (nombre, efecto)
                VALUES 
                    ('Compra', 'Carga'),
                    ('Venta', 'Descarga'),
                    ('Baja por defecto', 'Descarga'),
                    ('Uso interno', 'Transferencia');";

            using (var cmd = new MySqlCommand(insertarTiposMovimiento, conexion)) {
                cmd.ExecuteNonQuery();
            }

            // Paso 2: Actualizar adv__movimiento con id_tipo_movimiento
            const string actualizarMovimientos = @"
                UPDATE adv__movimiento m
                JOIN adv__tipo_movimiento tm ON m.motivo = tm.nombre
                SET m.id_tipo_movimiento = tm.id_tipo_movimiento;";

            using (var cmd = new MySqlCommand(actualizarMovimientos, conexion)) {
                cmd.ExecuteNonQuery();
            }

            // Paso 3: Eliminar la columna 'motivo'
            const string eliminarColumnaMotivo = @"
                ALTER TABLE adv__movimiento 
                DROP COLUMN motivo;";

            using (var cmd = new MySqlCommand(eliminarColumnaMotivo, conexion)) {
                cmd.ExecuteNonQuery();
            }
        }
    }

    private static void EliminarVentasYMovimientosAsociados() {
        using (var conexion = new MySqlConnection(UtilesConfServidores.ObtenerStringConfServidorMySQL())) {
            try {
                conexion.Open();
            }
            catch (Exception) {
                throw new ExcepcionConexionServidorMySQL();
            }

            // Orden de eliminación recomendado
            string[] consultasEliminacion = {
                "DELETE FROM adv__detalle_pago_transferencia;", // Detalles específicos de transferencias
                "DELETE FROM adv__pago;", // Pagos generales
                "DELETE FROM adv__detalle_venta_articulo;", // Detalles de ventas
                "DELETE FROM adv__movimiento WHERE id_tipo_movimiento = 2;", // Movimientos de ventas (tipo 2)
                "DELETE FROM adv__venta;" // Cabecera de ventas
            };

            foreach (var consulta in consultasEliminacion)
                using (var cmd = new MySqlCommand(consulta, conexion)) {
                    cmd.ExecuteNonQuery();
                }
        }
    }

    private static void EliminarModuloVentasYPermisos() {
        using (var conexion = new MySqlConnection(UtilesConfServidores.ObtenerStringConfServidorMySQL())) {
            try {
                conexion.Open();
            }
            catch (Exception) {
                throw new ExcepcionConexionServidorMySQL();
            }

            // Paso 1: Eliminar las referencias en adv__rol_permiso que apuntan a permisos relacionados con MOD_VENTAS
            var eliminarReferenciasRoles = @"
            DELETE FROM adv__rol_permiso
            WHERE id_permiso IN (
                SELECT id_permiso FROM adv__permiso WHERE nombre LIKE '%MOD_VENTAS%'
            );";

            using (var cmd = new MySqlCommand(eliminarReferenciasRoles, conexion)) {
                cmd.ExecuteNonQuery();
            }

            // Paso 2: Eliminar los permisos que contienen la frase 'MOD_VENTAS' en su nombre
            var eliminarPermisosVentas = @"
            DELETE FROM adv__permiso
            WHERE nombre LIKE '%MOD_VENTAS%';";

            using (var cmd = new MySqlCommand(eliminarPermisosVentas, conexion)) {
                cmd.ExecuteNonQuery();
            }

            // Paso 3: Eliminar el módulo MOD_VENTAS
            var eliminarModuloVentas = @"
            DELETE FROM adv__modulo
            WHERE nombre = 'MOD_VENTAS';";

            using (var cmd = new MySqlCommand(eliminarModuloVentas, conexion)) {
                cmd.ExecuteNonQuery();
            }
        }
    }

    private static void MigrarPreciosCompraADetallesCompra() {
        using (var conexion = new MySqlConnection(UtilesConfServidores.ObtenerStringConfServidorMySQL())) {
            try {
                conexion.Open();
            }
            catch (Exception) {
                throw new ExcepcionConexionServidorMySQL();
            }

            // Paso 1: Crear una compra genérica
            const string crearCompraGenerica = @"
            INSERT INTO adv__compra (fecha, id_almacen, id_proveedor, total)
            VALUES (NOW(), 8, 0, 0);";

            int idCompra;
            using (var cmd = new MySqlCommand(crearCompraGenerica, conexion)) {
                cmd.ExecuteNonQuery();

                // Obtener ID de la compra recién creada
                cmd.CommandText = "SELECT LAST_INSERT_ID();";
                idCompra = Convert.ToInt32(cmd.ExecuteScalar());
            }

            // Paso 2: Insertar detalles de compra para cada artículo
            const string migrarDetallesCompra = @"
            INSERT INTO adv__detalle_compra_articulo 
                (id_compra, id_articulo, cantidad, precio_compra)
            SELECT 
                @idCompra,
                a.id_articulo,
                COALESCE(aa.stock_total, 0) AS cantidad,
                a.precio_compra_base
            FROM adv__articulo a
            LEFT JOIN (
                SELECT id_articulo, SUM(stock) AS stock_total
                FROM adv__articulo_almacen
                GROUP BY id_articulo
            ) aa ON a.id_articulo = aa.id_articulo;";

            using (var cmd = new MySqlCommand(migrarDetallesCompra, conexion)) {
                cmd.Parameters.AddWithValue("@idCompra", idCompra);
                cmd.ExecuteNonQuery();
            }

            // Paso 3: Crear movimientos de carga para cada artículo
            const string crearMovimientos = @"
            INSERT INTO adv__movimiento 
                (id_articulo, id_almacen_origen, id_almacen_destino, fecha, cantidad_movida, id_tipo_movimiento)
            SELECT 
                aa.id_articulo,
                0,  -- Asumiendo que el origen es '0' (proveedor/externo)
                8,  -- Almacén destino (8 según la compra)
                NOW(),
                aa.stock_total,
                1   -- Tipo movimiento: Compra (Carga)
            FROM (
                SELECT id_articulo, SUM(stock) AS stock_total
                FROM adv__articulo_almacen
                GROUP BY id_articulo
            ) aa;";

            using (var cmd = new MySqlCommand(crearMovimientos, conexion)) {
                cmd.ExecuteNonQuery();
            }

            // Paso 4: Actualizar el total de la compra genérica
            const string actualizarTotalCompra = @"
            UPDATE adv__compra 
            SET total = (
                SELECT SUM(cantidad * precio_compra) 
                FROM adv__detalle_compra_articulo 
                WHERE id_compra = @idCompra
            )
            WHERE id_compra = @idCompra;";

            using (var cmd = new MySqlCommand(actualizarTotalCompra, conexion)) {
                cmd.Parameters.AddWithValue("@idCompra", idCompra);
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
        }
        catch (Exception ex) {
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