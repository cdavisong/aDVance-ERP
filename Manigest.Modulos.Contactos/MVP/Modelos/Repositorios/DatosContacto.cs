using Manigest.Core.Excepciones;
using Manigest.Core.MVP.Modelos.Repositorios;
using Manigest.Core.Utiles;
using Manigest.Modulos.Contactos.MVP.Modelos.Repositorios.Plantillas;

using MySql.Data.MySqlClient;

namespace Manigest.Modulos.Contactos.MVP.Modelos.Repositorios {
    public class DatosContacto : RepositorioDatosBase<Contacto, CriterioBusquedaContacto>, IRepositorioContacto {
        public static DatosContacto Instance { get; } = new();

        public DatosContacto() : base() { }

        public override string ComandoCantidad() {
            return "SELECT COUNT(id_contacto) FROM mg__contacto;";
        }

        public override string ComandoAdicionar(Contacto objeto) {
            return $"INSERT INTO mg__contacto (nombre, direccion_correo_electronico, direccion, notas) VALUES ('{objeto.Nombre}', '{objeto.DireccionCorreoElectronico}', '{objeto.Direccion}', '{objeto.Notas}');";
        }

        public override string ComandoEditar(Contacto objeto) {
            return $"UPDATE mg__contacto SET nombre='{objeto.Nombre}', direccion_correo_electronico='{objeto.DireccionCorreoElectronico}', direccion='{objeto.Direccion}', notas='{objeto.Notas}' WHERE id_contacto='{objeto.Id}';";
        }

        public override string ComandoEliminar(long id) {
            return $"DELETE FROM mg__contacto WHERE id_contacto='{id}';";
        }

        public override string ComandoObtener(CriterioBusquedaContacto criterio, string dato) {
            var comando = string.Empty;

            switch (criterio) {
                case CriterioBusquedaContacto.Id:
                    comando = $"SELECT * FROM mg__contacto WHERE id_contacto='{dato}';";
                    break;
                case CriterioBusquedaContacto.Nombre:
                    comando = $"SELECT * FROM mg__contacto WHERE LOWER(nombre) LIKE LOWER('%{dato}%');";
                    break;
                default:
                    comando = "SELECT * FROM mg__contacto;";
                    break;
            }

            return comando;
        }

        public override Contacto ObtenerObjetoDataReader(MySqlDataReader lectorDatos) {
            return new Contacto(
                idContacto: lectorDatos.GetInt32(lectorDatos.GetOrdinal("id_contacto")),
                nombre: lectorDatos.GetString(lectorDatos.GetOrdinal("nombre")),
                direccionCorreoElectronico: lectorDatos.GetString(lectorDatos.GetOrdinal("direccion_correo_electronico")),
                direccion: lectorDatos.GetString(lectorDatos.GetOrdinal("direccion")),
                notas: lectorDatos.GetValue(lectorDatos.GetOrdinal("notas")).ToString()
            );
        }

        public override string ComandoExiste(string dato) {
            return $"SELECT * FROM mg__contacto WHERE nombre='{dato}';";
        }
    }
}
