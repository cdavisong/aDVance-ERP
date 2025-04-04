using aDVanceERP.Core.MVP.Modelos.Repositorios;
using aDVanceERP.Modulos.Contactos.MVP.Modelos.Repositorios.Plantillas;
using MySql.Data.MySqlClient;

namespace aDVanceERP.Modulos.Contactos.MVP.Modelos.Repositorios; 

public class DatosContacto : RepositorioDatosBase<Contacto, CriterioBusquedaContacto>, IRepositorioContacto {
    public override string ComandoCantidad() {
        return """
               SELECT
                COUNT(id_contacto)
               FROM adv__contacto;
               """;
    }

    public override string ComandoAdicionar(Contacto objeto) {
        return $"""
                INSERT INTO adv__contacto (
                    nombre,
                    direccion_correo_electronico,
                    direccion,
                    notas
                )
                VALUES (
                    '{objeto.Nombre}',
                    '{objeto.DireccionCorreoElectronico}',
                    '{objeto.Direccion}',
                    '{objeto.Notas}'
                );
                """;
    }

    public override string ComandoEditar(Contacto objeto) {
        return $"""
                UPDATE adv__contacto
                SET
                    nombre='{objeto.Nombre}',
                    direccion_correo_electronico='{objeto.DireccionCorreoElectronico}',
                    direccion='{objeto.Direccion}',
                    notas='{objeto.Notas}'
                WHERE id_contacto='{objeto.Id}';
                """;
    }

    public override string ComandoEliminar(long id) {
        return $"""
                DELETE FROM adv__contacto
                WHERE id_contacto='{id}';

                DELETE FROM adv__telefono_contacto
                WHERE id_contacto='{id}';

                UPDATE adv__proveedor
                SET
                    id_contacto=0
                WHERE id_contacto='{id}';

                UPDATE adv__mensajero
                SET
                    id_contacto=0
                WHERE id_contacto='{id}';

                UPDATE adv__cliente
                SET
                    id_contacto=0
                WHERE id_contacto='{id}';
                """;
    }

    public override string ComandoObtener(CriterioBusquedaContacto criterio, string dato) {
        var comando = string.Empty;

        switch (criterio) {
            case CriterioBusquedaContacto.Id:
                comando = $"SELECT * FROM adv__contacto WHERE id_contacto='{dato}';";
                break;
            case CriterioBusquedaContacto.Nombre:
                comando = $"SELECT * FROM adv__contacto WHERE LOWER(nombre) LIKE LOWER('%{dato}%');";
                break;
            default:
                comando = "SELECT * FROM adv__contacto;";
                break;
        }

        return comando;
    }

    public override Contacto ObtenerObjetoDataReader(MySqlDataReader lectorDatos) {
        return new Contacto(
            lectorDatos.GetInt32(lectorDatos.GetOrdinal("id_contacto")),
            lectorDatos.GetString(lectorDatos.GetOrdinal("nombre")),
            lectorDatos.GetString(lectorDatos.GetOrdinal("direccion_correo_electronico")),
            lectorDatos.GetString(lectorDatos.GetOrdinal("direccion")),
            lectorDatos.GetValue(lectorDatos.GetOrdinal("notas")).ToString()
        );
    }

    public override string ComandoExiste(string dato) {
        return $"SELECT * FROM adv__contacto WHERE nombre='{dato}';";
    }
}