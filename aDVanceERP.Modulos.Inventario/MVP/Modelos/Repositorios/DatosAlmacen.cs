namespace aDVanceERP.Modulos.Inventario.MVP.Modelos.Repositorios {
    using aDVanceERP.Core.MVP.Modelos.Repositorios;
    using aDVanceERP.Modulos.Inventario.MVP.Modelos.Repositorios.Plantillas;

    using MySql.Data.MySqlClient;

    public class DatosAlmacen : RepositorioDatosBase<Almacen, CriterioBusquedaAlmacen>, IRepositorioAlmacen {
        public static DatosAlmacen Instance { get; } = new();

        public DatosAlmacen() : base() { }

        public override string ComandoCantidad() {
            return "SELECT COUNT(id_almacen) FROM adv__almacen;";
        }

        public override string ComandoAdicionar(Almacen objeto) {
            return $"INSERT INTO adv__almacen (nombre, direccion, autorizo_venta, notas) VALUES ('{objeto.Nombre}', '{objeto.Direccion}', '{(objeto.AutorizoVenta ? 1 : 0)}', '{objeto.Notas}');";
        }

        public override string ComandoEditar(Almacen objeto) {
            return $"UPDATE adv__almacen SET nombre='{objeto.Nombre}', direccion='{objeto.Direccion}', autorizo_venta='{(objeto.AutorizoVenta ? 1 : 0)}', notas='{objeto.Notas}' WHERE id_almacen={objeto.Id};";
        }

        public override string ComandoEliminar(long id) {
            return $"DELETE FROM adv__almacen WHERE id_almacen={id};";
        }

        public override string ComandoObtener(CriterioBusquedaAlmacen criterio, string dato) {
            var comando = string.Empty;

            switch (criterio) {
                case CriterioBusquedaAlmacen.Id:
                    comando = $"SELECT * FROM adv__almacen WHERE id_almacen={dato};";
                    break;
                case CriterioBusquedaAlmacen.Nombre:
                    comando = $"SELECT * FROM adv__almacen WHERE LOWER(nombre) LIKE LOWER('%{dato}%');";
                    break;
                default:
                    comando = "SELECT * FROM adv__almacen;";
                    break;
            }

            return comando;
        }

        public override Almacen ObtenerObjetoDataReader(MySqlDataReader lectorDatos) {
            return new Almacen(
                idAlmacen: lectorDatos.GetInt32(lectorDatos.GetOrdinal("id_almacen")),
                nombre: lectorDatos.GetString(lectorDatos.GetOrdinal("nombre")),
                direccion: lectorDatos.GetString(lectorDatos.GetOrdinal("direccion")),
                autorizoVenta: lectorDatos.GetBoolean(lectorDatos.GetOrdinal("autorizo_venta")),
                notas: lectorDatos.GetString(lectorDatos.GetOrdinal("notas"))
            );
        }

        public override string ComandoExiste(string dato) {
            return $"SELECT * FROM adv__almacen WHERE nombre='{dato}';";
        }
    }
}
