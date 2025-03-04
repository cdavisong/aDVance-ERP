using aDVanceERP.Core.Seguridad.MVP.Vistas.Permiso.Plantillas;

namespace aDVanceERP.Core.Seguridad.MVP.Vistas.Permiso {
    public partial class VistaTuplaPermiso : Form, IVistaTuplaPermiso {
        private string _idArticulo;

        public VistaTuplaPermiso() {
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

        public string? IdPermiso {
            get => _idArticulo;
            set => _idArticulo = value;
        }

        public string? NombrePermiso {
            get => fieldNombrePermiso.Text;
            set => fieldNombrePermiso.Text = value;
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
            
            fieldNombrePermiso.Click += delegate (object? sender, EventArgs e) {
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
