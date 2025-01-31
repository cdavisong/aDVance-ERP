using Manigest.Core.Excepciones;
using Manigest.Core.Utiles;
using Manigest.Modulos.Contactos.MVP.Modelos.Repositorios.Plantillas;

using MySql.Data.MySqlClient;

namespace Manigest.Modulos.Contactos.MVP.Modelos.Repositorios {
    public class DatosProveedor : IRepositorioProveedor {
        public static DatosProveedor Instance { get; } = new();

        public DatosProveedor() {
            Objetos = new List<Proveedor>();
        }

        public List<Proveedor> Objetos { get; }

        public long Cantidad() {
            long Cantidad = 0;

            using (var conexion = new MySqlConnection(UtilesConfServidores.ObtenerStringConfServidorMySQL())) {
                try {
                    conexion.Open();
                } catch (Exception) {
                    throw new ExcepcionConexionServidorMySQL();
                }

                using (var comando = conexion.CreateCommand()) {
                    comando.CommandText = "SELECT COUNT(id_proveedor) FROM mg__proveedor;";

                    using (var lectorDatos = comando.ExecuteReader())
                        if (lectorDatos != null && lectorDatos.Read())
                            Cantidad = lectorDatos.GetUInt32(0);
                }
            }

            return Cantidad;
        }

        public long Adicionar(Proveedor objeto) {
            long ultimoIdInsertado = 0;

            using (var conexion = new MySqlConnection(UtilesConfServidores.ObtenerStringConfServidorMySQL())) {
                try {
                    conexion.Open();
                } catch (Exception) {
                    throw new ExcepcionConexionServidorMySQL();
                }

                using (var comando = conexion.CreateCommand()) {
                    comando.CommandText = $"INSERT INTO `mg__proveedor`(`razon_social`, `nit`, `id_contacto`) VALUES ('{objeto.RazonSocial}','{objeto.NumeroIdentificacionTributaria}','{objeto.IdContactoRepresentante}');";
                    comando.ExecuteNonQuery();
                }

                using (var comando = conexion.CreateCommand()) {
                    comando.CommandText = "SELECT LAST_INSERT_ID();";

                    using (var lectorDatos = comando.ExecuteReader())
                        if (lectorDatos != null && lectorDatos.Read())
                            ultimoIdInsertado = lectorDatos.GetUInt32(0);
                }
            }

            return ultimoIdInsertado;
        }

        public bool Editar(Proveedor objeto, long nuevoId = 0) {
            using (var conexion = new MySqlConnection(UtilesConfServidores.ObtenerStringConfServidorMySQL())) {
                try {
                    conexion.Open();
                } catch (Exception) {
                    throw new ExcepcionConexionServidorMySQL();
                }

                using (var comando = conexion.CreateCommand()) {
                    comando.CommandText = $"UPDATE `mg__proveedor` SET `razon_social`='{objeto.RazonSocial}',`nit`='{objeto.NumeroIdentificacionTributaria}',`id_contacto`='{objeto.IdContactoRepresentante}'' WHERE id_proveedor = {objeto.Id};";
                    comando.ExecuteNonQuery();
                }
            }

            return true;
        }

        public bool Eliminar(long id) {
            using (var conexion = new MySqlConnection(UtilesConfServidores.ObtenerStringConfServidorMySQL())) {
                try {
                    conexion.Open();
                } catch (Exception) {
                    throw new ExcepcionConexionServidorMySQL();
                }

                using (var comando = conexion.CreateCommand()) {
                    comando.CommandText = $"DELETE FROM `mg__proveedor` WHERE `id_proveedor` = '{id}';";
                    comando.ExecuteNonQuery();
                }
            }

            return true;
        }

        public IEnumerable<Proveedor> Obtener(string textoComando = "", int limite = 0, int desplazamiento = 0) {
            Objetos.Clear();

            using (var conexion = new MySqlConnection(UtilesConfServidores.ObtenerStringConfServidorMySQL())) {
                using (var comando = conexion.CreateCommand()) {
                    try {
                        conexion.Open();
                    } catch (Exception) {
                        throw new ExcepcionConexionServidorMySQL();
                    }

                    comando.CommandText = string.IsNullOrEmpty(textoComando) ? "SELECT * FROM `mg__proveedor`;" : textoComando;

                    using (var lectorDatos = comando.ExecuteReader()) {
                        if (lectorDatos == null)
                            return Objetos;

                        while (lectorDatos.Read()) {
                            var proveedor = new Proveedor(
                                idProveedor: lectorDatos.GetInt32(lectorDatos.GetOrdinal("id_proveedor")),
                                razonSocial: lectorDatos.GetString(lectorDatos.GetOrdinal("razon_social")),
                                numeroIdentificacionTributaria: lectorDatos.GetString(lectorDatos.GetOrdinal("nit")),
                                idContactoRepresentante: long.TryParse(lectorDatos.GetValue(lectorDatos.GetOrdinal("id_contacto")).ToString(), out var idContacto) ? idContacto : 0
                            );

                            Objetos.Add(proveedor);
                        }
                    }
                }
            }

            return Objetos;
        }

        public IEnumerable<Proveedor> Obtener(CriterioBusquedaProveedor criterio, string dato, int limite = 0, int desplazamiento = 0) {
            var comando = string.Empty;

            switch (criterio) {
                case CriterioBusquedaProveedor.Id:
                    comando = $"SELECT * FROM mg__proveedor WHERE id_cliente='{dato}';";
                    break;
                case CriterioBusquedaProveedor.RazonSocial:
                    comando = $"SELECT * FROM mg__proveedor WHERE LOWER(razon_social) LIKE LOWER('%{dato}%');";
                    break;
                case CriterioBusquedaProveedor.NIT:
                    comando = $"SELECT * FROM mg__proveedor WHERE nit = '{dato}';";
                    break;
            }

            return Obtener(comando);
        }

        public bool Existe(string dato) {
            return Obtener($"SELECT * FROM mg__proveedor WHERE razon_social = '{dato}';").Any();
        }

        public static string[] ObtenerRazonesSocialesProveedores() {
            var nombresProveedores = new List<string>();

            using (var conexion = new MySqlConnection(UtilesConfServidores.ObtenerStringConfServidorMySQL())) {
                try {
                    conexion.Open();
                } catch (Exception) {
                    throw new ExcepcionConexionServidorMySQL();
                }

                using (var comando = conexion.CreateCommand()) {
                    comando.CommandText = @"
                        SELECT razon_social
                        FROM mg__proveedor;";

                    using (var lectorDatos = comando.ExecuteReader()) {
                        if (lectorDatos != null) {
                            while (lectorDatos.Read()) {
                                nombresProveedores.Add(lectorDatos.GetString(lectorDatos.GetOrdinal("razon_social")));
                            }
                        }
                    }
                }
            }

            return nombresProveedores.ToArray();
        }
    }
}
