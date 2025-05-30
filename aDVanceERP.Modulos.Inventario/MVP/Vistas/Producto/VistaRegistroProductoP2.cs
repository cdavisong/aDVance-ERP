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

        public event EventHandler? RegistrarUnidadMedida;
        public event EventHandler? RegistrarTipoProducto;
        public event EventHandler? RegistrarDisenoProducto;
        public event EventHandler? EliminarUnidadMedida;
        public event EventHandler? EliminarTipoProducto;
        public event EventHandler? EliminarDisenoProducto;

        private void Inicializar() {
            // Eventos
            fieldUnidadMedida.SelectedIndexChanged += delegate (object? sender, EventArgs args) {
                fieldDescripcionUnidadMedida.Text = DescripcionesUnidadMedida[fieldUnidadMedida.SelectedIndex];
            };
            btnAdicionarUnidadMedida.Click += delegate (object? sender, EventArgs args) {
                RegistrarUnidadMedida?.Invoke(sender, args);
            };
            btnAdicionarTipoProducto.Click += delegate (object? sender, EventArgs args) {
                RegistrarTipoProducto?.Invoke(sender, args);
            };
            btnAdicionarDisenoProducto.Click += delegate (object? sender, EventArgs args) {
                RegistrarDisenoProducto?.Invoke(sender, args);
            };
            btnEliminarUnidadMedida.Click += delegate (object? sender, EventArgs args) {
                EliminarUnidadMedida?.Invoke(sender, args);
            };
            btnEliminarTipoProducto.Click += delegate (object? sender, EventArgs args) {
                EliminarTipoProducto?.Invoke(sender, args);
            };
            btnEliminarDisenoProducto.Click += delegate (object? sender, EventArgs args) {
                EliminarDisenoProducto?.Invoke(sender, args);
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

        public void CargarColores(string[] colores) {
            fieldColorPrimario.AutoCompleteCustomSource.Clear();
            fieldColorPrimario.AutoCompleteCustomSource.AddRange(colores);
            fieldColorPrimario.AutoCompleteMode = AutoCompleteMode.Suggest;
            fieldColorPrimario.AutoCompleteSource = AutoCompleteSource.CustomSource;

            fieldColorSecundario.AutoCompleteCustomSource.Clear();
            fieldColorSecundario.AutoCompleteCustomSource.AddRange(colores);
            fieldColorSecundario.AutoCompleteMode = AutoCompleteMode.Suggest;
            fieldColorSecundario.AutoCompleteSource = AutoCompleteSource.CustomSource;
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
            fieldUnidadMedida.SelectedIndex = 0;
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
