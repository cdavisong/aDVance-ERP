using Manigest.Core.MVP.Modelos.Plantillas;

namespace Manigest.Modulos.Ventas.MVP.Modelos {
    public class Venta : IObjetoUnico {
        public Venta(long id, DateTime fecha, long idAlmacen, long idCliente, float total) {
            Id = id;
            Fecha = fecha;
            IdAlmacen = idAlmacen;
            IdCliente = idCliente;
            Total = total;
        }

        public Venta(DateTime fecha, long idAlmacen, long idCliente, float total) 
            : this (0, fecha, idCliente, idAlmacen, total ) { }

        public long Id { get; set; }
        public DateTime Fecha { get; set; }
        public long IdAlmacen { get; set; }
        public long IdCliente { get; set; }
        public float Total { get; set; }
    }

    public enum CriterioBusquedaVenta {
        Todos,
        Id,
        IdAlmacen,
        IdCliente,
        Fecha
    }
}
