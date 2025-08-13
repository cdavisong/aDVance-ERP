using aDVanceERP.Core.Infraestructura.Extensiones;
using aDVanceERP.Core.Modelos.BD;

using MySql.Data.MySqlClient;

namespace aDVanceERP.Core.Infraestructura.Globales;

public static class ContextoBaseDatos {
    static ContextoBaseDatos() {
        Configuracion = ConfiguracionBaseDatos.Default;
        EsConfiguracionCargada = false;
    }

    public static ConfiguracionBaseDatos Configuracion { get; }

    public static bool EsConfiguracionCargada { get; set; }

    public static void ActualizarConfiguracion(ConfiguracionBaseDatos configuracion) {
        if (configuracion == null) {
            throw new ArgumentNullException(nameof(configuracion), "La configuración de la base de datos no puede ser nula.");
        }
        if (string.IsNullOrWhiteSpace(configuracion.Servidor)) {
            throw new ArgumentException("El servidor de la base de datos no puede estar vacío.", nameof(configuracion.Servidor));
        }
        if (string.IsNullOrWhiteSpace(configuracion.BaseDatos)) {
            throw new ArgumentException("El nombre de la base de datos no puede estar vacío.", nameof(configuracion.BaseDatos));
        }
        if (string.IsNullOrWhiteSpace(configuracion.Usuario)) {
            throw new ArgumentException("El usuario de la base de datos no puede estar vacío.", nameof(configuracion.Usuario));
        }
        if (configuracion.RecordarConfiguracion && string.IsNullOrWhiteSpace(configuracion.Password)) {
            throw new ArgumentException("La contraseña de la base de datos no puede estar vacía si se recuerda la configuración.", nameof(configuracion.Password));
        }

        Configuracion.Servidor = configuracion.Servidor;
        Configuracion.BaseDatos = configuracion.BaseDatos;
        Configuracion.Usuario = configuracion.Usuario;
        Configuracion.Password = configuracion.Password;
        Configuracion.RecordarConfiguracion = configuracion.RecordarConfiguracion;

        // Crear una nueva conexión para verificar que la configuración es válida:
        using (var connection = new MySqlConnection(Configuracion.ToStringConexion())) {
            try {
                connection.Open();
                // Si la conexión se abre correctamente, la configuración es válida.
            } catch (MySqlException ex) {
                throw new InvalidOperationException("Error al conectar a la base de datos con la nueva configuración.", ex);
            }
        }

        EsConfiguracionCargada = true;
    }
}