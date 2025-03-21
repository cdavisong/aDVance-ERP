using aDVanceERP.Core.Excepciones;
using aDVanceERP.Core.MVP.Modelos.Plantillas;
using aDVanceERP.Core.MVP.Modelos.Repositorios.Plantillas;
using aDVanceERP.Core.Utiles;

using MySql.Data.MySqlClient;

namespace aDVanceERP.Core.MVP.Modelos.Repositorios {
    public abstract class RepositorioDatosBase<O, C> : IRepositorioDatos<O, C>, IDisposable
        where O : class, IObjetoUnico, new()
        where C : Enum {
        protected RepositorioDatosBase() {
            Objetos = new List<O>();
        }

        public List<O> Objetos { get; }

        public abstract string ComandoCantidad();
        public abstract string ComandoAdicionar(O objeto);
        public abstract string ComandoEditar(O objeto);
        public abstract string ComandoEliminar(long id);
        public abstract string ComandoObtener(C criterio, string dato);
        public abstract string ComandoExiste(string dato);
        public abstract O ObtenerObjetoDataReader(MySqlDataReader lectorDatos);

        public virtual long Cantidad() {
            return EjecutarConsultaEscalar<long>(ComandoCantidad());
        }

        public virtual long Adicionar(O objeto) {
            EjecutarComandoNoQuery(ComandoAdicionar(objeto));
            return EjecutarConsultaEscalar<long>("SELECT LAST_INSERT_ID();");
        }

        public virtual bool Editar(O objeto, long nuevoId = 0) {
            EjecutarComandoNoQuery(ComandoEditar(objeto));
            return true;
        }

        public virtual bool Eliminar(long id) {
            EjecutarComandoNoQuery(ComandoEliminar(id));
            return true;
        }

        public IEnumerable<O> Obtener(string? textoComando = "", int limite = 0, int desplazamiento = 0) {
            Objetos.Clear();
            var comando = string.IsNullOrEmpty(textoComando) ? ComandoObtener(default, string.Empty) : textoComando;

            // Agregar LIMIT y OFFSET si es necesario (antes del ;)
            if (limite > 0) {
                comando = comando.TrimEnd(';'); // Eliminar el ; si existe
                comando += $" LIMIT {limite}";
                if (desplazamiento > 0) {
                    comando += $" OFFSET {desplazamiento}";
                }
                comando += ";"; // Agregar el ; al final
            }

            return EjecutarConsulta(comando, lectorDatos => Objetos.Add(ObtenerObjetoDataReader(lectorDatos)));
        }

        public IEnumerable<O> Obtener(C? criterio, string? dato, int limite = 0, int desplazamiento = 0) {
            var comando = ComandoObtener(criterio, dato);

            // Agregar LIMIT y OFFSET si es necesario (antes del ;)
            if (limite > 0) {
                comando = comando.TrimEnd(';'); // Eliminar el ; si existe
                comando += $" LIMIT {limite}";
                if (desplazamiento > 0) {
                    comando += $" OFFSET {desplazamiento}";
                }
                comando += ";"; // Agregar el ; al final
            }

            return Obtener(comando);
        }

        public bool Existe(string dato) {
            return Obtener(ComandoExiste(dato)).Any();
        }

        public void Dispose() {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing) {
            if (disposing) {
                Objetos?.Clear();
            }
        }

        ~RepositorioDatosBase() {
            Dispose(false);
        }

        private T EjecutarConsultaEscalar<T>(string comandoTexto) {
            using (var conexion = new MySqlConnection(UtilesConfServidores.ObtenerStringConfServidorMySQL())) {
                try {
                    conexion.Open();
                } catch (MySqlException) {
                    throw new ExcepcionConexionServidorMySQL();
                }

                using (var comando = conexion.CreateCommand()) {
                    comando.CommandText = comandoTexto;
                    return (T) Convert.ChangeType(comando.ExecuteScalar(), typeof(T));
                }
            }
        }

        private void EjecutarComandoNoQuery(string comandoTexto) {
            using (var conexion = new MySqlConnection(UtilesConfServidores.ObtenerStringConfServidorMySQL())) {
                try {
                    conexion.Open();
                } catch (MySqlException) {
                    throw new ExcepcionConexionServidorMySQL();
                }

                using (var comando = conexion.CreateCommand()) {
                    comando.CommandText = comandoTexto;
                    comando.ExecuteNonQuery();
                }
            }
        }

        private IEnumerable<O> EjecutarConsulta(string comandoTexto, Action<MySqlDataReader> procesarLector) {
            using (var conexion = new MySqlConnection(UtilesConfServidores.ObtenerStringConfServidorMySQL())) {
                try {
                    conexion.Open();
                } catch (MySqlException) {
                    throw new ExcepcionConexionServidorMySQL();
                }
                using (var comando = conexion.CreateCommand()) {
                    comando.CommandText = comandoTexto;
                    using (var lectorDatos = comando.ExecuteReader()) {
                        if (lectorDatos != null) {
                            while (lectorDatos.Read()) {
                                procesarLector(lectorDatos);
                            }
                        }
                    }
                }
            }
            return Objetos;
        }
    }
}
