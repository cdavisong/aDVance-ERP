using aDVanceERP.Core.MVP.Modelos.Plantillas;

namespace aDVanceERP.Modulos.Taller.Modelos {
    public class OrdenActividadProduccion : IObjetoUnico {
        public OrdenActividadProduccion() {
            IdOrdenProduccion = 0;
            IdActividadProduccion = 0;
            Cantidad = 0.0m; // Horas o unidades según tipo
            CostoTotal = 0.0m;
            FechaRegistro = DateTime.Now;
            Observaciones = string.Empty;
        }

        public OrdenActividadProduccion(long id, long idOrdenProduccion, long idActividadProduccion, decimal cantidad, decimal costoTotal, DateTime fechaRegistro, string observaciones) {
            Id = id;
            IdOrdenProduccion = idOrdenProduccion;
            IdActividadProduccion = idActividadProduccion;
            Cantidad = cantidad; // Horas o unidades según tipo
            CostoTotal = costoTotal;
            FechaRegistro = fechaRegistro;
            Observaciones = observaciones;
        }   

        public long Id { get; set; }
        public long IdOrdenProduccion { get; set; }
        public long IdActividadProduccion { get; set; }
        public decimal Cantidad { get; set; } // Horas o unidades según tipo
        public decimal CostoTotal { get; set; }
        public DateTime FechaRegistro { get; set; } = DateTime.Now;
        public string Observaciones { get; set; }
    }

    public enum CriterioBusquedaOrdenActividadProduccion {
        Todas,
        Id,
        OrdenProduccion,
        Actividad,
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