using System.CodeDom;

using aDVanceERP.Modulos.Contactos.MVP.Vistas.Mensajero.Plantillas;

namespace aDVanceERP.Modulos.Contactos.MVP.Vistas.Mensajero; 

public partial class VistaRegistroMensajero : Form, IVistaRegistroMensajero {
    private bool _modoEdicion;

    public VistaRegistroMensajero() {
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

    public string TelefonoMovil {
        get => fieldTelefonoMovil.Text;
        set => fieldTelefonoMovil.Text = value;
    }

    public bool ModoEdicionDatos {
        get => _modoEdicion;
        set {
            fieldTelefonoMovil.ReadOnly = value;
            fieldSubtitulo.Text = value ? "Detalles y actualización" : "Registro";
            btnRegistrar.Text = value ? "Actualizar contacto" : "Registrar contacto";
            _modoEdicion = value;
        }
    }

    public event EventHandler? RegistrarDatos;
    public event EventHandler? EditarDatos;
    public event EventHandler? EliminarDatos;
    

    public void Inicializar() {
        // Eventos
        btnCerrar.Click += delegate(object? sender, EventArgs args) { 
            Close(); 
        };
        btnRegistrar.Click += delegate(object? sender, EventArgs args) {
            if (ModoEdicionDatos)
                EditarDatos?.Invoke(sender, args);
            else
                RegistrarDatos?.Invoke(sender, args);
        };
        btnSalir.Click += delegate(object? sender, EventArgs args) { 
            Close(); 
        };
    }

    public void Mostrar() {
        BringToFront();
        ShowDialog();
    }

    public void Restaurar() {
        Nombre = string.Empty;
        TelefonoMovil = string.Empty;
        ModoEdicionDatos = false;
    }

    public void Ocultar() {
        Hide();
    }

    public void Cerrar() {
        Dispose();
    }
}