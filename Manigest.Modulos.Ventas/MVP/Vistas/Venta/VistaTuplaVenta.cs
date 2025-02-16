using Manigest.Modulos.Ventas.MVP.Vistas.Venta.Plantillas;

namespace Manigest.Modulos.Ventas.MVP.Vistas.Venta {
    public partial class VistaTuplaVenta : Form, IVistaTuplaVenta {
        public VistaTuplaVenta() {
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

        public string Fecha {
            get => fieldFecha.Text;
            set => fieldFecha.Text = value;
        }

        public string NombreAlmacen {
            get => fieldNombreAlmacen.Text;
            set => fieldNombreAlmacen.Text = value;
        }

        public string NombreCliente {
            get => fieldNombreCliente.Text;
            set => fieldNombreCliente.Text = value;
        }

        public string CantidadProductos {
            get => fieldCantidadProductos.Text;
            set => fieldCantidadProductos.Text = value;
        }

        public string Total {
            get => fieldTotal.Text;
            set => fieldTotal.Text = value;
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
            fieldId.Click += delegate (object? sender, EventArgs e) {
                TuplaSeleccionada?.Invoke(this, e);
            };
            fieldFecha.Click += delegate (object? sender, EventArgs e) {
                TuplaSeleccionada?.Invoke(this, e);
            };
            fieldNombreAlmacen.Click += delegate (object? sender, EventArgs e) {
                TuplaSeleccionada?.Invoke(this, e);
            };
            fieldNombreCliente.Click += delegate (object? sender, EventArgs e) {
                TuplaSeleccionada?.Invoke(this, e);
            };
            fieldCantidadProductos.Click += delegate (object? sender, EventArgs e) {
                TuplaSeleccionada?.Invoke(this, e);
            };
            fieldTotal.Click += delegate (object? sender, EventArgs e) {
                TuplaSeleccionada?.Invoke(this, e);
            };

            btnEditar.Click += delegate (object? sender, EventArgs e) {
                EditarDatosTupla?.Invoke(this, e);
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
