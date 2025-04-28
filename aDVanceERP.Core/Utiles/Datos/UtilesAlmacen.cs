using aDVanceERP.Core.Excepciones;
using MySql.Data.MySqlClient;

namespace aDVanceERP.Core.Utiles.Datos; 

public static class UtilesAlmacen {
    private static async Task<T?> EjecutarConsultaAsync<T>(string query, Func<MySqlDataReader, T> procesarResultado, params MySqlParameter[] parametros) {
        using var conexion = new MySqlConnection(UtilesConfServidores.ObtenerStringConfServidorMySQL());
        try {
            await conexion.OpenAsync().ConfigureAwait(false);
        } catch (MySqlException) {
            throw new ExcepcionConexionServidorMySQL();
        }

        using var comando = new MySqlCommand(query, conexion);
        comando.Parameters.AddRange(parametros);

        using var lectorDatos = await comando.ExecuteReaderAsync().ConfigureAwait(false);
        return lectorDatos != null && await lectorDatos.ReadAsync().ConfigureAwait(false)
            ? procesarResultado((MySqlDataReader) lectorDatos)
            : default;
    }

    private static T? EjecutarConsulta<T>(string query, Func<MySqlDataReader, T> procesarResultado, params MySqlParameter[] parametros) {
        using var conexion = new MySqlConnection(UtilesConfServidores.ObtenerStringConfServidorMySQL());
        try {
            conexion.Open();
        } catch (MySqlException) {
            throw new ExcepcionConexionServidorMySQL();
        }

        using var comando = new MySqlCommand(query, conexion);
        comando.Parameters.AddRange(parametros);

        using var lectorDatos = comando.ExecuteReader();
        return lectorDatos != null && lectorDatos.Read()
            ? procesarResultado(lectorDatos)
            : default;
    }

    public static async Task<long> ObtenerIdAlmacen(string? nombreAlmacen) {
        const string query = "SELECT id_almacen FROM adv__almacen WHERE LOWER(nombre) LIKE LOWER(@NombreAlmacen);";
        var result = await EjecutarConsultaAsync(query, lector => lector.GetInt32("id_almacen"),
            new MySqlParameter("@NombreAlmacen", $"%{nombreAlmacen}%"));
        return result != 0 ? result : 0;
    }

    public static string? ObtenerNombreAlmacen(long idAlmacen) {
        const string query = "SELECT nombre FROM adv__almacen WHERE id_almacen = @IdAlmacen;";
        return EjecutarConsulta(query, lector => lector.GetString("nombre"),
            new MySqlParameter("@IdAlmacen", idAlmacen));
    }

    public static object[] ObtenerNombresAlmacenes(bool autorizoVenta = false) {
        var query = autorizoVenta
            ? "SELECT nombre FROM adv__almacen WHERE autorizo_venta = 1;"
            : "SELECT nombre FROM adv__almacen;";
        return EjecutarConsulta(query, lector => {
            var nombres = new List<string>();
            do {
                nombres.Add(lector.GetString("nombre"));
            } while (lector.Read());
            return nombres.ToArray();
        }) ?? Array.Empty<object>();
    }
}
