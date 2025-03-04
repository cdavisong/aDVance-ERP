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
            // Crear las nuevas tablas
            CrearTablasNuevas();

            // Modificar y actualizar los datos de tablas existentes
            ActualizarTablasExistentes();

            Console.WriteLine("Parche aplicado correctamente.");
            Console.ReadLine();
        } catch (Exception ex) {
            Console.WriteLine("Error al aplicar el parche: " + ex.Message);
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

            // Crear tabla adv__modulo
            string crearTablaModulo = @"
                    CREATE TABLE IF NOT EXISTS adv__modulo (
                        id_modulo INT AUTO_INCREMENT PRIMARY KEY,
                        nombre VARCHAR(100) NOT NULL
                    );";

            using (MySqlCommand cmd = new MySqlCommand(crearTablaModulo, conexion)) 
                cmd.ExecuteNonQuery();
            

            // Crear tabla adv__permiso
            string crearTablaPermiso = @"
                    CREATE TABLE IF NOT EXISTS adv__permiso (
                        id_permiso INT AUTO_INCREMENT PRIMARY KEY,
                        id_modulo INT NOT NULL,
                        nombre VARCHAR(100) NOT NULL
                    );";

            using (MySqlCommand cmd = new MySqlCommand(crearTablaPermiso, conexion)) 
                cmd.ExecuteNonQuery();
            

            // Crear tabla adv__rol_permiso
            string crearTablaRolPermiso = @"
                    CREATE TABLE IF NOT EXISTS adv__rol_permiso (
                        id_rol_permiso INT AUTO_INCREMENT PRIMARY KEY,
                        id_rol_usuario INT NOT NULL,
                        id_permiso INT NOT NULL
                    );";

            using (MySqlCommand cmd = new MySqlCommand(crearTablaRolPermiso, conexion)) 
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

            // Verificar si la columna nivel_acceso existe antes de eliminarla
            string verificarColumna = @"
                    SELECT COUNT(*)
                    FROM information_schema.COLUMNS
                    WHERE TABLE_SCHEMA = DATABASE()
                    AND TABLE_NAME = 'adv__rol_usuario'
                    AND COLUMN_NAME = 'nivel_acceso';";

            using (MySqlCommand cmd = new MySqlCommand(verificarColumna, conexion)) {
                int existeColumna = Convert.ToInt32(cmd.ExecuteScalar());

                if (existeColumna > 0) {
                    // Eliminar la columna nivel_acceso
                    string eliminarColumna = @"
                            ALTER TABLE adv__rol_usuario
                            DROP COLUMN nivel_acceso;";

                    using (MySqlCommand cmdEliminar = new MySqlCommand(eliminarColumna, conexion)) {
                        cmdEliminar.ExecuteNonQuery();
                        Console.Write(" Tablas actualizadas correctamente.\n");
                    }
                } else {
                    Console.Write(" La columna nivel_acceso no existe en la tabla adv__rol_usuario.\n");
                }
            }
        }
    }
}