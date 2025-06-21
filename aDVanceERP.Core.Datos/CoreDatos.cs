using aDVanceERP.Core.Datos.Modelos;

namespace aDVanceERP.Core.Datos;

public static class CoreDatos {
    public static string Version => "0.4.0.0";
    public static string VersionBd => "0.4.0.0";
    public static string Nombre => "aDVanceERP.Core.Datos";
    public static string Descripcion => "Biblioteca de acceso a datos para aDVanceERP.";
    public static string Autor => "aDVanceERP Team";
    public static string Licencia => "GNU General Public License v3.0";

    #region Configuración de la conexión con la base de datos

    public static ConfiguracionServidorMySQL ConfServidorMySQL = new();
    public static bool ConfiguracionServidorMySQLCargada = false;

    public static ConfiguracionServidorMySQL CargarArchivoConfiguracionServidorMySQL() {
        var ruta = @".\settings\mysqlsrv.config";
        
        if (!File.Exists(ruta)) {
            Directory.CreateDirectory(@".\settings");
            File.WriteAllText(ruta, $"{ConfServidorMySQL.Servidor};{ConfServidorMySQL.BaseDatos};{ConfServidorMySQL.Usuario};{ConfServidorMySQL.Password}");
        }

        var datos = File.ReadAllText(ruta);
        var partes = datos.Split(';');

        if (partes.Length < 4)
            throw new InvalidOperationException("El archivo de configuración del servidor MySQL no contiene los datos necesarios.");
        
        var configuracion = new ConfiguracionServidorMySQL(partes[0], partes[1], partes[2], partes[3]);
        ConfiguracionServidorMySQLCargada = true;

        return configuracion;
    }

    public static void GuardarArchivoConfiguracionServidorMySQL(ConfiguracionServidorMySQL configuracion) {
        var ruta = @".\settings\mysqlsrv.config";

        Directory.CreateDirectory(@".\settings");
        File.WriteAllText(ruta, $"{ConfServidorMySQL.Servidor};{ConfServidorMySQL.BaseDatos};{ConfServidorMySQL.Usuario};{ConfServidorMySQL.Password}");

        ConfiguracionServidorMySQLCargada = false;
    }

    #endregion
}