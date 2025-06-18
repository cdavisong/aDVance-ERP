using aDVancePOS.Mobile.Models;
using SQLite;

namespace aDVancePOS.Mobile.Database {
    // Database/DatabaseContext.cs
    public class DatabaseContext {
        private readonly SQLiteAsyncConnection _database;

        public DatabaseContext(string dbPath) {
            _database = new SQLiteAsyncConnection(dbPath);
            _database.CreateTableAsync<Producto>().Wait();
            _database.CreateTableAsync<Venta>().Wait();
            _database.CreateTableAsync<DetalleVenta>().Wait();
            _database.CreateTableAsync<Pago>().Wait();
            _database.CreateTableAsync<DetallePagoTransferencia>().Wait();
        }

        // Métodos para Productos
        public Task<List<Producto>> GetProductosAsync() => _database.Table<Producto>().ToListAsync();
        public Task<Producto> GetProductoAsync(int id) => _database.Table<Producto>().Where(p => p.IdProducto == id).FirstOrDefaultAsync();
        public Task<int> SaveProductoAsync(Producto producto) => producto.IdProducto == 0 ?
            _database.InsertAsync(producto) : _database.UpdateAsync(producto);
        public Task<int> DeleteProductoAsync(Producto producto) => _database.DeleteAsync(producto);

        // Métodos para Ventas
        public Task<List<Venta>> GetVentasAsync() => _database.Table<Venta>().ToListAsync();
        public Task<Venta> GetVentaAsync(int id) => _database.Table<Venta>().Where(v => v.Id == id).FirstOrDefaultAsync();
        public Task<int> SaveVentaAsync(Venta venta) => venta.Id == 0 ?
            _database.InsertAsync(venta) : _database.UpdateAsync(venta);

        // Métodos para Detalles de Venta
        public Task<List<DetalleVenta>> GetDetallesVentaAsync(int idVenta) =>
            _database.Table<DetalleVenta>().Where(d => d.IdVenta == idVenta).ToListAsync();
        public Task<int> SaveDetalleVentaAsync(DetalleVenta detalle) => detalle.Id == 0 ?
            _database.InsertAsync(detalle) : _database.UpdateAsync(detalle);

        // Métodos para Pagos
        public Task<List<Pago>> GetPagosAsync(int idVenta) =>
            _database.Table<Pago>().Where(p => p.IdVenta == idVenta).ToListAsync();
        public Task<int> SavePagoAsync(Pago pago) => pago.Id == 0 ?
            _database.InsertAsync(pago) : _database.UpdateAsync(pago);

        // Métodos para Detalles de Transferencia
        public Task<DetallePagoTransferencia> GetDetalleTransferenciaAsync(int idPago) =>
            _database.Table<DetallePagoTransferencia>().Where(d => d.IdPago == idPago).FirstOrDefaultAsync();
        public Task<int> SaveDetalleTransferenciaAsync(DetallePagoTransferencia detalle) => detalle.Id == 0 ?
            _database.InsertAsync(detalle) : _database.UpdateAsync(detalle);
    }
}