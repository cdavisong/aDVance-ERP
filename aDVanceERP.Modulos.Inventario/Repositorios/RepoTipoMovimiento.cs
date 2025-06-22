using aDVanceERP.Core.Repositorios;
using aDVanceERP.Modulos.Inventario.MVP.Modelos;

using MySql.Data.MySqlClient;

using System.Text;

namespace aDVanceERP.Modulos.Inventario.Repositorios; 

public class RepoTipoMovimiento : RepositorioDatosEntidadBase<TipoMovimiento, FbTipoMovimiento> {
    public RepoTipoMovimiento() : base("adv__tipo_movimiento", "id_tipo_movimiento") { }

    public override string[] FiltrosBusqueda => UtilesBusquedaTipoMovimiento.FbTipoMovimiento;

    protected override (string Query, Dictionary<string, object> Parametros) GenerarComandoInsertar(TipoMovimiento entidad) {
        var query = $"""
            INSERT INTO {NombreTabla} (
                nombre,
                efecto
            )
            VALUES (
                @nombre,
                @efecto
            );
            """;

        var parametros = new Dictionary<string, object>
        {
            { "@nombre", entidad.Nombre ?? string.Empty },
            { "@efecto", (int)entidad.Efecto }
        };

        return (query, parametros);
    }

    protected override (string Query, Dictionary<string, object> Parametros) GenerarComandoActualizar(TipoMovimiento entidad) {
        var query = $"""
            UPDATE {NombreTabla}
            SET
                nombre = @nombre,
                efecto = @efecto
            WHERE {ColumnaId} = @id;
            """;

        var parametros = new Dictionary<string, object>
        {
            { "@nombre", entidad.Nombre ?? string.Empty },
            { "@efecto", (int)entidad.Efecto },
            { "@id", entidad.Id }
        };

        return (query, parametros);
    }

    protected override (string WhereClause, Dictionary<string, object> Parametros) GenerarWhereClause(FbTipoMovimiento filtroBusqueda, string? datosComplementarios) {
        var whereClause = new StringBuilder();
        var parametros = new Dictionary<string, object>();

        switch (filtroBusqueda) {
            case FbTipoMovimiento.Id:
                whereClause.Append($"{ColumnaId} = @id");
                parametros.Add("@id", datosComplementarios);
                break;
            case FbTipoMovimiento.Nombre:
                whereClause.Append("LOWER(nombre) LIKE LOWER(@nombre)");
                parametros.Add("@nombre", $"%{datosComplementarios}%");
                break;
            default:
                whereClause.Append("1=1");
                break;
        }

        return (whereClause.ToString(), parametros);
    }

    protected override TipoMovimiento MapearEntidad(MySqlDataReader lectorDatos) {
        return new TipoMovimiento(
            lectorDatos.GetInt64(lectorDatos.GetOrdinal("id_tipo_movimiento")),
            lectorDatos.GetString(lectorDatos.GetOrdinal("nombre")),
            (EfectoMovimiento) lectorDatos.GetInt32(lectorDatos.GetOrdinal("efecto"))
        );
    }

    public override void Eliminar(TipoMovimiento entidad, MySqlConnection? conexionBd = null) {
        var conexion = conexionBd ?? new MySqlConnection(ObtenerCadenaConexion());
        if (conexionBd == null || conexion.State != System.Data.ConnectionState.Open)
            conexion.Open();

        using (var transaccion = conexion.BeginTransaction()) {
            try {
                var parametros = new Dictionary<string, object> { { "@id", entidad.Id } };

                // 1. Desvincular movimientos
                var queryUpdateMovimientos = @"
                    UPDATE adv__movimiento
                    SET id_tipo_movimiento = 0
                    WHERE id_tipo_movimiento = @id;";
                EjecutarComandoNoQuery(conexion, queryUpdateMovimientos, parametros, transaccion);

                // 2. Eliminar el tipo de movimiento
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
