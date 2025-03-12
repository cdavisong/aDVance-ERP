namespace aDVanceERP.Modulos.Ventas.MVP.Modelos {
    public class DatosEstadisticosVentas {
        public Dictionary<DateTime, decimal> VentasPorHora { get; set; } = new();
        public Dictionary<DateTime, decimal> VentasPorDia { get; set; } = new();
        public Dictionary<DateTime, decimal> VentasPorMes { get; set; } = new();
    }
}
