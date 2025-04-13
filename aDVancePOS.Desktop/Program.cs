using aDVancePOS.Desktop.MVP.Presentadores.Principal;

namespace aDVancePOS.Desktop {
    internal static class Program {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main() {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            Application.Run((Form) new PresentadorPrincipal().Vista);
        }
    }
}