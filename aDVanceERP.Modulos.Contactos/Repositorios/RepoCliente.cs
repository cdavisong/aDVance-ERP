using aDVanceERP.Core.MVP.Modelos.Repositorios;
using aDVanceERP.Modulos.Contactos.MVP.Modelos;

using MySql.Data.MySqlClient;

using System.Text;

namespace aDVanceERP.Modulos.Contactos.Repositorios; 

public class RepoCliente : RepositorioDatosEntidadBase<Cliente, FbCliente> {
    public RepoCliente() : base("adv__cliente", "id_cliente") { }

    public override string[] FiltrosBusqueda => UtilesBusquedaCliente.FbCliente;

    protected override (string Query, Dictionary<string, object> Parametros) GenerarComandoInsertar(Cliente entidad) {
        var query = $"""
            INSERT INTO {NombreTabla} (
                numero,
                razon_social,
                id_contacto
            )
            VALUES (
                @numero,
                @razon_social,
                @id_contacto
            );
            """;

        var parametros = new Dictionary<string, object>
        {
            { "@numero", entidad.Numero ?? string.Empty },
            { "@razon_social", entidad.RazonSocial ?? string.Empty },
            { "@id_contacto", entidad.IdContacto }
        };

        return (query, parametros);
    }

    protected override (string Query, Dictionary<string, object> Parametros) GenerarComandoActualizar(Cliente entidad) {
        var query = $"""
            UPDATE {NombreTabla}
            SET
                numero = @numero,
                razon_social = @razon_social,
                id_contacto = @id_contacto
            WHERE {ColumnaId} = @id;
            """;

        var parametros = new Dictionary<string, object>
        {
            { "@numero", entidad.Numero ?? string.Empty },
            { "@razon_social", entidad.RazonSocial ?? string.Empty },
            { "@id_contacto", entidad.IdContacto },
            { "@id", entidad.Id }
        };

        return (query, parametros);
    }

    protected override (string WhereClause, Dictionary<string, object> Parametros) GenerarWhereClause(FbCliente filtroBusqueda, string? datosComplementarios) {
        var whereClause = new StringBuilder();
        var parametros = new Dictionary<string, object>();

        switch (filtroBusqueda) {
            case FbCliente.Id:
                whereClause.Append($"{ColumnaId} = @id");
                parametros.Add("@id", datosComplementarios);
                break;
            case FbCliente.RazonSocial:
                whereClause.Append("LOWER(razon_social) LIKE LOWER(@razon_social)");
                parametros.Add("@razon_social", $"%{datosComplementarios}%");
                break;
            case FbCliente.Numero:
                whereClause.Append("LOWER(numero) LIKE LOWER(@numero)");
                parametros.Add("@numero", $"%{datosComplementarios}%");
                break;
            default:
                whereClause.Append("1=1");
                break;
        }

        return (whereClause.ToString(), parametros);
    }

    protected override Cliente MapearEntidad(MySqlDataReader lectorDatos) {
        return new Cliente(
            lectorDatos.GetInt64(lectorDatos.GetOrdinal("id_cliente")),
            lectorDatos.GetString(lectorDatos.GetOrdinal("numero")),
            lectorDatos.GetString(lectorDatos.GetOrdinal("razon_social")),
            lectorDatos.GetInt64(lectorDatos.GetOrdinal("id_contacto"))
        );
    }
}
