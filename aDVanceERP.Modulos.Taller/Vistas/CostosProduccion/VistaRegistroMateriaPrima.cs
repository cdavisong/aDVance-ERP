
using aDVanceERP.Core.Utiles.Datos;

namespace aDVanceERP.Modulos.Taller.Vistas.CostosProduccion {
    public partial class VistaRegistroMateriaPrima : Form {
        private string[] _descripcionesProductos = Array.Empty<string>();

        public VistaRegistroMateriaPrima() {
            InitializeComponent();
            Inicializar();

            CargarNombresMateriasPrimas();
        }

        public string Nombre {
            get => fieldNombreProducto.Text;
            set => fieldNombreProducto.Text = value;
        }

        public string Descripcion {
            get => fieldDescripcionProducto.Text;
            set => fieldDescripcionProducto.Text = value;
        }

        private void Inicializar() {
            // Eventos
            fieldNombreProducto.TextChanged += delegate (object? sender, EventArgs args) {
                if (string.IsNullOrWhiteSpace(Nombre)) {
                    fieldDescripcionProducto.Text = "No ha descripción disponible para la materia prima seleccionada";
                } else {
                    var index = fieldNombreProducto.AutoCompleteCustomSource.IndexOf(fieldNombreProducto.Text);
                    if (index >= 0 && index < _descripcionesProductos.Length)
                        fieldDescripcionProducto.Text = _descripcionesProductos[index];
                    else
                        fieldDescripcionProducto.Text = "No ha descripción disponible para la materia prima seleccionada";
                }
            };
        }

        private void CargarNombresMateriasPrimas() {
            var nombresDescripcionesProductos = UtilesProducto.ObtenerNombresProductos(0, "MateriaPrima", false, true).Result;
            var nombres = nombresDescripcionesProductos.Select(ndp => ndp.Split('|')[0]).ToArray();

            _descripcionesProductos = nombresDescripcionesProductos.Select(ndp => ndp.Split('|')[1]).ToArray();

            fieldNombreProducto.AutoCompleteCustomSource.Clear();
            fieldNombreProducto.AutoCompleteCustomSource.AddRange(nombres);
            fieldNombreProducto.AutoCompleteMode = AutoCompleteMode.Suggest;
            fieldNombreProducto.AutoCompleteSource = AutoCompleteSource.CustomSource;
        }

        public void Restaurar() {
            Nombre = string.Empty;
            Descripcion = "No ha descripción disponible para la materia prima seleccionada";
        }
    }
}
