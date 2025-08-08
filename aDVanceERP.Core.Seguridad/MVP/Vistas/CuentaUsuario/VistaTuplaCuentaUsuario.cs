using aDVanceERP.Core.Seguridad.MVP.Vistas.CuentaUsuario.Plantillas;

namespace aDVanceERP.Core.Seguridad.MVP.Vistas.CuentaUsuario; 

public partial class VistaTuplaCuentaUsuario : Form, IVistaTuplaCuentaUsuario {
    public VistaTuplaCuentaUsuario() {
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

    public string? Id {
        get => fieldId.Text;
        set => fieldId.Text = value;
    }

    public string? NombreUsuario {
        get => fieldNombreUsuario.Text;
        set => fieldNombreUsuario.Text = value;
    }

    public string? NombreRolUsuario {
        get => fieldNombreRolUsuario.Text;
        set {
            fieldNombreRolUsuario.Text = value;

            if (value != null && value.Equals("Administrador")) {
                btnEditar.Enabled = false;
                btnEliminar.Enabled = false;
            }
        }
    }

    public string? EstadoCuentaUsuario {
        get => fieldEstadoCuentaUsuario.Text;
        set => fieldEstadoCuentaUsuario.Text = value;
    }

    public Color ColorFondo {
        get => layoutVista.BackColor;
        set => layoutVista.BackColor = value;
    }

    public event EventHandler? TuplaSeleccionada;
    public event EventHandler? EditarTuplaDatos;
    public event EventHandler? EliminarTuplaDatos;
    public event EventHandler? Salir;

    public void Inicializar() {
        // Eventos
        fieldId.Click += delegate(object? sender, EventArgs e) { TuplaSeleccionada?.Invoke(this, e); };
        fieldNombreUsuario.Click += delegate(object? sender, EventArgs e) { TuplaSeleccionada?.Invoke(this, e); };
        fieldNombreRolUsuario.Click += delegate(object? sender, EventArgs e) { TuplaSeleccionada?.Invoke(this, e); };
        fieldEstadoCuentaUsuario.Click += delegate(object? sender, EventArgs e) { TuplaSeleccionada?.Invoke(this, e); };

        btnEditar.Click += delegate(object? sender, EventArgs e) { EditarTuplaDatos?.Invoke(this, e); };
        btnEliminar.Click += delegate(object? sender, EventArgs e) { EliminarTuplaDatos?.Invoke(this, e); };
    }

    public void Mostrar() {
        BringToFront();
        Show();
    }

    public void Restaurar() {
        ColorFondo = BackColor;
    }

    public void Ocultar() {
        Hide();
    }

    public void Dispose() {
        base.Dispose();
    }
}