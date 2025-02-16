using Manigest.Modulos.Ventas.MVP.Vistas.Menu.Plantillas;

namespace Manigest.Modulos.Ventas.MVP.Vistas.Menu {
    public partial class VistaMenuVentas : Form, IVistaMenuVentas {
        public VistaMenuVentas() {
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

        public event EventHandler? VerVentaArticulos;
        public event EventHandler? CambioMenu;
        public event EventHandler? Salir;
        

        public void Inicializar() {
            // Eventos
            btnVentaArticulos.Click += delegate (object? sender, EventArgs e) {
                CambioMenu?.Invoke(sender, e);
                VerVentaArticulos?.Invoke(sender, e);
            };
        }

        public void Mostrar() {
            BringToFront();
            Show();
        }

        public void Restaurar() {
            btnVentaArticulos.Checked = false;
        }

        public void Ocultar() {
            Hide();
        }

        public void Cerrar() {
            Dispose();
        }
    }
}
