using aDVanceERP.Core.Modelos.BD;
using aDVanceERP.Core.Presentadores.BD;
using aDVanceERP.Core.Properties;
using aDVanceERP.Core.Repositorios.BD;
using aDVanceERP.Core.Vistas.Interfaces;

namespace aDVanceERP.Core.Vistas.BD;

public partial class VistaConfBd : Form, IVistaConfServidorMySQL {
    private PresentadorConfBd? _presentador;

    public VistaConfBd() {
        InitializeComponent();

        _presentador = new PresentadorConfBd(this, new RepoConfBd());
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

    public string? NombreDireccionServidor {
        get => fieldDireccionServidor.Text;
        set => fieldDireccionServidor.Text = value;
    }

    public string? NombreBaseDatos {
        get => fieldNombreBd.Text;
        set => fieldNombreBd.Text = value;
    }

    public string? NombreUsuario {
        get => fieldNombreUsuario.Text;
        set => fieldNombreUsuario.Text = value;
    }

    public string? Password {
        get => fieldPassword.Text;
        set => fieldPassword.Text = value;
    }

    public bool RecordarConfiguracion {
        get => fieldRecordarConfiguracionBd.Checked;
        set => fieldRecordarConfiguracionBd.Checked = value;
    }

    public event EventHandler<ConfBd>? AlmacenarConfiguracion;

    public void Inicializar() {
        // Conectar eventos
        fieldNombreBd.IconRightClick += delegate {
            fieldNombreBd.UseSystemPasswordChar = !fieldNombreBd.UseSystemPasswordChar;
            fieldNombreBd.PasswordChar = fieldNombreBd.UseSystemPasswordChar ? '●' : char.MinValue;
            fieldNombreBd.IconRight = fieldNombreBd.UseSystemPasswordChar ? Resources.closed_eye_20px : Resources.eye_20px;
        };
        btnValidarConexion.Click += delegate(object? sender, EventArgs e) {
            AlmacenarConfiguracion?.Invoke(sender,
                new ConfBd {
                    Servidor = NombreDireccionServidor ?? "localhost",
                    BaseDatos = NombreBaseDatos ?? "advanceerp",
                    Usuario = NombreUsuario ?? "admin",
                    Password = Password ?? "admin",
                    RecordarConfiguracion = RecordarConfiguracion
                });
        };
    }

    public void Mostrar() {
        BringToFront();
        Show();
    }

    public void Restaurar() {
        NombreDireccionServidor = string.Empty;
        NombreBaseDatos = string.Empty;
        NombreUsuario = string.Empty;
        Password = string.Empty;
    }

    public void Ocultar() {
        Hide();
    }

    public void Cerrar() {
        Dispose();
    }
}