using aDVanceERP.Core.Modelos.BD;

namespace aDVanceERP.Core.Infraestructura.Extensiones {
    public static class ConfServidorMySQLExtension {
        public static string ToStringConexion(this ConfServidorMySQL conf) {
            if (conf == null) {
                throw new ArgumentNullException(nameof(conf), "La configuración del servidor MySQL no puede ser nula.");
            }
            if (string.IsNullOrWhiteSpace(conf.Servidor)) {
                throw new ArgumentException("El nombre o dirección del servidor no puede estar vacío.", nameof(conf.Servidor));
            }
            if (string.IsNullOrWhiteSpace(conf.BaseDatos)) {
                throw new ArgumentException("El nombre de la base de datos no puede estar vacío.", nameof(conf.BaseDatos));
            }
            if (string.IsNullOrWhiteSpace(conf.Usuario)) {
                throw new ArgumentException("El nombre de usuario no puede estar vacío.", nameof(conf.Usuario));
            }
            // Password can be empty, depending on the server configuration
            return $"Server={conf.Servidor};Database={conf.BaseDatos};User ID={conf.Usuario};Password={conf.Password};Pooling=false;Min Pool Size=0;Max Pool Size=100;Connection Timeout=30;";
        }
    }
}