using aDVanceERP.Core.MVP.Modelos.Plantillas;

namespace aDVanceERP.Modulos.Taller.Modelos {
    public class CostoDirecto : IObjetoUnico {
        public CostoDirecto() {
            Id = 0;
            IdProducto = 0;
            CostoMateriaPrima = 0.0m;
            CostoManoObra = 0.0m;
            OtrosCostos = 0.0m;
            CostoTotal = 0.0m;
            FechaRegistro = DateTime.Now;
            Observaciones = "No hay observaciones para el costo directo de producción actual";
        }

        public CostoDirecto(long id, long idProducto, decimal costoMateriaPrima, decimal costoManoObra, decimal costoIndirectoFabricacion, decimal costoTotal, string? observaciones) {
            Id = id;
            IdProducto = idProducto;
            CostoMateriaPrima = costoMateriaPrima;
            CostoManoObra = costoManoObra;
            OtrosCostos = costoIndirectoFabricacion;
            CostoTotal = costoTotal;
            Observaciones = observaciones;
        }

        public long Id { get; set; }
        public long IdProducto { get; set; }
        public decimal CostoMateriaPrima { get; set; }
        public decimal CostoManoObra { get; set; }
        public decimal OtrosCostos { get; set; }
        public decimal CostoTotal { get; set; }
        public DateTime FechaRegistro { get; set; }
        public string? Observaciones { get; set; }
    }

    public enum FiltroBusquedaCostoProduccion {
        Todos,
        Id,
        IdProducto,
        Fecha
    }

    public static class UtilesBusquedaCostoProduccion {
        public static object[] CriterioBusqueda = {
            "Todos los costos de producción",
            "Identificador de BD",
            "Identificador del producto",
            "Fecha de registro"
        };
    }
}