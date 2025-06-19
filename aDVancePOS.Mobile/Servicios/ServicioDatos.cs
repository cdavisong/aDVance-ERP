using aDVancePOS.Mobile.Modelos;

using Newtonsoft.Json;

using System.Xml;

namespace aDVancePOS.Mobile.Servicios {
    public class ServicioDatos {
        private List<Producto> _productos;
        private List<Venta> _ventas;

        public ServicioDatos(string productosPath, string ventasPath) {
            ProductosPath = productosPath;
            VentasPath = ventasPath;
            CargarProductos();
            CargarVentas();
        }

        public string ProductosPath { get; }

        public string VentasPath { get; }

        private void CargarProductos() {
            if (File.Exists(ProductosPath)) {
                var json = File.ReadAllText(ProductosPath);
                _productos = JsonConvert.DeserializeObject<List<Producto>>(json);
            } else {
                _productos = new List<Producto>();
            }
        }

        private void CargarVentas() {
            if (File.Exists(VentasPath)) {
                var json = File.ReadAllText(VentasPath);
                _ventas = JsonConvert.DeserializeObject<List<Venta>>(json);
            } else {
                _ventas = new List<Venta>();
            }
        }

        public List<Producto> BuscarProductos(string termino) {
            return _productos.Where(p =>
                p.Nombre.Contains(termino, StringComparison.OrdinalIgnoreCase) ||
                p.Codigo.Contains(termino, StringComparison.OrdinalIgnoreCase))
                .ToList();
        }

        public Producto ObtenerProductoPorId(int id) {
            return _productos.FirstOrDefault(p => p.IdProducto == id);
        }

        public void RegistrarVenta(Venta venta) {
            // Actualizar stock
            foreach (var item in venta.Productos) {
                var producto = _productos.First(p => p.IdProducto == item.Producto.IdProducto);
                producto.Stock -= item.Cantidad;
            }

            // Guardar venta
            venta.IdVenta = _ventas.Count + 1;
            venta.Fecha = DateTime.Now;
            _ventas.Add(venta);

            // Guardar cambios
            GuardarDatos();
        }

        private void GuardarDatos() {
            var productosJson = JsonConvert.SerializeObject(_productos, Newtonsoft.Json.Formatting.Indented);
            File.WriteAllText(ProductosPath, productosJson);

            var ventasJson = JsonConvert.SerializeObject(_ventas, Newtonsoft.Json.Formatting.Indented);
            File.WriteAllText(VentasPath, ventasJson);
        }

        public bool ValidarEstructuraProductos(string json) {
            try {
                var productos = JsonConvert.DeserializeObject<List<Producto>>(json);

                if (productos == null || productos.Count == 0)
                    return false;

                // Verificar que todos los productos tengan los campos mínimos requeridos
                return productos.All(p =>
                    p.IdProducto > 0 &&
                    !string.IsNullOrEmpty(p.Nombre) &&
                    p.PrecioVentaBase > 0 &&
                    p.Stock >= 0);
            } catch {
                return false;
            }
        }
    }
}