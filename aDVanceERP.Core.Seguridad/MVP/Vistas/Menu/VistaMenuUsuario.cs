using aDVanceERP.Core.Seguridad.MVP.Vistas.Menu.Plantillas;

namespace aDVanceERP.Core.Seguridad.MVP.Vistas.Menu {
    public partial class VistaMenuUsuario : Form, IVistaMenuUsuario {
        public VistaMenuUsuario() {
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
        public Image? ImagenPerfil {
            get => fieldFotoPerfil.BackgroundImage;
            set => fieldFotoPerfil.BackgroundImage = value;
        }

        public string? NombreApellidos {
            get => fieldNombreApellidos.Text;
            set => fieldNombreApellidos.Text = value;
        }

        public string? CorreoElectronico {
            get => fieldCorreoElectronico.Text;
            set => fieldCorreoElectronico.Text = value;
        }

        public event EventHandler? VerProveedores;
        public event EventHandler? VerClientes;
        public event EventHandler? VerContactos;
        public event EventHandler? CambioMenu;
        public event EventHandler? Salir;
        public event EventHandler? CerrarSesion;
        public event EventHandler? ConfigurarCuenta;

        public void Inicializar() {
            // Eventos
            btnCerrar.Click += delegate (object? sender, EventArgs args) {
                Salir?.Invoke(sender, args);
                Ocultar();
            };
            btnCerrarSesion.Click += delegate (object? sender, EventArgs args) {
                CerrarSesion?.Invoke(sender, args);
                Ocultar();
            };
            btnConfiguracionCuenta.Click += delegate (object? sender, EventArgs args) {
                ConfigurarCuenta?.Invoke(sender, args);
                Ocultar();
            };
        }

        public void Mostrar() {
            BringToFront();
            Show();
        }

        public void Restaurar() {
            
        }

        public void Ocultar() {
            Hide();
        }

        public void Cerrar() {
            Dispose();
        }
    }
}
