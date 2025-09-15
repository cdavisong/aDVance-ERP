using aDVanceERP.Actualizador.Interfaces;
using aDVanceERP.Actualizador.Modelos;
using aDVanceERP.Actualizador.Servicios;
using aDVanceERP.Actualizador.Vistas;

namespace aDVanceERP.Actualizador {
    internal static class Program {
        public static string CurrentVersion = "0.0.0.1";
        static IServicioActualizacion? _updateService;        

        const string PropietarioRepositorio = "cdavisong";
        const string NombreRepositorio = "aDVance-ERP";

        static void ShowUpdateDialog(InfoActualizacion updateInfo) {
            ApplicationConfiguration.Initialize();
            Application.Run(new VistaNotificadorActualizacion(_updateService, updateInfo));
        }

        static void ShowUpdateDialog(string message) {
            ApplicationConfiguration.Initialize();
            Application.Run(new VistaNotificadorActualizacion(message));
        }

        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main() {
            // Carga de la versión
            if (File.Exists(@".\app.ver"))
                using (var fs = new FileStream(@".\app.ver", FileMode.Open)) {
                    using (var sr = new StreamReader(fs)) {
                        CurrentVersion = sr.ReadToEnd().Trim();
                    }
                }

            // Inicializacion
            _updateService = new ServicioActualizacionGitHub(PropietarioRepositorio, NombreRepositorio);

            try {
                var updateInfo = _updateService.ComprobarActualizaciones(CurrentVersion, true).Result;

                if (updateInfo.ActualizacionDisponible)
                    ShowUpdateDialog(updateInfo);
                else ShowUpdateDialog("no-actualizaciones");
            } catch (Exception ex) {
                ShowUpdateDialog($"no-conexion|{ex.Message}");
            }
        }
    }
}