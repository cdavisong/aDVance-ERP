using Manigest.Core.Excepciones;
using Manigest.Core.MVP.Modelos.Plantillas;
using Manigest.Core.MVP.Modelos.Repositorios.Plantillas;
using Manigest.Core.Utiles;

using MySql.Data.MySqlClient;

namespace Manigest.Core.MVP.Modelos.Repositorios {
    public abstract class RepositorioDatosBase<O, C> : IRepositorioDatos<O, C>
        where O : class, IObjetoUnico
        where C : Enum {
        protected RepositorioDatosBase() {
            Objetos = new List<O>();
        }

        public List<O> Objetos { get; }

        public abstract string ComandoCantidad();

        public virtual long Cantidad() {
            long longitud = 0;

            using (var conexion = new MySqlConnection(UtilesConfServidores.ObtenerStringConfServidorMySQL())) {
                try {
                    conexion.Open();
                } catch (Exception) {
                    throw new ExcepcionConexionServidorMySQL();
                }

                using (var comando = conexion.CreateCommand()) {
                    comando.CommandText = ComandoCantidad();

                    using (var lectorDatos = comando.ExecuteReader())
                        if (lectorDatos != null && lectorDatos.Read())
                            longitud = lectorDatos.GetUInt32(0);
                }
            }

            return longitud;
        }

        public abstract string ComandoAdicionar(O objeto);

        public virtual long Adicionar(O objeto) {
            long ultimoIdInsertado = 0;

            using (var conexion = new MySqlConnection(UtilesConfServidores.ObtenerStringConfServidorMySQL())) {
                try {
                    conexion.Open();
                } catch (Exception) {
                    throw new ExcepcionConexionServidorMySQL();
                }

                using (var comando = conexion.CreateCommand()) {
                    comando.CommandText = ComandoAdicionar(objeto);
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

        public abstract string ComandoEditar(O objeto);

        public bool Editar(O objeto, long nuevoId = 0) {
            using (var conexion = new MySqlConnection(UtilesConfServidores.ObtenerStringConfServidorMySQL())) {
                try {
                    conexion.Open();
                } catch (Exception) {
                    throw new ExcepcionConexionServidorMySQL();
                }

                using (var comando = conexion.CreateCommand()) {
                    comando.CommandText = ComandoEditar(objeto);
                    comando.ExecuteNonQuery();
                }
            }

            return true;
        }

        public abstract string ComandoEliminar(long id);

        public bool Eliminar(long id) {
            using (var conexion = new MySqlConnection(UtilesConfServidores.ObtenerStringConfServidorMySQL())) {
                try {
                    conexion.Open();
                } catch (Exception) {
                    throw new ExcepcionConexionServidorMySQL();
                }

                using (var comando = conexion.CreateCommand()) {
                    comando.CommandText = ComandoEliminar(id);
                    comando.ExecuteNonQuery();
                }
            }

            return true;
        }

        public abstract string ComandoObtener(C criterio, string dato);

        public abstract O ObtenerObjetoDataReader(MySqlDataReader lectorDatos);

        public IEnumerable<O> Obtener(string textoComando = "", int limite = 0, int desplazamiento = 0) {
            Objetos.Clear();

            using (var conexion = new MySqlConnection(UtilesConfServidores.ObtenerStringConfServidorMySQL())) {
                using (var comando = conexion.CreateCommand()) {
                    try {
                        conexion.Open();
                    } catch (Exception) {
                        throw new ExcepcionConexionServidorMySQL();
                    }

                    comando.CommandText = string.IsNullOrEmpty(textoComando) ? ComandoObtener(default, string.Empty) : textoComando;

                    using (var lectorDatos = comando.ExecuteReader()) {
                        if (lectorDatos == null)
                            return Objetos;

                        while (lectorDatos.Read()) {
                            Objetos.Add(ObtenerObjetoDataReader(lectorDatos));
                        }
                    }
                }
            }

            return Objetos;
        }

        public IEnumerable<O> Obtener(C criterio, string dato, int limite = 0, int desplazamiento = 0) {
            var comando = ComandoObtener(criterio, dato);

            return Obtener(comando);
        }

        public abstract string ComandoExiste(string dato);

        public bool Existe(string dato) {
            return Obtener(ComandoExiste(dato)).Any();
        }
    }
}
