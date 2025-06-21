using aDVanceERP.Core.MVP.Modelos.Repositorios;
using aDVanceERP.Modulos.Contactos.MVP.Modelos;

using MySql.Data.MySqlClient;

namespace aDVanceERP.Modulos.Contactos.Repositorios;

public class RepoMensajero : RepositorioDatosEntidadBase<Mensajero, FbMensajero> {
    public RepoMensajero() : base("adv__mensajero", "id_mensajero") { }

    public override string[] FiltrosBusqueda => UtilesBusquedaMensajero.FbMensajero;

    protected override (string Query, Dictionary<string, object> Parametros) GenerarComandoInsertar(Mensajero entidad) {
        var query = $"""
            INSERT INTO {NombreTabla} (
                nombre,
                activo,
                id_contacto
            )
            VALUES (
                @nombre,
                @activo,
                @id_contacto
            );
            """;

        var parametros = new Dictionary<string, object>
        {
            { "@nombre", entidad.Nombre ?? string.Empty },
            { "@activo", entidad.Activo },
            { "@id_contacto", entidad.IdContacto }
        };

        return (query, parametros);
    }

    protected override (string Query, Dictionary<string, object> Parametros) GenerarComandoActualizar(Mensajero entidad) {
        var query = $"""
            UPDATE {NombreTabla}
            SET
                nombre = @nombre,
                activo = @activo,
                id_contacto = @id_contacto
            WHERE {ColumnaId} = @id;
            """;

        var parametros = new Dictionary<string, object>
        {
            { "@nombre", entidad.Nombre ?? string.Empty },
            { "@activo", entidad.Activo },
            { "@id_contacto", entidad.IdContacto },
            { "@id", entidad.Id }
        };

        return (query, parametros);
    }

    protected override (string WhereClause, Dictionary<string, object> Parametros) GenerarWhereClause(FbMensajero filtroBusqueda, string? datosComplementarios) {
        var whereClause = new System.Text.StringBuilder();
        var parametros = new Dictionary<string, object>();

        switch (filtroBusqueda) {
            case FbMensajero.Id:
                whereClause.Append($"{ColumnaId} = @id");
                parametros.Add("@id", datosComplementarios);
                break;
            case FbMensajero.Nombre:
                whereClause.Append("LOWER(nombre) LIKE LOWER(@nombre)");
                parametros.Add("@nombre", $"%{datosComplementarios}%");
                break;
            default:
                whereClause.Append("1=1");
                break;
        }

        return (whereClause.ToString(), parametros);
    }

    protected override Mensajero MapearEntidad(MySqlDataReader lectorDatos) {
        return new Mensajero(
            lectorDatos.GetInt64(lectorDatos.GetOrdinal("id_mensajero")),
            lectorDatos.GetString(lectorDatos.GetOrdinal("nombre")),
            lectorDatos.GetBoolean(lectorDatos.GetOrdinal("activo")),
            lectorDatos.GetInt64(lectorDatos.GetOrdinal("id_contacto"))
        );
    }
}
