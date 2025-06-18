using aDVancePOS.Mobile.Database;
using AndroidX.AppCompat.App;

namespace aDVancePOS.Mobile {
    [Activity(Label = "@string/app_name", MainLauncher = true)]
    public class MainActivity : AppCompatActivity {
        private DatabaseContext _database;

        protected override void OnCreate(Bundle savedInstanceState) {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.activity_main);

            // Configurar base de datos
            var dbPath = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal), "advancepos.db");
            _database = new DatabaseContext(dbPath);

            // Configurar botones
            FindViewById<Button>(Resource.Id.btnNuevaVenta).Click += (sender, e) =>
            {
                StartActivity(typeof(RegistroVentaActivity));
            };

            FindViewById<Button>(Resource.Id.btnExportarVentas).Click += async (sender, e) =>
            {
                var exportador = new ExportadorService(_database);
                var filePath = await exportador.ExportarVentasAJson();

                if (filePath != null) {
                    Toast.MakeText(this, $"Ventas exportadas a: {filePath}", ToastLength.Long).Show();
                } else {
                    Toast.MakeText(this, "Error al exportar ventas", ToastLength.Short).Show();
                }
            };
        }
    }
}