using Manigest.Modulos.Inventario.MVP.Vistas.Menu.Plantillas;

namespace Manigest.Modulos.Inventario.MVP.Vistas.Menu {
    public partial class VistaMenuInventario : Form, IVistaMenuInventario {
        public VistaMenuInventario() {
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
         
        public event EventHandler? VerArticulos;
        public event EventHandler? VerMovimientos;
        public event EventHandler? VerAlmacenes;
        public event EventHandler? CambioMenu;
        public event EventHandler? Salir;

        public void Inicializar() {
            // Eventos
            btnArticulos.Click += delegate (object? sender, EventArgs e) {
                CambioMenu?.Invoke(sender, e);
                VerArticulos?.Invoke(sender, e);
            };
            btnMovimientos.Click += delegate (object? sender, EventArgs e) {
                CambioMenu?.Invoke(sender, e);
                VerMovimientos?.Invoke(sender, e);
            };
            btnAlmacenes.Click += delegate (object? sender, EventArgs e) {
                CambioMenu?.Invoke(sender, e);
                VerAlmacenes?.Invoke(sender, e);
            };
        }

        public void Mostrar() {
            BringToFront();
            Show();
        }

        public void Restaurar() {
            btnArticulos.Checked = false;
            btnAlmacenes.Checked = false;
        }

        public void Ocultar() {
            Hide();
        }

        public void Cerrar() {
            Dispose();
        }
    }
}
