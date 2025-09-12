using aDVanceERP.Core.Repositorios.Comun;
using aDVanceERP.Core.Utiles;
using aDVanceERP.Desktop.MVP.Vistas.Principal.Plantillas;

using Guna.UI2.WinForms;

namespace aDVanceERP.Desktop.MVP.Vistas.Principal;

public partial class VistaPrincipal : Form, IVistaPrincipal {
    public VistaPrincipal() {
        InitializeComponent();
        Inicializar();
    }

    public RepoVistaBase? Vistas { get; private set; }

    public RepoVistaBase? Menus { get; private set; }

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

    public int AlturaContenedorVistas {
        get => contenedorVistas.Height;
    }

    public int TuplasMaximasContenedor {
        get => AlturaContenedorVistas / VariablesGlobales.AlturaTuplaPredeterminada;
    }

    public Guna2CirclePictureBox BtnSubmenuUsuario {
        get => btnSubMenuUsuario;
    }

    public bool BtnSubmenuUsuarioDisponible {
        get => btnSubMenuUsuario.Visible;
        set {
            btnSubMenuUsuario.Visible = value;
            //TODO: btnMensajes.Visible = value; 
            //TODO: btnNotificaciones.Visible = value;
        }
    }

    public event EventHandler? VerNotificaciones;
    public event EventHandler? VerMensajes;
    public event EventHandler? SubMenuUsuario;
    

    public void Inicializar() {
        FormClosing += delegate {
            Cerrar();
        };

        // Repositorios
        Vistas = new RepoVistaBase(contenedorVistas);
        Menus = new RepoVistaBase(contenedorMenus);

        // Eventos        
        btnNotificaciones.Click += delegate(object? sender, EventArgs args) {
            VerNotificaciones?.Invoke(sender, args);
        };
        btnMensajes.Click += delegate(object? sender, EventArgs args) { 
            VerMensajes?.Invoke(sender, args); };
        btnSubMenuUsuario.Click += delegate(object? sender, EventArgs args) { 
            SubMenuUsuario?.Invoke(sender, args); 
        };
        Resize += delegate { };
        FormClosing += delegate(object? sender, FormClosingEventArgs args) {
            
        };
    }

    public void Mostrar() {        
        BringToFront();
        Show();

        WindowState = FormWindowState.Maximized;
    }

    public void Ocultar() {
        WindowState = FormWindowState.Minimized;
    }

    public void Restaurar() {
        throw new NotImplementedException();
    }

    public void Cerrar() {
        Vistas?.CerrarTodos();
    }
}