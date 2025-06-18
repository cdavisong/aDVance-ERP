using Android.Content;
using AndroidX.AppCompat.App;

namespace aDVancePOS.Mobile.Activities {
    // Activities/DetalleTransferenciaActivity.cs
    [Activity(Label = "Detalle de Transferencia", Theme = "@style/AppTheme")]
    public class DetalleTransferenciaActivity : AppCompatActivity {
        protected override void OnCreate(Bundle savedInstanceState) {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.activity_detalle_transferencia);

            var monto = (decimal) Intent.GetDoubleExtra("Monto", 0);
            FindViewById<TextView>(Resource.Id.txtMonto).Text = monto.ToString("C");

            FindViewById<Button>(Resource.Id.btnConfirmar).Click += (sender, e) =>
            {
                var alias = FindViewById<EditText>(Resource.Id.editAlias).Text;
                var numeroTransaccion = FindViewById<EditText>(Resource.Id.editNumeroTransaccion).Text;
                var numeroConfirmacion = FindViewById<EditText>(Resource.Id.editNumeroConfirmacion).Text;
                var recordarNumero = FindViewById<CheckBox>(Resource.Id.checkRecordarNumero).Checked;

                if (string.IsNullOrEmpty(alias) || string.IsNullOrEmpty(numeroTransaccion) || string.IsNullOrEmpty(numeroConfirmacion)) {
                    Toast.MakeText(this, "Todos los campos son obligatorios", ToastLength.Short).Show();
                    return;
                }

                var resultIntent = new Intent();
                resultIntent.PutExtra("Monto", (double) monto);
                SetResult(Result.Ok, resultIntent);
                Finish();
            };

            FindViewById<Button>(Resource.Id.btnCancelar).Click += (sender, e) =>
            {
                SetResult(Result.Canceled);
                Finish();
            };
        }
    }
}