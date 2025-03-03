using aDVanceERP.Core.Seguridad.MVP.Vistas.CuentaUsuario.Plantillas;
using aDVanceERP.Core.Seguridad.Properties;

using System.Security;

namespace aDVanceERP.Core.Seguridad.MVP.Vistas.CuentaUsuario {
    public partial class VistaRegistroCuentaUsuario : Form, IVistaRegistroCuentaUsuario {
        private bool _modoEdicion;

        public VistaRegistroCuentaUsuario() {
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

        public string? NombreUsuario {
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

        public string? NombreRolUsuario {
            get => fieldNombreRolUsuario.Text;
            set => fieldNombreRolUsuario.Text = value;
        }

        public bool ModoEdicionDatos {
            get => _modoEdicion;
            set {
                if (value) {
                    fieldPassword.Text = "test-password1";
                    fieldConfirmarPassword.Text = "test-password1";
                }

                fieldPassword.Enabled = !value;
                fieldConfirmarPassword.Enabled = !value;
                fieldSubtitulo.Text = value ? "Detalles y actualización" : "Registro";
                btnRegistrar.Text = value ? "Actualizar usuario" : "Registrar usuario";
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
            fieldPassword.IconRightClick += delegate {
                // fieldPassword
                fieldPassword.UseSystemPasswordChar = !fieldPassword.UseSystemPasswordChar;
                fieldPassword.PasswordChar = fieldPassword.UseSystemPasswordChar ? '●' : char.MinValue;
                fieldPassword.IconRight = fieldPassword.UseSystemPasswordChar ? Resources.closed_eye_20px : Resources.eye_20px;
                // fieldConfirmarPassword
                fieldConfirmarPassword.UseSystemPasswordChar = fieldPassword.UseSystemPasswordChar;
                fieldConfirmarPassword.PasswordChar = fieldPassword.UseSystemPasswordChar ? '●' : char.MinValue;
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

        public void CargarRolesUsuarios(string[] rolesUsuarios) {
            fieldNombreRolUsuario.Items.Add("Ninguno");
            fieldNombreRolUsuario.Items.AddRange(rolesUsuarios);
            fieldNombreRolUsuario.SelectedIndex = 0;
        }

        public void Mostrar() {
            BringToFront();
            ShowDialog();
        }

        public void Restaurar() {
            NombreUsuario = string.Empty;
            fieldPassword.Text = string.Empty;
            fieldConfirmarPassword.Text = string.Empty;
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
