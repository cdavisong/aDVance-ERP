using System.Diagnostics;

using aDVanceERP.Core.Excepciones;
using aDVanceERP.Core.Infraestructura.Extensiones;
using aDVanceERP.Core.Infraestructura.Globales;
using aDVanceERP.Core.Utiles;
using aDVanceERP.Desktop.MVP.Presentadores.Principal;

using MySql.Data.MySqlClient;

namespace aDVanceERP.Desktop;

internal static class Program {
    private static string CurrentDbVersion = "";

    /// <summary>
    ///     The main entry point for the application.
    /// </summary>
    [STAThread]
    private static void Main() {
        // Configuración de la aplicación
        ApplicationConfiguration.Initialize();
        Application.Run((Form) new PresentadorPrincipal().Vista);
    }

    private static void EjecutarParcheBD() {
        try {
            // Verificar si el patch ya fue aplicado
            using (var conexion = new MySqlConnection(ContextoBaseDatos.Configuracion.ToStringConexion())) {
                if (conexion.State != System.Data.ConnectionState.Open) if (conexion.State != System.Data.ConnectionState.Open) conexion.Open();

                // Crear tabla de control de versiones si no existe
                const string createVersionTable = @"
                    CREATE TABLE IF NOT EXISTS adv__db_version (
                        version VARCHAR(20) PRIMARY KEY,
                        applied_date DATETIME NOT NULL,
                        patch_name VARCHAR(100)
                    );";

                using (var cmd = new MySqlCommand(createVersionTable, conexion)) {
                    cmd.ExecuteNonQuery();
                }

                if (File.Exists(@".\app.ver"))
                    using (var fs = new FileStream(@".\app.ver", FileMode.Open)) {
                        using (var sr = new StreamReader(fs)) {
                            CurrentDbVersion = sr.ReadToEnd().Trim();
                        }
                    }

                // Verificar si la versión actual ya está registrada
                const string checkVersion = "SELECT COUNT(*) FROM adv__db_version WHERE version = @version";
                using (var cmd = new MySqlCommand(checkVersion, conexion)) {
                    cmd.Parameters.AddWithValue("@version", CurrentDbVersion);
                    var exists = Convert.ToInt32(cmd.ExecuteScalar()) > 0;

                    if (exists) return; // El patch ya fue aplicado
                }
            }

            // Si llegamos aquí, necesitamos ejecutar el patch
            EjecutarParche();
        } catch (MySqlException ex) {
            MessageBox.Show($"No se pudo aplicar el parche de la Base de datos. {ex.Message}",
                @"Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    private static void EjecutarParche() {
        try {
            var patchProcess = new Process {
                StartInfo = new ProcessStartInfo {
                    FileName = "aDVanceERP.PatchDB.exe",
                    UseShellExecute = false,
                    CreateNoWindow = false
                }
            };

            patchProcess.Start();
            patchProcess.WaitForExit();

            using (var conexion = new MySqlConnection(ContextoBaseDatos.Configuracion.ToStringConexion())) {
                if (conexion.State != System.Data.ConnectionState.Open) if (conexion.State != System.Data.ConnectionState.Open) conexion.Open();

                // Registrar la versión aplicada
                const string registerVersion = @"
                    INSERT INTO adv__db_version (version, applied_date, patch_name)
                    VALUES (@version, NOW(), 'Órdenes de producción y reportes de inventario. Fase BETA de la aplicación')";

                using (var cmd = new MySqlCommand(registerVersion, conexion)) {
                    cmd.Parameters.AddWithValue("@version", CurrentDbVersion);
                    cmd.ExecuteNonQuery();
                }
            }
        } catch (Exception ex) {
            MessageBox.Show($@"Error al ejecutar el patch: {ex.Message}",
                @"Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}