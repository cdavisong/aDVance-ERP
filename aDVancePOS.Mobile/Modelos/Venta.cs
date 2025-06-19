namespace aDVancePOS.Mobile.Modelos {
    public class Venta {
        public int IdVenta { get; set; }
        public DateTime Fecha { get; set; }
        public List<ProductoVendido> Productos { get; set; }
        public double Total { get; set; }
        public string MetodoPago { get; set; } // "Efectivo" o "Transferencia"
    }
}