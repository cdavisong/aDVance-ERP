using Manigest.Modulos.Inventario.MVP.Vistas.Articulo.Plantillas;

namespace Manigest.Modulos.Inventario.MVP.Vistas.Articulo {
    public partial class VistaTuplaArticulo : Form, IVistaTuplaArticulo {
        public VistaTuplaArticulo() {
            InitializeComponent();
            Inicializar();
        }

        public bool Habilitada {
            get => Enabled;
            set => Enabled = value;
        }

        public Point Coordenadas {
            get => Location;
            set => Location = value;
        }

        public Size Dimensiones {
            get => Size;
            set => Size = value;
        }

        public string Id {
            get => fieldId.Text;
            set => fieldId.Text = value;
        }

        public string NombreAlmacen {
            get => fieldNombreAlmacen.Text;
            set => fieldNombreAlmacen.Text = value;
        }

        public string Codigo {
            get => fieldCodigo.Text;
            set => fieldCodigo.Text = value;
        }

        public string Nombre {
            get => fieldNombre.Text;
            set => fieldNombre.Text = value;
        }

        public string Descripcion {
            get => fieldDescripcion.Text;
            set => fieldDescripcion.Text = value;
        }

        public float PrecioAdquisicion {
            get => float.TryParse(fieldPrecioAdquisicion.Text, out var value) ? value : 0;
            set => fieldPrecioAdquisicion.Text = value.ToString();
        }

        public float PrecioCesion {
            get => float.TryParse(fieldPrecioCesion.Text, out var value) ? value : 0;
            set => fieldPrecioCesion.Text = value.ToString();
        }

        public int Stock {
            get => int.TryParse(fieldStock.Text, out var value) ? value : 0;
            set => fieldStock.Text = value.ToString();
        }
        
        public Color ColorFondoTupla {
            get => layoutVista.BackColor;
            set => layoutVista.BackColor = value;
        }

        public event EventHandler? TuplaSeleccionada;
        public event EventHandler? MovimientoPositivoStock;
        public event EventHandler? MovimientoNegativoStock;
        public event EventHandler? EditarDatosTupla;
        public event EventHandler? EliminarDatosTupla;
        public event EventHandler? Salir;        

        public void Inicializar() {
            // Eventos
            fieldId.Click += delegate (object? sender, EventArgs e) {
                TuplaSeleccionada?.Invoke(this, e);
            };
            fieldNombreAlmacen.Click += delegate (object? sender, EventArgs e) {
                TuplaSeleccionada?.Invoke(this, e);
            };
            fieldCodigo.Click += delegate (object? sender, EventArgs e) {
                TuplaSeleccionada?.Invoke(this, e);
            };
            fieldNombre.Click += delegate (object? sender, EventArgs e) {
                TuplaSeleccionada?.Invoke(this, e);
            };
            fieldDescripcion.Click += delegate (object? sender, EventArgs e) {
                TuplaSeleccionada?.Invoke(this, e);
            };
            fieldPrecioAdquisicion.Click += delegate (object? sender, EventArgs e) {
                TuplaSeleccionada?.Invoke(this, e);
            };
            fieldPrecioCesion.Click += delegate (object? sender, EventArgs e) {
                TuplaSeleccionada?.Invoke(this, e);
            };
            fieldStock.Click += delegate (object? sender, EventArgs e) {
                TuplaSeleccionada?.Invoke(this, e);
            };

            btnEditar.Click += delegate (object? sender, EventArgs e) {
                EditarDatosTupla?.Invoke(this, e);
            };
            btnMovimientoPositivo.Click += delegate (object? sender, EventArgs e) {
                MovimientoPositivoStock?.Invoke(this, e);
            };
            btnMovimientoNegativo.Click += delegate (object? sender, EventArgs e) {
                MovimientoNegativoStock?.Invoke(this, e);
            };
        }

        public void Mostrar() {
            BringToFront();
            Show();
        }

        public void Restaurar() {
            ColorFondoTupla = BackColor;
        }

        public void Ocultar() {
            Hide();
        }

        public void Cerrar() {
            Dispose();
        }
    }
}
