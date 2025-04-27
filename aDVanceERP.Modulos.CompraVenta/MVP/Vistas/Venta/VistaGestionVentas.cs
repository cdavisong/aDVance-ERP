using System.Globalization;
using aDVanceERP.Core.MVP.Modelos.Repositorios;
using aDVanceERP.Core.MVP.Modelos.Repositorios.Plantillas;
using aDVanceERP.Core.Seguridad.Utiles;
using aDVanceERP.Core.Utiles;
using aDVanceERP.Core.Utiles.Datos;
using aDVanceERP.Modulos.CompraVenta.MVP.Modelos;
using aDVanceERP.Modulos.CompraVenta.MVP.Vistas.Venta.Plantillas;

namespace aDVanceERP.Modulos.CompraVenta.MVP.Vistas.Venta; 

public partial class VistaGestionVentas : Form, IVistaGestionVentas {
    private int _paginaActual = 1;
    private int _paginasTotales = 1;

    public VistaGestionVentas() {
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

    public string FormatoReporte {
        get => fieldFormatoReporte.Text;
        set => fieldFormatoReporte.Text = value;
    }

    public bool HabilitarBtnConfirmarEntrega {
        get => btnConfirmarEntrega.Visible;
        set => btnConfirmarEntrega.Visible = value;
    }

    public bool HabilitarBtnConfirmarPagos {
        get => btnConfirmarPagos.Visible;
        set => btnConfirmarPagos.Visible = value;
    }

    public CriterioBusquedaVenta CriterioBusqueda {
        get => fieldCriterioBusqueda.SelectedIndex >= 0
            ? (CriterioBusquedaVenta)fieldCriterioBusqueda.SelectedIndex
            : default;
        set => fieldCriterioBusqueda.SelectedIndex = (int)value;
    }

    public string? DatoBusqueda {
        get => fieldDatoBusqueda.Text;
        set => fieldDatoBusqueda.Text = value;
    }

    public string ValorBrutoVenta {
        get => fieldValorBrutoVenta.Text;
        set {
            layoutValorBrutoVenta.Visible = !value.Equals("0.00");
            fieldValorBrutoVenta.Text = value;
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

    public IRepositorioVista? Vistas { get; private set; }

    public event EventHandler? AlturaContenedorTuplasModificada;
    public event EventHandler? MostrarPrimeraPagina;
    public event EventHandler? MostrarPaginaAnterior;
    public event EventHandler? MostrarPaginaSiguiente;
    public event EventHandler? MostrarUltimaPagina;
    public event EventHandler? SincronizarDatos;
    public event EventHandler? Salir;
    public event EventHandler? RegistrarDatos;
    public event EventHandler? ConfirmarEntrega;
    public event EventHandler? ConfirmarPagos;
    public event EventHandler? EditarDatos;
    public event EventHandler? EliminarDatos;
    public event EventHandler? DescargarReporte;
    public event EventHandler? ImprimirReporte;
    public event EventHandler? BuscarDatos;

    public void Inicializar() {
        // Vistas
        Vistas = new RepositorioVistaBase(contenedorVistas);

        // Eventos
        btnDescargar.Click += delegate {
            var tuplasVentas = contenedorVistas.Controls.OfType<IVistaTuplaVenta>();
            var filas = new List<string[]>();

            foreach (var tuplaVenta in tuplasVentas) {
                var fila = new string[3];

                fila[0] = tuplaVenta.NombreAlmacen;
                fila[1] = tuplaVenta.CantidadProductos;
                fila[2] = tuplaVenta.MontoTotal;

                filas.Add(fila);
            }

            UtilesReportes.GenerarReporteVentas(fieldDatoBusquedaFecha.Value, filas);
        };
        fieldDatoBusqueda.TextChanged += delegate(object? sender, EventArgs e) {
            if (!string.IsNullOrEmpty(DatoBusqueda))
                BuscarDatos?.Invoke(new object[] { CriterioBusqueda, DatoBusqueda }, e);
            else SincronizarDatos?.Invoke(sender, e);
        };
        fieldDatoBusquedaFecha.ValueChanged += delegate(object? sender, EventArgs e) {
            BuscarDatos?.Invoke(new object[] { CriterioBusqueda, fieldDatoBusquedaFecha.Value.ToString("yyyy-MM-dd") },
                e);
        };
        btnCerrar.Click += delegate(object? sender, EventArgs e) {
            Salir?.Invoke(sender, e);
            Ocultar();
        };
        btnRegistrar.Click += delegate(object? sender, EventArgs e) { RegistrarDatos?.Invoke(sender, e); };
        btnConfirmarEntrega.Click += delegate(object? sender, EventArgs e) { ConfirmarEntrega?.Invoke(sender, e); };
        btnConfirmarPagos.Click += delegate(object? sender, EventArgs e) { ConfirmarPagos?.Invoke(sender, e); };
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

    public void ActualizarValorBrutoVentas() {
        ValorBrutoVenta = UtilesVenta.ObtenerValorBrutoVentaDia(fieldDatoBusquedaFecha.Value)
            .ToString("N2", CultureInfo.InvariantCulture);
        ;
    }

    public void CargarCriteriosBusqueda(object[] criteriosBusqueda) {
        fieldCriterioBusqueda.Items.Clear();
        fieldCriterioBusqueda.Items.AddRange(criteriosBusqueda);
        fieldCriterioBusqueda.SelectedIndexChanged += delegate {
            if (CriterioBusqueda == CriterioBusquedaVenta.Fecha) {
                fieldDatoBusquedaFecha.Value = DateTime.Now;
                fieldDatoBusquedaFecha.Focus();

                ActualizarValorBrutoVentas();
            }
            else {
                layoutValorBrutoVenta.Visible = false;

                fieldDatoBusqueda.Text = string.Empty;
                fieldDatoBusqueda.Focus();
            }

            fieldDatoBusqueda.Visible = CriterioBusqueda != CriterioBusquedaVenta.Fecha &&
                                        fieldCriterioBusqueda.SelectedIndex != 0;
            fieldDatoBusquedaFecha.Visible = CriterioBusqueda == CriterioBusquedaVenta.Fecha &&
                                             fieldCriterioBusqueda.SelectedIndex != 0;

            if (CriterioBusqueda != CriterioBusquedaVenta.Fecha)
                BuscarDatos?.Invoke(new object[] { CriterioBusqueda, string.Empty }, EventArgs.Empty);

            // Ir a la primera página al cambiar el criterio de búsqueda
            PaginaActual = 1;
            HabilitarBotonesPaginacion();
        };

        fieldCriterioBusqueda.SelectedIndex = 4;
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
        HabilitarBtnConfirmarEntrega = false;
        HabilitarBtnConfirmarPagos = false;

        fieldCriterioBusqueda.SelectedIndex = 4;
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
                                   "MOD_COMPRAVENTA_VENTA_ADICIONAR")
                               || UtilesCuentaUsuario.PermisosUsuario.ContienePermisoExacto(
                                   "MOD_COMPRAVENTA_VENTA_TODOS")
                               || UtilesCuentaUsuario.PermisosUsuario.ContienePermisoExacto("MOD_COMPRAVENTA_TODOS");
    }

    private void HabilitarBotonesPaginacion() {
        btnPrimeraPagina.Enabled = PaginaActual > 1;
        btnPaginaAnterior.Enabled = PaginaActual > 1;
        btnUltimaPagina.Enabled = PaginaActual < PaginasTotales;
        btnPaginaSiguiente.Enabled = PaginaActual < PaginasTotales;
    }
}