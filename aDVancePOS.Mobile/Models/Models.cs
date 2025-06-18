using SQLite;

namespace aDVancePOS.Mobile.Models {
    // Models/Producto.cs
    public class Producto {
        [PrimaryKey, AutoIncrement]
        public int IdProducto { get; set; }
        public string Codigo { get; set; }
        public string Nombre { get; set; }
        public string Categoria { get; set; }
        public decimal PrecioCompraBase { get; set; }
        public decimal PrecioVentaBase { get; set; }
        public int Stock { get; set; }
        public string NombreAlmacen { get; set; }
        public string UnidadMedida { get; set; }
        public string AbreviaturaMedida { get; set; }
    }

    // Models/Venta.cs
    public class Venta {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public DateTime Fecha { get; set; }
        public int IdAlmacen { get; set; }
        public int IdCliente { get; set; }
        public int IdTipoEntrega { get; set; }
        public string Direccion { get; set; }
        public string EstadoEntrega { get; set; }
        public decimal Total { get; set; }
    }

    // Models/DetalleVenta.cs
    public class DetalleVenta {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public int IdVenta { get; set; }
        public int IdProducto { get; set; }
        public int Cantidad { get; set; }
        public decimal PrecioUnitario { get; set; }
    }

    // Models/Pago.cs
    public class Pago {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public int IdVenta { get; set; }
        public string MetodoPago { get; set; }
        public decimal Monto { get; set; }
        public DateTime FechaConfirmacion { get; set; }
        public string Estado { get; set; }
    }

    // Models/DetallePagoTransferencia.cs
    public class DetallePagoTransferencia {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public int IdPago { get; set; }
        public string Alias { get; set; }
        public string NumeroTransaccion { get; set; }
        public string NumeroConfirmacion { get; set; }
        public bool RecordarNumero { get; set; }
    }
}