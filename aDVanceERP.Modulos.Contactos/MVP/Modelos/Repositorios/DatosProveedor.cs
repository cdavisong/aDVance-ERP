using aDVanceERP.Core.Controladores.DB;
using aDVanceERP.Core.Excepciones;
using aDVanceERP.Core.MVP.Modelos.Repositorios;
using aDVanceERP.Core.Utiles;
using aDVanceERP.Modulos.Contactos.MVP.Modelos.Repositorios.Plantillas;
using MySql.Data.MySqlClient;

namespace aDVanceERP.Modulos.Contactos.MVP.Modelos.Repositorios; 

public class DatosProveedor : RepositorioDatosBase<Proveedor, CriterioBusquedaProveedor>, IRepositorioProveedor {
    public override string ComandoCantidad() {
        return "SELECT COUNT(id_proveedor) FROM adv__proveedor;";
    }

    public override string ComandoAdicionar(Proveedor objeto) {
        return
            $"INSERT INTO adv__proveedor (razon_social, nit, id_contacto) VALUES ('{objeto.RazonSocial}', '{objeto.NumeroIdentificacionTributaria}', '{objeto.IdContacto}');";
    }

    public override string ComandoEditar(Proveedor objeto) {
        return
            $"UPDATE adv__proveedor SET razon_social='{objeto.RazonSocial}', nit='{objeto.NumeroIdentificacionTributaria}', id_contacto='{objeto.IdContacto}' WHERE id_proveedor={objeto.Id};";
    }

    public override string ComandoEliminar(long id) {
        return $"DELETE FROM adv__proveedor WHERE id_proveedor={id};";
    }

    public override string ComandoObtener(CriterioBusquedaProveedor criterio, string dato) {
        var comando = string.Empty;

        switch (criterio) {
            case CriterioBusquedaProveedor.Id:
                comando = $"SELECT * FROM adv__proveedor WHERE id_proveedor={dato};";
                break;
            case CriterioBusquedaProveedor.RazonSocial:
                comando = $"SELECT * FROM adv__proveedor WHERE LOWER(razon_social) LIKE LOWER('%{dato}%');";
                break;
            case CriterioBusquedaProveedor.NIT:
                comando = $"SELECT * FROM adv__proveedor WHERE LOWER(nit) LIKE LOWER('%{dato}%');";
                break;
            default:
                comando = "SELECT * FROM adv__proveedor;";
                break;
        }

        return comando;
    }

    public override Proveedor ObtenerObjetoDataReader(MySqlDataReader lectorDatos) {
        return new Proveedor(
            lectorDatos.GetInt32(lectorDatos.GetOrdinal("id_proveedor")),
            lectorDatos.GetString(lectorDatos.GetOrdinal("razon_social")),
            lectorDatos.GetString(lectorDatos.GetOrdinal("nit")),
            long.TryParse(lectorDatos.GetValue(lectorDatos.GetOrdinal("id_contacto")).ToString(), out var idContacto)
                ? idContacto
                : 0
        );
    }

    public override string ComandoExiste(string dato) {
        return $"SELECT * FROM adv__proveedor WHERE razon_social='{dato}';";
    }

    // Métodos específicos adicionales
    public static string[] ObtenerRazonesSocialesProveedores() {
        var nombresProveedores = new List<string>();

        using (var conexion = new MySqlConnection(ConectorDB.ConfServidorMySQL.ToString())) {
            try {
                conexion.Open();
            }
            catch (Exception) {
                throw new ExcepcionConexionServidorMySQL();
            }

            using (var comando = conexion.CreateCommand()) {
                comando.CommandText = "SELECT razon_social FROM adv__proveedor;";

                using (var lectorDatos = comando.ExecuteReader()) {
                    if (lectorDatos != null)
                        while (lectorDatos.Read())
                            nombresProveedores.Add(lectorDatos.GetString(lectorDatos.GetOrdinal("razon_social")));
                }
            }
        }

        return nombresProveedores.ToArray();
    }
}