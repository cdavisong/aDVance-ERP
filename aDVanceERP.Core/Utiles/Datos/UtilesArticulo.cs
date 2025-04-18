using aDVanceERP.Core.Excepciones;
using MySql.Data.MySqlClient;

namespace aDVanceERP.Core.Utiles.Datos; 

public static class UtilesArticulo {
    // Método auxiliar para ejecutar consultas y devolver un valor escalar
    private static async Task<T?> EjecutarConsultaEscalar<T>(string query, Func<MySqlDataReader, T> mapper,
        params MySqlParameter[]? parameters) {
        await using (var conexion = new MySqlConnection(UtilesConfServidores.ObtenerStringConfServidorMySQL())) {
            try {
                await conexion.OpenAsync().ConfigureAwait(false);

                await using var comando = new MySqlCommand(query, conexion);

                if (parameters != null && parameters.Length > 0)
                    comando.Parameters.AddRange(parameters);

                await using var lectorDatos = await comando.ExecuteReaderAsync().ConfigureAwait(false);

                if (!await lectorDatos.ReadAsync().ConfigureAwait(false)) 
                    return default;
                
                // Verificar si el valor es DBNull antes de mapear
                return !lectorDatos.IsDBNull(0) ? mapper((MySqlDataReader)lectorDatos) : default;
            } catch (MySqlException) {
                throw new ExcepcionConexionServidorMySQL();
            } catch (Exception ex) {
                throw new Exception("Error inesperado al ejecutar la consulta.", ex);
            }
        }
    }

    // Método auxiliar para ejecutar consultas y devolver una lista
    private static async Task<List<T>> EjecutarConsultaLista<T>(string query, Func<MySqlDataReader, T> mapper,
        params MySqlParameter[]? parameters) {
        var resultados = new List<T>();

        await using (var conexion = new MySqlConnection(UtilesConfServidores.ObtenerStringConfServidorMySQL())) {
            try {
                await conexion.OpenAsync().ConfigureAwait(false);

                await using (var comando = new MySqlCommand(query, conexion)) {
                    if (parameters != null) comando.Parameters.AddRange(parameters);

                    await using (var lectorDatos = await comando.ExecuteReaderAsync().ConfigureAwait(false)) {
                        while (await lectorDatos.ReadAsync().ConfigureAwait(false))
                            if (!lectorDatos.IsDBNull(0))
                                resultados.Add(mapper((MySqlDataReader)lectorDatos));
                    }
                }
            }
            catch (MySqlException) {
                throw new ExcepcionConexionServidorMySQL();
            }
            catch (Exception ex) {
                throw new Exception("Error inesperado al ejecutar la consulta.", ex);
            }
        }

        return resultados;
    }

    public static async Task<long> ObtenerIdArticulo(string nombreArticulo) {
        const string query = """
                             SELECT
                                id_articulo
                             FROM adv__articulo
                             WHERE nombre = @nombreArticulo;
                             """;
        var parametros = new[] {
            new MySqlParameter("@nombreArticulo", nombreArticulo)
        };

        return await EjecutarConsultaEscalar(query, lector => lector.GetInt64("id_articulo"), parametros);
    }

    public static async Task<string?> ObtenerNombreArticulo(long idArticulo) {
        const string query = """
                             SELECT
                                nombre
                             FROM adv__articulo
                             WHERE id_articulo = @idArticulo;
                             """;
        var parametros = new[] {
            new MySqlParameter("@idArticulo", idArticulo)
        };

        return await EjecutarConsultaEscalar(query, lector => lector.GetString(lector.GetOrdinal("nombre")),
            parametros);
    }

    public static async Task<string?> ObtenerNombreArticulo(string codigo) {
        const string query = """
                             SELECT
                                nombre
                             FROM adv__articulo
                             WHERE codigo = @codigo;
                             """;
        var parametros = new[] {
            new MySqlParameter("@codigo", codigo)
        };

        return await EjecutarConsultaEscalar(query, lector => lector.GetString(lector.GetOrdinal("nombre")),
            parametros);
    }

    public static async Task<string[]> ObtenerNombresArticulos() {
        const string query = """
                             SELECT
                                nombre
                             FROM adv__articulo;
                             """;
        var nombres = await EjecutarConsultaLista(query, lector => lector.GetString(lector.GetOrdinal("nombre")));

        return nombres.ToArray();
    }

    public static async Task<string[]> ObtenerNombresArticulos(long idAlmacen) {
        const string query = """
                             SELECT
                                a.nombre
                             FROM adv__articulo a
                             JOIN adv__articulo_almacen aa ON a.id_articulo = aa.id_articulo
                             WHERE aa.id_almacen = @IdAlmacen;
                             """;
        var parametros = new[] {
            new MySqlParameter("@IdAlmacen", idAlmacen)
        };
        var nombres =
            await EjecutarConsultaLista(query, lector => lector.GetString(lector.GetOrdinal("nombre")), parametros);

        return nombres.ToArray();
    }

    public static async Task<int> ObtenerStockTotalArticulos() {
        const string query = """
                             SELECT
                                SUM(aa.stock) AS total_articulos
                             FROM adv__articulo_almacen aa
                             JOIN adv__articulo a ON aa.id_articulo = a.id_articulo;
                             """;

        return await EjecutarConsultaEscalar(query, lector => lector.GetInt32(lector.GetOrdinal("total_articulos")));
    }

    public static async Task<int> ObtenerStockTotalArticulo(long idArticulo) {
        // Usamos COALESCE para devolver 0 si SUM(stock) es NULL
        const string query = """
                             SELECT
                                COALESCE(SUM(stock), 0) as stock_total
                             FROM adv__articulo_almacen
                             WHERE id_articulo = @IdArticulo;
                             """;
        var parametros = new[] {
            new MySqlParameter("@IdArticulo", idArticulo)
        };

        return await EjecutarConsultaEscalar(query, lector => lector.GetInt32(lector.GetOrdinal("stock_total")),
            parametros);
    }

    public static async Task<int> ObtenerStockArticulo(string nombreArticulo, string? nombreAlmacen) {
        const string query = """
                             SELECT
                                 aa.stock
                             FROM adv__articulo_almacen aa
                             JOIN adv__articulo ar ON aa.id_articulo = ar.id_articulo
                             JOIN adv__almacen al ON aa.id_almacen = al.id_almacen
                             WHERE ar.nombre = @NombreArticulo AND al.nombre = @NombreAlmacen;
                             """;
        var parametros = new[] {
            new MySqlParameter("@NombreArticulo", nombreArticulo),
            new MySqlParameter("@NombreAlmacen", nombreAlmacen)
        };

        return await EjecutarConsultaEscalar(query, lector => lector.GetInt32(lector.GetOrdinal("stock")), parametros);
    }

    public static async Task<decimal> ObtenerPrecioVentaBase(long idArticulo) {
        const string query = """
                             SELECT precio_venta_base
                             FROM adv__articulo
                             WHERE id_articulo = @IdArticulo;
                             """;
        var parametros = new[] {
            new MySqlParameter("@IdArticulo", idArticulo)
        };

        return await EjecutarConsultaEscalar(query, lector => lector.GetDecimal(lector.GetOrdinal("precio_venta_base")),
            parametros);
    }

    public static bool ActualizarPrecioVentaBase(long idArticulo, decimal nuevoPrecioVenta) {
        const string queryVerificar = """
                                      SELECT precio_venta_base
                                      FROM adv__articulo
                                      WHERE id_articulo = @IdArticulo;
                                      """;

        const string queryActualizar = """
                                       UPDATE adv__articulo
                                       SET precio_venta_base = @PrecioVenta
                                       WHERE id_articulo = @IdArticulo;
                                       """;

        var parametros = new[] {
            new MySqlParameter("@IdArticulo", idArticulo),
            new MySqlParameter("@PrecioVenta", nuevoPrecioVenta)
        };

        try {
            using (var conexion = new MySqlConnection(UtilesConfServidores.ObtenerStringConfServidorMySQL())) {
                conexion.Open();

                // Primero verificar el precio actual
                decimal precioActual;
                using (var comandoVerificar = new MySqlCommand(queryVerificar, conexion)) {
                    comandoVerificar.Parameters.Add(parametros[0]);
                    precioActual = Convert.ToDecimal(comandoVerificar.ExecuteScalar());
                }

                // Solo actualizar si es diferente
                if (precioActual == nuevoPrecioVenta)
                    return false; // No se actualizó porque el precio es igual

                using (var comandoActualizar = new MySqlCommand(queryActualizar, conexion)) {
                    comandoActualizar.Parameters.AddRange(parametros);
                    return comandoActualizar.ExecuteNonQuery() > 0;
                }
            }
        }
        catch {
            return false;
        }
    }

    public static async Task<decimal> ObtenerPrecioCompraBase(long idArticulo) {
        const string query = """
                             SELECT precio_compra_base
                             FROM adv__articulo
                             WHERE id_articulo = @IdArticulo;
                             """;
        var parametros = new[] {
            new MySqlParameter("@IdArticulo", idArticulo)
        };

        return await EjecutarConsultaEscalar(query,
            lector => lector.GetDecimal(lector.GetOrdinal("precio_compra_base")), parametros);
    }

    public static bool ActualizarPrecioCompraBase(long idArticulo, decimal nuevoPrecioCompra) {
        const string queryVerificar = """
                                      SELECT precio_compra_base
                                      FROM adv__articulo
                                      WHERE id_articulo = @IdArticulo;
                                      """;

        const string queryActualizar = """
                                       UPDATE adv__articulo
                                       SET precio_compra_base = @PrecioCompra
                                       WHERE id_articulo = @IdArticulo;
                                       """;

        var parametros = new[] {
            new MySqlParameter("@IdArticulo", idArticulo),
            new MySqlParameter("@PrecioCompra", nuevoPrecioCompra)
        };

        try {
            using (var conexion = new MySqlConnection(UtilesConfServidores.ObtenerStringConfServidorMySQL())) {
                conexion.Open();

                // Verificar el precio actual
                decimal precioActual;
                using (var comandoVerificar = new MySqlCommand(queryVerificar, conexion)) {
                    comandoVerificar.Parameters.Add(parametros[0]);
                    precioActual = Convert.ToDecimal(comandoVerificar.ExecuteScalar());
                }

                // Solo actualizar si es diferente
                if (precioActual == nuevoPrecioCompra)
                    return false; // No se actualizó porque el precio es igual

                using (var comandoActualizar = new MySqlCommand(queryActualizar, conexion)) {
                    comandoActualizar.Parameters.AddRange(parametros);
                    return comandoActualizar.ExecuteNonQuery() > 0;
                }
            }
        }
        catch {
            return false;
        }
    }

    public static async Task<decimal> ObtenerMontoInvertidoEnArticulos(long idAlmacen = 0) {
        var query = $"""
                     SELECT
                        SUM(dca.precio_compra * dca.cantidad) AS monto_invertido
                     FROM adv__detalle_compra_articulo dca
                     JOIN adv__compra c ON dca.id_compra = c.id_compra
                     {(idAlmacen != 0 ? "WHERE c.id_almacen = @IdAlmacen" : "")};
                     """;
        var parametros = idAlmacen != 0 ? new[] { new MySqlParameter("@IdAlmacen", idAlmacen) } : null;

        return await EjecutarConsultaEscalar(query,
            lector => lector.IsDBNull(lector.GetOrdinal("monto_invertido"))
                ? 0
                : lector.GetDecimal(lector.GetOrdinal("monto_invertido")), parametros);
    }

    public static async Task<bool> PuedeEliminarArticulo(long idArticulo) {
        const string queryVentas = """
                                   SELECT
                                    COUNT(*)
                                   FROM adv__detalle_venta_articulo
                                   WHERE id_articulo = @IdArticulo;
                                   """;
        const string queryMovimientos = """
                                        SELECT
                                            COUNT(*)
                                        FROM adv__movimiento
                                        WHERE id_articulo = @IdArticulo;
                                        """;
        var parametros = new[] {
            new MySqlParameter("@IdArticulo", idArticulo)
        };
        var cantidadVentas = await EjecutarConsultaEscalar(queryVentas, lector => lector.GetInt32(0), parametros);
        var cantidadMovimientos =
            await EjecutarConsultaEscalar(queryMovimientos, lector => lector.GetInt32(0), parametros);

        return cantidadVentas == 0 && cantidadMovimientos == 0;
    }
}