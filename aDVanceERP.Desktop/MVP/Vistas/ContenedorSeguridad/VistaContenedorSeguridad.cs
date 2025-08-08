using aDVanceERP.Core.Interfaces;
using aDVanceERP.Core.MVP.Modelos.Repositorios;
using aDVanceERP.Core.Seguridad.Utiles;
using aDVanceERP.Core.Utiles;
using aDVanceERP.Desktop.MVP.Vistas.ContenedorSeguridad.Plantillas;

namespace aDVanceERP.Desktop.MVP.Vistas.ContenedorSeguridad;

public partial class VistaContenedorSeguridad : Form, IVistaContenedorSeguridad {
    public VistaContenedorSeguridad() {
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

    public int AlturaContenedorVistas {
        get => contenedorVistas.Height;
    }

    public int TuplasMaximasContenedor {
        get => AlturaContenedorVistas / VariablesGlobales.AlturaTuplaPredeterminada;
    }

    public IRepositorioVista? Vistas { get; private set; }

    public event EventHandler? Salir;

    public void Inicializar() {
        // Propiedades locales
        Vistas = new PanelContenedorVistas(contenedorVistas);
    }

    public void Mostrar() {
        BringToFront();
        Show();
    }

    public void Restaurar() {
        Vistas?.Restaurar("vistaAutenticacionUsuario");

        // Restablecer el usuario autenticado
        UtilesCuentaUsuario.UsuarioAutenticado = null;
    }

    public void Ocultar() {
        Hide();
    }

    public void Dispose() {
        Vistas?.Cerrar();
    }
}