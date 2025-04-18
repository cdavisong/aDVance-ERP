using System.Net;
using System.Net.Sockets;
using System.Text;
using _Microsoft.Android.Resource.Designer;
using aDVanceSCANNER.MVP.Modelos;

using Android.Content;
using Android.Content.PM;
using Android.Runtime;
using Android.Support.V4.App;
using Android.Support.V4.Content;
using Android.Views;
using Android.Views.InputMethods;

using ZXing;
using ZXing.Mobile;

using Environment = System.Environment;

namespace aDVanceSCANNER {
    [Activity(Label = "@string/app_name", MainLauncher = true)]
    public class MainActivity : Activity {
        // Componentes UI
        //  - Configuraci�n de red y conexi�n del cliente
        private LinearLayout? _layoutDireccionPuerto;
        private EditText? _fieldDireccionIp;
        private EditText? _fieldPuerto;
        private Button? _btnConectar;
        private Button btnScan;
        private TextView txtResult;
        private TextView txtStatus;
        private LinearLayout historyContainer;

        // Servicios
        private ClienteTCP _clienteTcp;
        private MobileBarcodeScanner barcodeScanner;

        // Lista para almacenar el historial
        private List<string> scanHistory = new List<string>(); 

        // Permisos
        private const int REQUEST_CAMERA = 1;
        private const int REQUEST_INTERNET = 2;

        protected override void OnCreate(Bundle? savedInstanceState) {
            base.OnCreate(savedInstanceState);

            // Configurar pantalla completa (oculta barra de estado y barra de navegaci�n)
            RequestWindowFeature(WindowFeatures.NoTitle);
            Window?.SetFlags(WindowManagerFlags.Fullscreen, WindowManagerFlags.Fullscreen);
            OcultarInterfazSistema();

            // Configurar vista
            SetContentView(ResourceConstant.Layout.activity_main);

            // Inicializar esc�ner
            MobileBarcodeScanner.Initialize(Application);
            barcodeScanner = new MobileBarcodeScanner();

            // Inicializar cliente TCP
            _clienteTcp = new ClienteTCP();

            // Obtener referencias UI
            //  - Configuraci�n de red
            _layoutDireccionPuerto = FindViewById<LinearLayout>(ResourceConstant.Id.layoutDireccionPuerto);
            _fieldDireccionIp = FindViewById<EditText>(ResourceConstant.Id.fieldDireccionIp);
            _fieldPuerto = FindViewById<EditText>(ResourceConstant.Id.fieldPuerto);
            _btnConectar = FindViewById<Button>(ResourceConstant.Id.connectButton);

            btnScan = FindViewById<Button>(ResourceConstant.Id.scanButton);
            txtResult = FindViewById<TextView>(ResourceConstant.Id.resultText);
            txtStatus = FindViewById<TextView>(ResourceConstant.Id.connectionStatus);
            historyContainer = FindViewById<LinearLayout>(ResourceConstant.Id.historyContainer);

            // Preferencias de conexi�n
            var preferenciasConex = GetSharedPreferences("PreferenciasConexion", FileCreationMode.Private);
            if (_fieldDireccionIp != null) _fieldDireccionIp.Text = preferenciasConex?.GetString("ultimoIP", "192.168.1.");

            // Configurar eventos
            if (_btnConectar != null) _btnConectar.Click += ConectarCliente;
            btnScan.Click += BtnScan_Click;

            // Verificar permisos
            CheckPermissions();
        }

        protected override void OnResume() {
            base.OnResume();
            
            // Restaurar pantalla completa cuando la actividad se reanuda
            OcultarInterfazSistema();
        }

        private async void ConectarCliente(object? sender, EventArgs e) {
            OcultarTeclado();

            var textoDireccionIp = _fieldDireccionIp?.Text?.Trim();
            var textoPuerto = _fieldPuerto?.Text?.Trim();

            if (string.IsNullOrEmpty(textoDireccionIp) || !_clienteTcp.EstablecerDireccionIp(textoDireccionIp)) {
                Toast.MakeText(this, "Ingrese una direcci�n IP v�lida", ToastLength.Long)?.Show();
                return;
            }

            if (string.IsNullOrEmpty(textoPuerto) || !_clienteTcp.EstablecerPuerto(int.TryParse(textoPuerto, out var puerto) ? puerto : 0)) {
                Toast.MakeText(this, "Ingrese un puerto v�lido", ToastLength.Long)?.Show();
                return;
            }

            txtStatus.Text = "Conectando...";

            try {
                txtStatus.Text = _clienteTcp.Conectar();

                Toast.MakeText(this, "Conexi�n exitosa", ToastLength.Short)?.Show();

                if (_clienteTcp.Conectado) {
                    var prefs = GetSharedPreferences("PreferenciasConexion", FileCreationMode.Private);
                    var editor = prefs?.Edit();

                    editor?.PutString("ultimoIP", textoDireccionIp);
                    editor?.Commit();
                }

                if (_layoutDireccionPuerto != null) _layoutDireccionPuerto.Visibility = ViewStates.Gone;
                if (_btnConectar != null) _btnConectar.Text = "Desconectar";
            } catch (Exception ex) {
                txtStatus.Text = "Error de conexi�n";
                Toast.MakeText(this, $"Error: {ex.Message}", ToastLength.Long)?.Show();
            }
        }

        private void CheckPermissions() {
            // Permiso de c�mara
            if (ContextCompat.CheckSelfPermission(this, Android.Manifest.Permission.Camera) != Permission.Granted) {
                ActivityCompat.RequestPermissions(this,
                    new string[] { Android.Manifest.Permission.Camera },
                    REQUEST_CAMERA);
            }

            // Permiso de internet
            if (ContextCompat.CheckSelfPermission(this, Android.Manifest.Permission.Internet) != Permission.Granted) {
                ActivityCompat.RequestPermissions(this, new string[] { Android.Manifest.Permission.Internet },
                    REQUEST_INTERNET);
            }
        }

        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Permission[] grantResults) {
            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            if (requestCode != REQUEST_CAMERA) 
                return;

            if (grantResults.Length > 0 && grantResults[0] == Permission.Granted)
                Toast.MakeText(this, "Permiso de c�mara concedido", ToastLength.Short)?.Show();
            else
                Toast.MakeText(this, "Se necesita permiso de c�mara para escanear", ToastLength.Long)?.Show();
        }

        private async void BtnScan_Click(object sender, EventArgs e) {
            try {
                var options = new MobileBarcodeScanningOptions {
                    PossibleFormats = new List<BarcodeFormat> {
                        BarcodeFormat.EAN_13,    // C�digos de barras est�ndar
                        BarcodeFormat.EAN_8,     // C�digos de barras cortos
                        BarcodeFormat.UPC_A,     // C�digos UPC
                        BarcodeFormat.CODE_128,  // C�digos 128
                        BarcodeFormat.QR_CODE    // C�digos QR 
                },
                    TryHarder = true,
                    UseFrontCameraIfAvailable = false // Usar siempre la c�mara trasera
                };

                // Configurar el esc�ner para pantalla completa
                barcodeScanner.UseCustomOverlay = false;
                barcodeScanner.TopText = "Escaneo de c�digo QR/Barra";
                barcodeScanner.FlashButtonText = "Flash";
                barcodeScanner.CancelButtonText = "Cancelar";

                // Forzar pantalla completa en la vista del esc�ner
                barcodeScanner.CustomOverlay = new LinearLayout(this) {
                    LayoutParameters = new ViewGroup.LayoutParams(
                        ViewGroup.LayoutParams.MatchParent,
                        ViewGroup.LayoutParams.MatchParent)
                };

                var result = await barcodeScanner.Scan(options);

                if (result == null) 
                    return;

                txtResult.Text = result.Text;

                // A�adir al historial
                AdicionarResultadoHistorial(result.Text, result.BarcodeFormat.ToString());

                // Enviar datos al servidor
                _clienteTcp.Enviar(result.Text);
            } catch (Exception ex) {
                Toast.MakeText(this, $"Error: {ex.Message}", ToastLength.Long)?.Show();
            }
        }

        private void AdicionarResultadoHistorial(string code, string format) {
            // A�adir a la lista en memoria
            scanHistory.Insert(0, $"{DateTime.Now:HH:mm:ss} - {format}: {code}");

            // Limitar el historial a los �ltimos 50 escaneos (opcional)
            if (scanHistory.Count > 50) {
                scanHistory.RemoveAt(scanHistory.Count - 1);
            }

            // Actualizar la UI
            ActualizarInterfazHistorial();
        }

        private void ActualizarInterfazHistorial() {
            // Limpiar el contenedor
            historyContainer.RemoveAllViews();

            // A�adir cada elemento del historial
            foreach (var textView in scanHistory.Select(item => new TextView(this) {
                         Text = item,
                         TextSize = 12,
                         LayoutParameters = new LinearLayout.LayoutParams(
                             ViewGroup.LayoutParams.MatchParent,
                             ViewGroup.LayoutParams.WrapContent)
                     })) {

                // A�adir margen inferior
                ((LinearLayout.LayoutParams) textView.LayoutParameters!).BottomMargin = 8;

                historyContainer.AddView(textView);
            }
        }

        [Obsolete("Obsolete")]
        private void OcultarInterfazSistema() {
            if (Window != null)
                Window.DecorView.SystemUiVisibility = (StatusBarVisibility)
                    (SystemUiFlags.LayoutStable |
                     SystemUiFlags.LayoutHideNavigation |
                     SystemUiFlags.LayoutFullscreen |
                     SystemUiFlags.HideNavigation |
                     SystemUiFlags.Fullscreen |
                     SystemUiFlags.ImmersiveSticky);
        }

        private void OcultarTeclado() {
            var inputMethodManager = (InputMethodManager) GetSystemService(InputMethodService)!;
            var currentFocus = CurrentFocus;

            if (currentFocus != null)
                inputMethodManager.HideSoftInputFromWindow(currentFocus.WindowToken, HideSoftInputFlags.None);

            // Tambi�n limpia el foco del EditText
            _fieldDireccionIp?.ClearFocus();
            _fieldPuerto?.ClearFocus();
        }

        protected override void OnDestroy() {
            base.OnDestroy();

            // Cerrar conexiones
            try {
                _clienteTcp.Dispose();
            }
            catch {
                // ignored
            }
        }
    }
}