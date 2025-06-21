using aDVanceERP.Core.MVP.Modelos.Repositorios;
using aDVanceERP.Modulos.Contactos.MVP.Modelos;

using MySql.Data.MySqlClient;

using System.Text;

namespace aDVanceERP.Modulos.Contactos.Repositorios; 

public class RepoProveedor : RepositorioDatosEntidadBase<Proveedor, FbProveedor> {
    public RepoProveedor() : base("adv__proveedor", "id_proveedor") { }

    public override string[] FiltrosBusqueda => UtilesBusquedaProveedor.FbProveedor;

    protected override (string Query, Dictionary<string, object> Parametros) GenerarComandoInsertar(Proveedor entidad) {
        var query = $"""
            INSERT INTO {NombreTabla} (
                razon_social,
                nit
            )
            VALUES (
                @razon_social,
                @nit
            );
            """;

        var parametros = new Dictionary<string, object>
        {
            { "@razon_social", entidad.RazonSocial ?? string.Empty },
            { "@nit", entidad.NumeroIdentificacionTributaria ?? string.Empty }
        };

        return (query, parametros);
    }

    protected override (string Query, Dictionary<string, object> Parametros) GenerarComandoActualizar(Proveedor entidad) {
        var query = $"""
            UPDATE {NombreTabla}
            SET
                razon_social = @razon_social,
                nit = @nit
            WHERE {ColumnaId} = @id;
            """;

        var parametros = new Dictionary<string, object>
        {
            { "@razon_social", entidad.RazonSocial ?? string.Empty },
            { "@nit", entidad.NumeroIdentificacionTributaria ?? string.Empty },
            { "@id", entidad.Id }
        };

        return (query, parametros);
    }

    protected override (string WhereClause, Dictionary<string, object> Parametros) GenerarWhereClause(FbProveedor filtroBusqueda, string? datosComplementarios) {
        var whereClause = new StringBuilder();
        var parametros = new Dictionary<string, object>();

        switch (filtroBusqueda) {
            case FbProveedor.Id:
                whereClause.Append($"{ColumnaId} = @id");
                parametros.Add("@id", datosComplementarios);
                break;
            case FbProveedor.RazonSocial:
                whereClause.Append("LOWER(razon_social) LIKE LOWER(@razon_social)");
                parametros.Add("@razon_social", $"%{datosComplementarios}%");
                break;
            case FbProveedor.NIT:
                whereClause.Append("nit = @nit");
                parametros.Add("@nit", datosComplementarios);
                break;
            default:
                whereClause.Append("1=1");
                break;
        }

        return (whereClause.ToString(), parametros);
    }

    protected override Proveedor MapearEntidad(MySqlDataReader lectorDatos) {
        return new Proveedor(
            lectorDatos.GetInt64(lectorDatos.GetOrdinal("id_proveedor")),
            lectorDatos.GetString(lectorDatos.GetOrdinal("razon_social")),
            lectorDatos.GetString(lectorDatos.GetOrdinal("nit")),
            lectorDatos.GetInt64(lectorDatos.GetOrdinal("id_contacto"))
        );
    }
}
