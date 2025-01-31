using Manigest.Core.Excepciones;
using Manigest.Core.Utiles;
using Manigest.Modulos.Contactos.MVP.Modelos.Repositorios.Plantillas;

using MySql.Data.MySqlClient;

namespace Manigest.Modulos.Contactos.MVP.Modelos.Repositorios {
    public class DatosTelefonoContacto : IRepositorioTelefonoContacto {
        public static DatosTelefonoContacto Instance { get; } = new();

        public DatosTelefonoContacto() {
            Objetos = new List<TelefonoContacto>();
        }

        public List<TelefonoContacto> Objetos { get; }

        public long Cantidad() {
            long Cantidad = 0;

            using (var conexion = new MySqlConnection(UtilesConfServidores.ObtenerStringConfServidorMySQL())) {
                try {
                    conexion.Open();
                } catch (Exception) {
                    throw new ExcepcionConexionServidorMySQL();
                }

                using (var comando = conexion.CreateCommand()) {
                    comando.CommandText = "SELECT COUNT(id_telefono_contacto) FROM mg__telefono_contacto;";

                    using (var lectorDatos = comando.ExecuteReader())
                        if (lectorDatos != null && lectorDatos.Read())
                            Cantidad = lectorDatos.GetUInt32(0);
                }
            }

            return Cantidad;
        }

        public long Adicionar(TelefonoContacto objeto) {
            long ultimoIdInsertado = 0;

            using (var conexion = new MySqlConnection(UtilesConfServidores.ObtenerStringConfServidorMySQL())) {
                try {
                    conexion.Open();
                } catch (Exception) {
                    throw new ExcepcionConexionServidorMySQL();
                }

                using (var comando = conexion.CreateCommand()) {
                    comando.CommandText = $"INSERT INTO mg__telefono_contacto (prefijo, numero, categoria, id_contacto) VALUES ('{objeto.Prefijo}', '{objeto.Numero}', '{objeto.Categoria}', '{objeto.IdContacto}');";
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

        public bool Editar(TelefonoContacto objeto, long nuevoId = 0) {
            using (var conexion = new MySqlConnection(UtilesConfServidores.ObtenerStringConfServidorMySQL())) {
                try {
                    conexion.Open();
                } catch (Exception) {
                    throw new ExcepcionConexionServidorMySQL();
                }

                using (var comando = conexion.CreateCommand()) {
                    comando.CommandText = $"UPDATE mg__telefono_contacto SET prefijo='{objeto.Prefijo}', numero='{objeto.Numero}', categoria='{objeto.Categoria}', id_contacto='{objeto.IdContacto}' WHERE id_telefono_contacto='{objeto.Id}';";
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
                    comando.CommandText = $"DELETE FROM mg__telefono_contacto WHERE id_telefono_contacto='{id}';";
                    comando.ExecuteNonQuery();
                }
            }

            return true;
        }

        public IEnumerable<TelefonoContacto> Obtener(string textoComando = "", int limite = 0, int desplazamiento = 0) {
            Objetos.Clear();

            using (var conexion = new MySqlConnection(UtilesConfServidores.ObtenerStringConfServidorMySQL())) {
                using (var comando = conexion.CreateCommand()) {
                    try {
                        conexion.Open();
                    } catch (Exception) {
                        throw new ExcepcionConexionServidorMySQL();
                    }

                    comando.CommandText = string.IsNullOrEmpty(textoComando) ? "SELECT * FROM mg__telefono_contacto;" : textoComando;

                    using (var lectorDatos = comando.ExecuteReader()) {
                        if (lectorDatos == null)
                            return Objetos;

                        while (lectorDatos.Read()) {
                            var telefonoContacto = new TelefonoContacto(
                                idTelefonoContacto: lectorDatos.GetInt32(lectorDatos.GetOrdinal("id_telefono_contacto")),
                                prefijo: lectorDatos.GetString(lectorDatos.GetOrdinal("prefijo")),
                                numero: lectorDatos.GetString(lectorDatos.GetOrdinal("numero")),
                                categoria: (CategoriaTelefonoContacto) Enum.Parse(typeof(CategoriaTelefonoContacto), lectorDatos.GetString(lectorDatos.GetOrdinal("categoria"))),
                                idContacto: lectorDatos.GetInt32(lectorDatos.GetOrdinal("id_contacto"))
                            );

                            Objetos.Add(telefonoContacto);
                        }
                    }
                }
            }

            return Objetos;
        }

        public IEnumerable<TelefonoContacto> Obtener(CriterioBusquedaTelefonoContacto criterio, string dato, int limite = 0, int desplazamiento = 0) {
            var comando = string.Empty;

            switch (criterio) {
                case CriterioBusquedaTelefonoContacto.Id:
                    comando = $"SELECT * FROM mg__telefono_contacto WHERE id_telefono_contacto='{dato}';";
                    break;
                case CriterioBusquedaTelefonoContacto.Numero:
                    comando = $"SELECT * FROM mg__telefono_contacto WHERE numero='{dato}';";
                    break;
                case CriterioBusquedaTelefonoContacto.IdContacto:
                    comando = $"SELECT * FROM mg__telefono_contacto WHERE id_contacto='{dato}';";
                    break;
            }

            return Obtener(comando);
        }

        public bool Existe(string dato) {
            return Obtener($"SELECT * FROM mg__telefono_contacto WHERE numero='{dato}';").Any();
        }
    }
}
