using aDVanceERP.Core.Repositorios.BD;
using aDVanceERP.Modulos.Contactos.MVP.Modelos.Repositorios.Plantillas;
using MySql.Data.MySqlClient;

namespace aDVanceERP.Modulos.Contactos.MVP.Modelos.Repositorios;

public class DatosCliente : RepoEntidadBaseDatos<Cliente, FiltroBusquedaCliente>, IRepositorioCliente {
    public override string ComandoCantidad() {
        return "SELECT COUNT(id_cliente) FROM adv__cliente;";
    }

    public override string GenerarComandoInsertar(Cliente objeto) {
        return $"INSERT INTO adv__cliente (numero, razon_social, id_contacto) VALUES ('{objeto.Numero}', '{objeto.RazonSocial}', '{objeto.IdContacto}');";
    }

    public override string GenerarComandoActualizar(Cliente objeto) {
        return $"UPDATE adv__cliente SET numero='{objeto.Numero}', razon_social='{objeto.RazonSocial}', id_contacto='{objeto.IdContacto}' WHERE id_cliente='{objeto.Id}';";
    }

    public override string ComandoEliminar(long id) {
        return $"DELETE FROM adv__cliente WHERE id_cliente={id};";
    }

    public override string GenerarClausulaWhere(FiltroBusquedaCliente criterio, string dato) {
        string? comando;

        switch (criterio) {
            case FiltroBusquedaCliente.Id:
                comando = $"SELECT * FROM adv__cliente WHERE id_cliente='{dato}';";
                break;
            case FiltroBusquedaCliente.RazonSocial:
                comando = $"SELECT * FROM adv__cliente WHERE LOWER(razon_social) LIKE LOWER('%{dato}%');";
                break;
            case FiltroBusquedaCliente.Numero:
                comando = $"SELECT * FROM adv__cliente WHERE LOWER(numero) LIKE LOWER('%{dato}%');";
                break;
            default:
                comando = "SELECT * FROM adv__cliente;";
                break;
        }

        return comando;
    }

    public override Cliente MapearEntidad(MySqlDataReader lectorDatos) {
        return new Cliente(
            lectorDatos.GetInt32(lectorDatos.GetOrdinal("id_cliente")),
            lectorDatos.GetString(lectorDatos.GetOrdinal("numero")),
            lectorDatos.GetString(lectorDatos.GetOrdinal("razon_social")),
            long.TryParse(lectorDatos.GetValue(lectorDatos.GetOrdinal("id_contacto")).ToString(), out var idContacto)
                ? idContacto
                : 0
        );
    }

    public override string ComandoExiste(string dato) {
        return $"SELECT * FROM adv__cliente WHERE numero='{dato}';";
    }
}