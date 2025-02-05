namespace Manigest.Modulos.Inventario.MVP.Modelos.Repositorios {
    using Manigest.Core.MVP.Modelos.Repositorios;
    using Manigest.Modulos.Inventario.MVP.Modelos.Repositorios.Plantillas;

    using MySql.Data.MySqlClient;

    public class DatosAlmacen : RepositorioDatosBase<Almacen, CriterioBusquedaAlmacen>, IRepositorioAlmacen {
        public static DatosAlmacen Instance { get; } = new();

        public DatosAlmacen() : base() { }

        public override string ComandoCantidad() {
            return "SELECT COUNT(id_almacen) FROM mg__almacen;";
        }

        public override string ComandoAdicionar(Almacen objeto) {
            return $"INSERT INTO mg__almacen (nombre, direccion, notas) VALUES ('{objeto.Nombre}', '{objeto.Direccion}', '{objeto.Notas}');";
        }

        public override string ComandoEditar(Almacen objeto) {
            return $"UPDATE mg__almacen SET nombre='{objeto.Nombre}', direccion='{objeto.Direccion}', notas='{objeto.Notas}' WHERE id_almacen={objeto.Id};";
        }

        public override string ComandoEliminar(long id) {
            return $"DELETE FROM mg__almacen WHERE id_almacen={id};";
        }

        public override string ComandoObtener(CriterioBusquedaAlmacen criterio, string dato) {
            var comando = string.Empty;

            switch (criterio) {
                case CriterioBusquedaAlmacen.Id:
                    comando = $"SELECT * FROM mg__almacen WHERE id_almacen={dato};";
                    break;
                case CriterioBusquedaAlmacen.Nombre:
                    comando = $"SELECT * FROM mg__almacen WHERE LOWER(nombre) LIKE LOWER('%{dato}%');";
                    break;
                default:
                    comando = "SELECT * FROM mg__almacen;";
                    break;
            }

            return comando;
        }

        public override Almacen ObtenerObjetoDataReader(MySqlDataReader lectorDatos) {
            return new Almacen(
                idAlmacen: lectorDatos.GetInt32(lectorDatos.GetOrdinal("id_almacen")),
                nombre: lectorDatos.GetString(lectorDatos.GetOrdinal("nombre")),
                direccion: lectorDatos.GetString(lectorDatos.GetOrdinal("direccion")),
                notas: lectorDatos.GetString(lectorDatos.GetOrdinal("notas"))
            );
        }

        public override string ComandoExiste(string dato) {
            return $"SELECT * FROM mg__almacen WHERE nombre='{dato}';";
        }
    }
}
