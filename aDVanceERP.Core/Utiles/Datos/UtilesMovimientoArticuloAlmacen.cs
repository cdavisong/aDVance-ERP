using aDVanceERP.Core.Excepciones;

using MySql.Data.MySqlClient;

namespace aDVanceERP.Core.Utiles.Datos {
    public static class UtilesMovimientoArticuloAlmacen {
        public static string[] MotivoMovimientoPositivo = new[] {
            "Compra",
            "Devolución",
            "Rectificación (+)" // Rectificación (+)
        };

        public static string[] MotivoMovimientoNegativo = new[] {
            "Venta",
            "Donación",
            "Uso interno",
            "Caducidad",
            "Rectificación (-)" // Rectificación (-)
        };

        public static void ModificarStockArticuloAlmacen(long idArticulo, long idAlmacenOrigen, long idAlmacenDestino, int cantidad) {
            using (var conexion = new MySqlConnection(UtilesConfServidores.ObtenerStringConfServidorMySQL())) {
                try {
                    conexion.Open();
                } catch (Exception) {
                    throw new ExcepcionConexionServidorMySQL();
                }

                using (var transaccion = conexion.BeginTransaction()) {
                    using (var comando = conexion.CreateCommand()) {
                        comando.Transaction = transaccion;

                        try {
                            if (idAlmacenOrigen > 0) {
                                // Decrementar stock en el almacén de origen
                                comando.CommandText = "UPDATE adv__articulo_almacen SET stock = stock - @Cantidad WHERE id_articulo = @IdArticulo AND id_almacen = @IdAlmacenOrigen;";
                                comando.Parameters.AddWithValue("@Cantidad", cantidad);
                                comando.Parameters.AddWithValue("@IdArticulo", idArticulo);
                                comando.Parameters.AddWithValue("@IdAlmacenOrigen", idAlmacenOrigen);

                                comando.ExecuteNonQuery();
                                comando.Parameters.Clear();
                            }

                            if (idAlmacenDestino > 0) {
                                // Verificar si el artículo ya existe en el almacén de destino
                                comando.CommandText = "SELECT COUNT(*) FROM adv__articulo_almacen WHERE id_articulo = @IdArticulo AND id_almacen = @IdAlmacenDestino;";
                                comando.Parameters.AddWithValue("@IdArticulo", idArticulo);
                                comando.Parameters.AddWithValue("@IdAlmacenDestino", idAlmacenDestino);

                                int count = Convert.ToInt32(comando.ExecuteScalar());
                                comando.Parameters.Clear();

                                if (count > 0) {
                                    // Incrementar stock en el almacén de destino
                                    comando.CommandText = "UPDATE adv__articulo_almacen SET stock = stock + @Cantidad WHERE id_articulo = @IdArticulo AND id_almacen = @IdAlmacenDestino;";
                                } else {
                                    // Insertar nuevo registro en la tabla `adv__articulo_almacen` para el artículo en el almacén de destino
                                    comando.CommandText = "INSERT INTO adv__articulo_almacen (id_articulo, id_almacen, stock) VALUES (@IdArticulo, @IdAlmacenDestino, @Cantidad);";
                                }

                                comando.Parameters.AddWithValue("@Cantidad", cantidad);
                                comando.Parameters.AddWithValue("@IdArticulo", idArticulo);
                                comando.Parameters.AddWithValue("@IdAlmacenDestino", idAlmacenDestino);
                                comando.ExecuteNonQuery();
                            }

                            transaccion.Commit();
                        } catch (Exception) {
                            transaccion.Rollback();
                            throw;
                        }
                    }
                }
            }
        }
    }
}
