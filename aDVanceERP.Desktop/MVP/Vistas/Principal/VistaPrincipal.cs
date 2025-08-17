using aDVanceERP.Core.MVP.Modelos.Repositorios;
using aDVanceERP.Core.MVP.Modelos.Repositorios.Plantillas;
using aDVanceERP.Core.Utiles;
using aDVanceERP.Desktop.MVP.Vistas.Principal.Plantillas;

using Guna.UI2.WinForms;

namespace aDVanceERP.Desktop.MVP.Vistas.Principal; 

public partial class VistaPrincipal : Form, IVistaPrincipal {
    public VistaPrincipal() {
        InitializeComponent();
        Inicializar();
    }

    public IRepoVista? Vistas { get; private set; }

    public IRepoVista Menus { get; private set; }

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

    public bool ServicioTelegramActivo {
        get => fieldServicioTelegram.Visible;
        set {
            fieldServicioTelegram.Visible = value;
            fieldServicioTelegram.Text = $"     Servicio de Telegram {(value ? "activo" : "inactivo")}";
        }
    }

    public event EventHandler? VerNotificaciones;
    public event EventHandler? VerMensajes;
    public event EventHandler? SubMenuUsuario;
    public event EventHandler? Salir;

    public void Inicializar() {
        FormClosing += delegate {
            Salir?.Invoke(this, EventArgs.Empty);
            Cerrar();
        };

        // Repositorios
        Vistas = new RepositorioVistaBase(contenedorVistas);
        Menus = new RepositorioVistaBase(contenedorMenus);

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
            UtilesServidorScanner.Servidor.Detener();

            Salir?.Invoke(sender, args); 
        };

        // Eventos del Servidor SCANNER
        UtilesServidorScanner.Servidor.CambioEstado += delegate (string mensaje) {
            if (InvokeRequired)
                Invoke(new Action(() => { fieldServidorScanner.Text = $"     {mensaje}"; }));
            else fieldServidorScanner.Text = $"     {mensaje}";
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
        Vistas.Cerrar(true);
    }
}