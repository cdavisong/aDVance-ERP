using aDVanceERP.Core.Seguridad.MVP.Vistas.Menu.Plantillas;
using aDVanceERP.Core.Seguridad.Utiles;

namespace aDVanceERP.Core.Seguridad.MVP.Vistas.Menu {
    public partial class VistaMenuUsuario : Form, IVistaMenuUsuario {
        public VistaMenuUsuario() {
            InitializeComponent();
            Inicializar();
        }

        public bool Habilitar {
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

        public string? NombreUsuario {
            get => fieldNomreUsuario.Text;
            set => fieldNomreUsuario.Text = string.IsNullOrEmpty(value) ? "     Bienvenido!" : $"     Bienvenido(a) de vuelta {value}";
        }

        public Image? LogotipoEmpresa {
            get => fieldFotoPerfil.BackgroundImage;
            set => fieldFotoPerfil.BackgroundImage = value;
        }

        public string? NombreEmpresa {
            get => fieldNombreEmpresa.Text;
            set { 
                fieldNombreEmpresa.Text = value; 
                fieldIdEmpresa.Text = Math.Abs(value?.GetHashCode() ?? 0).ToString("0000000000").ToUpper();
            }
        }

        public string? CorreoElectronico {
            get => fieldCorreoElectronico.Text;
            set => fieldCorreoElectronico.Text = value;
        }

        public string? IdEmpresa {
            get => fieldIdEmpresa.Text;
        }

        public event EventHandler? VerProveedores;
        public event EventHandler? VerClientes;
        public event EventHandler? VerContactos;
        public event EventHandler? CambioMenu;
        public event EventHandler? Salir;
        public event EventHandler? CerrarSesion;
        public event EventHandler? ConfigurarEmpresa;

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
            btnConfigurarEmpresa.Click += delegate (object? sender, EventArgs args) {
                ConfigurarEmpresa?.Invoke(sender, args);
                Ocultar();
            };
        }

        public void Mostrar() {
            VerificarPermisos();
            BringToFront();
            Show();
        }

        public void Restaurar() {
            
        }

        public void Ocultar() {
            Hide();
        }

        public void Dispose() {
            base.Dispose();
        }

        private void VerificarPermisos() {
            btnConfigurarEmpresa.Visible = (UtilesCuentaUsuario.UsuarioAutenticado?.Administrador ?? false);
        }
    }
}
