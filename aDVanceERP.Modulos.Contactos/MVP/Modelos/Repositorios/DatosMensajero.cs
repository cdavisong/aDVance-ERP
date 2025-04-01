using aDVanceERP.Core.MVP.Modelos.Repositorios;
using aDVanceERP.Modulos.Contactos.MVP.Modelos.Repositorios.Plantillas;
using MySql.Data.MySqlClient;

namespace aDVanceERP.Modulos.Contactos.MVP.Modelos.Repositorios; 

public class DatosMensajero : RepositorioDatosBase<Mensajero, CriterioBusquedaMensajero>, IRepositorioMensajero {
    public override string ComandoCantidad() {
        return """
               SELECT 
                COUNT(id_mensajero) 
               FROM adv__mensajero;
               """;
    }

    public override string ComandoAdicionar(Mensajero objeto) {
        return $"""
                INSERT INTO adv__mensajero (
                    nombre, 
                    activo, 
                    id_contacto
                ) 
                VALUES (
                    '{objeto.Nombre}', 
                    '{(objeto.Activo ? 1 : 0)}', 
                    '{objeto.IdContacto}'
                );
                """;
    }

    public override string ComandoEditar(Mensajero objeto) {
        return $"""
                UPDATE adv__mensajero
                SET 
                    nombre='{objeto.Nombre}',
                    activo='{(objeto.Activo ? 1 : 0)}',
                    id_contacto='{objeto.IdContacto}'
                WHERE id_mensajero='{objeto.Id}';
                """;
    }

    public override string ComandoEliminar(long id) {
        return $"""
                DELETE FROM adv__mensajero
                WHERE id_mensajero={id};
                """;
    }

    public override string ComandoObtener(CriterioBusquedaMensajero criterio, string dato) {
        var comando = string.Empty;

        switch (criterio) {
            case CriterioBusquedaMensajero.Id:
                comando = $"""
                           SELECT * 
                           FROM adv__mensajero 
                           WHERE id_mensajero={dato};
                           """;
                break;
            case CriterioBusquedaMensajero.Nombre:
                comando = $"""
                             SELECT * 
                             FROM adv__mensajero 
                             WHERE LOWER(nombre) LIKE LOWER('%{dato}%');
                            """;
                break;
            default:
                comando = """
                          SELECT * 
                          FROM adv__mensajero;
                          """;
                break;
        }

        return comando;
    }

    public override Mensajero ObtenerObjetoDataReader(MySqlDataReader lectorDatos) {
        return new Mensajero(
            id: lectorDatos.GetInt32(lectorDatos.GetOrdinal("id_mensajero")),
            nombre: lectorDatos.GetString(lectorDatos.GetOrdinal("nombre")),
            activo: lectorDatos.GetBoolean(lectorDatos.GetOrdinal("activo")),
            idContacto: long.TryParse(lectorDatos.GetValue(lectorDatos.GetOrdinal("id_contacto")).ToString(), out var idContacto) ? idContacto : 0
            );
    }

    public override string ComandoExiste(string dato) {
        return $"""
                SELECT * 
                FROM adv__mensajero 
                WHERE nombre='{dato}';
                """;
    }
}