using aDVanceERP.Modulos.Inventario.MVP.Vistas.Almacen.Plantillas;

namespace aDVanceERP.Modulos.Inventario.MVP.Vistas.Almacen; 

public partial class VistaRegistroAlmacen : Form, IVistaRegistroAlmacen {
    private bool _modoEdicion;

    public VistaRegistroAlmacen() {
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

    public string Nombre {
        get => fieldNombre.Text;
        set => fieldNombre.Text = value;
    }

    public string Direccion {
        get => fieldDireccion.Text;
        set => fieldDireccion.Text = value;
    }

    public bool AutorizoVenta {
        get => fieldAutorizoVentaArticulos.Checked;
        set => fieldAutorizoVentaArticulos.Checked = value;
    }

    public string Notas {
        get => fieldNotas.Text;
        set => fieldNotas.Text = value;
    }

    public bool ModoEdicionDatos {
        get => _modoEdicion;
        set {
            fieldSubtitulo.Text = value ? "Detalles y actualización" : "Registro";
            btnRegistrar.Text = value ? "Actualizar almacén" : "Registrar almacén";
            _modoEdicion = value;
        }
    }

    public event EventHandler? RegistrarDatos;
    public event EventHandler? EditarDatos;
    public event EventHandler? EliminarDatos;
    public event EventHandler? Salir;

    public void Inicializar() {
        // Eventos
        btnCerrar.Click += delegate(object? sender, EventArgs args) { Salir?.Invoke(sender, args); };
        btnRegistrar.Click += delegate(object? sender, EventArgs args) {
            if (ModoEdicionDatos)
                EditarDatos?.Invoke(sender, args);
            else
                RegistrarDatos?.Invoke(sender, args);
        };
        btnSalir.Click += delegate(object? sender, EventArgs args) { Salir?.Invoke(sender, args); };
    }

    public void Mostrar() {
        BringToFront();
        ShowDialog();
    }

    public void Restaurar() {
        Nombre = string.Empty;
        Direccion = string.Empty;
        AutorizoVenta = false;
        Notas = string.Empty;
        ModoEdicionDatos = false;
    }

    public void Ocultar() {
        Hide();
    }

    public void Cerrar() {
        Dispose();
    }
}