using Manigest.Core.MVP.Modelos.Repositorios;
using Manigest.Modulos.Contactos.MVP.Modelos.Repositorios.Plantillas;

using MySql.Data.MySqlClient;

namespace Manigest.Modulos.Contactos.MVP.Modelos.Repositorios {
    public class DatosTelefonoContacto : RepositorioDatosBase<TelefonoContacto, CriterioBusquedaTelefonoContacto>, IRepositorioTelefonoContacto {
        public static DatosTelefonoContacto Instance { get; } = new();

        public DatosTelefonoContacto() : base() { }

        public override string ComandoCantidad() {
            return "SELECT COUNT(id_telefono_contacto) FROM mg__telefono_contacto;";
        }

        public override string ComandoAdicionar(TelefonoContacto objeto) {
            return $"INSERT INTO mg__telefono_contacto (prefijo, numero, categoria, id_contacto) VALUES ('{objeto.Prefijo}', '{objeto.Numero}', '{objeto.Categoria}', '{objeto.IdContacto}');";
        }

        public override string ComandoEditar(TelefonoContacto objeto) {
            return $"UPDATE mg__telefono_contacto SET prefijo='{objeto.Prefijo}', numero='{objeto.Numero}', categoria='{objeto.Categoria}', id_contacto='{objeto.IdContacto}' WHERE id_telefono_contacto='{objeto.Id}';";
        }

        public override string ComandoEliminar(long id) {
            return $"DELETE FROM mg__telefono_contacto WHERE id_telefono_contacto={id};";
        }

        public override string ComandoObtener(CriterioBusquedaTelefonoContacto criterio, string dato) {
            var comando = string.Empty;

            switch (criterio) {
                case CriterioBusquedaTelefonoContacto.Id:
                    comando = $"SELECT * FROM mg__telefono_contacto WHERE id_telefono_contacto={dato};";
                    break;
                case CriterioBusquedaTelefonoContacto.Numero:
                    comando = $"SELECT * FROM mg__telefono_contacto WHERE numero='{dato}';";
                    break;
                case CriterioBusquedaTelefonoContacto.IdContacto:
                    comando = $"SELECT * FROM mg__telefono_contacto WHERE id_contacto={dato};";
                    break;
                default:
                    comando = "SELECT * FROM mg__telefono_contacto;";
                    break;
            }

            return comando;
        }

        public override TelefonoContacto ObtenerObjetoDataReader(MySqlDataReader lectorDatos) {
            return new TelefonoContacto(
                idTelefonoContacto: lectorDatos.GetInt32(lectorDatos.GetOrdinal("id_telefono_contacto")),
                prefijo: lectorDatos.GetString(lectorDatos.GetOrdinal("prefijo")),
                numero: lectorDatos.GetString(lectorDatos.GetOrdinal("numero")),
                categoria: (CategoriaTelefonoContacto) Enum.Parse(typeof(CategoriaTelefonoContacto), lectorDatos.GetString(lectorDatos.GetOrdinal("categoria"))),
                idContacto: lectorDatos.GetInt32(lectorDatos.GetOrdinal("id_contacto"))
            );
        }

        public override string ComandoExiste(string dato) {
            return $"SELECT * FROM mg__telefono_contacto WHERE numero='{dato}';";
        }
    }
}
