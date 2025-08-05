using aDVanceERP.Core.Modelos.Comun;

namespace aDVanceERP.Core.Controladores.Comun;

public static class ConexionServidorMySQL {
    static ConexionServidorMySQL() {
        ConfServidorMySQL = CargarArchivoConfiguracionServidorMySQL() ?? new();
    }

    public static ConfiguracionServidorMySQL ConfServidorMySQL { get; }
    public static bool ConfiguracionServidorMySQLCargada = false;

    public static ConfiguracionServidorMySQL CargarArchivoConfiguracionServidorMySQL() {
        var ruta = @".\settings\mysqlsrv.config";

        if (!File.Exists(ruta)) {
            Directory.CreateDirectory(@".\settings");
            File.WriteAllText(ruta, "127.0.0.1;advanceerp;admin;admin");
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
}
