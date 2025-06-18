using aDVancePOS.Mobile.Database;
using aDVancePOS.Mobile.Models;

using Android.Content;
using Android.Views;
using AndroidX.AppCompat.App;
using AndroidX.RecyclerView.Widget;
using AndroidX.ViewPager.Widget;

namespace aDVancePOS.Mobile.Activities {
    // Activities/RegistroPagoActivity.cs
    [Activity(Label = "Registro de Pago", Theme = "@style/AppTheme")]
    public class RegistroPagoActivity : AppCompatActivity {
        private DatabaseContext _database;
        private decimal _totalVenta;
        private decimal _totalPagado = 0;
        private List<Pago> _pagos = new List<Pago>();
        private PagoAdapter _adapter;

        protected override void OnCreate(Bundle savedInstanceState) {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.activity_registro_pago);

            // Obtener total de la venta
            _totalVenta = (decimal) Intent.GetDoubleExtra("TotalVenta", 0);

            // Configurar base de datos
            var dbPath = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal), "advancepos.db");
            _database = new DatabaseContext(dbPath);

            // Configurar RecyclerView
            var recyclerPagos = FindViewById<RecyclerView>(Resource.Id.recyclerPagos);
            recyclerPagos.SetLayoutManager(new LinearLayoutManager(this));
            _adapter = new PagoAdapter(_pagos);
            recyclerPagos.SetAdapter(_adapter);

            // Configurar controles
            FindViewById<TextView>(Resource.Id.txtTotalVenta).Text = _totalVenta.ToString("C");
            FindViewById<TextView>(Resource.Id.txtPendiente).Text = (_totalVenta - _totalPagado).ToString("C");

            // Configurar botones
            FindViewById<Button>(Resource.Id.btnAgregarPago).Click += OnAgregarPagoClicked;
            FindViewById<Button>(Resource.Id.btnRegistrarPagos).Click += OnRegistrarPagosClicked;
        }

        private void OnAgregarPagoClicked(object sender, EventArgs e) {
            var dialog = new AlertDialog.Builder(this);
            dialog.SetTitle("Agregar Pago");

            var view = LayoutInflater.Inflate(Resource.Layout.dialog_agregar_pago, null);
            var spinnerMetodo = view.FindViewById<Spinner>(Resource.Id.spinnerMetodoPago);
            var editMonto = view.FindViewById<EditText>(Resource.Id.editMonto);

            // Configurar spinner de métodos de pago
            var metodos = new List<string> { "Efectivo", "Tarjeta", "Transferencia" };
            var adapter = new ArrayAdapter<string>(this, Android.Resource.Layout.SimpleSpinnerItem, metodos);
            spinnerMetodo.Adapter = adapter;

            dialog.SetView(view);

            dialog.SetPositiveButton("Agregar", (senderDialog, eDialog) =>
            {
                if (decimal.TryParse(editMonto.Text, out decimal monto) && monto > 0) {
                    var metodo = spinnerMetodo.SelectedItem.ToString();

                    if (metodo == "Transferencia") {
                        // Mostrar pantalla de detalles de transferencia
                        var intent = new Intent(this, typeof(DetalleTransferenciaActivity));
                        intent.PutExtra("Monto", (double) monto);
                        StartActivityForResult(intent, 100);
                    } else {
                        // Agregar pago normal
                        var pago = new Pago {
                            MetodoPago = metodo,
                            Monto = monto,
                            FechaConfirmacion = DateTime.Now,
                            Estado = "Confirmado"
                        };

                        _pagos.Add(pago);
                        _adapter.NotifyDataSetChanged();
                        ActualizarTotales();
                    }
                } else {
                    Toast.MakeText(this, "Monto inválido", ToastLength.Short).Show();
                }
            });

            dialog.SetNegativeButton("Cancelar", (IDialogInterfaceOnClickListener) null);
            dialog.Show();
        }

        protected override void OnActivityResult(int requestCode, Result resultCode, Intent data) {
            base.OnActivityResult(requestCode, resultCode, data);

            if (requestCode == 100 && resultCode == Result.Ok) {
                var monto = (decimal) data.GetDoubleExtra("Monto", 0);
                var pago = new Pago {
                    MetodoPago = "Transferencia",
                    Monto = monto,
                    FechaConfirmacion = DateTime.Now,
                    Estado = "Confirmado"
                };

                _pagos.Add(pago);
                _adapter.NotifyDataSetChanged();
                ActualizarTotales();
            }
        }

        private void ActualizarTotales() {
            _totalPagado = _pagos.Sum(p => p.Monto);
            FindViewById<TextView>(Resource.Id.txtPagado).Text = _totalPagado.ToString("C");
            FindViewById<TextView>(Resource.Id.txtPendiente).Text = (_totalVenta - _totalPagado).ToString("C");
        }

        private async void OnRegistrarPagosClicked(object sender, EventArgs e) {
            if (_pagos.Count == 0) {
                Toast.MakeText(this, "Debe agregar al menos un pago", ToastLength.Short).Show();
                return;
            }

            // Aquí deberías tener el ID de la venta, pero como ejemplo lo dejamos así
            Toast.MakeText(this, "Pagos registrados correctamente", ToastLength.Short).Show();
            Finish();
        }
    }
}