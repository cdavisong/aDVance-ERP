namespace Manigest.Modulos.Inventario.MVP.Modelos.Repositorios {
    using Manigest.Core.MVP.Modelos.Repositorios;
    using Manigest.Modulos.Inventario.MVP.Modelos.Repositorios.Plantillas;

    using MySql.Data.MySqlClient;

    public class DatosArticulo : RepositorioDatosBase<Articulo, CriterioBusquedaArticulo>, IRepositorioArticulo {
        public static DatosArticulo Instance { get; } = new();

        public DatosArticulo() : base() { }

        public override string ComandoCantidad() {
            return "SELECT COUNT(id_articulo) FROM mg__articulo;";
        }

        public override string ComandoAdicionar(Articulo objeto) {
            return $"INSERT INTO mg__articulo (codigo, nombre, descripcion, id_proveedor, precio_adquisicion, precio_cesion, stock_minimo, pedido_minimo) VALUES ('{objeto.Codigo}', '{objeto.Nombre}', '{objeto.Descripcion}', '{objeto.IdProveedor}', '{objeto.PrecioAdquisicion}', '{objeto.PrecioCesion}', '{objeto.StockMinimo}', '{objeto.PedidoMinimo}');";
        }

        public override string ComandoEditar(Articulo objeto) {
            return $"UPDATE mg__articulo SET codigo='{objeto.Codigo}', nombre='{objeto.Nombre}', descripcion='{objeto.Descripcion}', id_proveedor='{objeto.IdProveedor}', precio_adquisicion='{objeto.PrecioAdquisicion}', precio_cesion='{objeto.PrecioCesion}', stock_minimo='{objeto.StockMinimo}', pedido_minimo='{objeto.PedidoMinimo}' WHERE id_articulo={objeto.Id};";
        }

        public override string ComandoEliminar(long id) {
            return $"DELETE FROM mg__articulo WHERE id_articulo={id};";
        }

        public override string ComandoObtener(CriterioBusquedaArticulo criterio, string dato) {
            string? comando;
            switch (criterio) {
                case CriterioBusquedaArticulo.Id:
                    comando = $"SELECT * FROM mg__articulo WHERE id_articulo='{dato}';";
                    break;
                case CriterioBusquedaArticulo.Codigo:
                    comando = $"SELECT * FROM mg__articulo WHERE codigo='{dato}';";
                    break;
                case CriterioBusquedaArticulo.Nombre:
                    comando = $"SELECT * FROM mg__articulo WHERE LOWER(nombre) LIKE LOWER('%{dato}%');";
                    break;
                default:
                    comando = "SELECT * FROM mg__articulo;";
                    break;
            }

            return comando;
        }

        public override Articulo ObtenerObjetoDataReader(MySqlDataReader lectorDatos) {
            return new Articulo(
                id: lectorDatos.GetInt32(lectorDatos.GetOrdinal("id_articulo")),
                codigo: lectorDatos.GetString(lectorDatos.GetOrdinal("codigo")),
                nombre: lectorDatos.GetString(lectorDatos.GetOrdinal("nombre")),
                descripcion: lectorDatos.GetString(lectorDatos.GetOrdinal("descripcion")),
                idProveedor: lectorDatos.GetInt32(lectorDatos.GetOrdinal("id_proveedor")),
                precioAdquisicion: lectorDatos.GetFloat(lectorDatos.GetOrdinal("precio_adquisicion")),
                precioCesion: lectorDatos.GetFloat(lectorDatos.GetOrdinal("precio_cesion")),
                stockMinimo: lectorDatos.GetInt32(lectorDatos.GetOrdinal("stock_minimo")),
                pedidoMinimo: lectorDatos.GetInt32(lectorDatos.GetOrdinal("pedido_minimo"))
            );
        }

        public override string ComandoExiste(string dato) {
            return $"SELECT * FROM mg__articulo WHERE codigo='{dato}';";
        }
    }
}
