using System.Security;

using aDVanceERP.Core.Mensajes.Utiles;
using aDVanceERP.Core.Seguridad.MVP.Vistas.CuentaUsuario.Plantillas;
using aDVanceERP.Core.Seguridad.Properties;

namespace aDVanceERP.Core.Seguridad.MVP.Vistas.CuentaUsuario;

public partial class VistaRegistroCuentaUsuario : Form, IVistaRegistroCuentaUsuario {
    private bool _modoEdicion;

    public VistaRegistroCuentaUsuario() {
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
        get => fieldNombreUsuario.Text;
        set => fieldNombreUsuario.Text = value;
    }

    public SecureString? Password {
        get {
            if (!fieldPassword.Text.Equals(fieldConfirmarPassword.Text)) {
                CentroNotificaciones.Mostrar($"Las contraseñas no coinciden, rectifique los datos y presiones al botón \"{btnRegistrar.Text}\"", Mensajes.MVP.Modelos.TipoNotificacion.Advertencia);
                return null;
            }

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

    public bool ModoEdicion {
        get => _modoEdicion;
        set {
            if (value) {
                fieldPassword.Text = "test-password1";
                fieldConfirmarPassword.Text = "test-password1";
            }

            fieldPassword.IconRight = null;
            fieldSubtitulo.Text = value ? "Detalles y actualización" : "Registro";
            btnRegistrar.Text = value ? "Actualizar usuario" : "Registrar usuario";
            _modoEdicion = value;
        }
    }

    public event EventHandler? Registrar;
    public event EventHandler? Editar;
    public event EventHandler? EliminarDatos;
    public event EventHandler? Salir;

    public void Inicializar() {
        // Eventos
        btnCerrar.Click += delegate (object? sender, EventArgs args) { Salir?.Invoke(sender, args); };
        fieldPassword.IconRightClick += delegate {
            if (ModoEdicion)
                return;

            // fieldPassword
            fieldPassword.UseSystemPasswordChar = !fieldPassword.UseSystemPasswordChar;
            fieldPassword.PasswordChar = fieldPassword.UseSystemPasswordChar ? '●' : char.MinValue;
            fieldPassword.IconRight = fieldPassword.UseSystemPasswordChar ? Resources.closed_eye_20px : Resources.eye_20px;
            
            // fieldConfirmarPassword
            fieldConfirmarPassword.UseSystemPasswordChar = fieldPassword.UseSystemPasswordChar;
            fieldConfirmarPassword.PasswordChar = fieldPassword.UseSystemPasswordChar ? '●' : char.MinValue;
        };
        btnRegistrar.Click += delegate (object? sender, EventArgs args) {
            if (ModoEdicion && fieldPassword.Text.Equals("test-password1"))
                Salir?.Invoke(sender, args);
            else if (ModoEdicion)
                Editar?.Invoke(sender, args);
            else
                Registrar?.Invoke(sender, args);
        };
        btnSalir.Click += delegate (object? sender, EventArgs args) { Salir?.Invoke(sender, args); };
    }

    public void CargarRolesUsuarios(string[] rolesUsuarios) {
        var rolesFiltrados = rolesUsuarios.Where(rol => rol != "Administrador").ToArray();

        fieldNombreRolUsuario.Items.Add("Ninguno");
        fieldNombreRolUsuario.Items.AddRange(rolesFiltrados);
        fieldNombreRolUsuario.SelectedIndex = rolesUsuarios.Length > 0 ? 0 : -1;
    }

    public void Mostrar() {
        BringToFront();
        ShowDialog();
    }

    public void Restaurar() {
        NombreUsuario = string.Empty;
        fieldPassword.Text = string.Empty;
        fieldConfirmarPassword.Text = string.Empty;
        ModoEdicion = false;
    }

    public void Ocultar() {
        Hide();
    }

    public void Dispose() {
        base.Dispose();
    }
}