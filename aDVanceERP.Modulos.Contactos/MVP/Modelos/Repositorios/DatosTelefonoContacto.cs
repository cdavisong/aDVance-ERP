using aDVanceERP.Core.Repositorios.BD;
using aDVanceERP.Modulos.Contactos.MVP.Modelos.Repositorios.Plantillas;
using MySql.Data.MySqlClient;

namespace aDVanceERP.Modulos.Contactos.MVP.Modelos.Repositorios;

public class DatosTelefonoContacto : RepoEntidadBaseDatos<TelefonoContacto, FiltroBusquedaTelefonoContacto>,
    IRepositorioTelefonoContacto {
    public override string ComandoCantidad() {
        return "SELECT COUNT(id_telefono_contacto) FROM adv__telefono_contacto;";
    }

    public override string ComandoAdicionar(TelefonoContacto objeto) {
        return
            $"INSERT INTO adv__telefono_contacto (prefijo, numero, categoria, id_contacto) VALUES ('{objeto.Prefijo}', '{objeto.Numero}', '{objeto.Categoria}', '{objeto.IdContacto}');";
    }

    public override string ComandoEditar(TelefonoContacto objeto) {
        return
            $"UPDATE adv__telefono_contacto SET prefijo='{objeto.Prefijo}', numero='{objeto.Numero}', categoria='{objeto.Categoria}', id_contacto='{objeto.IdContacto}' WHERE id_telefono_contacto='{objeto.Id}';";
    }

    public override string ComandoEliminar(long id) {
        return $"DELETE FROM adv__telefono_contacto WHERE id_telefono_contacto={id};";
    }

    public override string ComandoObtener(FiltroBusquedaTelefonoContacto criterio, string dato) {
        var comando = string.Empty;

        switch (criterio) {
            case FiltroBusquedaTelefonoContacto.Id:
                comando = $"SELECT * FROM adv__telefono_contacto WHERE id_telefono_contacto={dato};";
                break;
            case FiltroBusquedaTelefonoContacto.Numero:
                comando = $"SELECT * FROM adv__telefono_contacto WHERE numero='{dato}';";
                break;
            case FiltroBusquedaTelefonoContacto.IdContacto:
                comando = $"SELECT * FROM adv__telefono_contacto WHERE id_contacto={dato};";
                break;
            default:
                comando = "SELECT * FROM adv__telefono_contacto;";
                break;
        }

        return comando;
    }

    public override TelefonoContacto MapearEntidad(MySqlDataReader lectorDatos) {
        return new TelefonoContacto(
            lectorDatos.GetInt32(lectorDatos.GetOrdinal("id_telefono_contacto")),
            lectorDatos.GetString(lectorDatos.GetOrdinal("prefijo")),
            lectorDatos.GetString(lectorDatos.GetOrdinal("numero")),
            (CategoriaTelefonoContacto)Enum.Parse(typeof(CategoriaTelefonoContacto),
                lectorDatos.GetString(lectorDatos.GetOrdinal("categoria"))),
            lectorDatos.GetInt32(lectorDatos.GetOrdinal("id_contacto"))
        );
    }

    public override string ComandoExiste(string dato) {
        return $"SELECT * FROM adv__telefono_contacto WHERE numero='{dato}';";
    }
}