using aDVanceERP.Desktop.MVP.Presentadores.Principal;

namespace aDVanceERP.Desktop;

internal static class Program {
    public static string Version = "0.4.0.0";
    public static string NombreVersion = $"aDVance ERP patch versi�n {Version}";

    /// <summary>
    ///     The main entry point for the application.
    /// </summary>
    [STAThread]
    private static void Main() {
        // Configuraci�n de la aplicaci�n
        ApplicationConfiguration.Initialize();
        Application.Run((Form) new PresentadorPrincipal().Vista);
    }
}