using aDVancePOS.Mobile.Adapters;
using aDVancePOS.Mobile.Database;
using aDVancePOS.Mobile.Models;
using Android.Content;
using Android.Text;
using AndroidX.AppCompat.App;
using AndroidX.RecyclerView.Widget;
using Newtonsoft.Json;

namespace aDVancePOS.Mobile.Activities {
    // Activities/RegistroVentaActivity.cs
    [Activity(Label = "Registro de Venta", Theme = "@style/AppTheme")]
    public class RegistroVentaActivity : AppCompatActivity {
        private DatabaseContext _database;
        private List<Producto> _productosDisponibles = new List<Producto>();
        private List<Producto> _productosSeleccionados = new List<Producto>();
        private ProductoAdapter _adapterDisponibles;
        private ProductoAdapter _adapterSeleccionados;
        private decimal _totalVenta = 0;
        private string _nombreAlmacen = "Punto de venta 01"; // Puedes hacerlo configurable

        protected override void OnCreate(Bundle savedInstanceState) {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.activity_registro_venta);

            // Configurar base de datos
            var dbPath = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal), "advancepos.db");
            _database = new DatabaseContext(dbPath);

            // Configurar RecyclerViews
            var recyclerDisponibles = FindViewById<RecyclerView>(Resource.Id.recyclerProductosDisponibles);
            var recyclerSeleccionados = FindViewById<RecyclerView>(Resource.Id.recyclerProductosSeleccionados);

            recyclerDisponibles.SetLayoutManager(new LinearLayoutManager(this));
            recyclerSeleccionados.SetLayoutManager(new LinearLayoutManager(this));

            _adapterDisponibles = new ProductoAdapter(_productosDisponibles, OnProductoSelected);
            _adapterSeleccionados = new ProductoAdapter(_productosSeleccionados, OnProductoRemoved);

            recyclerDisponibles.SetAdapter(_adapterDisponibles);
            recyclerSeleccionados.SetAdapter(_adapterSeleccionados);

            // Cargar productos
            LoadProductos();

            // Configurar botones
            FindViewById<Button>(Resource.Id.btnRegistrarVenta).Click += OnRegistrarVentaClicked;
            FindViewById<Button>(Resource.Id.btnProcesarPago).Click += OnProcesarPagoClicked;
        }

        private async void LoadProductos() {
            // Primero intenta cargar desde la base de datos local
            _productosDisponibles = await _database.GetProductosAsync();

            if (_productosDisponibles.Count == 0) {
                // Si no hay datos, cargar desde JSON
                await CargarProductosDesdeJson();
                _productosDisponibles = await _database.GetProductosAsync();
            }

            _adapterDisponibles.UpdateData(_productosDisponibles);
        }

        private async Task CargarProductosDesdeJson() {
            try {
                var jsonPath = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal), "productos_almacen_2.json");

                if (!File.Exists(jsonPath)) {
                    // Si el archivo no existe, puedes copiarlo desde Assets
                    using (var asset = Assets.Open("productos_almacen_2.json"))
                    using (var dest = File.Create(jsonPath)) {
                        await asset.CopyToAsync(dest);
                    }
                }

                var json = File.ReadAllText(jsonPath);
                var productos = JsonConvert.DeserializeObject<List<Producto>>(json);

                foreach (var producto in productos) {
                    await _database.SaveProductoAsync(producto);
                }
            } catch (Exception ex) {
                Toast.MakeText(this, $"Error al cargar productos: {ex.Message}", ToastLength.Long).Show();
            }
        }

        private void OnProductoSelected(Producto producto) {
            // Mostrar diálogo para seleccionar cantidad
            var dialog = new Android.App.AlertDialog.Builder(this);
            dialog.SetTitle($"Seleccionar cantidad de {producto.Nombre}");

            var input = new EditText(this) { InputType = InputTypes.ClassNumber };
            dialog.SetView(input);

            dialog.SetPositiveButton("Aceptar", (sender, e) =>
            {
                if (int.TryParse(input.Text, out int cantidad) && cantidad > 0 && cantidad <= producto.Stock) {
                    // Clonar el producto y establecer la cantidad
                    var productoSeleccionado = new Producto {
                        IdProducto = producto.IdProducto,
                        Codigo = producto.Codigo,
                        Nombre = producto.Nombre,
                        PrecioVentaBase = producto.PrecioVentaBase,
                        Stock = cantidad // Usamos Stock temporalmente para la cantidad
                    };

                    _productosSeleccionados.Add(productoSeleccionado);
                    _adapterSeleccionados.UpdateData(_productosSeleccionados);
                    CalcularTotal();
                } else {
                    Toast.MakeText(this, "Cantidad inválida", ToastLength.Short).Show();
                }
            });

            dialog.SetNegativeButton("Cancelar", (IDialogInterfaceOnClickListener) null);
            dialog.Show();
        }

        private void OnProductoRemoved(Producto producto) {
            _productosSeleccionados.Remove(producto);
            _adapterSeleccionados.UpdateData(_productosSeleccionados);
            CalcularTotal();
        }

        private void CalcularTotal() {
            _totalVenta = _productosSeleccionados.Sum(p => p.PrecioVentaBase * p.Stock);
            FindViewById<TextView>(Resource.Id.txtTotalVenta).Text = _totalVenta.ToString("C");
        }

        private async void OnRegistrarVentaClicked(object sender, EventArgs e) {
            if (_productosSeleccionados.Count == 0) {
                Toast.MakeText(this, "Debe seleccionar al menos un producto", ToastLength.Short).Show();
                return;
            }

            // Crear la venta
            var venta = new Venta {
                Fecha = DateTime.Now,
                IdAlmacen = 1, // Asumimos que el almacén tiene ID 1
                Total = _totalVenta,
                EstadoEntrega = "Pendiente"
            };

            await _database.SaveVentaAsync(venta);

            // Guardar detalles de venta
            foreach (var producto in _productosSeleccionados) {
                var detalle = new DetalleVenta {
                    IdVenta = venta.Id,
                    IdProducto = producto.IdProducto,
                    Cantidad = producto.Stock,
                    PrecioUnitario = producto.PrecioVentaBase
                };

                await _database.SaveDetalleVentaAsync(detalle);

                // Actualizar stock
                var productoOriginal = await _database.GetProductoAsync(producto.IdProducto);
                if (productoOriginal != null) {
                    productoOriginal.Stock -= producto.Stock;
                    await _database.SaveProductoAsync(productoOriginal);
                }
            }

            Toast.MakeText(this, "Venta registrada correctamente", ToastLength.Short).Show();

            // Limpiar selección
            _productosSeleccionados.Clear();
            _adapterSeleccionados.UpdateData(_productosSeleccionados);
            CalcularTotal();

            // Actualizar lista de productos disponibles
            _productosDisponibles = await _database.GetProductosAsync();
            _adapterDisponibles.UpdateData(_productosDisponibles);
        }

        private void OnProcesarPagoClicked(object sender, EventArgs e) {
            if (_productosSeleccionados.Count == 0) {
                Toast.MakeText(this, "Debe seleccionar al menos un producto", ToastLength.Short).Show();
                return;
            }

            var intent = new Intent(this, typeof(RegistroPagoActivity));
            intent.PutExtra("TotalVenta", (double) _totalVenta);
            StartActivity(intent);
        }
    }
}