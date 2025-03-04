using aDVanceERP.Core.Seguridad.MVP.Vistas.Autenticacion.Plantillas;
using aDVanceERP.Core.Seguridad.Properties;

using System.Security;

namespace aDVanceERP.Core.Seguridad.MVP.Vistas.Autenticacion {
    public partial class VistaRegistroUsuario : Form, IVistaRegistroUsuario {
        private bool _modoEdicion;

        public VistaRegistroUsuario() {
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

        public string NombreUsuario {
            get => fieldNombreUsuario.Text;
            set => fieldNombreUsuario.Text = value;
        }

        public SecureString? Password {
            get {
                if (!fieldPassword.Text.Equals(fieldConfirmarPassword.Text))
                    return null;

                var password = new SecureString();

                foreach (var c in fieldPassword.Text)
                    password.AppendChar(c);
                password.MakeReadOnly();

                return password;
            }
        }

        public bool ConfirmacionTerminosServicio {
            get => fieldAceptacionTerminosServicio.Checked;
            set => fieldAceptacionTerminosServicio.Checked = value;
        }

        public bool ModoEdicionDatos {
            get => _modoEdicion;
            set => _modoEdicion = value;
        }

        public event EventHandler? RegistrarDatos;
        public event EventHandler? EditarDatos;
        public event EventHandler? EliminarDatos;
        public event EventHandler? Salir;

        public void Inicializar() {
            // Eventos
            fieldPassword.IconRightClick += delegate {
                // fieldPassword
                fieldPassword.UseSystemPasswordChar = !fieldPassword.UseSystemPasswordChar;
                fieldPassword.PasswordChar = fieldPassword.UseSystemPasswordChar ? '●' : char.MinValue;
                fieldPassword.IconRight = fieldPassword.UseSystemPasswordChar ? Resources.closed_eye_20px : Resources.eye_20px;
                // fieldConfirmarPassword
                fieldConfirmarPassword.UseSystemPasswordChar = fieldPassword.UseSystemPasswordChar;
                fieldConfirmarPassword.PasswordChar = fieldPassword.UseSystemPasswordChar ? '●' : char.MinValue;
            };
            btnRegistrarCuentaUsuario.Click += delegate (object? sender, EventArgs e) {
                RegistrarDatos?.Invoke(sender, e);
            };
            btnRegresarAutenticar.Click += delegate (object? sender, EventArgs e) {
                Salir?.Invoke(sender, e);
                Ocultar();
            };
        }

        public void Mostrar() {
            BringToFront();
            Show();
        }

        public void Restaurar() {
            NombreUsuario = string.Empty;
            fieldPassword.Text = string.Empty;
            fieldConfirmarPassword.Text = string.Empty;
            ConfirmacionTerminosServicio = false;
        }

        public void Ocultar() {
            Hide();
        }

        public void Cerrar() {
            Dispose();
        }
    }
}
