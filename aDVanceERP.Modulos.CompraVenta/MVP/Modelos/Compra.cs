using aDVanceERP.Core.MVP.Modelos.Plantillas;

namespace aDVanceERP.Modulos.CompraVenta.MVP.Modelos {
    public class Compra : IObjetoUnico {
        public Compra() {
        }

        public Compra(long id, DateTime fecha, long idAlmacen, long idProveedor, long idArticulo, int cantidad, decimal total) {
            Id = id;
            Fecha = fecha;
            IdAlmacen = idAlmacen;
            IdProveedor = idProveedor;
            IdArticulo = idArticulo;
            Cantidad = cantidad;
            Total = total;
        }

        public long Id { get; set; }
        public DateTime Fecha { get; set; }
        public long IdAlmacen { get; set; }
        public long IdProveedor { get; set; }
        public long IdArticulo { get; set; }
        public int Cantidad { get; set; }
        public decimal Total { get; set; }
    }

    public enum CriterioBusquedaCompra {
        Todos,
        Id,
        NombreAlmacen,
        RazonSocialProveedor,
        NombreArticulo,
        Fecha
    }

    public static class UtilesBusquedaCompra {
        public static string[] CriterioBusquedaCompra = new string[] {
            "Todas las compras",
            "Identificador de BD",
            "Nombre del almacén",
            "Razón social del proveedor",
            "Nombre del artículo",
            "Fecha de la compra"
        };
    }
}
