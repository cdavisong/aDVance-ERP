using aDVanceERP.Core.Interfaces.Comun;
using aDVanceERP.Core.MVP.Modelos.Repositorios;
using aDVanceERP.Core.Seguridad.Utiles;
using aDVanceERP.Core.Utiles;
using aDVanceERP.Modulos.Contactos.MVP.Modelos;
using aDVanceERP.Modulos.Contactos.MVP.Vistas.Contacto.Plantillas;

namespace aDVanceERP.Modulos.Contactos.MVP.Vistas.Contacto;

public partial class VistaGestionContactos : Form, IVistaGestionContactos {
    private int _paginaActual = 1;
    private int _paginasTotales = 1;

    public VistaGestionContactos() {
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

    public CriterioBusquedaContacto CriterioBusqueda {
        get => fieldCriterioBusqueda.SelectedIndex >= 0
            ? (CriterioBusquedaContacto)fieldCriterioBusqueda.SelectedIndex
            : default;
        set => fieldCriterioBusqueda.SelectedIndex = (int)value;
    }

    public string? DatoBusqueda {
        get => fieldDatoBusqueda.Text;
        set => fieldDatoBusqueda.Text = value;
    }

    public int AlturaContenedorVistas {
        get => contenedorVistas.Height;
    }

    public int TuplasMaximasContenedor {
        get => AlturaContenedorVistas / VariablesGlobales.AlturaTuplaPredeterminada;
    }

    public int PaginaActual {
        get => _paginaActual;
        set {
            _paginaActual = value;
            fieldPaginaActual.Text = $"Página {value}";
        }
    }

    public int PaginasTotales {
        get => _paginasTotales;
        set {
            _paginasTotales = value;
            fieldPaginasTotales.Text = $"de {value}";
            HabilitarBotonesPaginacion();
        }
    }

    public IRepositorioVista? Vistas { get; private set; }

    public event EventHandler? AlturaContenedorTuplasModificada;
    public event EventHandler? MostrarPrimeraPagina;
    public event EventHandler? MostrarPaginaAnterior;
    public event EventHandler? MostrarPaginaSiguiente;
    public event EventHandler? MostrarUltimaPagina;
    public event EventHandler? SincronizarDatos;
    public event EventHandler? Salir;
    public event EventHandler? RegistrarDatos;
    public event EventHandler? EditarDatos;
    public event EventHandler? EliminarDatos;
    public event EventHandler? BuscarDatos;

    public void Inicializar() {
        // Variables locales
        Vistas = new PanelContenedorVistas(contenedorVistas);

        // Eventos
        fieldCriterioBusqueda.SelectedIndexChanged += delegate {
            fieldDatoBusqueda.Text = string.Empty;
            fieldDatoBusqueda.Visible = fieldCriterioBusqueda.SelectedIndex != 0;
            fieldDatoBusqueda.Focus();

            BuscarDatos?.Invoke(new object[] { CriterioBusqueda, string.Empty }, EventArgs.Empty);

            // Ir a la primera página al cambiar el criterio de búsqueda
            PaginaActual = 1;
            HabilitarBotonesPaginacion();
        };
        fieldDatoBusqueda.TextChanged += delegate(object? sender, EventArgs e) {
            if (!string.IsNullOrEmpty(DatoBusqueda))
                BuscarDatos?.Invoke(new object[] { CriterioBusqueda, DatoBusqueda }, e);
            else SincronizarDatos?.Invoke(sender, e);
        };
        btnCerrar.Click += delegate(object? sender, EventArgs e) {
            Salir?.Invoke(sender, e);
            Ocultar();
        };
        btnRegistrar.Click += delegate(object? sender, EventArgs e) { RegistrarDatos?.Invoke(sender, e); };
        btnPrimeraPagina.Click += delegate(object? sender, EventArgs e) {
            PaginaActual = 1;
            MostrarPrimeraPagina?.Invoke(sender, e);
            SincronizarDatos?.Invoke(sender, e);
            HabilitarBotonesPaginacion();
        };
        btnPaginaAnterior.Click += delegate(object? sender, EventArgs e) {
            PaginaActual--;
            MostrarPaginaAnterior?.Invoke(sender, e);
            SincronizarDatos?.Invoke(sender, e);
            HabilitarBotonesPaginacion();
        };
        btnPaginaSiguiente.Click += delegate(object? sender, EventArgs e) {
            PaginaActual++;
            MostrarPaginaSiguiente?.Invoke(sender, e);
            SincronizarDatos?.Invoke(sender, e);
            HabilitarBotonesPaginacion();
        };
        btnUltimaPagina.Click += delegate(object? sender, EventArgs e) {
            PaginaActual = PaginasTotales;
            MostrarUltimaPagina?.Invoke(sender, e);
            SincronizarDatos?.Invoke(sender, e);
            HabilitarBotonesPaginacion();
        };
        btnSincronizarDatos.Click += delegate(object? sender, EventArgs e) { SincronizarDatos?.Invoke(sender, e); };
        contenedorVistas.Resize += delegate { AlturaContenedorTuplasModificada?.Invoke(this, EventArgs.Empty); };
    }

    public void CargarCriteriosBusqueda(object[] criteriosBusqueda) {
        fieldCriterioBusqueda.Items.Clear();
        fieldCriterioBusqueda.Items.AddRange(criteriosBusqueda);
        
        fieldCriterioBusqueda.SelectedIndex = 0;
    }

    public void Mostrar() {
        Habilitada = true;
        VerificarPermisos();
        BringToFront();
        Show();
    }

    public void Restaurar() {
        Habilitada = true;
        PaginaActual = 1;
        PaginasTotales = 1;

        fieldCriterioBusqueda.SelectedIndex = 0;
    }

    public void Ocultar() {
        Habilitada = false;
        Hide();
    }

    public void Cerrar() {
        // ...
    }

    private void VerificarPermisos() {
        btnRegistrar.Enabled = (UtilesCuentaUsuario.UsuarioAutenticado?.Administrador ?? false)
                               || UtilesCuentaUsuario.PermisosUsuario.ContienePermisoExacto(
                                   "MOD_CONTACTO_CONTACTOS_ADICIONAR")
                               || UtilesCuentaUsuario.PermisosUsuario.ContienePermisoExacto(
                                   "MOD_CONTACTO_CONTACTOS_TODOS")
                               || UtilesCuentaUsuario.PermisosUsuario.ContienePermisoExacto("MOD_CONTACTO_TODOS");
    }

    private void HabilitarBotonesPaginacion() {
        btnPrimeraPagina.Enabled = PaginaActual > 1;
        btnPaginaAnterior.Enabled = PaginaActual > 1;
        btnUltimaPagina.Enabled = PaginaActual < PaginasTotales;
        btnPaginaSiguiente.Enabled = PaginaActual < PaginasTotales;
    }
}