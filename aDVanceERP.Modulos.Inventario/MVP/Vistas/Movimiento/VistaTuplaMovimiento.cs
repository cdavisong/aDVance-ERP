using aDVanceERP.Modulos.Inventario.MVP.Vistas.Movimiento.Plantillas;
using aDVanceERP.Modulos.Inventario.Properties;

namespace aDVanceERP.Modulos.Inventario.MVP.Vistas.Movimiento {
    public partial class VistaTuplaMovimiento : Form, IVistaTuplaMovimiento {
        public VistaTuplaMovimiento() {
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

        public string NombreArticulo {
            get => fieldNombreArticulo.Text;
            set => fieldNombreArticulo.Text = value;
        }

        public string NombreAlmacenOrigen {
            get => fieldNombreAlmacenOrigen.Text;
            set => fieldNombreAlmacenOrigen.Text = value;
        }

        public string NombreAlmacenDestino {
            get => fieldNombreAlmacenDestino.Text;
            set => fieldNombreAlmacenDestino.Text = value;
        }

        public string CantidadMovida {
            get => fieldCantidadMovida.Text;
            set => fieldCantidadMovida.Text = value;
        }

        public string Motivo {
            get => fieldMotivo.Text;
            set => fieldMotivo.Text = value;
        }

        public string Fecha {
            get => fieldFecha.Text;
            set => fieldFecha.Text = value;
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
            fieldNombreArticulo.Click += delegate (object? sender, EventArgs e) {
                TuplaSeleccionada?.Invoke(this, e);
            };
            fieldNombreAlmacenOrigen.Click += delegate (object? sender, EventArgs e) {
                TuplaSeleccionada?.Invoke(this, e);
            };
            fieldNombreAlmacenDestino.Click += delegate (object? sender, EventArgs e) {
                TuplaSeleccionada?.Invoke(this, e);
            };
            fieldCantidadMovida.Click += delegate (object? sender, EventArgs e) {
                TuplaSeleccionada?.Invoke(this, e);
            };
            fieldMotivo.Click += delegate (object? sender, EventArgs e) {
                TuplaSeleccionada?.Invoke(this, e);
            };
            fieldFecha.Click += delegate (object? sender, EventArgs e) {
                TuplaSeleccionada?.Invoke(this, e);
            };

            btnEditar.Click += delegate (object? sender, EventArgs e) {
                EditarDatosTupla?.Invoke(this, e);
            };
            btnEliminar.Click += delegate (object? sender, EventArgs e) {
                EliminarDatosTupla?.Invoke(this, e);
            };
        }

        public void ActualizarIconoStock(bool movPositivo) {
            if (movPositivo)
                fieldIcono.BackgroundImage = Resources.move_stockG_20px;
            else
                fieldIcono.BackgroundImage = Resources.move_stockR_20px;
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
