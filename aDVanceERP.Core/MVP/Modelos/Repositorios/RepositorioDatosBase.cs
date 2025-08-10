using aDVanceERP.Core.Datos;
using aDVanceERP.Core.Excepciones;
using aDVanceERP.Core.MVP.Modelos.Plantillas;

using MySql.Data.MySqlClient;

namespace aDVanceERP.Core.MVP.Modelos.Repositorios; 

public abstract class RepositorioDatosBase<En, Fb> : IDisposable
    where En : class, IEntidad, new()
    where Fb : Enum {
    protected RepositorioDatosBase() {
        Objetos = new List<En>();
    }

    public List<En> Objetos { get; }

    public virtual long Cantidad() {
        return EjecutarConsultaEscalar<long>(ComandoCantidad());
    }

    public virtual async Task<long> CantidadAsync() {
        return await EjecutarConsultaEscalarAsync<long>(ComandoCantidad());
    }

    public virtual long Adicionar(En objeto) {
        using (var conexion = new MySqlConnection(CoreDatos.ConfServidorMySQL.ToString())) {
            conexion.Open();

            using (var comando = conexion.CreateCommand()) {
                comando.CommandText = ComandoAdicionar(objeto);
                comando.ExecuteNonQuery();

                return comando.LastInsertedId;
            }
        }
    }

    public virtual async Task<long> AdicionarAsync(En objeto) {
        using (var conexion = new MySqlConnection(CoreDatos.ConfServidorMySQL.ToString())) {
            await conexion.OpenAsync().ConfigureAwait(false);

            using (var comando = conexion.CreateCommand()) {
                comando.CommandText = ComandoAdicionar(objeto);
                await comando.ExecuteNonQueryAsync().ConfigureAwait(false);

                return comando.LastInsertedId; // Más directo y eficiente
            }
        }
    }

    public virtual bool Editar(En objeto, long nuevoId = 0) {
        EjecutarComandoNoQuery(ComandoEditar(objeto));
        return true;
    }

    public virtual async Task<bool> EditarAsync(En objeto, long nuevoId = 0) {
        await EjecutarComandoNoQueryAsync(ComandoEditar(objeto));
        return true;
    }

    public virtual bool Eliminar(long id) {
        EjecutarComandoNoQuery(ComandoEliminar(id));
        return true;
    }

    public virtual async Task<bool> EliminarAsync(long id) {
        await EjecutarComandoNoQueryAsync(ComandoEliminar(id));
        return true;
    }

    public IEnumerable<En> Obtener(string? textoComando = "", int limite = 0, int desplazamiento = 0) {
        Objetos.Clear();
        var comando = string.IsNullOrEmpty(textoComando) ? ComandoObtener(default, string.Empty) : textoComando;

        // Agregar LIMIT y OFFSET si es necesario (antes del ;)
        if (limite > 0) {
            comando = comando.TrimEnd(';'); // Eliminar el ; si existe
            comando += $" LIMIT {limite}";
            if (desplazamiento > 0) comando += $" OFFSET {desplazamiento}";
            comando += ";"; // Agregar el ; al final
        }

        return EjecutarConsulta(comando, lectorDatos => Objetos.Add(ObtenerObjetoDataReader(lectorDatos)));
    }

    public IEnumerable<En> Obtener(Fb? criterio, string? dato, int limite = 0, int desplazamiento = 0) {
        var comando = ComandoObtener(criterio, dato);

        // Agregar LIMIT y OFFSET si es necesario (antes del ;)
        if (limite > 0) {
            comando = comando.TrimEnd(';'); // Eliminar el ; si existe
            comando += $" LIMIT {limite}";
            if (desplazamiento > 0) comando += $" OFFSET {desplazamiento}";
            comando += ";"; // Agregar el ; al final
        }

        return Obtener(comando);
    }

    public Task<IEnumerable<En>> ObtenerAsync(Fb? criterio, string? dato, out int totalFilas, int limite = 0,
        int desplazamiento = 0) {
        Objetos.Clear();
        var comando = ComandoObtener(criterio, dato);
        var comandoCount =
            $"SELECT COUNT(*) as total_filas {comando[comando.IndexOf("FROM", StringComparison.Ordinal)..]}";

        // Agregar LIMIT y OFFSET si es necesario (antes del ;)
        if (limite > 0) {
            comando = comando.TrimEnd(';'); // Eliminar el ; si existe
            comando += $" LIMIT {limite}";
            if (desplazamiento > 0) comando += $" OFFSET {desplazamiento}";
            comando += ";"; // Agregar el ; al final
        }

        totalFilas = (int)EjecutarConsultaEscalar<long>(comandoCount);

        return EjecutarConsultaAsync(comando);
    }

    public bool Existe(string dato) {
        return Obtener(ComandoExiste(dato)).Any();
    }

    public async Task<bool> ExisteAsync(string dato) {
        var comando = ComandoExiste(dato);
        var resultados = await EjecutarConsultaAsync(comando);
        return resultados.Any();
    }

    public void Dispose() {
        Dispose(true);
        GC.SuppressFinalize(this);
    }

    public abstract string ComandoCantidad();
    public abstract string ComandoAdicionar(En objeto);
    public abstract string ComandoEditar(En objeto);
    public abstract string ComandoEliminar(long id);
    public abstract string ComandoObtener(Fb criterio, string dato);
    public abstract string ComandoExiste(string dato);
    public abstract En ObtenerObjetoDataReader(MySqlDataReader lectorDatos);

    protected virtual void Dispose(bool disposing) {
        if (disposing) Objetos?.Clear();
    }

    ~RepositorioDatosBase() {
        Dispose(false);
    }

    private T EjecutarConsultaEscalar<T>(string comandoTexto) {
        using (var conexion = new MySqlConnection(CoreDatos.ConfServidorMySQL.ToString())) {
            try {
                conexion.Open();
            }
            catch (MySqlException) {
                throw new ExcepcionConexionServidorMySQL();
            }

            using (var comando = conexion.CreateCommand()) {
                comando.CommandText = comandoTexto;
                return (T)Convert.ChangeType(comando.ExecuteScalar(), typeof(T));
            }
        }
    }

    private async Task<T> EjecutarConsultaEscalarAsync<T>(string comandoTexto) {
        using (var conexion = new MySqlConnection(CoreDatos.ConfServidorMySQL.ToString())) {
            try {
                await conexion.OpenAsync().ConfigureAwait(false);
            }
            catch (MySqlException) {
                throw new ExcepcionConexionServidorMySQL();
            }

            using (var comando = conexion.CreateCommand()) {
                comando.CommandText = comandoTexto;
                
                var result = await comando.ExecuteScalarAsync().ConfigureAwait(false);
                
                return (T)Convert.ChangeType(result, typeof(T));
            }
        }
    }

    private void EjecutarComandoNoQuery(string comandoTexto) {
        using (var conexion = new MySqlConnection(CoreDatos.ConfServidorMySQL.ToString())) {
            try {
                conexion.Open();
            }
            catch (MySqlException) {
                throw new ExcepcionConexionServidorMySQL();
            }

            using (var comando = conexion.CreateCommand()) {
                comando.CommandText = comandoTexto;
                comando.ExecuteNonQuery();
            }
        }
    }

    private async Task EjecutarComandoNoQueryAsync(string comandoTexto) {
        using (var conexion = new MySqlConnection(CoreDatos.ConfServidorMySQL.ToString())) {
            try {
                await conexion.OpenAsync().ConfigureAwait(false);
            }
            catch (MySqlException) {
                throw new ExcepcionConexionServidorMySQL();
            }

            using (var comando = conexion.CreateCommand()) {
                comando.CommandText = comandoTexto;
                await comando.ExecuteNonQueryAsync().ConfigureAwait(false);
            }
        }
    }

    private IEnumerable<En> EjecutarConsulta(string comandoTexto, Action<MySqlDataReader> procesarLector) {
        using (var conexion = new MySqlConnection(CoreDatos.ConfServidorMySQL.ToString())) {
            try {
                conexion.Open();
            }
            catch (MySqlException) {
                throw new ExcepcionConexionServidorMySQL();
            }

            using (var comando = conexion.CreateCommand()) {
                comando.CommandText = comandoTexto;
                using (var lectorDatos = comando.ExecuteReader()) {
                    if (lectorDatos != null)
                        while (lectorDatos.Read())
                            procesarLector(lectorDatos);
                }
            }
        }

        return Objetos;
    }

    private async Task<IEnumerable<En>> EjecutarConsultaAsync(string comandoTexto) {
        using (var conexion = new MySqlConnection(CoreDatos.ConfServidorMySQL.ToString())) {
            try {
                await conexion.OpenAsync().ConfigureAwait(false);
            }
            catch (MySqlException) {
                throw new ExcepcionConexionServidorMySQL();
            }

            using (var comando = conexion.CreateCommand()) {
                comando.CommandText = comandoTexto;
                using (var lectorDatos = await comando.ExecuteReaderAsync().ConfigureAwait(false)) {
                    while (await lectorDatos.ReadAsync().ConfigureAwait(false))
                        Objetos.Add(ObtenerObjetoDataReader((MySqlDataReader)lectorDatos));
                }
            }
        }

        return Objetos;
    }
}