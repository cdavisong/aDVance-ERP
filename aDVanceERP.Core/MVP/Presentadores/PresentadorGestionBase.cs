using aDVanceERP.Core.Modelos.Comun;
using aDVanceERP.Core.Modelos.Comun.Interfaces;
using aDVanceERP.Core.MVP.Presentadores.Plantillas;
using aDVanceERP.Core.MVP.Vistas.Plantillas;
using aDVanceERP.Core.Presentadores.Comun;
using aDVanceERP.Core.Repositorios.Comun.Interfaces;
using aDVanceERP.Core.Utiles;
using aDVanceERP.Core.Vistas.Comun;

namespace aDVanceERP.Core.MVP.Presentadores;

public abstract class PresentadorGestionBase<Pt, Vg, Vt, En, Re, Fb> : PresentadorVistaBase<Vg>,
    IPresentadorGestion<Vg, Re, En, Fb>
    where Pt : IPresentadorTupla<Vt, En>
    where Vg : class, IVistaContenedor, IGestorEntidades, IBuscadorEntidades<Fb>, INavegadorTuplasEntidades
    where Vt : class, IVistaTupla
    where Re : class, IRepoEntidadBaseDatos<En, Fb>, new()
    where En : class, IEntidadBaseDatos, new()
    where Fb : Enum {
    protected readonly VistaCargaDatos _cargaDatos;
    protected readonly List<Pt> _tuplasEntidades;
    private bool disposedValue;

    protected PresentadorGestionBase(Vg vista) : base(vista) {
        _cargaDatos = new VistaCargaDatos();
        _tuplasEntidades = new List<Pt>();

        (Vista as Control).VisibleChanged += OnMostrarOcultarVista;

        Vista.Habilitada = false;
        Vista.BuscarEntidades += OnBuscarDatos;
        Vista.AlturaContenedorTuplasModificada += OnAlturaContenedorTuplasModificada;
        Vista.SincronizarDatos += OnSincronizarDatos;

        CargaDatosCompletada += (sender, completed) => { _cargaDatos.Ocultar(); };
    }

    public Re RepositorioEntidad => new();
    public Fb? FiltroBusqueda { get; protected set; }
    public string? CriterioBusqueda { get; protected set; }
    public IEnumerable<Pt> TuplasSeleccionadas => _tuplasEntidades.Where(t => t.TuplaSeleccionada);

    public event EventHandler? EditarObjeto;
    public event EventHandler<bool>? CargaDatosCompletada;

    public void BusquedaEntidades(Fb filtroBusqueda, string? criterioBusqueda) {
        FiltroBusqueda = filtroBusqueda;
        CriterioBusqueda = criterioBusqueda;

        ActualizarResultadosBusqueda();

        Vista.PaginaActual = 1;
    }

    public async void ActualizarResultadosBusqueda() {
        if (!Vista.Habilitada)
            return;

        try {
            if (Vista.TuplasMaximasContenedor == 0) return;

            Vista.Vistas?.CerrarTodos();

            // Desuscribir eventos del presentador de tuplas
            foreach (var presentadorTupla in _tuplasEntidades) {
                presentadorTupla.ObjetoSeleccionado -= OnObjetoSeleccionado;
                presentadorTupla.EditarObjeto -= OnEditarObjeto;
                presentadorTupla.EliminarObjeto -= OnEliminarObjeto;
                presentadorTupla.Dispose();
            }
            _tuplasEntidades.Clear();

            VariablesGlobales.CoordenadaYUltimaTupla = 0;

            var incremento = (Vista.PaginaActual - 1) * Vista.TuplasMaximasContenedor;

            // Ejecutar la búsqueda en un hilo separado
            var datos = await Task.Run(() =>
                RepositorioEntidad.Buscar(FiltroBusqueda, CriterioBusqueda, Vista.TuplasMaximasContenedor, incremento));

            var entidades = datos.resultados.ToList();
            var calculoPaginas = datos.cantidad / Vista.TuplasMaximasContenedor;
            var entero = datos.cantidad % Vista.TuplasMaximasContenedor == 0;

            Vista.PaginasTotales = calculoPaginas < 1 ? 1 : entero ? calculoPaginas : calculoPaginas + 1;

            _cargaDatos.Mostrar();

            // Procesar las tuplas de forma asíncrona
            await Task.Run(() => {
                for (var i = 0; i < entidades.Count && i < Vista.TuplasMaximasContenedor; i++) {
                    var entidad = entidades[i];
                    (Vista as Control)?.Invoke(() => {
                        AdicionarTuplaEntidad(entidad);
                    });

                    // Pequeña pausa para permitir que la UI se actualice
                    Thread.Sleep(10);
                }
            });

            CargaDatosCompletada?.Invoke(this, true);
        } catch (Exception ex) {
            Console.WriteLine($"Error al refrescar la lista de objetos: {ex.Message}");
        }
    }

    protected virtual void AdicionarTuplaEntidad(En objeto) {
        (Vista as Control)?.Invoke(() => {
            var presentadorTupla = ObtenerValoresTupla(objeto);
            if (presentadorTupla == null) return;

            presentadorTupla.ObjetoSeleccionado += OnObjetoSeleccionado;
            presentadorTupla.EditarObjeto += OnEditarObjeto;
            presentadorTupla.EliminarObjeto += OnEliminarObjeto;

            _tuplasEntidades.Add(presentadorTupla);

            Vista.Vistas?.Registrar(
                $"vistaTupla{objeto.GetType().Name}{objeto.Id}",
                presentadorTupla.Vista,
                new Point(0, VariablesGlobales.CoordenadaYUltimaTupla),
                new Size(0, VariablesGlobales.AlturaTuplaPredeterminada),
                TipoRedimensionadoVista.Horizontal);

            presentadorTupla.Vista.Mostrar();
        });

        VariablesGlobales.CoordenadaYUltimaTupla += VariablesGlobales.AlturaTuplaPredeterminada;
    }

    private void DeseleccionarTuplas(IVistaTupla vista) {
        _tuplasEntidades.ForEach(tupla => {
            if (!tupla.Vista.Equals(vista))
                tupla.TuplaSeleccionada = false;
        });
    }

    protected abstract Pt ObtenerValoresTupla(En objeto);

    protected virtual void OnObjetoSeleccionado(object? sender, EventArgs e) {
        DeseleccionarTuplas(sender as IVistaTupla);
    }

    protected virtual void OnEditarObjeto(object? sender, EventArgs e) {
        EditarObjeto?.Invoke(sender, e);
    }

    protected virtual void OnEliminarObjeto(object? sender, EventArgs e) {
        if (sender is En objeto)
            try {
                RepositorioEntidad.Eliminar(objeto.Id);
                Vista.PaginaActual = 1;

                ActualizarResultadosBusqueda();
            } catch (Exception ex) {
                throw new Exception($"Error al eliminar el objeto: {ex.Message}");
            }
    }

    private void OnBuscarDatos(object? sender, EventArgs e) {
        if (sender is not object[] objetoSplit || objetoSplit.Length < 2)
            return;

        var criterioBusqueda = (Fb) objetoSplit[0];
        var datoBusqueda = objetoSplit[1] is string[] datosBusquedaMultiple
            ? string.Join(";", datosBusquedaMultiple)
            : objetoSplit[1].ToString();

        BusquedaEntidades(criterioBusqueda, datoBusqueda);
    }

    private void OnAlturaContenedorTuplasModificada(object? sender, EventArgs e) {
        if (Vista is Form vistaForm)
            if (!vistaForm.Visible)
                return;

        ActualizarResultadosBusqueda();
    }

    private void OnSincronizarDatos(object? sender, EventArgs e) {
        ActualizarResultadosBusqueda();
    }

    private void OnMostrarOcultarVista(object? sender, EventArgs e) {
        var vista = (Vista as Control);

        if (vista == null)
            return;

        Vista.Habilitada = vista.Visible;
    }

    protected virtual void Dispose(bool disposing) {
        if (!disposedValue) {
            if (disposing) {
                (Vista as Control).VisibleChanged -= OnMostrarOcultarVista;

                Vista.BuscarEntidades -= OnBuscarDatos;
                Vista.AlturaContenedorTuplasModificada -= OnAlturaContenedorTuplasModificada;
                Vista.SincronizarDatos -= OnSincronizarDatos;
            }

            // TODO: liberar los recursos no administrados (objetos no administrados) y reemplazar el finalizador
            // TODO: establecer los campos grandes como NULL
            disposedValue = true;
        }
    }

    public override void Dispose() {
        Dispose(disposing: true);
        GC.SuppressFinalize(this);
    }
}