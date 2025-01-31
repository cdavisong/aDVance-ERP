using Manigest.Core.Excepciones;
using Manigest.Core.Utiles;
using Manigest.Modulos.Contactos.MVP.Modelos.Repositorios.Plantillas;

using MySql.Data.MySqlClient;

namespace Manigest.Modulos.Contactos.MVP.Modelos.Repositorios {
    public class DatosContacto : IRepositorioContacto {
        public static DatosContacto Instance { get; } = new();

        public DatosContacto() {
            Objetos = new List<Contacto>();
        }

        public List<Contacto> Objetos { get; }

        public long Cantidad() {
            long Cantidad = 0;

            using (var conexion = new MySqlConnection(UtilesConfServidores.ObtenerStringConfServidorMySQL())) {
                try {
                    conexion.Open();
                } catch (Exception) {
                    throw new ExcepcionConexionServidorMySQL();
                }

                using (var comando = conexion.CreateCommand()) {
                    comando.CommandText = "SELECT COUNT(id_contacto) FROM mg__contacto;";

                    using (var lectorDatos = comando.ExecuteReader())
                        if (lectorDatos != null && lectorDatos.Read())
                            Cantidad = lectorDatos.GetUInt32(0);
                }
            }

            return Cantidad;
        }

        public long Adicionar(Contacto objeto) {
            long ultimoIdInsertado = 0;

            using (var conexion = new MySqlConnection(UtilesConfServidores.ObtenerStringConfServidorMySQL())) {
                try {
                    conexion.Open();
                } catch (Exception) {
                    throw new ExcepcionConexionServidorMySQL();
                }

                using (var comando = conexion.CreateCommand()) {
                    comando.CommandText = $"INSERT INTO mg__contacto (nombre, direccion_correo_electronico, direccion, notas) VALUES ('{objeto.Nombre}', '{objeto.DireccionCorreoElectronico}', '{objeto.Direccion}', '{objeto.Notas}');";
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

        public bool Editar(Contacto objeto, long nuevoId = 0) {
            using (var conexion = new MySqlConnection(UtilesConfServidores.ObtenerStringConfServidorMySQL())) {
                try {
                    conexion.Open();
                } catch (Exception) {
                    throw new ExcepcionConexionServidorMySQL();
                }

                using (var comando = conexion.CreateCommand()) {
                    comando.CommandText = $"UPDATE mg__contacto SET nombre='{objeto.Nombre}', direccion_correo_electronico='{objeto.DireccionCorreoElectronico}', direccion='{objeto.Direccion}', notas='{objeto.Notas}' WHERE id_contacto='{objeto.Id}';";
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

                // Telefonos
                var datosTelefonoContacto = new DatosTelefonoContacto();
                var telefonosContacto = datosTelefonoContacto.Obtener(CriterioBusquedaTelefonoContacto.IdContacto, id.ToString());

                foreach (var telefonoContacto in telefonosContacto)
                    datosTelefonoContacto.Eliminar(telefonoContacto.Id);

                using (var comando = conexion.CreateCommand()) {
                    comando.CommandText = $"DELETE FROM mg__contacto WHERE id_contacto='{id}';";
                    comando.ExecuteNonQuery();
                }
            }

            return true;
        }

        public IEnumerable<Contacto> Obtener(string textoComando = "", int limite = 0, int desplazamiento = 0) {
            Objetos.Clear();

            using (var conexion = new MySqlConnection(UtilesConfServidores.ObtenerStringConfServidorMySQL())) {
                using (var comando = conexion.CreateCommand()) {
                    try {
                        conexion.Open();
                    } catch (Exception) {
                        throw new ExcepcionConexionServidorMySQL();
                    }

                    comando.CommandText = string.IsNullOrEmpty(textoComando) ? "SELECT * FROM mg__contacto;" : textoComando;

                    using (var lectorDatos = comando.ExecuteReader()) {
                        if (lectorDatos == null)
                            return Objetos;

                        while (lectorDatos.Read()) {
                            var contacto = new Contacto(
                                idContacto: lectorDatos.GetInt32(lectorDatos.GetOrdinal("id_contacto")),
                                nombre: lectorDatos.GetString(lectorDatos.GetOrdinal("nombre")),
                                direccionCorreoElectronico: lectorDatos.GetString(lectorDatos.GetOrdinal("direccion_correo_electronico")),
                                direccion: lectorDatos.GetString(lectorDatos.GetOrdinal("direccion")),
                                notas: lectorDatos.GetValue(lectorDatos.GetOrdinal("notas")).ToString()
                            );

                            Objetos.Add(contacto);
                        }
                    }
                }
            }

            return Objetos;
        }

        public IEnumerable<Contacto> Obtener(CriterioBusquedaContacto criterio, string dato, int limite = 0, int desplazamiento = 0) {
            var comando = string.Empty;

            switch (criterio) {
                case CriterioBusquedaContacto.Id:
                    comando = $"SELECT * FROM mg__contacto WHERE id_contacto='{dato}';";
                    break;
                case CriterioBusquedaContacto.Nombre:
                    comando = $"SELECT * FROM mg__contacto WHERE LOWER(nombre) LIKE LOWER('%{dato}%');";
                    break;
            }

            return Obtener(comando);
        }

        public bool Existe(string dato) {
            return Obtener($"SELECT * FROM mg__contacto WHERE nombre='{dato}';").Any();
        }

        public static string[] ObtenerNombresContactos() {
            var nombresContactos = new List<string>();

            using (var conexion = new MySqlConnection(UtilesConfServidores.ObtenerStringConfServidorMySQL())) {
                try {
                    conexion.Open();
                } catch (Exception) {
                    throw new ExcepcionConexionServidorMySQL();
                }

                using (var comando = conexion.CreateCommand()) {
                    comando.CommandText = @"
                        SELECT nombre
                        FROM mg__contacto;";

                    using (var lectorDatos = comando.ExecuteReader()) {
                        if (lectorDatos != null) {
                            while (lectorDatos.Read()) {
                                nombresContactos.Add(lectorDatos.GetString(lectorDatos.GetOrdinal("nombre")));
                            }
                        }
                    }
                }
            }

            return nombresContactos.ToArray();
        }
    }
}
