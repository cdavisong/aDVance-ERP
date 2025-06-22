using System.Text;

using aDVanceERP.Core.Repositorios;
using aDVanceERP.Modulos.CompraVenta.MVP.Modelos;

using MySql.Data.MySqlClient;

namespace aDVanceERP.Modulos.CompraVenta.Repositorios;


public class RepoPago : RepositorioDatosEntidadBase<Pago, FbPago> {
    public RepoPago() : base("adv__pago", "id_pago") { }

    public override string[] FiltrosBusqueda => new[] {
        "Todos",
        "Id",
        "IdVenta"
    };

    protected override (string Query, Dictionary<string, object> Parametros) GenerarComandoInsertar(Pago entidad) {
        var query = $"""
            INSERT INTO {NombreTabla} (
                id_venta,
                metodo_pago,
                monto,
                fecha_confirmacion,
                estado
            )
            VALUES (
                @id_venta,
                @metodo_pago,
                @monto,
                @fecha_confirmacion,
                @estado
            );
            """;

        var parametros = new Dictionary<string, object>
        {
            { "@id_venta", entidad.IdVenta },
            { "@metodo_pago", entidad.MetodoPago ?? string.Empty },
            { "@monto", entidad.Monto },
            { "@fecha_confirmacion", entidad.FechaConfirmacion },
            { "@estado", entidad.Estado ?? string.Empty }
        };

        return (query, parametros);
    }

    protected override (string Query, Dictionary<string, object> Parametros) GenerarComandoActualizar(Pago entidad) {
        var query = $"""
            UPDATE {NombreTabla}
            SET
                id_venta = @id_venta,
                metodo_pago = @metodo_pago,
                monto = @monto,
                fecha_confirmacion = @fecha_confirmacion,
                estado = @estado
            WHERE {ColumnaId} = @id;
            """;

        var parametros = new Dictionary<string, object>
        {
            { "@id_venta", entidad.IdVenta },
            { "@metodo_pago", entidad.MetodoPago ?? string.Empty },
            { "@monto", entidad.Monto },
            { "@fecha_confirmacion", entidad.FechaConfirmacion },
            { "@estado", entidad.Estado ?? string.Empty },
            { "@id", entidad.Id }
        };

        return (query, parametros);
    }

    protected override (string WhereClause, Dictionary<string, object> Parametros) GenerarWhereClause(FbPago filtroBusqueda, string? datosComplementarios) {
        var whereClause = new StringBuilder();
        var parametros = new Dictionary<string, object>();

        switch (filtroBusqueda) {
            case FbPago.Id:
                whereClause.Append($"{ColumnaId} = @id");
                parametros.Add("@id", datosComplementarios);
                break;
            case FbPago.IdVenta:
                whereClause.Append("id_venta = @id_venta");
                parametros.Add("@id_venta", datosComplementarios);
                break;
            default:
                whereClause.Append("1=1");
                break;
        }

        return (whereClause.ToString(), parametros);
    }

    protected override Pago MapearEntidad(MySqlDataReader lectorDatos) {
        return new Pago(
            lectorDatos.GetInt64(lectorDatos.GetOrdinal("id_pago")),
            lectorDatos.GetInt64(lectorDatos.GetOrdinal("id_venta")),
            lectorDatos.GetString(lectorDatos.GetOrdinal("metodo_pago")),
            lectorDatos.GetDecimal(lectorDatos.GetOrdinal("monto"))
        ) {
            FechaConfirmacion = lectorDatos.GetDateTime(lectorDatos.GetOrdinal("fecha_confirmacion")),
            Estado = lectorDatos.GetString(lectorDatos.GetOrdinal("estado"))
        };
    }
}
