using aDVanceERP.Core.MVP.Modelos.Repositorios;
using aDVanceERP.Modulos.Inventario.MVP.Modelos;

using MySql.Data.MySqlClient;

using System.Text;

namespace aDVanceERP.Modulos.Inventario.Repositorios;

public class RepoTipoMateriaPrima : RepositorioDatosEntidadBase<TipoMateriaPrima, FbTipoMateriaPrima> {
    public RepoTipoMateriaPrima() : base("adv__tipo_materia_prima", "id_tipo_materia_prima") { }

    public override string[] FiltrosBusqueda => UtilesBusquedaTiposMateriasPrimas.FbTiposMateriasPrimas;

    protected override (string Query, Dictionary<string, object> Parametros) GenerarComandoInsertar(TipoMateriaPrima entidad) {
        var query = $"""
            INSERT INTO {NombreTabla} (
                nombre,
                descripcion
            )
            VALUES (
                @nombre,
                @descripcion
            );
            """;

        var parametros = new Dictionary<string, object>
        {
            { "@nombre", entidad.Nombre ?? string.Empty },
            { "@descripcion", entidad.Descripcion ?? string.Empty }
        };

        return (query, parametros);
    }

    protected override (string Query, Dictionary<string, object> Parametros) GenerarComandoActualizar(TipoMateriaPrima entidad) {
        var query = $"""
            UPDATE {NombreTabla}
            SET
                nombre = @nombre,
                descripcion = @descripcion
            WHERE {ColumnaId} = @id;
            """;

        var parametros = new Dictionary<string, object>
        {
            { "@nombre", entidad.Nombre ?? string.Empty },
            { "@descripcion", entidad.Descripcion ?? string.Empty },
            { "@id", entidad.Id }
        };

        return (query, parametros);
    }

    protected override (string WhereClause, Dictionary<string, object> Parametros) GenerarWhereClause(FbTipoMateriaPrima filtroBusqueda, string? datosComplementarios) {
        var whereClause = new StringBuilder();
        var parametros = new Dictionary<string, object>();

        switch (filtroBusqueda) {
            case FbTipoMateriaPrima.Id:
                whereClause.Append($"{ColumnaId} = @id");
                parametros.Add("@id", datosComplementarios);
                break;
            case FbTipoMateriaPrima.Nombre:
                whereClause.Append("nombre LIKE @nombre");
                parametros.Add("@nombre", $"%{datosComplementarios}%");
                break;
            default:
                whereClause.Append("1=1");
                break;
        }

        return (whereClause.ToString(), parametros);
    }

    protected override TipoMateriaPrima MapearEntidad(MySqlDataReader lectorDatos) {
        return new TipoMateriaPrima(
            lectorDatos.GetInt64(lectorDatos.GetOrdinal("id_tipo_materia_prima")),
            lectorDatos.GetString(lectorDatos.GetOrdinal("nombre")),
            lectorDatos.GetString(lectorDatos.GetOrdinal("descripcion"))
        );
    }

    // Lógica especial: desvincular productos antes de eliminar el tipo de materia prima
    public override void Eliminar(TipoMateriaPrima entidad, MySqlConnection? conexionBd = null) {
        var conexion = conexionBd ?? new MySqlConnection(ObtenerCadenaConexion());
        if (conexionBd == null || conexion.State != System.Data.ConnectionState.Open)
            conexion.Open();

        using (var transaccion = conexion.BeginTransaction()) {
            try {
                var parametros = new Dictionary<string, object> { { "@id", entidad.Id } };

                // 1. Desvincular productos
                var queryUpdateProductos = @"
                    UPDATE adv__producto
                    SET id_tipo_materia_prima = 0
                    WHERE id_tipo_materia_prima = @id;";
                EjecutarComandoNoQuery(conexion, queryUpdateProductos, parametros, transaccion);

                // 2. Eliminar el tipo de materia prima
                base.Eliminar(entidad, conexion);

                transaccion.Commit();
            } catch {
                transaccion.Rollback();
                throw;
            } finally {
                if (conexionBd == null)
                    conexion.Close();
            }
        }
    }
}
