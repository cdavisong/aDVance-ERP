namespace aDVanceERP.Modulos.Inventario.MVP.Modelos.Repositorios {
    using aDVanceERP.Core.MVP.Modelos.Repositorios;
    using aDVanceERP.Modulos.Inventario.MVP.Modelos.Repositorios.Plantillas;

    using MySql.Data.MySqlClient;

    public class DatosArticulo : RepositorioDatosBase<Articulo, CriterioBusquedaArticulo>, IRepositorioArticulo {
        public override string ComandoCantidad() {
            return "SELECT COUNT(id_articulo) FROM adv__articulo;";
        }

        public override string ComandoAdicionar(Articulo objeto) {
            return $"""
                    INSERT INTO adv__articulo (
                        codigo, 
                        nombre, 
                        descripcion, 
                        id_proveedor, 
                        precio_compra_base, 
                        precio_venta_base
                    ) 
                    VALUES (
                        '{objeto.Codigo}', 
                        '{objeto.Nombre}', 
                        '{objeto.Descripcion}', 
                        '{objeto.IdProveedor}', 
                        '{objeto.PrecioCompraBase}', 
                        '{objeto.PrecioVentaBase}'
                    );
                    """;
        }

        public override string ComandoEditar(Articulo objeto) {
            return $"""
                    UPDATE adv__articulo 
                    SET 
                        codigo='{objeto.Codigo}', 
                        nombre='{objeto.Nombre}', 
                        descripcion='{objeto.Descripcion}', 
                        id_proveedor='{objeto.IdProveedor}', 
                        precio_compra_base='{objeto.PrecioCompraBase}', 
                        precio_venta_base='{objeto.PrecioVentaBase}'
                    WHERE id_articulo={objeto.Id};
                    """;
        }

        public override string ComandoEliminar(long id) {
            return $"DELETE FROM adv__articulo WHERE id_articulo={id};";
        }

        public override string ComandoObtener(CriterioBusquedaArticulo criterio, string dato) {
            if (string.IsNullOrEmpty(dato))
                dato = "Todos";

            string? comando;
            var datoMultiple = dato.Split(';');
            var todosLosAlmacenes = datoMultiple.Length > 1 && datoMultiple[0].Contains("Todos");
            var aplicarFiltroAlmacen = datoMultiple.Length > 1 && !todosLosAlmacenes;
            var comandoAdicionalSelect = ", ta.stock, a.nombre AS nombre_almacen";
            var comandoAdicionalJoin = $"JOIN adv__articulo_almacen ta ON t.id_articulo = ta.id_articulo JOIN adv__almacen a ON ta.id_almacen = a.id_almacen ";
            var comandoAdicionalWhere = $"AND a.nombre = '{datoMultiple[0]}'";

            switch (criterio) {
                case CriterioBusquedaArticulo.Id:
                    comando = $"SELECT t.*{(aplicarFiltroAlmacen ? comandoAdicionalSelect : string.Empty)} FROM adv__articulo t {(aplicarFiltroAlmacen ? comandoAdicionalJoin : string.Empty)}WHERE t.id_articulo='{(datoMultiple.Length > 0 ? datoMultiple[1] : dato)}' {(aplicarFiltroAlmacen ? comandoAdicionalWhere : string.Empty)};";
                    break;
                case CriterioBusquedaArticulo.Codigo:
                    comando = $"SELECT t.*{(aplicarFiltroAlmacen ? comandoAdicionalSelect : string.Empty)} FROM adv__articulo t {(aplicarFiltroAlmacen ? comandoAdicionalJoin : string.Empty)}WHERE LOWER(t.codigo) LIKE LOWER('%{(datoMultiple.Length > 0 ? datoMultiple[1] : dato)}%') {(aplicarFiltroAlmacen ? comandoAdicionalWhere : string.Empty)};";
                    break;
                case CriterioBusquedaArticulo.Nombre:
                    comando = $"SELECT t.*{(aplicarFiltroAlmacen ? comandoAdicionalSelect : string.Empty)} FROM adv__articulo t {(aplicarFiltroAlmacen ? comandoAdicionalJoin : string.Empty)}WHERE LOWER(t.nombre) LIKE LOWER('%{(datoMultiple.Length > 0 ? datoMultiple[1] : dato)}%') {(aplicarFiltroAlmacen ? comandoAdicionalWhere : string.Empty)};";
                    break;
                default:
                    comando = $"SELECT t.*{(aplicarFiltroAlmacen ? comandoAdicionalSelect : string.Empty)} FROM adv__articulo t {(aplicarFiltroAlmacen ? comandoAdicionalJoin : string.Empty)}{(aplicarFiltroAlmacen ? comandoAdicionalWhere : string.Empty).Replace("AND", "WHERE")};";
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
                precioCompraBase: lectorDatos.GetDecimal(lectorDatos.GetOrdinal("precio_compra_base")),
                precioVentaBase: lectorDatos.GetDecimal(lectorDatos.GetOrdinal("precio_venta_base"))
            ) {
                Stock = lectorDatos.FieldCount > 9 ? lectorDatos.GetValue(lectorDatos.GetOrdinal("stock")).ToString() ?? string.Empty : string.Empty,
                NombreAlmacen = lectorDatos.FieldCount > 9 ? lectorDatos.GetValue(lectorDatos.GetOrdinal("nombre_almacen")).ToString() ?? string.Empty : string.Empty
            };
        }

        public override string ComandoExiste(string dato) {
            return $"SELECT * FROM adv__articulo WHERE codigo='{dato}';";
        }
    }
}
