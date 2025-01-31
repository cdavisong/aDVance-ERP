using Manigest.Core.Excepciones;
using Manigest.Core.Utiles;
using Manigest.Modulos.Contactos.MVP.Modelos.Repositorios.Plantillas;

using MySql.Data.MySqlClient;

namespace Manigest.Modulos.Contactos.MVP.Modelos.Repositorios {
    public class DatosCliente : IRepositorioCliente {
        public static DatosCliente Instance { get; } = new();

        public DatosCliente() {
            Objetos = new List<Cliente>();
        }

        public List<Cliente> Objetos { get; }

        public long Longitud() {
            long longitud = 0;

            using (var conexion = new MySqlConnection(UtilesConfServidores.ObtenerStringConfServidorMySQL())) {
                try {
                    conexion.Open();
                } catch (Exception) {
                    throw new ExcepcionConexionServidorMySQL();
                }

                using (var comando = conexion.CreateCommand()) {
                    comando.CommandText = "SELECT COUNT(id_cliente) FROM mg__cliente;";

                    using (var lectorDatos = comando.ExecuteReader())
                        if (lectorDatos != null && lectorDatos.Read())
                            longitud = lectorDatos.GetUInt32(0);
                }
            }

            return longitud;
        }

        public long Adicionar(Cliente objeto) {
            long ultimoIdInsertado = 0;

            using (var conexion = new MySqlConnection(UtilesConfServidores.ObtenerStringConfServidorMySQL())) {
                try {
                    conexion.Open();
                } catch (Exception) {
                    throw new ExcepcionConexionServidorMySQL();
                }

                using (var comando = conexion.CreateCommand()) {
                    comando.CommandText = $"INSERT INTO mg__cliente (numero, razon_social, id_contacto) VALUES ('{objeto.Numero}', '{objeto.RazonSocial}', '{objeto.Id}');";
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

        public bool Editar(Cliente objeto, long nuevoId = 0) {
            using (var conexion = new MySqlConnection(UtilesConfServidores.ObtenerStringConfServidorMySQL())) {
                try {
                    conexion.Open();
                } catch (Exception) {
                    throw new ExcepcionConexionServidorMySQL();
                }

                using (var comando = conexion.CreateCommand()) {
                    comando.CommandText = $"UPDATE mg__cliente SET numero='{objeto.Numero}', razon_social='{objeto.RazonSocial}', id_cliente='{objeto.Id}' WHERE id_cliente='{objeto.Id}';";
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
                    comando.CommandText = $"DELETE FROM mg__cliente WHERE id_cliente='{id}';";
                    comando.ExecuteNonQuery();
                }
            }

            return true;
        }


        public IEnumerable<Cliente> Obtener(string textoComando = "", int limite = 0, int desplazamiento = 0) {
            Objetos.Clear();

            using (var conexion = new MySqlConnection(UtilesConfServidores.ObtenerStringConfServidorMySQL())) {
                using (var comando = conexion.CreateCommand()) {
                    try {
                        conexion.Open();
                    } catch (Exception) {
                        throw new ExcepcionConexionServidorMySQL();
                    }

                    comando.CommandText = string.IsNullOrEmpty(textoComando) ? "SELECT * FROM mg__cliente;" : textoComando;

                    using (var lectorDatos = comando.ExecuteReader()) {
                        if (lectorDatos == null)
                            return Objetos;

                        while (lectorDatos.Read()) {
                            var cliente = new Cliente(
                                idCliente: lectorDatos.GetInt32(lectorDatos.GetOrdinal("id_cliente")),
                                numero: lectorDatos.GetString(lectorDatos.GetOrdinal("numero")),
                                razonSocial: lectorDatos.GetString(lectorDatos.GetOrdinal("razon_social")),
                                idContacto: long.TryParse(lectorDatos.GetValue(lectorDatos.GetOrdinal("id_contacto")).ToString(), out var idContacto) ? idContacto : 0
                            );

                            Objetos.Add(cliente);
                        }
                    }
                }
            }

            return Objetos;
        }

        public IEnumerable<Cliente> Obtener(CriterioBusquedaCliente criterio, string dato, int limite = 0, int desplazamiento = 0) {
            var comando = string.Empty;

            switch (criterio) {
                case CriterioBusquedaCliente.Id:
                    comando = $"SELECT * FROM mg__cliente WHERE id_cliente='{dato}';";
                    break;
                case CriterioBusquedaCliente.Nombre:
                    comando = $"SELECT * FROM mg__cliente WHERE LOWER(nombre) LIKE LOWER('%{dato}%');";
                    break;
                case CriterioBusquedaCliente.Numero:
                    comando = $"SELECT * FROM mg__cliente WHERE numero='{dato}';";
                    break;
            }

            return Obtener(comando);
        }

        public bool Existe(string dato) {
            return Obtener($"SELECT * FROM mg__cliente WHERE numero='{dato}';").Any();
        }

        public long Cantidad() {
            throw new NotImplementedException();
        }
    }
}
