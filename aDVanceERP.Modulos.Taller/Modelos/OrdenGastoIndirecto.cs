using aDVanceERP.Core.MVP.Modelos.Plantillas;

namespace aDVanceERP.Modulos.Taller.Modelos {
    public class OrdenGastoIndirecto : IObjetoUnico {
        public OrdenGastoIndirecto() {
            IdOrdenProduccion = 0;
            Concepto = string.Empty;
            Monto = 0.0m;
            FechaRegistro = DateTime.Now;
            Observaciones = string.Empty;
        }

        public OrdenGastoIndirecto(long id, long idOrdenProduccion, string concepto, decimal monto, 
            DateTime fechaRegistro, string observaciones) {
            Id = id;
            IdOrdenProduccion = idOrdenProduccion;
            Concepto = concepto;
            Monto = monto;
            FechaRegistro = fechaRegistro;
            Observaciones = observaciones;
        }

        public long Id { get; set; }
        public long IdOrdenProduccion { get; set; }
        public string Concepto { get; set; }
        public decimal Monto { get; set; }
        public DateTime FechaRegistro { get; set; } = DateTime.Now;
        public string Observaciones { get; set; }
    }

    public enum CriterioBusquedaOrdenGastoIndirecto {
        Todos,
        Id,
        OrdenProduccion,
        Concepto,
        Monto,
        FechaRegistro
    }

    public static class UtilesBusquedaOrdenGastoIndirecto {
        public static object[] CriterioBusquedaOrdenGastoIndirecto =
        {
            "Todos los gastos indirectos",
            "Identificador de BD",
            "Orden de producción asociada",
            "Concepto del gasto",
            "Monto del gasto",
            "Fecha de registro"
        };
    }
}