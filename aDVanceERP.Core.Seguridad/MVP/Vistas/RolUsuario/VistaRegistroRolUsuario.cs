using aDVanceERP.Core.Seguridad.MVP.Vistas.RolUsuario.Plantillas;

namespace aDVanceERP.Core.Seguridad.MVP.Vistas.RolUsuario {
    public partial class VistaRegistroRolUsuario : Form, IVistaRegistroRolUsuario {
        private bool _modoEdicion;

        public VistaRegistroRolUsuario() {
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

        public string? NombreRolUsuario {
            get => fieldNombreRolUsuario.Text;
            set => fieldNombreRolUsuario.Text = value;
        }

        public byte NivelAcceso {
            get => (byte) (byte.TryParse(fieldNivelAcceso.Text, out var nivelAcceso) ? nivelAcceso >= 1 ? nivelAcceso : 1 : 1);
            set => fieldNivelAcceso.Text = value == 1 ? string.Empty : value.ToString();
        }

        public bool ModoEdicionDatos {
            get => _modoEdicion;
            set {
                fieldSubtitulo.Text = value ? "Detalles y actualización" : "Registro";
                btnRegistrar.Text = value ? "Actualizar rol" : "Registrar rol";
                _modoEdicion = value;
            }
        }

        public event EventHandler? RegistrarDatos;
        public event EventHandler? EditarDatos;
        public event EventHandler? EliminarDatos;
        public event EventHandler? Salir;

        public void Inicializar() {
            // Eventos
            btnCerrar.Click += delegate (object? sender, EventArgs args) {
                Salir?.Invoke(sender, args);
            };
            btnRegistrar.Click += delegate (object? sender, EventArgs args) {
                if (ModoEdicionDatos)
                    EditarDatos?.Invoke(sender, args);
                else
                    RegistrarDatos?.Invoke(sender, args);
            };
            btnSalir.Click += delegate (object? sender, EventArgs args) {
                Salir?.Invoke(sender, args);
            };
        }

        public void Mostrar() {
            BringToFront();
            ShowDialog();
        }

        public void Restaurar() {
            NombreRolUsuario = string.Empty;
            NivelAcceso = 1;
            ModoEdicionDatos = false;
        }

        public void Ocultar() {
            Hide();
        }

        public void Cerrar() {
            Dispose();
        }
    }
}
