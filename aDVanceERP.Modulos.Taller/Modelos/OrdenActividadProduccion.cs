using aDVanceERP.Core.Modelos.Comun;

namespace aDVanceERP.Modulos.Taller.Modelos {
    public class OrdenActividadProduccion : IEntidadBd {
        public OrdenActividadProduccion() {
            IdOrdenProduccion = 0;
            Nombre = string.Empty;
            Cantidad = 0.0m;
            Costo = 0.0m;
            Total = 0.0m;
            FechaRegistro = DateTime.Now;
        }

        public OrdenActividadProduccion(long id, long idOrdenProduccion, string nombre, decimal cantidad,
            decimal costo, decimal costoTotal) {
            Id = id;
            IdOrdenProduccion = idOrdenProduccion;
            Nombre = nombre;
            Cantidad = cantidad;
            Costo = costo;
            Total = costoTotal;
            FechaRegistro = DateTime.Now;
        }

        public long Id { get; set; }
        public long IdOrdenProduccion { get; set; }
        public string Nombre { get; set; }
        public decimal Cantidad { get; set; }
        public decimal Costo { get; set; }
        public decimal Total { get; set; }
        public DateTime FechaRegistro { get; set; } = DateTime.Now;
    }

    public enum CriterioBusquedaOrdenActividadProduccion {
        Todos,
        Id,
        OrdenProduccion,
        Nombre,
        FechaRegistro
    }

    public static class UtilesBusquedaOrdenActividadProduccion {
        public static object[] CriterioBusquedaOrdenActividadProduccion =
        {
            "Todas las actividades registradas",
            "Identificador de BD",
            "Orden de producción asociada",
            "Actividad realizada",
            "Fecha de registro"
        };
    }
}