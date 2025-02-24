using aDVanceERP.Modulos.Ventas.MVP.Vistas.DetalleVentaArticulo.Plantillas;

namespace aDVanceERP.Modulos.Ventas.MVP.Vistas.DetalleVentaArticulo {
    public partial class VistaTuplaDetalleVentaArticulo : Form, IVistaTuplaDetalleVentaArticulo {
        private string _idArticulo;

        public VistaTuplaDetalleVentaArticulo() {
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

        public string IdArticulo {
            get => _idArticulo;
            set => _idArticulo = value;
        }

        public string NombreArticulo {
            get => fieldNombreArticulo.Text;
            set => fieldNombreArticulo.Text = value;
        }

        public string Precio {
            get => fieldPrecio.Text;
            set => fieldPrecio.Text = value;
        }

        public string Cantidad {
            get => fieldCantidad.Text;
            set => fieldCantidad.Text = value;
        }

        public Color ColorFondoTupla {
            get => layoutVista.BackColor;
            set => layoutVista.BackColor = value;
        }

        public event EventHandler? TuplaSeleccionada;
        public event EventHandler? EditarDatosTupla;
        public event EventHandler? EliminarDatosTupla;
        public event EventHandler? Salir;

        public void Inicializar() {
            // Eventos
            fieldNombreArticulo.Click += delegate (object? sender, EventArgs e) {
                TuplaSeleccionada?.Invoke(this, e);
            };
            fieldPrecio.Click += delegate (object? sender, EventArgs e) {
                TuplaSeleccionada?.Invoke(this, e);
            };
            fieldCantidad.Click += delegate (object? sender, EventArgs e) {
                TuplaSeleccionada?.Invoke(this, e);
            };

            btnEliminar.Click += delegate (object? sender, EventArgs e) {
                EliminarDatosTupla?.Invoke(this, e);
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
