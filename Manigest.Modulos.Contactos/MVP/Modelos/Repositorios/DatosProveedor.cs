using Manigest.Core.Excepciones;
using Manigest.Core.MVP.Modelos.Repositorios;
using Manigest.Core.Utiles;
using Manigest.Modulos.Contactos.MVP.Modelos.Repositorios.Plantillas;

using MySql.Data.MySqlClient;

namespace Manigest.Modulos.Contactos.MVP.Modelos.Repositorios {
    public class DatosProveedor : RepositorioDatosBase<Proveedor, CriterioBusquedaProveedor>, IRepositorioProveedor {
        public static DatosProveedor Instance { get; } = new();

        public DatosProveedor() : base() { }

        public override string ComandoCantidad() {
            return "SELECT COUNT(id_proveedor) FROM mg__proveedor;";
        }

        public override string ComandoAdicionar(Proveedor objeto) {
            return $"INSERT INTO mg__proveedor (razon_social, nit, id_contacto) VALUES ('{objeto.RazonSocial}', '{objeto.NumeroIdentificacionTributaria}', '{objeto.IdContactoRepresentante}');";
        }

        public override string ComandoEditar(Proveedor objeto) {
            return $"UPDATE mg__proveedor SET razon_social='{objeto.RazonSocial}', nit='{objeto.NumeroIdentificacionTributaria}', id_contacto='{objeto.IdContactoRepresentante}' WHERE id_proveedor={objeto.Id};";
        }

        public override string ComandoEliminar(long id) {
            return $"DELETE FROM mg__proveedor WHERE id_proveedor={id};";
        }

        public override string ComandoObtener(CriterioBusquedaProveedor criterio, string dato) {
            var comando = string.Empty;

            switch (criterio) {
                case CriterioBusquedaProveedor.Id:
                    comando = $"SELECT * FROM mg__proveedor WHERE id_proveedor={dato};";
                    break;
                case CriterioBusquedaProveedor.RazonSocial:
                    comando = $"SELECT * FROM mg__proveedor WHERE LOWER(razon_social) LIKE LOWER('%{dato}%');";
                    break;
                case CriterioBusquedaProveedor.NIT:
                    comando = $"SELECT * FROM mg__proveedor WHERE nit='{dato}';";
                    break;
                default:
                    comando = "SELECT * FROM mg__proveedor;";
                    break;
            }

            return comando;
        }

        public override Proveedor ObtenerObjetoDataReader(MySqlDataReader lectorDatos) {
            return new Proveedor(
                idProveedor: lectorDatos.GetInt32(lectorDatos.GetOrdinal("id_proveedor")),
                razonSocial: lectorDatos.GetString(lectorDatos.GetOrdinal("razon_social")),
                numeroIdentificacionTributaria: lectorDatos.GetString(lectorDatos.GetOrdinal("nit")),
                idContactoRepresentante: long.TryParse(lectorDatos.GetValue(lectorDatos.GetOrdinal("id_contacto")).ToString(), out var idContacto) ? idContacto : 0
            );
        }

        public override string ComandoExiste(string dato) {
            return $"SELECT * FROM mg__proveedor WHERE razon_social='{dato}';";
        }

        // Métodos específicos adicionales
        public static string[] ObtenerRazonesSocialesProveedores() {
            var nombresProveedores = new List<string>();

            using (var conexion = new MySqlConnection(UtilesConfServidores.ObtenerStringConfServidorMySQL())) {
                try {
                    conexion.Open();
                } catch (Exception) {
                    throw new ExcepcionConexionServidorMySQL();
                }

                using (var comando = conexion.CreateCommand()) {
                    comando.CommandText = "SELECT razon_social FROM mg__proveedor;";

                    using (var lectorDatos = comando.ExecuteReader()) {
                        if (lectorDatos != null) {
                            while (lectorDatos.Read()) {
                                nombresProveedores.Add(lectorDatos.GetString(lectorDatos.GetOrdinal("razon_social")));
                            }
                        }
                    }
                }
            }

            return nombresProveedores.ToArray();
        }
    }
}
