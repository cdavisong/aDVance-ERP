using aDVanceERP.Core.Repositorios;
using aDVanceERP.Modulos.Finanzas.MVP.Modelos;

using MySql.Data.MySqlClient;

using System.Text;

namespace aDVanceERP.Modulos.Finanzas.Repositorios; 

public class RepoCuentaBancaria : RepositorioDatosEntidadBase<CuentaBancaria, FbCuentaBancaria> {
    public RepoCuentaBancaria() : base("adv__cuenta_bancaria", "id_cuenta_bancaria") { }

    public override string[] FiltrosBusqueda => UtilesBusquedaCuentaBancaria.FbCuentaBancaria;

    protected override (string Query, Dictionary<string, object> Parametros) GenerarComandoInsertar(CuentaBancaria entidad) {
        var query = $"""
            INSERT INTO {NombreTabla} (
                alias,
                numero_tarjeta,
                moneda,
                id_contacto
            )
            VALUES (
                @alias,
                @numero_tarjeta,
                @moneda,
                @id_contacto
            );
            """;

        var parametros = new Dictionary<string, object>
        {
            { "@alias", entidad.Alias ?? string.Empty },
            { "@numero_tarjeta", entidad.NumeroTarjeta ?? string.Empty },
            { "@moneda", (int)entidad.Moneda },
            { "@id_contacto", entidad.IdContacto }
        };

        return (query, parametros);
    }

    protected override (string Query, Dictionary<string, object> Parametros) GenerarComandoActualizar(CuentaBancaria entidad) {
        var query = $"""
            UPDATE {NombreTabla}
            SET
                alias = @alias,
                numero_tarjeta = @numero_tarjeta,
                moneda = @moneda,
                id_contacto = @id_contacto
            WHERE {ColumnaId} = @id;
            """;

        var parametros = new Dictionary<string, object>
        {
            { "@alias", entidad.Alias ?? string.Empty },
            { "@numero_tarjeta", entidad.NumeroTarjeta ?? string.Empty },
            { "@moneda", (int)entidad.Moneda },
            { "@id_contacto", entidad.IdContacto },
            { "@id", entidad.Id }
        };

        return (query, parametros);
    }

    protected override (string WhereClause, Dictionary<string, object> Parametros) GenerarWhereClause(FbCuentaBancaria filtroBusqueda, string? datosComplementarios) {
        var whereClause = new StringBuilder();
        var parametros = new Dictionary<string, object>();

        switch (filtroBusqueda) {
            case FbCuentaBancaria.Id:
                whereClause.Append($"{ColumnaId} = @id");
                parametros.Add("@id", datosComplementarios);
                break;
            case FbCuentaBancaria.Alias:
                whereClause.Append("alias LIKE @alias");
                parametros.Add("@alias", $"%{datosComplementarios}%");
                break;
            default:
                whereClause.Append("1=1");
                break;
        }

        return (whereClause.ToString(), parametros);
    }

    protected override CuentaBancaria MapearEntidad(MySqlDataReader lectorDatos) {
        return new CuentaBancaria(
            lectorDatos.GetInt64(lectorDatos.GetOrdinal("id_cuenta_bancaria")),
            lectorDatos.GetString(lectorDatos.GetOrdinal("alias")),
            lectorDatos.GetString(lectorDatos.GetOrdinal("numero_tarjeta")),
            (TipoMoneda) lectorDatos.GetInt32(lectorDatos.GetOrdinal("moneda")),
            lectorDatos.GetInt64(lectorDatos.GetOrdinal("id_contacto"))
        );
    }
}
