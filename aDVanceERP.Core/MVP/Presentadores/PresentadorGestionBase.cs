using aDVanceERP.Core.MVP.Modelos.Plantillas;
using aDVanceERP.Core.MVP.Presentadores.Plantillas;
using aDVanceERP.Core.MVP.Vistas.Plantillas;
using aDVanceERP.Core.Repositorios.Plantillas;
using aDVanceERP.Core.Utiles;

namespace aDVanceERP.Core.MVP.Presentadores;

public abstract class PresentadorGestionBase<Pt, Vg, Vt, En, Rd, Fb> : PresentadorBase<Vg>, IPresentadorGestion<Vg, Rd, En, Fb>
    where Pt : IPresentadorTupla<Vt, En>
    where Vg : class, IVistaContenedor, IGestorDatos, IBuscadorDatos<Fb>, IGestorTablaDatos
    where Vt : IVistaTupla
    where Rd : class, IRepositorioDatosEntidad<En, Fb>, new()
    where En : class, IEntidad, new()
    where Fb : Enum {
    private readonly SemaphoreSlim _semaphore = new(1, 1); // Para controlar la concurrencia
    protected readonly List<Pt> _tuplasEntidades;
    private bool disposedValue;

    protected PresentadorGestionBase(Vg vista) : base(vista) {
        _tuplasEntidades = new List<Pt>();

        Vista.BuscarDatos += OnBuscarDatos;
        Vista.AlturaContenedorTuplasModificada += OnAlturaContenedorTuplasModificada;
        Vista.SincronizarDatos += OnSincronizarDatos;
    }

    public Rd RepoDatosEntidad {
        get => new();
    }

    public Fb? FiltroBusquedaEntidad { get; protected set; }

    public string? DatosComplementariosBusqueda { get; protected set; }

    public event EventHandler? EditarEntidad;

    public async void BuscarDatosEntidad(Fb filtroBusqueda, string datosComplementarios) {
        FiltroBusquedaEntidad = filtroBusqueda;
        DatosComplementariosBusqueda = datosComplementarios;

        await PopularTuplasDatosEntidades();

        Vista.PaginaActual = 1;
    }

    public virtual async Task PopularTuplasDatosEntidades() {
        if (Vista.TuplasMaximasContenedor == 0)
            return;

        try {
            await _semaphore.WaitAsync();

            Vista.Vistas?.Cerrar(true);

            // Desuscribir eventos del presentador de tuplas
            foreach (var presentadorTupla in _tuplasEntidades) {
                presentadorTupla.EntidadSeleccionada -= OnObjetoSeleccionado;
                presentadorTupla.EditarDatosEntidad -= OnEditarObjeto;
                presentadorTupla.EliminarDatosEntidad -= OnEliminarObjeto;
                presentadorTupla.Dispose();
            }
            _tuplasEntidades.Clear();

            VariablesGlobales.CoordenadaYUltimaTupla = 0;

            var incremento = (Vista.PaginaActual - 1) * Vista.TuplasMaximasContenedor;
            var (entidades, totalFilas) = RepoDatosEntidad.Buscar(
                FiltroBusquedaEntidad,
                DatosComplementariosBusqueda,
                Vista.TuplasMaximasContenedor,
                incremento);
            var paginasTotales = (int)Math.Ceiling((double)totalFilas / Vista.TuplasMaximasContenedor);

            // 3. Asignar páginas totales
            Vista.PaginasTotales = paginasTotales;

            // 4. Agregar tuplas
            foreach ( var entidad in entidades ) {
                if (Vista is Control control)
                    control.Invoke(() => AdicionarTuplaObjeto(entidad));                
            };
        }
        catch (Exception ex) {
            //TODO: Manejar la excepción (por ejemplo, mostrar un mensaje al usuario)
            Console.WriteLine($"Error al refrescar la lista de objetos: {ex.Message}");
        }
        finally {
            _semaphore.Release();
        }
    }

    private void LiberarRecursosTuplas() {
        foreach (var tupla in _tuplasEntidades) {
            tupla.Vista.Cerrar();

            if (tupla.Vista is IDisposable disposable)
                disposable.Dispose();
        }

        _tuplasEntidades.Clear();

        VariablesGlobales.CoordenadaYUltimaTupla = 0;

        // Forzar liberación de memoria si hay muchas tuplas
        if (_tuplasEntidades.Capacity > 100) {
            _tuplasEntidades.TrimExcess();

            GC.Collect(GC.MaxGeneration, GCCollectionMode.Optimized);
        }
    }

    protected virtual void AdicionarTuplaObjeto(En objeto) {
        var presentadorTupla = ObtenerValoresTupla(objeto);
        
        if (presentadorTupla == null) 
            return;

        presentadorTupla.EntidadDeseleccionada += OnObjetoSeleccionado;
        presentadorTupla.EditarDatosEntidad += OnEditarObjeto;
        presentadorTupla.EliminarDatosEntidad += OnEliminarObjeto;

        _tuplasEntidades.Add(presentadorTupla);

        Vista.Vistas?.Registrar(
            $"vistaTupla{objeto.GetType().Name}{objeto.Id}",
            presentadorTupla.Vista,
            new Point(0, VariablesGlobales.CoordenadaYUltimaTupla),
            new Size(0, VariablesGlobales.AlturaTuplaPredeterminada), "H");

        presentadorTupla.Vista.Mostrar();

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
        EditarEntidad?.Invoke(sender, e);
    }

    protected virtual async void OnEliminarObjeto(object? sender, EventArgs e) {
        if (sender is En entidad)
            try {
                RepoDatosEntidad.Eliminar(entidad.Id);
                Vista.PaginaActual = 1;

                await PopularTuplasDatosEntidades();
            }
            catch (Exception ex) {
                throw new Exception($"Error al eliminar el objeto: {ex.Message}");
            }
    }

    private void OnBuscarDatos(object? sender, EventArgs e) {
        if (sender is not object[] objetoSplit || objetoSplit.Length < 2)
            return;

        var criterioBusqueda = (Fb)objetoSplit[0];
        var datoBusqueda = objetoSplit[1] is string[] datosBusquedaMultiple
            ? string.Join(";", datosBusquedaMultiple)
            : objetoSplit[1].ToString();

        BuscarDatosEntidad(criterioBusqueda, datoBusqueda);
    }

    private async void OnAlturaContenedorTuplasModificada(object? sender, EventArgs e) {
        if (Vista is Form vistaForm)
            if (!vistaForm.Visible)
                return;

        await PopularTuplasDatosEntidades();
    }

    private async void OnSincronizarDatos(object? sender, EventArgs e) {
        await PopularTuplasDatosEntidades();
    }

    protected virtual void Dispose(bool disposing) {
        if (!disposedValue) {
            if (disposing) {
                Vista.BuscarDatos -= OnBuscarDatos;
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