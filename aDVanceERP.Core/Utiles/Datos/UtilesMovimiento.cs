using aDVanceERP.Core.Excepciones;
using MySql.Data.MySqlClient;

namespace aDVanceERP.Core.Utiles.Datos; 

public static class UtilesMovimiento {
    public static long ObtenerIdTipoMovimiento(string nombreTipoMovimiento) {
        var idModulo = 0;

        using (var conexion = new MySqlConnection(UtilesConfServidores.ObtenerStringConfServidorMySQL())) {
            try {
                conexion.Open();
            }
            catch (Exception) {
                throw new ExcepcionConexionServidorMySQL();
            }

            using (var comando = conexion.CreateCommand()) {
                comando.CommandText =
                    $"SELECT id_tipo_movimiento FROM adv__tipo_movimiento WHERE LOWER(nombre) LIKE LOWER('%{nombreTipoMovimiento}%');";

                using (var lectorDatos = comando.ExecuteReader()) {
                    if (lectorDatos != null && lectorDatos.Read())
                        idModulo = lectorDatos.GetInt32(lectorDatos.GetOrdinal("id_tipo_movimiento"));
                }
            }
        }

        return idModulo;
    }

    public static string? ObtenerNombreTipoMovimiento(long idTipoMovimiento) {
        var nombreTipoMovimiento = string.Empty;

        using (var conexion = new MySqlConnection(UtilesConfServidores.ObtenerStringConfServidorMySQL())) {
            try {
                conexion.Open();
            }
            catch (Exception) {
                throw new ExcepcionConexionServidorMySQL();
            }

            using (var comando = conexion.CreateCommand()) {
                comando.CommandText =
                    $"SELECT nombre FROM adv__tipo_movimiento WHERE id_tipo_movimiento='{idTipoMovimiento}';";

                using (var lectorDatos = comando.ExecuteReader()) {
                    if (lectorDatos != null && lectorDatos.Read())
                        nombreTipoMovimiento = lectorDatos.GetString(lectorDatos.GetOrdinal("nombre"));
                }
            }
        }

        return nombreTipoMovimiento;
    }

    public static string ObtenerEfectoTipoMovimiento(long idTipoMovimiento) {
        var efectoTipoMovimiento = string.Empty;

        using (var conexion = new MySqlConnection(UtilesConfServidores.ObtenerStringConfServidorMySQL())) {
            try {
                conexion.Open();
            }
            catch (Exception) {
                throw new ExcepcionConexionServidorMySQL();
            }

            using (var comando = conexion.CreateCommand()) {
                comando.CommandText =
                    $"SELECT efecto FROM adv__tipo_movimiento WHERE id_tipo_movimiento='{idTipoMovimiento}';";

                using (var lectorDatos = comando.ExecuteReader()) {
                    if (lectorDatos != null && lectorDatos.Read())
                        efectoTipoMovimiento = lectorDatos.GetString(lectorDatos.GetOrdinal("efecto"));
                }
            }
        }

        return efectoTipoMovimiento;
    }

    public static object[] ObtenerNombresTiposMovimientos(string? signo = "") {
        var nombresTiposMovimientos = new List<string>();

        using (var conexion = new MySqlConnection(UtilesConfServidores.ObtenerStringConfServidorMySQL())) {
            try {
                conexion.Open();
            }
            catch (Exception) {
                throw new ExcepcionConexionServidorMySQL();
            }

            using (var comando = conexion.CreateCommand()) {
                comando.CommandText = "SELECT nombre FROM adv__tipo_movimiento" +
                                      $"{(string.IsNullOrEmpty(signo)
                                          ? string.Empty
                                          : signo.Equals("+")
                                              ? " WHERE efecto = 'Carga'"
                                              : " WHERE efecto = 'Descarga'")};";

                using (var lectorDatos = comando.ExecuteReader()) {
                    if (lectorDatos == null)
                        return nombresTiposMovimientos.ToArray();

                    while (lectorDatos.Read())
                        nombresTiposMovimientos.Add(lectorDatos.GetString(lectorDatos.GetOrdinal("nombre")));
                }
            }
        }

        return nombresTiposMovimientos.ToArray();
    }

    public static void ModificarStockProductoAlmacen(long idProducto, long idAlmacenOrigen, long idAlmacenDestino,
        float cantidad) {
        using (var conexion = new MySqlConnection(UtilesConfServidores.ObtenerStringConfServidorMySQL())) {
            try {
                conexion.Open();
            }
            catch (Exception) {
                throw new ExcepcionConexionServidorMySQL();
            }

            using (var transaccion = conexion.BeginTransaction()) {
                using (var comando = conexion.CreateCommand()) {
                    comando.Transaction = transaccion;

                    try {
                        if (idAlmacenOrigen > 0) {
                            // Decrementar stock en el almacén de origen
                            comando.CommandText = """
                                                  UPDATE adv__producto_almacen
                                                  SET stock = stock - @Cantidad
                                                  WHERE id_producto = @IdProducto
                                                    AND id_almacen = @IdAlmacenOrigen;
                                                  """;
                            comando.Parameters.AddWithValue("@Cantidad", cantidad);
                            comando.Parameters.AddWithValue("@IdProducto", idProducto);
                            comando.Parameters.AddWithValue("@IdAlmacenOrigen", idAlmacenOrigen);

                            comando.ExecuteNonQuery();
                            comando.Parameters.Clear();
                        }

                        if (idAlmacenDestino > 0) {
                            // Verificar si el producto ya existe en el almacén de destino
                            comando.CommandText = """
                                                  SELECT COUNT(*)
                                                  FROM adv__producto_almacen
                                                  WHERE id_producto = @IdProducto
                                                    AND id_almacen = @IdAlmacenDestino;
                                                  """;
                            comando.Parameters.AddWithValue("@IdProducto", idProducto);
                            comando.Parameters.AddWithValue("@IdAlmacenDestino", idAlmacenDestino);

                            var count = Convert.ToInt32(comando.ExecuteScalar());
                            comando.Parameters.Clear();

                            // Incrementar stock en el almacén de destino y de ser necesario, insertar nuevo
                            // registro en la tabla `adv__producto_almacen` para el producto en el almacén de destino
                            comando.CommandText = count > 0
                                ? """
                                  UPDATE adv__producto_almacen
                                  SET stock = stock + @Cantidad
                                  WHERE id_producto = @IdProducto
                                    AND id_almacen = @IdAlmacenDestino;
                                  """
                                : """
                                  INSERT INTO adv__producto_almacen (
                                    id_producto,
                                    id_almacen,
                                    stock
                                  )
                                  VALUES (
                                    @IdProducto,
                                    @IdAlmacenDestino,
                                    @Cantidad
                                  );
                                  """;

                            comando.Parameters.AddWithValue("@Cantidad", cantidad);
                            comando.Parameters.AddWithValue("@IdProducto", idProducto);
                            comando.Parameters.AddWithValue("@IdAlmacenDestino", idAlmacenDestino);
                            comando.ExecuteNonQuery();
                        }

                        transaccion.Commit();
                    }
                    catch (Exception) {
                        transaccion.Rollback();
                        throw;
                    }
                }
            }
        }
    }
}