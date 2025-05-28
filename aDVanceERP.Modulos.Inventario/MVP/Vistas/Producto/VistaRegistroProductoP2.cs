namespace aDVanceERP.Modulos.Inventario.MVP.Vistas.Producto {
    public partial class VistaRegistroProductoP2 : Form {
        public VistaRegistroProductoP2() {
            InitializeComponent();
            Inicializar();
        }

        public string UnidadMedida {
            get => fieldUnidadMedida.Text;
            set => fieldUnidadMedida.Text = value;
        }

        public string[] DescripcionesUnidadMedida { get; private set; } = Array.Empty<string>();

        public string? ColorPrimario {
            get => fieldColorPrimario.Text;
            set => fieldColorPrimario.Text = value;
        }

        public string? ColorSecundario {
            get => fieldColorSecundario.Text;
            set => fieldColorSecundario.Text = value;
        }

        public string? Tipo {
            get => fieldTipoProducto.Text;
            set => fieldTipoProducto.Text = value;
        }

        public string? Diseno {
            get => fieldDisenoProducto.Text;
            set => fieldDisenoProducto.Text = value;
        }

        private void Inicializar() {
            // Eventos
            fieldUnidadMedida.SelectedIndexChanged += delegate (object? sender, EventArgs args) {
                fieldDescripcionUnidadMedida.Text = DescripcionesUnidadMedida[fieldUnidadMedida.SelectedIndex];
            };
        }

        public void CargarDescripcionesUnidadesMedida(string[] descripcionesUnidadesMedida) {
            Array.Clear(DescripcionesUnidadMedida);
            DescripcionesUnidadMedida = descripcionesUnidadesMedida;
        }

        public void CargarUnidadesMedida(object[] unidadesMedida) {
            fieldUnidadMedida.Items.Clear();
            fieldUnidadMedida.Items.AddRange(unidadesMedida);
            fieldUnidadMedida.SelectedIndex = 0;
        }

        public void CargarTiposProducto(object[] tiposProducto) {
            fieldTipoProducto.Items.Clear();
            fieldTipoProducto.Items.AddRange(tiposProducto);
            fieldTipoProducto.SelectedIndex = -1;
        }

        public void CargarDisenosProducto(object[] disenosProducto) {
            fieldDisenoProducto.Items.Clear();
            fieldDisenoProducto.Items.AddRange(disenosProducto);
            fieldDisenoProducto.SelectedIndex = -1;
        }

        public void Restaurar() {
            UnidadMedida = string.Empty;
            fieldUnidadMedida.SelectedIndex = -1;
            fieldDescripcionUnidadMedida.Text = "Seleccione o registre una unidad de medida";
            ColorPrimario = string.Empty;
            ColorSecundario = string.Empty;
            Tipo = string.Empty;
            fieldTipoProducto.SelectedIndex = -1;
            Diseno = string.Empty;
            fieldDisenoProducto.SelectedIndex = -1;
        }
    }
}
