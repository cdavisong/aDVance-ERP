using aDVanceERP.Core.MVP.Modelos.Plantillas;

namespace aDVanceERP.Modulos.Ventas.MVP.Modelos {
    public class Venta : IObjetoUnico {
        public Venta(long id, DateTime fecha, long idAlmacen, long idCliente, float total) {
            Id = id;
            Fecha = fecha;
            IdAlmacen = idAlmacen;
            IdCliente = idCliente;
            Total = total;
        }

        public Venta(DateTime fecha, long idAlmacen, long idCliente, float total)
            : this(0, fecha, idCliente, idAlmacen, total) { }

        public long Id { get; set; }
        public DateTime Fecha { get; set; }
        public long IdAlmacen { get; set; }
        public long IdCliente { get; set; }
        public float Total { get; set; }
    }

    public enum CriterioBusquedaVenta {
        Todos,
        Id,
        NombreAlmacen,
        RazonSocialCliente,
        Fecha
    }

    public static class UtilesBusquedaVenta {
        public static string[] CriterioBusquedaVenta = new string[] {
            "Todas las ventas",
            "Identificador de BD",
            "Nombre del almacén",
            "Razón social del cliente",
            "Fecha de la venta"
        };
    }
}
