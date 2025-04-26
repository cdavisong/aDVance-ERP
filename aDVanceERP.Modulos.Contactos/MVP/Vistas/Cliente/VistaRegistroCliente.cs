using aDVanceERP.Modulos.Contactos.MVP.Vistas.Cliente.Plantillas;

namespace aDVanceERP.Modulos.Contactos.MVP.Vistas.Cliente; 

public partial class VistaRegistroCliente : Form, IVistaRegistroCliente {
    private bool _modoEdicion;

    public VistaRegistroCliente() {
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
    
    public string? RazonSocial {
        get => fieldRazonSocial.Text;
        set => fieldRazonSocial.Text = value;
    }

    public string? Numero {
        get => fieldNumero.Text;
        set => fieldNumero.Text = value;
    }

    public string TelefonoMovil {
        get => fieldTelefonoMovil.Text;
        set => fieldTelefonoMovil.Text = value;
    }

    public string TelefonoFijo {
        get => fieldTelefonoFijo.Text;
        set => fieldTelefonoFijo.Text = value;
    }

    public string Direccion {
        get => fieldDireccion.Text;
        set {
            fieldDireccion.Text = value;
            fieldDireccion.Margin = new Padding(1, value?.Length > 43 ? 10 : 1, 1, 1);
        }
    }

    public bool ModoEdicionDatos {
        get => _modoEdicion;
        set {
            fieldTelefonoMovil.ReadOnly = value;
            fieldTelefonoFijo.ReadOnly = value;
            fieldDireccion.ReadOnly = value;
            fieldSubtitulo.Text = value ? "Detalles y actualización" : "Registro";
            btnRegistrar.Text = value ? "Actualizar cliente" : "Crear cliente";
            _modoEdicion = value;
        }
    }

    public event EventHandler? RegistrarDatos;
    public event EventHandler? EditarDatos;
    public event EventHandler? EliminarDatos;
    public event EventHandler? Salir;

    public void Inicializar() {
        // Eventos
        btnCerrar.Click += delegate(object? sender, EventArgs args) { 
            Salir?.Invoke(sender, args); 
        };
        btnRegistrar.Click += delegate(object? sender, EventArgs args) {
            if (ModoEdicionDatos)
                EditarDatos?.Invoke(sender, args);
            else
                RegistrarDatos?.Invoke(sender, args);
        };
        btnSalir.Click += delegate(object? sender, EventArgs args) { 
            Salir?.Invoke(sender, args); 
        };
    }

    public void Mostrar() {
        BringToFront();
        ShowDialog();
    }

    public void Restaurar() {
        Numero = string.Empty;
        RazonSocial = string.Empty;
        TelefonoMovil = string.Empty;
        TelefonoFijo = string.Empty;
        Direccion = string.Empty;
        ModoEdicionDatos = false;
    }

    public void Ocultar() {
        Hide();
    }

    public void Cerrar() {
        Dispose();
    }
}