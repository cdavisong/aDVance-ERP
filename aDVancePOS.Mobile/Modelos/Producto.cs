namespace aDVancePOS.Mobile.Modelos {
    public class Producto {
        public int IdProducto { get; set; }
        public string Codigo { get; set; }
        public string Nombre { get; set; }
        public string Categoria { get; set; }
        public double PrecioCompraBase { get; set; }
        public double PrecioVentaBase { get; set; }
        public int Stock { get; set; }
        public string NombreAlmacen { get; set; }
        public string UnidadMedida { get; set; }
        public string AbreviaturaMedida { get; set; }
    }
}