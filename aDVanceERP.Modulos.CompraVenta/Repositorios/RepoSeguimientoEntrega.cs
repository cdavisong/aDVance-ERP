using System.Text;

using aDVanceERP.Core.Repositorios;
using aDVanceERP.Modulos.CompraVenta.MVP.Modelos;

using MySql.Data.MySqlClient;

namespace aDVanceERP.Modulos.CompraVenta.Repositorios;

public class RepoSeguimientoEntrega : RepositorioDatosEntidadBase<SeguimientoEntrega, FbSeguimientoEntrega> {
    public RepoSeguimientoEntrega() : base("adv__seguimiento_entrega", "id_seguimiento_entrega") { }

    public override string[] FiltrosBusqueda => UtilesBusquedaSeguimientoEntrega.FbSeguimientoEntrega;

    protected override (string Query, Dictionary<string, object> Parametros) GenerarComandoInsertar(SeguimientoEntrega entidad) {
        var query = $"""
            INSERT INTO {NombreTabla} (
                id_venta,
                id_mensajero,
                fecha_asignacion,
                fecha_entrega,
                fecha_pago,
                observaciones
            )
            VALUES (
                @id_venta,
                @id_mensajero,
                @fecha_asignacion,
                @fecha_entrega,
                @fecha_pago,
                @observaciones
            );
            """;

        var parametros = new Dictionary<string, object>
        {
            { "@id_venta", entidad.IdVenta },
            { "@id_mensajero", entidad.IdMensajero },
            { "@fecha_asignacion", entidad.FechaAsignacion },
            { "@fecha_entrega", entidad.FechaEntrega },
            { "@fecha_pago", entidad.FechaPago },
            { "@observaciones", entidad.Observaciones ?? string.Empty }
        };

        return (query, parametros);
    }

    protected override (string Query, Dictionary<string, object> Parametros) GenerarComandoActualizar(SeguimientoEntrega entidad) {
        var query = $"""
            UPDATE {NombreTabla}
            SET
                id_venta = @id_venta,
                id_mensajero = @id_mensajero,
                fecha_asignacion = @fecha_asignacion,
                fecha_entrega = @fecha_entrega,
                fecha_pago = @fecha_pago,
                observaciones = @observaciones
            WHERE {ColumnaId} = @id;
            """;

        var parametros = new Dictionary<string, object>
        {
            { "@id_venta", entidad.IdVenta },
            { "@id_mensajero", entidad.IdMensajero },
            { "@fecha_asignacion", entidad.FechaAsignacion },
            { "@fecha_entrega", entidad.FechaEntrega },
            { "@fecha_pago", entidad.FechaPago },
            { "@observaciones", entidad.Observaciones ?? string.Empty },
            { "@id", entidad.Id }
        };

        return (query, parametros);
    }

    protected override (string WhereClause, Dictionary<string, object> Parametros) GenerarWhereClause(FbSeguimientoEntrega filtroBusqueda, string? datosComplementarios) {
        var whereClause = new StringBuilder();
        var parametros = new Dictionary<string, object>();

        switch (filtroBusqueda) {
            case FbSeguimientoEntrega.Id:
                whereClause.Append($"{ColumnaId} = @id");
                parametros.Add("@id", datosComplementarios);
                break;
            case FbSeguimientoEntrega.IdVenta:
                whereClause.Append("id_venta = @id_venta");
                parametros.Add("@id_venta", datosComplementarios);
                break;
            case FbSeguimientoEntrega.NombreMensajero:
                whereClause.Append("id_mensajero = (SELECT id_mensajero FROM adv__mensajero WHERE nombre = @nombre_mensajero)");
                parametros.Add("@nombre_mensajero", datosComplementarios);
                break;
            case FbSeguimientoEntrega.FechaAsignacion:
                whereClause.Append("DATE(fecha_asignacion) = @fecha_asignacion");
                parametros.Add("@fecha_asignacion", datosComplementarios);
                break;
            case FbSeguimientoEntrega.FechaEntrega:
                whereClause.Append("DATE(fecha_entrega) = @fecha_entrega");
                parametros.Add("@fecha_entrega", datosComplementarios);
                break;
            case FbSeguimientoEntrega.FechaConfirmacion:
                whereClause.Append("DATE(fecha_confirmacion) = @fecha_confirmacion");
                parametros.Add("@fecha_confirmacion", datosComplementarios);
                break;
            case FbSeguimientoEntrega.FechaPago:
                whereClause.Append("DATE(fecha_pago) = @fecha_pago");
                parametros.Add("@fecha_pago", datosComplementarios);
                break;
            default:
                whereClause.Append("1=1");
                break;
        }

        return (whereClause.ToString(), parametros);
    }

    protected override SeguimientoEntrega MapearEntidad(MySqlDataReader lectorDatos) {
        return new SeguimientoEntrega(
            lectorDatos.GetInt64(lectorDatos.GetOrdinal("id_seguimiento_entrega")),
            lectorDatos.GetInt64(lectorDatos.GetOrdinal("id_venta")),
            lectorDatos.GetInt64(lectorDatos.GetOrdinal("id_mensajero")),
            lectorDatos.GetDateTime(lectorDatos.GetOrdinal("fecha_asignacion")),
            lectorDatos.GetDateTime(lectorDatos.GetOrdinal("fecha_entrega")),
            lectorDatos.GetDateTime(lectorDatos.GetOrdinal("fecha_pago")),
            lectorDatos.GetString(lectorDatos.GetOrdinal("observaciones"))
        );
    }
}
