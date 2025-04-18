using System.Net.Sockets;
using System.Text;
using Android.Content.PM;
using Android.Runtime;
using Android.Support.V4.App;
using Android.Support.V4.Content;
using Android.Views;

using ZXing;
using ZXing.Mobile;
using Environment = System.Environment;

namespace aDVanceERP.BluetoothScanner {
    [Activity(Label = "@string/app_name", MainLauncher = true)]
    public class MainActivity : Activity {
        // Componentes UI
        private Button btnScan;
        private Button btnConnect;
        private TextView txtResult;
        private TextView txtStatus;
        private EditText txtIpAddress;

        // Servicios
        private TcpClient tcpClient;
        private NetworkStream networkStream;
        private MobileBarcodeScanner barcodeScanner;

        // Permisos
        private const int REQUEST_CAMERA = 1;
        private const int REQUEST_INTERNET = 2;

        protected override void OnCreate(Bundle? savedInstanceState) {
            base.OnCreate(savedInstanceState);

            // Pantalla completa (oculta barra de estado y barra de navegación)
            Window.AddFlags(WindowManagerFlags.Fullscreen);
            Window.ClearFlags(WindowManagerFlags.ForceNotFullscreen);

            // Configurar vista
            SetContentView(Resource.Layout.activity_main);

            // Inicializar escáner
            MobileBarcodeScanner.Initialize(Application);
            barcodeScanner = new MobileBarcodeScanner();

            // Obtener referencias UI
            btnScan = FindViewById<Button>(Resource.Id.scanButton);
            btnConnect = FindViewById<Button>(Resource.Id.connectButton);
            txtResult = FindViewById<TextView>(Resource.Id.resultText);
            txtStatus = FindViewById<TextView>(Resource.Id.connectionStatus);
            txtIpAddress = FindViewById<EditText>(Resource.Id.ipAddressText);

            // Configurar eventos
            btnScan.Click += BtnScan_Click;
            btnConnect.Click += BtnConnect_Click;

            // Verificar permisos
            CheckPermissions();
        }

        private void CheckPermissions() {
            // Permiso de cámara
            if (ContextCompat.CheckSelfPermission(this, Android.Manifest.Permission.Camera) != Permission.Granted) {
                ActivityCompat.RequestPermissions(this,
                    new string[] { Android.Manifest.Permission.Camera },
                    REQUEST_CAMERA);
            }

            // Permiso de internet
            if (ContextCompat.CheckSelfPermission(this, Android.Manifest.Permission.Internet) != Permission.Granted) {
                ActivityCompat.RequestPermissions(this, new string[] { Android.Manifest.Permission.Internet }, REQUEST_INTERNET);
            }
        }

        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Permission[] grantResults) {
            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            if (requestCode == REQUEST_CAMERA) {
                if (grantResults.Length > 0 && grantResults[0] == Permission.Granted) {
                    Toast.MakeText(this, "Permiso de cámara concedido", ToastLength.Short).Show();
                } else {
                    Toast.MakeText(this, "Se necesita permiso de cámara para escanear", ToastLength.Long).Show();
                }
            }
        }

        private async void BtnConnect_Click(object sender, EventArgs e) {
            string ipAddress = txtIpAddress.Text.Trim();

            if (string.IsNullOrEmpty(ipAddress)) {
                Toast.MakeText(this, "Ingrese una dirección IP válida", ToastLength.Long).Show();
                return;
            }

            txtStatus.Text = "Conectando...";

            try {
                // Cerrar conexión existente
                if (tcpClient != null) {
                    networkStream?.Close();
                    tcpClient?.Close();
                }

                // Crear nueva conexión
                tcpClient = new TcpClient();
                await tcpClient.ConnectAsync(ipAddress, 9002);

                networkStream = tcpClient.GetStream();
                txtStatus.Text = $"Conectado a {ipAddress}";
                Toast.MakeText(this, "Conexión exitosa", ToastLength.Short).Show();
            } catch (Exception ex) {
                txtStatus.Text = "Error de conexión";
                Toast.MakeText(this, $"Error: {ex.Message}", ToastLength.Long).Show();
            }
        }

        private async void BtnScan_Click(object sender, EventArgs e) {
            try {
                var options = new MobileBarcodeScanningOptions {
                    PossibleFormats = new List<BarcodeFormat> {
                        BarcodeFormat.EAN_13,    // Códigos de barras estándar
                        BarcodeFormat.EAN_8,     // Códigos de barras cortos
                        BarcodeFormat.UPC_A,     // Códigos UPC
                        BarcodeFormat.CODE_128,  // Códigos 128
                        BarcodeFormat.QR_CODE    // Códigos QR 
                },
                    TryHarder = true,
                    UseFrontCameraIfAvailable = false // Usar siempre la cámara trasera
                };

                // Configurar overlay personalizado
                barcodeScanner.UseCustomOverlay = false;
                barcodeScanner.TopText = "Escaneo de código QR/Barra";

                var result = await barcodeScanner.Scan(options);

                if (result != null) {
                    txtResult.Text = result.Text;

                    // Mostrar tipo de código detectado
                    string codeType = result.BarcodeFormat.ToString();
                    Toast.MakeText(this, $"Tipo: {codeType}", ToastLength.Short).Show();

                    if (networkStream?.CanWrite == true) {
                        byte[] data = Encoding.UTF8.GetBytes(result.Text + Environment.NewLine);
                        await networkStream.WriteAsync(data, 0, data.Length);
                        Toast.MakeText(this, "Datos enviados", ToastLength.Short).Show();
                    } else {
                        Toast.MakeText(this, "No hay conexión WiFi activa", ToastLength.Long).Show();
                    }
                }
            } catch (Exception ex) {
                Toast.MakeText(this, $"Error: {ex.Message}", ToastLength.Long).Show();
            }
        }

        protected override void OnDestroy() {
            base.OnDestroy();

            // Cerrar conexiones
            try {
                networkStream?.Close();
                tcpClient?.Close();
            } catch { }
        }
    }
}