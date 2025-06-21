using aDVanceERP.Core.MVP.Modelos.Repositorios;
using aDVanceERP.Modulos.Contactos.MVP.Modelos;

using MySql.Data.MySqlClient;

using System.Text;

namespace aDVanceERP.Modulos.Contactos.Repositorios; 

public class RepoContacto : RepositorioDatosEntidadBase<Contacto, FbContacto> {
    public RepoContacto() : base("adv__contacto", "id_contacto") { }

    public override string[] FiltrosBusqueda => new[] {
        "Todos",
        "Id",
        "Nombre",
        "Correo"
    };

    protected override (string Query, Dictionary<string, object> Parametros) GenerarComandoInsertar(Contacto entidad) {
        var query = $"""
            INSERT INTO {NombreTabla} (
                nombre,
                direccion_correo_electronico,
                direccion,
                notas
            )
            VALUES (
                @nombre,
                @correo,
                @direccion,
                @notas
            );
            """;

        var parametros = new Dictionary<string, object>
        {
            { "@nombre", entidad.Nombre ?? string.Empty },
            { "@correo", entidad.DireccionCorreoElectronico ?? string.Empty },
            { "@direccion", entidad.Direccion ?? string.Empty },
            { "@notas", entidad.Notas ?? string.Empty }
        };

        return (query, parametros);
    }

    protected override (string Query, Dictionary<string, object> Parametros) GenerarComandoActualizar(Contacto entidad) {
        var query = $"""
            UPDATE {NombreTabla}
            SET
                nombre = @nombre,
                direccion_correo_electronico = @correo,
                direccion = @direccion,
                notas = @notas
            WHERE {ColumnaId} = @id;
            """;

        var parametros = new Dictionary<string, object>
        {
            { "@nombre", entidad.Nombre ?? string.Empty },
            { "@correo", entidad.DireccionCorreoElectronico ?? string.Empty },
            { "@direccion", entidad.Direccion ?? string.Empty },
            { "@notas", entidad.Notas ?? string.Empty },
            { "@id", entidad.Id }
        };

        return (query, parametros);
    }

    protected override (string WhereClause, Dictionary<string, object> Parametros) GenerarWhereClause(FbContacto filtroBusqueda, string? datosComplementarios) {
        var whereClause = new StringBuilder();
        var parametros = new Dictionary<string, object>();

        switch (filtroBusqueda) {
            case FbContacto.Id:
                whereClause.Append($"{ColumnaId} = @id");
                parametros.Add("@id", datosComplementarios);
                break;
            case FbContacto.Nombre:
                whereClause.Append("LOWER(nombre) LIKE LOWER(@nombre)");
                parametros.Add("@nombre", $"%{datosComplementarios}%");
                break;
            case FbContacto.CorreoElectronico:
                whereClause.Append("LOWER(direccion_correo_electronico) LIKE LOWER(@correo)");
                parametros.Add("@correo", $"%{datosComplementarios}%");
                break;
            default:
                whereClause.Append("1=1");
                break;
        }

        return (whereClause.ToString(), parametros);
    }

    protected override Contacto MapearEntidad(MySqlDataReader lectorDatos) {
        return new Contacto(
            lectorDatos.GetInt64(lectorDatos.GetOrdinal("id_contacto")),
            lectorDatos.GetString(lectorDatos.GetOrdinal("nombre")),
            lectorDatos.IsDBNull(lectorDatos.GetOrdinal("direccion_correo_electronico")) ? null : lectorDatos.GetString(lectorDatos.GetOrdinal("direccion_correo_electronico")),
            lectorDatos.IsDBNull(lectorDatos.GetOrdinal("direccion")) ? null : lectorDatos.GetString(lectorDatos.GetOrdinal("direccion")),
            lectorDatos.IsDBNull(lectorDatos.GetOrdinal("notas")) ? null : lectorDatos.GetString(lectorDatos.GetOrdinal("notas"))
        );
    }
}
