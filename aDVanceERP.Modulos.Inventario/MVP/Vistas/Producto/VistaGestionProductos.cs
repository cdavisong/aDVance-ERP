using System.Globalization;

using aDVanceERP.Core.MVP.Modelos.Repositorios;
using aDVanceERP.Core.MVP.Modelos.Repositorios.Plantillas;
using aDVanceERP.Core.Seguridad.Utiles;
using aDVanceERP.Core.Utiles;
using aDVanceERP.Core.Utiles.Datos;
using aDVanceERP.Modulos.Inventario.MVP.Modelos;
using aDVanceERP.Modulos.Inventario.MVP.Vistas.Producto.Plantillas;

namespace aDVanceERP.Modulos.Inventario.MVP.Vistas.Producto;

public partial class VistaGestionProductos : Form, IVistaGestionProductos {
    private int _paginaActual = 1;
    private int _paginasTotales = 1;

    public VistaGestionProductos() {
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

    public string? NombreAlmacen {
        get => fieldNombreAlmacen.Text;
        set => fieldNombreAlmacen.Text = value;
    }

    public int Categoria {
        get => fieldCriterioCategoriaProducto.SelectedIndex - 1;
        set => fieldCriterioCategoriaProducto.SelectedIndex = value + 1;
    }

    public FiltroBusquedaProducto FiltroBusqueda {
        get => fieldFiltroBusqueda.SelectedIndex > 0
            ? (FiltroBusquedaProducto) fieldFiltroBusqueda.SelectedIndex
            : default;
        set => fieldFiltroBusqueda.SelectedIndex = (int) value;
    }

    public string? DatoBusqueda {
        get => fieldDatoBusqueda.Text;
        set => fieldDatoBusqueda.Text = value;
    }

    public string ValorBrutoInversion {
        get => fieldValorBrutoInversion.Text;
        set {
            layoutValorBrutoInversion.Visible = !value.Equals("0.00");
            fieldValorBrutoInversion.Text = value;
        }
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
            fieldPaginaActual.Text = $@"Página {value}";
        }
    }

    public int PaginasTotales {
        get => _paginasTotales;
        set {
            _paginasTotales = value;
            fieldPaginasTotales.Text = $@"de {value}";
            HabilitarBotonesPaginacion();
        }
    }

    public IRepoVista? Vistas { get; private set; }

    public event EventHandler? AlturaContenedorTuplasModificada;
    public event EventHandler? MostrarPrimeraPagina;
    public event EventHandler? MostrarPaginaAnterior;
    public event EventHandler? MostrarPaginaSiguiente;
    public event EventHandler? MostrarUltimaPagina;
    public event EventHandler? SincronizarDatos;
    
    public event EventHandler? RegistrarDatos;
    public event EventHandler? EditarDatos;
    public event EventHandler? EliminarDatos;
    public event EventHandler? BuscarDatos;

    public void Inicializar() {
        // Variables locales
        Vistas = new RepositorioVistaBase(contenedorVistas);

        // Eventos
        fieldNombreAlmacen.SelectedIndexChanged += delegate (object? sender, EventArgs e) {
            if (!string.IsNullOrEmpty(NombreAlmacen))
                BuscarDatos?.Invoke(new object[] { FiltroBusqueda, new[] { NombreAlmacen, Categoria.ToString(), DatoBusqueda } }, e);
            else SincronizarDatos?.Invoke(sender, e);

            ActualizarMontoInversion();
        };
        fieldCriterioCategoriaProducto.SelectedIndexChanged += delegate (object? sender, EventArgs e) {
            if (Categoria > -1)
                BuscarDatos?.Invoke(new object[] { FiltroBusqueda, new[] { NombreAlmacen, Categoria.ToString(), DatoBusqueda } }, e);
            else SincronizarDatos?.Invoke(sender, e);

            ActualizarMontoInversion();
        };
        fieldFiltroBusqueda.SelectedIndexChanged += delegate {
            fieldDatoBusqueda.Text = string.Empty;
            fieldDatoBusqueda.Visible = fieldFiltroBusqueda.SelectedIndex != 0;
            fieldDatoBusqueda.Focus();

            BuscarDatos?.Invoke(new object[] { FiltroBusqueda, new[] { NombreAlmacen, Categoria.ToString(), DatoBusqueda } },
                EventArgs.Empty);

            // Ir a la primera página al cambiar el criterio de búsqueda
            PaginaActual = 1;
            HabilitarBotonesPaginacion();
        };
        fieldDatoBusqueda.TextChanged += delegate (object? sender, EventArgs e) {
            if (!string.IsNullOrEmpty(DatoBusqueda))
                BuscarDatos?.Invoke(new object[] { FiltroBusqueda, new[] { NombreAlmacen, Categoria.ToString(), DatoBusqueda } }, e);
            else SincronizarDatos?.Invoke(sender, e);
        };
        btnCerrar.Click += delegate (object? sender, EventArgs e) {
            Ocultar();
        };
        btnRegistrar.Click += delegate (object? sender, EventArgs e) {
            RegistrarDatos?.Invoke(sender, e);

            ActualizarMontoInversion();
        };
        btnPrimeraPagina.Click += delegate (object? sender, EventArgs e) {
            PaginaActual = 1;
            MostrarPrimeraPagina?.Invoke(sender, e);
            SincronizarDatos?.Invoke(sender, e);
            HabilitarBotonesPaginacion();
        };
        btnPaginaAnterior.Click += delegate (object? sender, EventArgs e) {
            PaginaActual--;
            MostrarPaginaAnterior?.Invoke(sender, e);
            SincronizarDatos?.Invoke(sender, e);
            HabilitarBotonesPaginacion();
        };
        btnPaginaSiguiente.Click += delegate (object? sender, EventArgs e) {
            PaginaActual++;
            MostrarPaginaSiguiente?.Invoke(sender, e);
            SincronizarDatos?.Invoke(sender, e);
            HabilitarBotonesPaginacion();
        };
        btnUltimaPagina.Click += delegate (object? sender, EventArgs e) {
            PaginaActual = PaginasTotales;
            MostrarUltimaPagina?.Invoke(sender, e);
            SincronizarDatos?.Invoke(sender, e);
            HabilitarBotonesPaginacion();
        };
        btnSincronizarDatos.Click += delegate (object? sender, EventArgs e) {
            SincronizarDatos?.Invoke(sender, e);

            ActualizarMontoInversion();
        };
        contenedorVistas.Resize += delegate {
            AlturaContenedorTuplasModificada?.Invoke(this, EventArgs.Empty);
        };
    }

    public void CargarNombresAlmacenes(object[] nombresAlmacenes) {
        fieldNombreAlmacen.Items.Clear();
        fieldNombreAlmacen.Items.Add("Todos los almacenes");
        fieldNombreAlmacen.Items.AddRange(nombresAlmacenes);
        fieldNombreAlmacen.SelectedIndex = fieldNombreAlmacen.Items.Count > 0 ? 0 : -1;
    }

    public void CargarCriteriosBusqueda(object[] criteriosBusqueda) {
        fieldFiltroBusqueda.Items.Clear();
        fieldFiltroBusqueda.Items.AddRange(criteriosBusqueda);
        fieldFiltroBusqueda.SelectedIndex = 0;
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

        fieldNombreAlmacen.SelectedIndex = 0;
        fieldFiltroBusqueda.SelectedIndex = 0;
    }

    public void Ocultar() {
        Habilitada = false;
        Hide();
    }

    public void Cerrar() {
        //...
    }

    private async void ActualizarMontoInversion() {
        ValorBrutoInversion =
            (await UtilesProducto.ObtenerMontoInvertidoEnProductos(await UtilesAlmacen.ObtenerIdAlmacen(NombreAlmacen)))
            .ToString("N2", CultureInfo.InvariantCulture);
    }

    private void VerificarPermisos() {
        if (UtilesCuentaUsuario.UsuarioAutenticado == null || UtilesCuentaUsuario.PermisosUsuario == null) {
            btnRegistrar.Enabled = false;
            return;
        }

        btnRegistrar.Enabled = (UtilesCuentaUsuario.UsuarioAutenticado?.Administrador ?? false)
                               || UtilesCuentaUsuario.PermisosUsuario.ContienePermisoExacto(
                                   "MOD_INVENTARIO_PRODUCTOS_ADICIONAR")
                               || UtilesCuentaUsuario.PermisosUsuario.ContienePermisoExacto(
                                   "MOD_INVENTARIO_PRODUCTOS_TODOS")
                               || UtilesCuentaUsuario.PermisosUsuario.ContienePermisoExacto("MOD_INVENTARIO_TODOS");
    }

    private void HabilitarBotonesPaginacion() {
        btnPrimeraPagina.Enabled = PaginaActual > 1;
        btnPaginaAnterior.Enabled = PaginaActual > 1;
        btnUltimaPagina.Enabled = PaginaActual < PaginasTotales;
        btnPaginaSiguiente.Enabled = PaginaActual < PaginasTotales;
    }
}