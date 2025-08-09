using aDVanceERP.Core.Interfaces;
using aDVanceERP.Core.Modelos.Comun;

namespace aDVanceERP.Core.Controles;

public partial class TablaResultadosBusqueda : UserControl, ITablaResultadosBusqueda {
    private int _paginaActual = 1;
    private int _paginasTotales = 1;
    private int _yUltimaTupla = 0;

    public const int AlturaTuplaPredeterminada = 45;
    
    public TablaResultadosBusqueda() {
        InitializeComponent();

        // Propiedades
        PanelResultados = new PanelContenedorVistas(panelResultados);

        // Eventos
        btnPrimeraPagina.Click += delegate (object? sender, EventArgs e) {
            PaginaActual = 1;
            MostrarPaginaPrimera?.Invoke(sender, e);
            SincronizarDatosEntidadesBd?.Invoke(sender, e);

            HabilitarBotonesPaginacion();
        };
        btnPaginaAnterior.Click += delegate (object? sender, EventArgs e) {
            PaginaActual--;
            MostrarPaginaAnterior?.Invoke(sender, e);
            SincronizarDatosEntidadesBd?.Invoke(sender, e);

            HabilitarBotonesPaginacion();
        };
        btnPaginaSiguiente.Click += delegate (object? sender, EventArgs e) {
            PaginaActual++;
            MostrarPaginaSiguiente?.Invoke(sender, e);
            SincronizarDatosEntidadesBd?.Invoke(sender, e);

            HabilitarBotonesPaginacion();
        };
        btnUltimaPagina.Click += delegate (object? sender, EventArgs e) {
            PaginaActual = PaginasTotales;
            MostrarPaginaUltima?.Invoke(sender, e);
            SincronizarDatosEntidadesBd?.Invoke(sender, e);

            HabilitarBotonesPaginacion();
        };
        btnSincronizarDatos.Click += delegate (object? sender, EventArgs e) {
            SincronizarDatosEntidadesBd?.Invoke(sender, e);
        };
        panelResultados.Resize += delegate (object? sender, EventArgs e) {
            SincronizarDatosEntidadesBd?.Invoke(sender, e);
        };
    }
    
    public IPanelContenedorVistas PanelResultados { get; }

    public int TuplasMaximasPanel { 
        get => panelResultados.Height / AlturaTuplaPredeterminada;
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

    public event EventHandler? MostrarPaginaPrimera;
    public event EventHandler? MostrarPaginaAnterior;
    public event EventHandler? MostrarPaginaSiguiente;
    public event EventHandler? MostrarPaginaUltima;
    public event EventHandler? SincronizarDatosEntidadesBd;

    void ActualizarResultadosBusqueda<En>(int cantidad, List<En> resultados) {
        if (TuplasMaximasPanel == 0)
            return;

        PanelResultados.CerrarVistas();

        _yUltimaTupla = 0;

        var paginasTotales = cantidad / TuplasMaximasPanel;
        var paginasTotalesExactas = cantidad % TuplasMaximasPanel == 0;

        PaginasTotales = paginasTotales < 1 ? 1 : paginasTotalesExactas ? paginasTotales : paginasTotales++;

        foreach (var resultado in resultados) {
            SubscripcionEventosTupla(resultado.Value);

            PanelResultados.AdicionarVista(
                resultado,
                new Point(0, _yUltimaTupla),
                new Size(0, AlturaTuplaPredeterminada),
                TipoRedimensionadoVista.Horizontal
            );

            PanelResultados.MostrarVista(resultado.Value.Nombre);

            // Incrementar la coordenada Y de la proxima tupla
            _yUltimaTupla += AlturaTuplaPredeterminada;
        }
    }

    private void HabilitarBotonesPaginacion() {
        btnPrimeraPagina.Enabled = PaginaActual > 1;
        btnPaginaAnterior.Enabled = PaginaActual > 1;
        btnUltimaPagina.Enabled = PaginaActual < PaginasTotales;
        btnPaginaSiguiente.Enabled = PaginaActual < PaginasTotales;
    }

    private void SubscripcionEventosTupla(IVistaTupla tupla, bool eliminar = false) {
        if (eliminar) {
            tupla.EditarTuplaDatos -= OnEditarTuplaDatos;
            tupla.EliminarTuplaDatos -= OnEliminarTuplaDatos;

            return;
        }

        tupla.EditarTuplaDatos += OnEditarTuplaDatos;
        tupla.EliminarTuplaDatos += OnEliminarTuplaDatos;
    }

    private void OnEditarTuplaDatos(object? sender, EventArgs e) {
        throw new NotImplementedException();
    }

    private void OnEliminarTuplaDatos(object? sender, EventArgs e) {
        throw new NotImplementedException();
    }
}

