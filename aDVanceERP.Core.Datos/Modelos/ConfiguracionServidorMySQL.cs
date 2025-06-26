using aDVanceERP.Core.Datos.Interfaces;

namespace aDVanceERP.Core.Datos.Modelos; 

public class ConfiguracionServidorMySQL {
    public ConfiguracionServidorMySQL() {
        Servidor = "127.0.0.1";
        BaseDatos = "advanceerp";
        Usuario = "admin";
        Password = "admin";
    }

    public ConfiguracionServidorMySQL(string servidor, string baseDatos, string usuario, string password) {
        Servidor = servidor;
        BaseDatos = baseDatos;
        Usuario = usuario;
        Password = password;
    }

    public string Servidor { get; set; }

    public string BaseDatos { get; set; }

    public string Usuario { get; set; }

    public string Password { get; set; }

    public override string ToString() {
        return $"Server={Servidor};Database={BaseDatos};User Id={Usuario};Password={Password};pooling=true;Min Pool Size=5;Max Pool Size=100;Connection Timeout=30;";
    }
}