using aDVanceERP.Core.Seguridad.MVP.Vistas.Permiso.Plantillas;

namespace aDVanceERP.Core.Seguridad.MVP.Vistas.Permiso; 

public partial class VistaTuplaPermiso : Form, IVistaTuplaPermiso {
    private string _idPermiso = string.Empty;

    public VistaTuplaPermiso() {
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

    public string? IdPermiso {
        get => _idPermiso;
        set => _idPermiso = value ?? string.Empty;
    }

    public string? NombrePermiso {
        get => fieldNombrePermiso.Text;
        set => fieldNombrePermiso.Text = value;
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
        fieldNombrePermiso.Click += delegate(object? sender, EventArgs e) { TuplaSeleccionada?.Invoke(this, e); };

        btnEliminar.Click += delegate(object? sender, EventArgs e) {
            EliminarTuplaDatos?.Invoke(new[] { IdPermiso ?? string.Empty, NombrePermiso ?? string.Empty }, e);
        };
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