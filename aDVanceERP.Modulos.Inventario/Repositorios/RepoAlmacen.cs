using aDVanceERP.Core.Repositorios;
using aDVanceERP.Modulos.Inventario.MVP.Modelos;

using MySql.Data.MySqlClient;

namespace aDVanceERP.Modulos.Inventario.Repositorios; 


public class RepoAlmacen : RepositorioDatosEntidadBase<Almacen, FbAlmacen> {
    public RepoAlmacen() : base("adv__almacen", "id_almacen") { }

    public override string[] FiltrosBusqueda => UtilesBusquedaAlmacen.FbAlmacen;

    protected override (string Query, Dictionary<string, object> Parametros) GenerarComandoInsertar(Almacen entidad) {
        var query = $"""
            INSERT INTO {NombreTabla} (
                nombre, 
                direccion, 
                autorizo_venta, 
                notas
            ) 
            VALUES (
                @nombre, 
                @direccion, 
                @autorizo_venta,
                @notas
            );
            """;
        var parametros = new Dictionary<string, object>
        {
            { "@nombre", entidad.Nombre ?? string.Empty },
            { "@direccion", entidad.Direccion ?? string.Empty },
            { "@autorizo_venta", entidad.AutorizoVenta ? 1 : 0 },
            { "@notas", entidad.Notas ?? string.Empty }
        };
        return (query, parametros);
    }

    protected override (string Query, Dictionary<string, object> Parametros) GenerarComandoActualizar(Almacen entidad) {
        var query = $"""
            UPDATE {NombreTabla} 
            SET 
                nombre = @nombre, 
                direccion = @direccion, 
                autorizo_venta = @autorizo_venta, 
                notas = @notas 
            WHERE {ColumnaId} = @id;
            """;
        var parametros = new Dictionary<string, object>
        {
            { "@nombre", entidad.Nombre ?? string.Empty },
            { "@direccion", entidad.Direccion ?? string.Empty },
            { "@autorizo_venta", entidad.AutorizoVenta ? 1 : 0 },
            { "@notas", entidad.Notas ?? string.Empty },
            { "@id", entidad.Id }
        };
        return (query, parametros);
    }

    protected override (string WhereClause, Dictionary<string, object> Parametros) GenerarWhereClause(FbAlmacen filtroBusqueda, string? datosComplementarios) {
        var parametros = new Dictionary<string, object>();
        string where = string.Empty;

        switch (filtroBusqueda) {
            case FbAlmacen.Id:
                where = "id_almacen = @id";
                parametros.Add("@id", long.TryParse(datosComplementarios, out var id) ? id : 0);
                break;
            case FbAlmacen.Nombre:
                where = "LOWER(nombre) LIKE LOWER(@nombre)";
                parametros.Add("@nombre", $"%{datosComplementarios}%");
                break;
            default:
                where = "1=1";
                break;
        }

        return (where, parametros);
    }

    protected override Almacen MapearEntidad(MySqlDataReader lectorDatos) {
        return new Almacen(
            lectorDatos.GetInt32(lectorDatos.GetOrdinal("id_almacen")),
            lectorDatos.GetString(lectorDatos.GetOrdinal("nombre")),
            lectorDatos.GetString(lectorDatos.GetOrdinal("direccion")),
            lectorDatos.GetBoolean(lectorDatos.GetOrdinal("autorizo_venta")),
            lectorDatos.GetString(lectorDatos.GetOrdinal("notas"))
        );
    }
}
