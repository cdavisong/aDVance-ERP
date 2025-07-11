
using aDVanceERP.Core.Utiles.Datos;

namespace aDVanceERP.Modulos.Taller.Vistas.CostosProduccion {
    public partial class VistaRegistroManoObra : Form {
        private string[] _descripcionesActividades = Array.Empty<string>();

        public VistaRegistroManoObra() {
            InitializeComponent();
            Inicializar();

            CargarNombresActividades();
        }

        public string Nombre {
            get => fieldNombreActividad.Text;
            set => fieldNombreActividad.Text = value;
        }

        public string Descripcion {
            get => fieldDescripcionActividad.Text;
            set => fieldDescripcionActividad.Text = value;
        }

        private void Inicializar() {
            // Eventos
            fieldNombreActividad.TextChanged += delegate (object? sender, EventArgs args) {
                if (string.IsNullOrWhiteSpace(Nombre)) {
                    fieldDescripcionActividad.Text = "No ha descripción disponible para la actividad seleccionada";
                } else {
                    var index = fieldNombreActividad.AutoCompleteCustomSource.IndexOf(fieldNombreActividad.Text);
                    if (index >= 0 && index < _descripcionesActividades.Length)
                        fieldDescripcionActividad.Text = _descripcionesActividades[index];
                    else
                        fieldDescripcionActividad.Text = "No ha descripción disponible para la actividad seleccionada";
                }
            };
        }

        private void CargarNombresActividades() {
            var nombresDescripcionesActividades = UtilesActividadProduccion.ObtenerNombresActividadesProduccion(true).Result;
            var nombres = nombresDescripcionesActividades.Select(nda => nda.Split('|')[0]).ToArray();

            _descripcionesActividades = nombresDescripcionesActividades.Select(nda => nda.Split('|')[1]).ToArray();

            fieldNombreActividad.AutoCompleteCustomSource.Clear();
            fieldNombreActividad.AutoCompleteCustomSource.AddRange(nombres);
            fieldNombreActividad.AutoCompleteMode = AutoCompleteMode.Suggest;
            fieldNombreActividad.AutoCompleteSource = AutoCompleteSource.CustomSource;
        }

        public void Restaurar() {
            Nombre = string.Empty;
            Descripcion = "No ha descripción disponible para la actividad seleccionada";
        }
    }
}
