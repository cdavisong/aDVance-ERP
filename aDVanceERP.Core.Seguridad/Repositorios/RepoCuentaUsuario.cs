using aDVanceERP.Core.MVP.Modelos.Repositorios;
using aDVanceERP.Core.Seguridad.MVP.Modelos;
using MySql.Data.MySqlClient;
using System.Text;

namespace aDVanceERP.Core.Seguridad.Repositorios;

public class RepoCuentaUsuario : RepositorioDatosEntidadBase<CuentaUsuario, FbCuentaUsuario> {
    public RepoCuentaUsuario() : base("adv__cuenta_usuario", "id_cuenta_usuario") {
    }

    public override string[] FiltrosBusqueda => UtilesBusquedaCuentaUsuario.FbCuentasUsuarios;

    protected override (string Query, Dictionary<string, object> Parametros) GenerarComandoInsertar(CuentaUsuario entidad) {
        var query = $"""
                INSERT INTO {NombreTabla} (
                    nombre, 
                    password_hash, 
                    password_salt, 
                    id_rol_usuario, 
                    administrador, 
                    aprobado
                )
                VALUES (
                    @nombre, 
                    @password_hash, 
                    @password_salt, 
                    @id_rol_usuario, 
                    @administrador, 
                    @aprobado
                );
                """;

        var parametros = new Dictionary<string, object>
        {
            { "@nombre", entidad.Nombre },
            { "@password_hash", entidad.PasswordHash },
            { "@password_salt", entidad.PasswordSalt },
            { "@id_rol_usuario", entidad.IdRolUsuario },
            { "@administrador", entidad.Administrador },
            { "@aprobado", entidad.Aprobado }
        };

        return (query, parametros);
    }

    protected override (string Query, Dictionary<string, object> Parametros) GenerarComandoActualizar(CuentaUsuario entidad) {
        var query =
           $"""
            UPDATE {NombreTabla} 
            SET 
                nombre = @nombre, 
                password_hash = @password_hash, 
                password_salt = @password_salt, 
                id_rol_usuario = @id_rol_usuario, 
                administrador = @administrador
            WHERE {ColumnaId} = @id;
            """;

        var parametros = new Dictionary<string, object> {
            { "@nombre", entidad.Nombre },
            { "@password_hash", entidad.PasswordHash },
            { "@password_salt", entidad.PasswordSalt },
            { "@id_rol_usuario", entidad.IdRolUsuario },
            { "@administrador", entidad.Administrador },
            { "@id", entidad.Id }
        };

        return (query, parametros);
    }

    protected override (string WhereClause, Dictionary<string, object> Parametros) GenerarWhereClause(FbCuentaUsuario filtroBusqueda, string? datosComplementarios) {
        var whereClause = new StringBuilder();
        var parametros = new Dictionary<string, object>();

        switch (filtroBusqueda) {
            case FbCuentaUsuario.Id:
                whereClause.Append($"{ColumnaId} = @id");
                parametros.Add("@id", $"{datosComplementarios}");
                break;
            case FbCuentaUsuario.Nombre:
                whereClause.Append("LOWER(nombre) LIKE LOWER(@nombre)");
                parametros.Add("@nombre", $"%{datosComplementarios}%");
                break;
            case FbCuentaUsuario.Rol:
                whereClause.Append("id_rol_usuario = @id_rol_usuario");
                parametros.Add("@id_rol_usuario", $"{datosComplementarios}");
                break;
            default:
                whereClause.Append("1=1");
                break;

        }

        return (whereClause.ToString(), parametros);
    }

    protected override CuentaUsuario MapearEntidad(MySqlDataReader lectorDatos) {
        return new CuentaUsuario(
            lectorDatos.GetInt64("id_cuenta_usuario"),
            lectorDatos.GetString("nombre"),
            lectorDatos.GetString("password_hash"),
            lectorDatos.GetString("password_salt"),
            lectorDatos.GetInt64("id_rol_usuario")) {
            Administrador = lectorDatos.GetBoolean("administrador"),
            Aprobado = lectorDatos.GetBoolean("aprobado")
        };
    }
}