using Manigest.Modulos.Contactos.MVP.Vistas.Menu.Plantillas;

namespace Manigest.Modulos.Contactos.MVP.Vistas.Menu {
    public partial class VistaMenuContacto : Form, IVistaMenuContacto {
        public VistaMenuContacto() {
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

        public event EventHandler? VerProveedores;
        public event EventHandler? VerClientes;
        public event EventHandler? VerContactos;
        public event EventHandler? CambioMenu;
        public event EventHandler? Salir;

        public void Inicializar() {
            // Eventos
            btnProveedores.Click += delegate (object? sender, EventArgs e) {
                CambioMenu?.Invoke(sender, e);
                VerProveedores?.Invoke(sender, e);
            };
            btnClientes.Click += delegate (object? sender, EventArgs e) {
                CambioMenu?.Invoke(sender, e);
                VerClientes?.Invoke(sender, e);
            };
            btnContactos.Click += delegate (object? sender, EventArgs e) {
                CambioMenu?.Invoke(sender, e);
                VerContactos?.Invoke(sender, e);
            };
        }

        public void Mostrar() {
            BringToFront();
            Show();
        }

        public void Restaurar() {
            btnProveedores.Checked = false;
            btnClientes.Checked = false;
            btnContactos.Checked = false;
        }

        public void Ocultar() {
            Hide();
        }

        public void Cerrar() {
            Dispose();
        }
    }
}
