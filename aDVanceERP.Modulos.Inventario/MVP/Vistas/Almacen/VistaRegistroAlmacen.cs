using aDVanceERP.Modulos.Inventario.MVP.Vistas.Almacen.Plantillas;

namespace aDVanceERP.Modulos.Inventario.MVP.Vistas.Almacen; 

public partial class VistaRegistroAlmacen : Form, IVistaRegistroAlmacen {
    private bool _modoEdicion;

    public VistaRegistroAlmacen() {
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

    public string Direccion {
        get => fieldDireccion.Text;
        set => fieldDireccion.Text = value;
    }

    public bool AutorizoVenta {
        get => fieldAutorizoVentaProductos.Checked;
        set => fieldAutorizoVentaProductos.Checked = value;
    }

    public string Notas {
        get => fieldNotas.Text;
        set => fieldNotas.Text = value;
    }

    public bool ModoEdicion {
        get => _modoEdicion;
        set {
            fieldSubtitulo.Text = value ? "Detalles y actualización" : "Registro";
            btnRegistrar.Text = value ? "Actualizar almacén" : "Registrar almacén";
            _modoEdicion = value;
        }
    }

    public event EventHandler? Registrar;
    public event EventHandler? Editar;
    public event EventHandler? EliminarDatos;
    public event EventHandler? Salir;

    public void Inicializar() {
        // Eventos
        btnRegistrar.Click += delegate(object? sender, EventArgs args) {
            if (ModoEdicion)
                Editar?.Invoke(sender, args);
            else
                Registrar?.Invoke(sender, args);
        };
        btnSalir.Click += delegate(object? sender, EventArgs args) { 
            Salir?.Invoke(sender, args); 
        };
    }

    public void Mostrar() {
        BringToFront();
        Show();
    }

    public void Restaurar() {
        Nombre = string.Empty;
        Direccion = string.Empty;
        AutorizoVenta = false;
        Notas = string.Empty;
        ModoEdicion = false;
    }

    public void Ocultar() {
        Hide();
    }

    public void Dispose() {
        base.Dispose();
    }
}