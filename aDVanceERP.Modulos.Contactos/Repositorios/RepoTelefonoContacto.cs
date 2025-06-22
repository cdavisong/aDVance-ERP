using aDVanceERP.Core.Repositorios;
using aDVanceERP.Modulos.Contactos.MVP.Modelos;

using MySql.Data.MySqlClient;

using System.Text;

namespace aDVanceERP.Modulos.Contactos.Repositorios; 

public class RepoTelefonoContacto : RepositorioDatosEntidadBase<TelefonoContacto, FbTelefonoContacto> {
    public RepoTelefonoContacto() : base("adv__telefono_contacto", "id_telefono_contacto") { }

    public override string[] FiltrosBusqueda => UtilesBusquedaContacto.FbContacto;

    protected override (string Query, Dictionary<string, object> Parametros) GenerarComandoInsertar(TelefonoContacto entidad) {
        var query = $"""
            INSERT INTO {NombreTabla} (
                prefijo,
                numero,
                categoria,
                id_contacto
            )
            VALUES (
                @prefijo,
                @numero,
                @categoria,
                @id_contacto
            );
            """;

        var parametros = new Dictionary<string, object>
        {
            { "@prefijo", entidad.Prefijo ?? string.Empty },
            { "@numero", entidad.Numero ?? string.Empty },
            { "@categoria", entidad.Categoria.ToString() },
            { "@id_contacto", entidad.IdContacto }
        };

        return (query, parametros);
    }

    protected override (string Query, Dictionary<string, object> Parametros) GenerarComandoActualizar(TelefonoContacto entidad) {
        var query = $"""
            UPDATE {NombreTabla}
            SET
                prefijo = @prefijo,
                numero = @numero,
                categoria = @categoria,
                id_contacto = @id_contacto
            WHERE {ColumnaId} = @id;
            """;

        var parametros = new Dictionary<string, object>
        {
            { "@prefijo", entidad.Prefijo ?? string.Empty },
            { "@numero", entidad.Numero ?? string.Empty },
            { "@categoria", entidad.Categoria.ToString() },
            { "@id_contacto", entidad.IdContacto },
            { "@id", entidad.Id }
        };

        return (query, parametros);
    }

    protected override (string WhereClause, Dictionary<string, object> Parametros) GenerarWhereClause(FbTelefonoContacto filtroBusqueda, string? datosComplementarios) {
        var whereClause = new StringBuilder();
        var parametros = new Dictionary<string, object>();

        switch (filtroBusqueda) {
            case FbTelefonoContacto.Id:
                whereClause.Append($"{ColumnaId} = @id");
                parametros.Add("@id", datosComplementarios);
                break;
            case FbTelefonoContacto.Numero:
                whereClause.Append("numero = @numero");
                parametros.Add("@numero", datosComplementarios);
                break;
            case FbTelefonoContacto.IdContacto:
                whereClause.Append("id_contacto = @id_contacto");
                parametros.Add("@id_contacto", datosComplementarios);
                break;
            default:
                whereClause.Append("1=1");
                break;
        }

        return (whereClause.ToString(), parametros);
    }

    protected override TelefonoContacto MapearEntidad(MySqlDataReader lectorDatos) {
        return new TelefonoContacto(
            lectorDatos.GetInt64(lectorDatos.GetOrdinal("id_telefono_contacto")),
            lectorDatos.GetString(lectorDatos.GetOrdinal("prefijo")),
            lectorDatos.GetString(lectorDatos.GetOrdinal("numero")),
            (CategoriaTelefonoContacto) Enum.Parse(typeof(CategoriaTelefonoContacto), lectorDatos.GetString(lectorDatos.GetOrdinal("categoria"))),
            lectorDatos.GetInt64(lectorDatos.GetOrdinal("id_contacto"))
        );
    }
}
