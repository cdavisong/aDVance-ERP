using aDVanceERP.Modulos.Inventario.MVP.Vistas.TipoMovimiento.Plantillas;

namespace aDVanceERP.Modulos.Inventario.MVP.Vistas.TipoMovimiento; 

public partial class VistaRegistroTipoMovimiento : Form, IVistaRegistroTipoMovimiento {
    private bool _modoEdicion;

    public VistaRegistroTipoMovimiento() {
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

    public string Nombre {
        get => fieldNombre.Text;
        set => fieldNombre.Text = value;
    }

    public string Efecto {
        get => fieldEfecto.Text;
        set => fieldEfecto.Text = value;
    }

    public bool ModoEdicion {
        get => _modoEdicion;
        set {
            fieldSubtitulo.Text = value ? "Detalles y actualización" : "Registro";
            btnRegistrar.Text = value ? "Actualizar tipo de movimiento" : "Registrar tipo de movimiento";
            _modoEdicion = value;
        }
    }

    public event EventHandler? Registrar;
    public event EventHandler? Editar;
    public event EventHandler? EliminarDatos;
    public event EventHandler? Salir;

    public void Inicializar() {
        // Eventos
        btnCerrar.Click += delegate(object? sender, EventArgs args) { Salir?.Invoke(sender, args); };
        btnRegistrar.Click += delegate(object? sender, EventArgs args) {
            if (ModoEdicion)
                Editar?.Invoke(sender, args);
            else
                Registrar?.Invoke(sender, args);
        };
        btnSalir.Click += delegate(object? sender, EventArgs args) { Salir?.Invoke(sender, args); };
    }

    public void Mostrar() {
        BringToFront();
        ShowDialog();
    }

    public void Restaurar() {
        Nombre = string.Empty;
        Efecto = string.Empty;
        fieldEfecto.SelectedIndex = -1;
        ModoEdicion = false;
    }

    public void Ocultar() {
        Hide();
    }

    public void Dispose() {
        base.Dispose();
    }
}