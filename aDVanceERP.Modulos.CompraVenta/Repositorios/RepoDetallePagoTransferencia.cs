using aDVanceERP.Core.MVP.Modelos.Repositorios;
using aDVanceERP.Modulos.CompraVenta.MVP.Modelos;

using MySql.Data.MySqlClient;

using System.Text;

namespace aDVanceERP.Modulos.CompraVenta.Repositorios;

public class RepoDetallePagoTransferencia :
    RepositorioDatosEntidadBase<DetallePagoTransferencia, FbDetallePagoTransferencia> {
    public RepoDetallePagoTransferencia() : base("adv__detalle_pago_transferencia", "id_detalle_pago_transferencia") {
    }

    public override string[] FiltrosBusqueda => new[] {
        "Todos",
        "Id",
        "IdVenta",
        "IdTarjeta"
    };

    protected override (string Query, Dictionary<string, object> Parametros) GenerarComandoInsertar(DetallePagoTransferencia entidad) {
        var query = $"""
                INSERT INTO {NombreTabla} (
                    id_venta, 
                    id_tarjeta, 
                    numero_confirmacion, 
                    numero_transaccion
                ) 
                VALUES (
                    @id_venta, 
                    @id_tarjeta, 
                    @numero_confirmacion, 
                    @numero_transaccion
                );
                """;
        

        var parametros = new Dictionary<string, object>
        {
            { "@id_venta", entidad.IdVenta },
            { "@id_tarjeta", entidad.IdTarjeta },
            { "@numero_confirmacion", entidad.NumeroConfirmacion ?? string.Empty },
            { "@numero_transaccion", entidad.NumeroTransaccion ?? string.Empty }
        };

        return (query, parametros);
    }

    protected override (string Query, Dictionary<string, object> Parametros) GenerarComandoActualizar(DetallePagoTransferencia entidad) {
        var query = $"""
            UPDATE {NombreTabla} 
            SET 
                id_venta = @id_venta, 
                id_tarjeta = @id_tarjeta,
                numero_confirmacion = @numero_confirmacion, 
                numero_transaccion = @numero_transaccion 
            WHERE {ColumnaId} = @id;
            """;

        var parametros = new Dictionary<string, object>
        {
            { "@id_venta", entidad.IdVenta },
            { "@id_tarjeta", entidad.IdTarjeta },
            { "@numero_confirmacion", entidad.NumeroConfirmacion ?? string.Empty },
            { "@numero_transaccion", entidad.NumeroTransaccion ?? string.Empty },
            { "@id", entidad.Id }
        };

        return (query, parametros);
    }

    protected override (string WhereClause, Dictionary<string, object> Parametros) GenerarWhereClause(FbDetallePagoTransferencia filtroBusqueda, string? datosComplementarios) {
        var whereClause = new StringBuilder();
        var parametros = new Dictionary<string, object>();

        switch (filtroBusqueda) {
            case FbDetallePagoTransferencia.Id:
                whereClause.Append($"{ColumnaId} = @id");
                parametros.Add("@id", datosComplementarios);
                break;
            case FbDetallePagoTransferencia.IdVenta:
                whereClause.Append("id_venta = @id_venta");
                parametros.Add("@id_venta", datosComplementarios);
                break;
            case FbDetallePagoTransferencia.IdTarjeta:
                whereClause.Append("id_tarjeta = @id_tarjeta");
                parametros.Add("@id_tarjeta", datosComplementarios);
                break;
            default:
                whereClause.Append("1=1");
                break;
        }

        return (whereClause.ToString(), parametros);
    }

    protected override DetallePagoTransferencia MapearEntidad(MySqlDataReader lectorDatos) {
        return new DetallePagoTransferencia(
            lectorDatos.GetInt64(lectorDatos.GetOrdinal("id_detalle_pago_transferencia")),
            lectorDatos.GetInt64(lectorDatos.GetOrdinal("id_venta")),
            lectorDatos.GetInt64(lectorDatos.GetOrdinal("id_tarjeta")),
            lectorDatos.GetString(lectorDatos.GetOrdinal("numero_confirmacion")),
            lectorDatos.GetString(lectorDatos.GetOrdinal("numero_transaccion"))
        );
    }
}
