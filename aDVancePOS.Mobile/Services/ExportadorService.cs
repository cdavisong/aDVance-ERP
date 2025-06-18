using aDVancePOS.Mobile.Database;
using Newtonsoft.Json;

namespace aDVancePOS.Mobile.Services {
    // Services/ExportadorService.cs
    public class ExportadorService {
        private readonly DatabaseContext _database;

        public ExportadorService(DatabaseContext database) {
            _database = database;
        }

        public async Task<string> ExportarVentasAJson() {
            try {
                var ventas = await _database.GetVentasAsync();
                var ventasCompletas = new List<object>();

                foreach (var venta in ventas) {
                    var detalles = await _database.GetDetallesVentaAsync(venta.Id);
                    var pagos = await _database.GetPagosAsync(venta.Id);

                    var ventaCompleta = new {
                        venta.Id,
                        venta.Fecha,
                        venta.Total,
                        Productos = detalles.Select(d => new
                        {
                            IdProducto = d.IdProducto,
                            d.Cantidad,
                            d.PrecioUnitario
                        }),
                        Pagos = pagos.Select(p => new
                        {
                            p.MetodoPago,
                            p.Monto,
                            p.FechaConfirmacion
                        })
                    };

                    ventasCompletas.Add(ventaCompleta);
                }

                var json = JsonConvert.SerializeObject(ventasCompletas, Formatting.Indented);
                var filePath = Path.Combine(Android.OS.Environment.ExternalStorageDirectory.AbsolutePath, "ventas_exportadas.json");

                await File.WriteAllTextAsync(filePath, json);
                return filePath;
            } catch (Exception ex) {
                Console.WriteLine($"Error al exportar ventas: {ex.Message}");
                return null;
            }
        }
    }
}