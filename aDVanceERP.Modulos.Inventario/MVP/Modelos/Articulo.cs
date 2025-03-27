using aDVanceERP.Core.MVP.Modelos.Plantillas;

namespace aDVanceERP.Modulos.Inventario.MVP.Modelos {
    public class Articulo : IObjetoUnico {
        public Articulo() {
        }

        public Articulo(long id, string codigo, string nombre, string descripcion, long idProveedor, decimal precioCompraBase, decimal precioVentaBase) {
            Id = id;
            Codigo = codigo;
            Nombre = nombre;
            Descripcion = descripcion;
            IdProveedor = idProveedor;
            PrecioCompraBase = precioCompraBase;
            PrecioVentaBase = precioVentaBase;
        }

        public long Id { get; set; }
        public string? Codigo { get; }
        public string? Nombre { get; }
        public string? Descripcion { get; set; }
        public long IdProveedor { get; set; }
        public decimal PrecioCompraBase { get; }
        public decimal PrecioVentaBase { get; }
        public string? Stock { get; set; }
        public string? NombreAlmacen { get; set; }
    }

    public enum CriterioBusquedaArticulo {
        Todos,
        Id,
        Codigo,
        Nombre
    }

    public static class UtilesBusquedaArticulo {
        public static object[] CriterioBusquedaArticulo = new string[] {
            "Todos los artículos",
            "Identificador de BD",
            "Código del artículo",
            "Nombre del artículo"
        };
    }
}
