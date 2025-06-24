using aDVancePOS.Mobile.Modelos;
using aDVancePOS.Mobile.Servicios;
using aDVancePOS.Mobile.Controladores;

using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Environment = System.Environment;

using Android;
using Android.App;
using Android.Content;
using Android.Content.PM;
using Android.OS;
using Android.Runtime;
using Android.Widget;
using Android.Support.V4.App;
using Android.Support.V4.Content;
using aDVancePOS.Mobile.Adaptadores;
using Android.Provider;


namespace aDVancePOS.Mobile {
    [Activity(
        Label = "@string/app_name", 
        MainLauncher = true, 
        LaunchMode = LaunchMode.SingleTop, 
        ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    [IntentFilter(new[] { Intent.ActionView },
        Categories = new[] {
            Intent.CategoryDefault,
            Intent.CategoryBrowsable
        },
        DataMimeType = "application/json",
        DataScheme = "file",
        DataHost = "*",
        DataPathPattern = ".*\\.json")]
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
        private Button _btnImportar;
        private Button _btnExportar;

        protected override void OnCreate(Bundle? savedInstanceState) {
            base.OnCreate(savedInstanceState);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.activity_main);

            //CheckPermissions();
            InicializarDatos();
            InicializarControlesUI();

            // Verificar y solicitar permisos primero
            VerificarYConfigurarPermisos();
        }

        private void InicializarControlesUI() {
            _txtBuscar = FindViewById<EditText>(Resource.Id.txtBuscar);
            _lstProductos = FindViewById<ListView>(Resource.Id.lstProductos);
            _lstCarrito = FindViewById<ListView>(Resource.Id.lstCarrito);
            _lblTotal = FindViewById<TextView>(Resource.Id.lblTotal);
            _btnPagarEfectivo = FindViewById<Button>(Resource.Id.btnPagarEfectivo);
            _btnPagarTransferencia = FindViewById<Button>(Resource.Id.btnPagarTransferencia);
            _btnImportar = FindViewById<Button>(Resource.Id.btnImportar);
            _btnExportar = FindViewById<Button>(Resource.Id.btnExportar);

            // Configurar adaptadores y eventos
            ConfigurarAdaptadores();
            ConfigurarEventos();
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
            var downloadsPath = _dataService.DirectorioDescargas;
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

        private void VerificarYConfigurarPermisos() {
            if (NecesitaSolicitarPermisos()) {
                SolicitarPermisos();
            } else {
                InicializarDatos();
            }
        }

        private bool NecesitaSolicitarPermisos() {
            if (Build.VERSION.SdkInt >= BuildVersionCodes.M) {
                return CheckSelfPermission(Manifest.Permission.ReadExternalStorage) != Permission.Granted ||
                       CheckSelfPermission(Manifest.Permission.WriteExternalStorage) != Permission.Granted;
            }
            return false;
        }

        private void SolicitarPermisos() {
            if (Build.VERSION.SdkInt >= BuildVersionCodes.M) {
                RequestPermissions(
                    new[]
                    {
                        Manifest.Permission.ReadExternalStorage,
                        Manifest.Permission.WriteExternalStorage
                    },
                    RequestStoragePermissionCode);
            }
        }

        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Permission[] grantResults) {
            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            if (requestCode == RequestStoragePermissionCode) {
                if (grantResults.Length > 0 && grantResults.All(r => r == Permission.Granted)) {
                    // Permisos concedidos - inicializar datos
                    Toast.MakeText(this, "Permisos concedidos", ToastLength.Short).Show();
                    InicializarDatos();
                } else {
                    // Permisos denegados - mostrar explicación y opción para intentar nuevamente
                    MostrarExplicacionPermisos();
                }
            }
        }

        private void MostrarExplicacionPermisos() {
            if (ShouldShowRequestPermissionRationale(Manifest.Permission.ReadExternalStorage)) {
                new AlertDialog.Builder(this)
                    .SetTitle("Permisos requeridos")
                    .SetMessage("La aplicación necesita acceso al almacenamiento para cargar los productos y guardar las ventas.")
                    .SetPositiveButton("Intentar nuevamente", (sender, args) => {
                        SolicitarPermisos();
                    })
                    .SetNegativeButton("Cancelar", (sender, args) => {
                        Toast.MakeText(this, "La funcionalidad estará limitada", ToastLength.Long).Show();
                    })
                    .Show();
            } else {
                Toast.MakeText(this, "Permisos denegados permanentemente. Puede cambiarlo en Configuración de la aplicación.", ToastLength.Long).Show();
            }
        }

        private void InicializarDatos() {
            // Configurar rutas de archivos
            var productosPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Personal), "productos.json");
            var ventasPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Personal), "ventas.json");

            // Si no existe el archivo de productos, crearlo con los datos iniciales
            if (!File.Exists(productosPath)) {
                var initialData = GetInitialProductData();
                _productosAdapter = new ArrayAdapter<Producto>(this, Android.Resource.Layout.SimpleListItem1, _productosEncontrados);
                _carritoAdapter = new ArrayAdapter<ProductoVendido>(this, Android.Resource.Layout.SimpleListItem1, _carrito);
                File.WriteAllText(productosPath, initialData);
            }

            // Inicializar servicios
            _dataService = new ServicioDatos();

            CargarDatosIniciales();
        }

        private void CargarDatosIniciales() {
            try {
                var downloadsPath = _dataService.DirectorioDescargas;
                var filePath = Path.Combine(downloadsPath, "productos_almacen.json");

                if (File.Exists(filePath)) {
                    ImportarProductos(filePath);
                }

                // Si el archivo no existe o no es válido, usar datos por defecto
                Toast.MakeText(this, "No se encontró archivo válido", ToastLength.Long).Show();
                return @"[]";
            } catch (Exception ex) {
                Toast.MakeText(this, $"Error cargando datos iniciales: {ex.Message}", ToastLength.Short).Show();
            }
        }

        private void ImportarProductos(string filePath) {
            try {
                var externalPath = Android.OS.Environment.ExternalStorageDirectory.Path;
                var filePath = Path.Combine(externalPath, "productos_almacen.json");

                if (File.Exists(filePath)) {
                    var jsonContent = File.ReadAllText(filePath);

                    if (_dataService.ValidarEstructuraProductos(jsonContent)) {
                        // Copiar el archivo a la ubicación interna de la app
                        File.WriteAllText(_dataService.ProductosPath, jsonContent);

                        // Opcional: mover el archivo a la carpeta de importados
                        var importDir = Path.Combine(_dataService.DirectorioDescargas, "imported");
                        Directory.CreateDirectory(importDir);
                        var destPath = Path.Combine(importDir, Path.GetFileName(filePath));
                        File.Move(filePath, destPath, true);

                        _dataService = new ServicioDatos(); // Reiniciar servicio
                        BuscarProductos();

                        Toast.MakeText(this, "Productos importados correctamente", ToastLength.Long).Show();
                        BuscarProductos();
                    } else {
                        Toast.MakeText(this, "El archivo no tiene el formato correcto", ToastLength.Long).Show();
                    }
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

        private void ExportarDatos() {
            var exportPath = Path.Combine(Android.OS.Environment.ExternalStorageDirectory.Path, "GestorVentas");
            Directory.CreateDirectory(exportPath);

            var productosExportPath = Path.Combine(exportPath, "productos_export.json");
            var ventasExportPath = Path.Combine(exportPath, "ventas_export.json");

            File.Copy(_dataService.ProductosPath, productosExportPath, true);
            File.Copy(_dataService.VentasPath, ventasExportPath, true);

            Toast.MakeText(this, $"Datos exportados a: {exportPath}", ToastLength.Long).Show();
        }
    }
}