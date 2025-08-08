using System.Globalization;
using aDVanceERP.Core.Interfaces;
using aDVanceERP.Core.MVP.Modelos.Repositorios;
using aDVanceERP.Core.Seguridad.Utiles;
using aDVanceERP.Core.Utiles;
using aDVanceERP.Core.Utiles.Datos;
using aDVanceERP.Modulos.CompraVenta.MVP.Modelos;
using aDVanceERP.Modulos.CompraVenta.MVP.Modelos.Repositorios;
using aDVanceERP.Modulos.CompraVenta.MVP.Vistas.Compra.Plantillas;

namespace aDVanceERP.Modulos.CompraVenta.MVP.Vistas.Compra;

public partial class VistaGestionCompras : Form, IVistaGestionCompras {
    private int _paginaActual = 1;
    private int _paginasTotales = 1;

    public VistaGestionCompras() {
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

    public string FormatoReporte {
        get => fieldFormatoReporte.Text;
        set => fieldFormatoReporte.Text = value;
    }

    public CriterioBusquedaCompra CriterioBusqueda {
        get => fieldCriterioBusqueda.SelectedIndex >= 0
            ? (CriterioBusquedaCompra)fieldCriterioBusqueda.SelectedIndex
            : default;
        set => fieldCriterioBusqueda.SelectedIndex = (int)value;
    }

    public string? DatoBusqueda {
        get => fieldDatoBusqueda.Text;
        set => fieldDatoBusqueda.Text = value;
    }

    public string ValorBrutoCompra {
        get => fieldValorBrutoCompra.Text;
        set {
            layoutValorBrutoCompra.Visible = !value.Equals("0.00");
            fieldValorBrutoCompra.Text = value;
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
    public event EventHandler? EditarDatos;
    public event EventHandler? EliminarDatos;
    public event EventHandler? DescargarReporte;
    public event EventHandler? ImprimirReporte;
    public event EventHandler? BuscarDatos;

    public void Inicializar() {
        // Vistas
        Vistas = new PanelContenedorVistas(contenedorVistas);

        // Eventos
        btnDescargar.Click += delegate {
            var filas = new List<string[]>();

            using (var datosCompras = new DatosCompra()) {
                var comprasFecha = datosCompras.Obtener(CriterioBusquedaCompra.Fecha, fieldDatoBusquedaFecha.Value.ToString("yyyy-MM-dd"));

                foreach (var venta in comprasFecha) {
                    using (var datosCompraProducto = new DatosDetalleCompraProducto()) {
                        var detalleCompraProducto = datosCompraProducto.Obtener(CriterioDetalleCompraProducto.IdCompra, venta.Id.ToString());

                        foreach (var ventaProducto in detalleCompraProducto) {
                            var fila = new string[7];

                            fila[0] = ventaProducto.Id.ToString();
                            fila[1] = UtilesProducto.ObtenerNombreProducto(ventaProducto.IdProducto).Result ?? string.Empty;
                            fila[2] = ventaProducto.Cantidad.ToString("N2", CultureInfo.InvariantCulture);
                            fila[3] = ventaProducto.PrecioCompra.ToString("N", CultureInfo.InvariantCulture);
                            fila[4] = "0";
                            fila[5] = "0.00%";
                            fila[6] = (ventaProducto.PrecioCompra * (decimal)ventaProducto.Cantidad).ToString("N", CultureInfo.InvariantCulture);

                            filas.Add(fila);
                        }
                    }
                }
            }

            UtilesReportes.GenerarEntradaMercancias(fieldDatoBusquedaFecha.Value, filas);
        };
        fieldCriterioBusqueda.SelectedIndexChanged += delegate {
            if (CriterioBusqueda == CriterioBusquedaCompra.Fecha) {
                fieldDatoBusquedaFecha.Value = DateTime.Now;
                fieldDatoBusquedaFecha.Focus();

                ActualizarValorBrutoCompras();
            }
            else {
                layoutValorBrutoCompra.Visible = false;

                fieldDatoBusqueda.Text = string.Empty;
                fieldDatoBusqueda.Focus();
            }

            fieldDatoBusqueda.Visible = CriterioBusqueda != CriterioBusquedaCompra.Fecha &&
                                        fieldCriterioBusqueda.SelectedIndex != 0;
            fieldDatoBusquedaFecha.Visible = CriterioBusqueda == CriterioBusquedaCompra.Fecha &&
                                             fieldCriterioBusqueda.SelectedIndex != 0;

            if (CriterioBusqueda != CriterioBusquedaCompra.Fecha)
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
        fieldDatoBusquedaFecha.ValueChanged += delegate(object? sender, EventArgs e) {
            BuscarDatos?.Invoke(new object[] { CriterioBusqueda, fieldDatoBusquedaFecha.Value.ToString("yyyy-MM-dd") },
                e);
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

    public void ActualizarValorBrutoCompras() {
        ValorBrutoCompra = UtilesCompra.ObtenerValorBrutoCompraDia(fieldDatoBusquedaFecha.Value)
            .ToString("N2", CultureInfo.InvariantCulture);
        ;
    }

    public void CargarCriteriosBusqueda(object[] criteriosBusqueda) {
        fieldCriterioBusqueda.Items.Clear();
        fieldCriterioBusqueda.Items.AddRange(criteriosBusqueda);
        
        fieldCriterioBusqueda.SelectedIndex = 4;
    }

    public void Mostrar() {
        Habilitar = true;
        VerificarPermisos();
        BringToFront();
        Show();
    }

    public void Restaurar() {
        Habilitar = true;
        PaginaActual = 1;
        PaginasTotales = 1;

        fieldCriterioBusqueda.SelectedIndex = 4;
    }

    public void Ocultar() {
        Habilitar = false;
        Hide();
    }

    public void Dispose() {
        // ...
    }

    private void VerificarPermisos() {
        btnRegistrar.Enabled = (UtilesCuentaUsuario.UsuarioAutenticado?.Administrador ?? false)
                               || UtilesCuentaUsuario.PermisosUsuario.ContienePermisoExacto(
                                   "MOD_COMPRAVENTA_COMPRA_ADICIONAR")
                               || UtilesCuentaUsuario.PermisosUsuario.ContienePermisoExacto(
                                   "MOD_COMPRAVENTA_COMPRA_TODOS")
                               || UtilesCuentaUsuario.PermisosUsuario.ContienePermisoExacto("MOD_COMPRAVENTA_TODOS");
    }

    private void HabilitarBotonesPaginacion() {
        btnPrimeraPagina.Enabled = PaginaActual > 1;
        btnPaginaAnterior.Enabled = PaginaActual > 1;
        btnUltimaPagina.Enabled = PaginaActual < PaginasTotales;
        btnPaginaSiguiente.Enabled = PaginaActual < PaginasTotales;
    }
}