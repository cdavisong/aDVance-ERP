using aDVanceERP.Core.Repositorios.Comun;
using aDVanceERP.Core.Vistas.Comun.Interfaces;
using aDVanceERP.Desktop.Properties;
using Guna.UI2.WinForms;

namespace aDVanceERP.Desktop.MVP.Vistas.Principal;

public partial class VistaPrincipal : Form, IVistaPrincipal {
    public VistaPrincipal() {
        InitializeComponent();

        Titulo = Resources.TituloAplicacion.Replace("[version]", $"{Program.Version}-beta");
        BarraTitulo = new RepoVistaBase(barraTitulo);
        PanelCentral = new RepoVistaBase(panelCentral);
        BarraEstado = new RepoVistaBase(barraEstado);

        Inicializar();
    }

    public string Titulo {
        get => fieldTitulo.Text;
        private set => fieldTitulo.Text = value;
    }

    public bool MenuUsuarioVisible {
        get => btnMenuUsuario.Visible;
        set {
            btnMenuUsuario.Visible = value;
            //TODO: btnMensajes.Visible = value; 
            //TODO: btnNotificaciones.Visible = value;
        }
    }

    #region Barra de título

    public RepoVistaBase BarraTitulo { get; private set; }
    public Guna2Button BtnNotificaciones => btnNotificaciones;
    public Guna2Button BtnMensajes => btnMensajes;
    public Guna2CirclePictureBox BtnMenuUsuario => btnMenuUsuario;

    #endregion

    public RepoVistaBase PanelCentral { get; private set; }
    public RepoVistaBase BarraEstado { get; private set; }

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
        get => Name;
        private set => Name = value;
    }

    public event EventHandler? VerMenuUsuario;
    public event EventHandler? VerMensajes;
    public event EventHandler? VerNotificaciones;

    public void Inicializar() {
        FormClosing += delegate {
            Cerrar();
        };

        // Eventos        
        btnNotificaciones.Click += (sender, e) => VerNotificaciones?.Invoke(this, EventArgs.Empty);
        btnMensajes.Click += (sender, e) => VerMensajes?.Invoke(this, EventArgs.Empty);
        btnMenuUsuario.Click += (sender, e) => VerMenuUsuario?.Invoke(this, EventArgs.Empty);
        btnMinimizar.Click += (sender, e) => Ocultar();
        btnCerrar.Click += (sender, e) => Close();
    }

    public void ModificarVisibilidadBotonesBarraTitulo(bool visible) {
        btnNotificaciones.Visible = visible;
        btnMensajes.Visible = visible;
        btnMenuUsuario.Visible = visible;
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
        //...
    }

    public void Cerrar() {
        BarraTitulo?.CerrarTodos();
        PanelCentral?.CerrarTodos();
        BarraEstado?.CerrarTodos();
    }
}