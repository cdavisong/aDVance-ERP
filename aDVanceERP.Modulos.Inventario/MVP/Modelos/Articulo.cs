using aDVanceERP.Core.MVP.Modelos.Plantillas;

namespace aDVanceERP.Modulos.Inventario.MVP.Modelos {
    public class Articulo : IObjetoUnico {
        public Articulo() {
        }

        public Articulo(long id, string codigo, string nombre, string descripcion, long idProveedor, float precioAdquisicion, float precioCesion, int stockMinimo, int pedidoMinimo) {
            Id = id;
            Codigo = codigo;
            Nombre = nombre;
            Descripcion = descripcion;
            IdProveedor = idProveedor;
            PrecioAdquisicion = precioAdquisicion;
            PrecioCesion = precioCesion;
            StockMinimo = stockMinimo;
            PedidoMinimo = pedidoMinimo;
        }

        public long Id { get; set; }
        public string? Codigo { get; }
        public string? Nombre { get; }
        public string? Descripcion { get; set; }
        public long IdProveedor { get; set; }
        public float PrecioAdquisicion { get; }
        public float PrecioCesion { get; }
        public int StockMinimo { get; }
        public int PedidoMinimo { get; }
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
        public static string[] CriterioBusquedaArticulo = new string[] {
            "Todos los artículos",
            "Identificador de BD",
            "Código del artículo",
            "Nombre del artículo"
        };
    }
}
