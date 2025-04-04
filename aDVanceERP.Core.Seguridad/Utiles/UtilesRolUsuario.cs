using aDVanceERP.Core.Excepciones;
using aDVanceERP.Core.Utiles;
using MySql.Data.MySqlClient;

namespace aDVanceERP.Core.Seguridad.Utiles; 

public static class UtilesRolUsuario {
    private static readonly Dictionary<long, string[]> _cachePermisosRol = new();

    public static async Task<long> ObtenerIdRolUsuario(string nombreRolUsuario) {
        var idRolUsuario = 0;

        using (var conexion = new MySqlConnection(UtilesConfServidores.ObtenerStringConfServidorMySQL())) {
            try {
                await conexion.OpenAsync().ConfigureAwait(false);
            }
            catch (Exception) {
                throw new ExcepcionConexionServidorMySQL();
            }

            using (var comando = conexion.CreateCommand()) {
                comando.CommandText = $"SELECT id_rol_usuario FROM adv__rol_usuario WHERE nombre='{nombreRolUsuario}';";

                using (var lectorDatos = await comando.ExecuteReaderAsync().ConfigureAwait(false)) {
                    if (lectorDatos != null && await lectorDatos.ReadAsync().ConfigureAwait(false))
                        idRolUsuario = lectorDatos.GetInt32(lectorDatos.GetOrdinal("id_rol_usuario"));
                }
            }
        }

        return idRolUsuario;
    }

    public static string? ObtenerNombreRolUsuario(long idRolUsuario) {
        var nombreRolUsuario = string.Empty;

        using (var conexion = new MySqlConnection(UtilesConfServidores.ObtenerStringConfServidorMySQL())) {
            try {
                conexion.Open();
            }
            catch (Exception) {
                throw new ExcepcionConexionServidorMySQL();
            }

            using (var comando = conexion.CreateCommand()) {
                comando.CommandText = $"SELECT nombre FROM adv__rol_usuario WHERE id_rol_usuario='{idRolUsuario}';";

                using (var lectorDatos = comando.ExecuteReader()) {
                    if (lectorDatos != null && lectorDatos.Read())
                        nombreRolUsuario = lectorDatos.GetString(lectorDatos.GetOrdinal("nombre"));
                }
            }
        }

        return nombreRolUsuario;
    }

    public static string[] ObtenerNombresRolesUsuarios() {
        var nombresRolesUsuarios = new List<string>();

        using (var conexion = new MySqlConnection(UtilesConfServidores.ObtenerStringConfServidorMySQL())) {
            try {
                conexion.Open();
            }
            catch (Exception) {
                throw new ExcepcionConexionServidorMySQL();
            }

            using (var comando = conexion.CreateCommand()) {
                comando.CommandText = "SELECT nombre FROM adv__rol_usuario;";

                using (var lectorDatos = comando.ExecuteReader()) {
                    if (lectorDatos != null)
                        while (lectorDatos.Read())
                            nombresRolesUsuarios.Add(lectorDatos.GetString(lectorDatos.GetOrdinal("nombre")));
                }
            }
        }

        return nombresRolesUsuarios.ToArray();
    }

    public static uint CantidadUsuariosNombreRol(string nombreRol) {
        uint longitud = 0;

        using (var conexion = new MySqlConnection(UtilesConfServidores.ObtenerStringConfServidorMySQL())) {
            try {
                conexion.Open();
            }
            catch (Exception) {
                throw new ExcepcionConexionServidorMySQL();
            }

            using (var comando = conexion.CreateCommand()) {
                comando.CommandText = $@"
                        SELECT COUNT(cu.id_cuenta_usuario) AS cant_usuarios_rol
                        FROM adv__cuenta_usuario cu 
                        JOIN adv__rol_usuario ru ON cu.id_rol_usuario = ru.id_rol_usuario 
                        WHERE ru.nombre = '{nombreRol}';";

                using (var lectorDatos = comando.ExecuteReader()) {
                    if (lectorDatos != null && lectorDatos.Read())
                        longitud = lectorDatos.GetUInt32(lectorDatos.GetOrdinal("cant_usuarios_rol"));
                }
            }
        }

        return longitud;
    }

    public static uint CantidadPermisosRol(long idRolUsuario) {
        uint cantidadPermisos = 0;

        using (var conexion = new MySqlConnection(UtilesConfServidores.ObtenerStringConfServidorMySQL())) {
            try {
                conexion.Open();
            }
            catch (Exception) {
                throw new ExcepcionConexionServidorMySQL();
            }

            using (var comando = conexion.CreateCommand()) {
                comando.CommandText = @"
                        SELECT COUNT(id_permiso) AS cant_permisos 
                        FROM adv__rol_permiso 
                        WHERE id_rol_usuario = @idRolUsuario;";

                comando.Parameters.AddWithValue("@idRolUsuario", idRolUsuario);

                using (var lectorDatos = comando.ExecuteReader()) {
                    if (lectorDatos != null && lectorDatos.Read())
                        cantidadPermisos = lectorDatos.GetUInt32(lectorDatos.GetOrdinal("cant_permisos"));
                }
            }
        }

        return cantidadPermisos;
    }

    public static async Task<int> VerificarOCrearRolAdministrador() {
        var rolId = 0;

        using (var conexion = new MySqlConnection(UtilesConfServidores.ObtenerStringConfServidorMySQL())) {
            try {
                conexion.Open();
            }
            catch (Exception) {
                throw new ExcepcionConexionServidorMySQL();
            }

            using (var comando =
                   new MySqlCommand("SELECT id_rol_usuario FROM adv__rol_usuario WHERE nombre = 'Administrador'",
                       conexion)) {
                rolId = Convert.ToInt32(await comando.ExecuteScalarAsync());
            }

            if (rolId == 0)
                using (var comando =
                       new MySqlCommand(
                           "INSERT INTO adv__rol_usuario (nombre, nivel_acceso) VALUES (@nombre, @nivelAcceso); SELECT LAST_INSERT_ID();",
                           conexion)) {
                    comando.Parameters.AddWithValue("@nombre", "Administrador");
                    comando.Parameters.AddWithValue("@nivelAcceso", 100);
                    rolId = Convert.ToInt32(await comando.ExecuteScalarAsync());
                }
        }

        return rolId;
    }

    public static string[] ObtenerPermisosDeRol(long idRolUsuario) {
        if (_cachePermisosRol.TryGetValue(idRolUsuario, out var permisosCache)) return permisosCache;

        var permisos = ObtenerPermisosDesdeBD(idRolUsuario);

        _cachePermisosRol[idRolUsuario] = permisos;

        return permisos;
    }

    private static string[] ObtenerPermisosDesdeBD(long idRolUsuario) {
        var permisos = new List<string>();

        using (var conexion = new MySqlConnection(UtilesConfServidores.ObtenerStringConfServidorMySQL())) {
            try {
                conexion.Open();
            }
            catch (Exception) {
                throw new ExcepcionConexionServidorMySQL();
            }

            using (var comando = conexion.CreateCommand()) {
                comando.CommandText = @"
                        SELECT p.nombre
                        FROM adv__rol_permiso rp
                        JOIN adv__permiso p ON rp.id_permiso = p.id_permiso
                        WHERE rp.id_rol_usuario = @idRolUsuario;";

                comando.Parameters.AddWithValue("@idRolUsuario", idRolUsuario);

                using (var lector = comando.ExecuteReader()) {
                    while (lector.Read()) permisos.Add(lector.GetString("nombre"));
                }
            }
        }

        return permisos.ToArray();
    }

    public static void LimpiarCacheRol() {
        _cachePermisosRol.Clear();
    }
}