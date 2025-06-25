using aDVancePOS.Mobile.Modelos;
using aDVancePOS.Mobile.Servicios;

using Android.Content.PM;
using Android.OS;
using aDVancePOS.Mobile.Adaptadores;
using Android.Views;

namespace aDVancePOS.Mobile {
    [Activity(
        Label = "@string/app_name",
        MainLauncher = true,
        LaunchMode = LaunchMode.SingleTop,
        ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : Activity {
        // Constante para el código de solicitud de permisos
        private const int RequestStoragePermission = 1;

        private ServicioDatos _dataService;
        private List<Producto> _productosEncontrados;
        private List<ProductoVendido> _carrito;
        private ProductoAdapter _productosAdapter;
        private ProductoVendidoAdapter _carritoAdapter;

        private EditText _txtBuscar;
        private ListView _lstProductos;
        private ListView _lstCarrito;
        private TextView _lblTotal;
        private Button _btnPagarEfectivo;
        private Button _btnPagarTransferencia;
        private ImageButton _btnImportar;
        private Button _btnExportar;

        protected override void OnCreate(Bundle? savedInstanceState) {
            base.OnCreate(savedInstanceState);

            // Configuración inicial de la ventana
            RequestWindowFeature(WindowFeatures.NoTitle);
            Window?.SetFlags(WindowManagerFlags.Fullscreen, WindowManagerFlags.Fullscreen);

            SetContentView(Resource.Layout.activity_main);

            //CheckPermissions();            
            InicializarControlesUI();
            InicializarDatos();
        }

        private void InicializarControlesUI() {
            _txtBuscar = FindViewById<EditText>(Resource.Id.txtBuscar);
            _lstProductos = FindViewById<ListView>(Resource.Id.lstProductos);
            _lstCarrito = FindViewById<ListView>(Resource.Id.lstCarrito);
            _lblTotal = FindViewById<TextView>(Resource.Id.lblTotal);
            _btnPagarEfectivo = FindViewById<Button>(Resource.Id.btnPagarEfectivo);
            _btnPagarTransferencia = FindViewById<Button>(Resource.Id.btnPagarTransferencia);
            _btnImportar = FindViewById<ImageButton>(Resource.Id.btnImportar);
            _btnExportar = FindViewById<Button>(Resource.Id.btnExportar);

            // Configurar adaptadores y eventos
            ConfigurarAdaptadores();
            ConfigurarEventos();

            // Acciones UI
            OcultarInterfazSistema();
        }

        private void ConfigurarAdaptadores() {
            _productosEncontrados = new List<Producto>();
            _productosAdapter = new ProductoAdapter(this, _productosEncontrados);
            _lstProductos.Adapter = _productosAdapter;

            _carrito = new List<ProductoVendido>();
            _carritoAdapter = new ProductoVendidoAdapter(this, _carrito);
            _lstCarrito.Adapter = _carritoAdapter;
        }

        private void ConfigurarEventos() {
            var downloadsPath = ObtenerRutaArchivosInterna();
            var filePath = Path.Combine(downloadsPath, "productos_almacen.json");

            _txtBuscar.TextChanged += (sender, e) => BuscarProductos();
            _lstProductos.ItemClick += (sender, e) => {
                AgregarAlCarrito(e.Position);
            };
            _btnPagarEfectivo.Click += (sender, e) => RealizarPago("Efectivo");
            _btnPagarTransferencia.Click += (sender, e) => RealizarPago("Transferencia");
            _btnImportar.Click += (sender, e) => ImportarProductos(filePath);
            _btnExportar.Click += (sender, e) => ExportarDatos();
        }

        private void OcultarInterfazSistema() {
            Window.InsetsController?.Hide(WindowInsets.Type.SystemBars());
            Window.SetDecorFitsSystemWindows(false);
        }

        private string? ObtenerRutaArchivosInterna() {
            if (Build.VERSION.SdkInt >= BuildVersionCodes.Q) {
                // Para Android 10+ usamos el contexto
                return Application.Context.GetExternalFilesDir("")?.AbsolutePath;
            } else {
                // Para versiones anteriores
                return Android.OS.Environment.GetExternalStoragePublicDirectory(Android.OS.Environment.DirectoryDownloads)?.AbsolutePath;
            }
        }

        private void InicializarDatos() {
            // Inicializar servicios
            _dataService = new ServicioDatos();

            CargarDatosIniciales();
        }

        private void CargarDatosIniciales() {
            try {
                var downloadsPath = _dataService.DirectorioDescargas;
                var filePath = Path.Combine(downloadsPath, "productos_almacen.json");

                if (File.Exists(filePath))
                    ImportarProductos(filePath);                

                BuscarProductos();
            } catch (Exception ex) {
                Toast.MakeText(this, $"Error cargando datos iniciales: {ex.Message}", ToastLength.Short).Show();
            }
        }

        private void ImportarProductos(string filePath) {
            try {
                if (File.Exists(filePath)) {
                    var jsonContent = File.ReadAllText(filePath);

                    // Copiar el archivo a la ubicación interna de la app
                    File.WriteAllText(_dataService.ProductosPath, jsonContent);

                    // Opcional: mover el archivo a la carpeta de importados
                    var importDir = Path.Combine(_dataService.DirectorioDescargas, "imported");
                    Directory.CreateDirectory(importDir);
                    var destPath = Path.Combine(importDir, Path.GetFileName(filePath));
                    File.Move(filePath, destPath, true);

                    _dataService = new ServicioDatos(); // Reiniciar servicio

                    Toast.MakeText(this, "Productos importados correctamente", ToastLength.Long).Show();
                } else {
                    Toast.MakeText(this, "Archivo no encontrado", ToastLength.Long).Show();
                }
            } catch (Exception ex) {
                Toast.MakeText(this, $"Error al importar: {ex.Message}", ToastLength.Long).Show();
            }
        }

        private void ExportarDatos() {
            var downloadsPath = _dataService.DirectorioDescargas;
            Directory.CreateDirectory(downloadsPath);

            var exportTime = DateTime.Now.ToString("yyyyMMdd_HHmmss");
            var productosExportPath = Path.Combine(downloadsPath, $"productos_export_{exportTime}.json");
            var ventasExportPath = Path.Combine(downloadsPath, $"ventas_export_{exportTime}.json");

            File.Copy(_dataService.ProductosPath, productosExportPath, true);
            File.Copy(_dataService.VentasPath, ventasExportPath, true);

            Toast.MakeText(this, $"Datos exportados a:\n{downloadsPath}", ToastLength.Long).Show();
        }

        private void BuscarProductos() {
            var termino = _txtBuscar.Text;
            _productosEncontrados = _dataService.BuscarProductos(termino);
            _productosAdapter.Clear();
            _productosAdapter.AddAll(_productosEncontrados);
            _productosAdapter.NotifyDataSetChanged();
        }

        private void AgregarAlCarrito(int position) {
            var producto = _productosEncontrados[position];

            // Mostrar diálogo para cantidad
            var input = new EditText(this);
            input.InputType = Android.Text.InputTypes.ClassNumber;
            input.Text = "1";

            new AlertDialog.Builder(this)
                .SetTitle($"Agregar {producto.nombre}")
                .SetMessage("Ingrese la cantidad:")
                .SetView(input)
                .SetPositiveButton("Agregar", (sender, e) => {
                    if (int.TryParse(input.Text, out int cantidad) && cantidad > 0) {
                        // Verificar si ya está en el carrito
                        var itemExistente = _carrito.FirstOrDefault(p => p.Producto.id_producto == producto.id_producto);
                        if (itemExistente != null) {
                            itemExistente.Cantidad += cantidad;
                        } else {
                            _carrito.Add(new ProductoVendido {
                                Producto = producto,
                                Cantidad = cantidad
                            });
                        }

                        ActualizarCarrito();
                    }
                })
                .SetNegativeButton("Cancelar", (sender, e) => { })
                .Show();
        }

        private void ActualizarCarrito() {
            _carritoAdapter.Clear();
            _carritoAdapter.AddAll(_carrito);
            _carritoAdapter.NotifyDataSetChanged();

            var total = _carrito.Sum(item => item.Producto.precio_venta_base * item.Cantidad);
            _lblTotal.Text = $"Total: ${total:N2}";
        }

        private void RealizarPago(string metodoPago) {
            if (_carrito.Count == 0) {
                Toast.MakeText(this, "El carrito está vacío", ToastLength.Short).Show();
                return;
            }

            var venta = new Venta {
                Productos = new List<ProductoVendido>(_carrito),
                Total = _carrito.Sum(item => (double) item.Producto.precio_venta_base * item.Cantidad),
                MetodoPago = metodoPago
            };

            _dataService.RegistrarVenta(venta);

            // Limpiar carrito
            _carrito.Clear();
            ActualizarCarrito();

            Toast.MakeText(this, $"Venta registrada ({metodoPago})", ToastLength.Long).Show();
        }
    }
}