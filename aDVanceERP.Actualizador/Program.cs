using aDVanceERP.Actualizador.Interfaces;
using aDVanceERP.Actualizador.Modelos;
using aDVanceERP.Actualizador.Servicios;
using aDVanceERP.Actualizador.Vistas;

namespace aDVanceERP.Actualizador {
    internal static class Program {
        static IServicioActualizacion _updateService;
        static string _currentVersion = "0.0.0.0";

        const string PropietarioRepositorio = "cdavisong";
        const string NombreRepositorio = "aDVance-ERP";

        static void ShowUpdateDialog(InfoActualizacion updateInfo) {
            ApplicationConfiguration.Initialize();
            Application.Run(new VistaNotificadorActualizacion(_updateService, updateInfo));
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
                        _currentVersion = sr.ReadToEnd().Trim();
                    }
                }

            // Inicializacion
            _updateService = new ServicioActualizacionGitHub(PropietarioRepositorio, NombreRepositorio);

            try {
                var updateInfo = _updateService.ComprobarActualizaciones(_currentVersion, true).Result;

                if (updateInfo.ActualizacionDisponible) {
                    ShowUpdateDialog(updateInfo);
                } 
            } catch (Exception) { }
        }
    }
}