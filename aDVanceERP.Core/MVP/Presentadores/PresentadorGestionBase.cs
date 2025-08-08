using aDVanceERP.Core.Interfaces;
using aDVanceERP.Core.MVP.Vistas.Plantillas;

namespace aDVanceERP.Core.MVP.Presentadores;

public abstract class PresentadorGestionBase<Pt, Vg, Vt, O, Do, C> : IPresentadorVistaBase<Vg>    
    where Pt : PresentadorTupla<Vt, O>
    where Vg : class, IVistaContenedor, IGestorDatos, IBuscadorDatos<C>, IGestorTablaDatos
    where Vt : IVistaTupla
    where Do : class, new()
    where O : class, IEntidadBd, new()
    where C : Enum {
    private readonly SemaphoreSlim _semaphore = new(1, 1); // Para controlar la concurrencia
    protected readonly List<Pt> _tuplasObjetos;
    private bool disposedValue;

    protected PresentadorGestionBase(Vg vista) : base(vista) {
        _tuplasObjetos = new List<Pt>();

        Vista.BuscarDatos += OnBuscarDatos;
        Vista.AlturaContenedorTuplasModificada += OnAlturaContenedorTuplasModificada;
        Vista.SincronizarDatos += OnSincronizarDatos;
    }

    public Do DatosObjeto {
        get => new();
    }

    public C? CriterioBusquedaObjeto { get; protected set; }
    public string? DatoBusquedaObjeto { get; protected set; }

    public event EventHandler? EditarObjeto;

    public async Task BusquedaDatos(C criterio, string? dato) {
        CriterioBusquedaObjeto = criterio;
        DatoBusquedaObjeto = dato;

        await RefrescarListaObjetos();
        Vista.PaginaActual = 1;
    }

    public virtual async Task RefrescarListaObjetos() {
        await _semaphore.WaitAsync();
        try {
            if (Vista.TuplasMaximasContenedor == 0) return;

            Vista.Vistas?.Cerrar(true);

            // Desuscribir eventos del presentador de tuplas
            foreach (var presentadorTupla in _tuplasObjetos) {
                presentadorTupla.ObjetoSeleccionado -= OnObjetoSeleccionado;
                presentadorTupla.EditarObjeto -= OnEditarObjeto;
                presentadorTupla.EliminarObjeto -= OnEliminarObjeto;
                presentadorTupla.Dispose();
            }
            _tuplasObjetos.Clear();

            VariablesGlobales.CoordenadaYUltimaTupla = 0;

            var incremento = (Vista.PaginaActual - 1) * Vista.TuplasMaximasContenedor;
            var objetos = (await DatosObjeto.(CriterioBusquedaObjeto, DatoBusquedaObjeto,
                out var totalFilas, Vista.TuplasMaximasContenedor, incremento)).ToList();
            var calculoPaginas = totalFilas / Vista.TuplasMaximasContenedor;
            var entero = totalFilas % Vista.TuplasMaximasContenedor == 0;

            Vista.PaginasTotales = calculoPaginas < 1 ? 1 : entero ? calculoPaginas : calculoPaginas + 1;

            for (var i = 0; i < objetos.Count && i < Vista.TuplasMaximasContenedor; i++)
                AdicionarTuplaObjeto(objetos[i]);
        }
        catch (Exception ex) {
            //TODO: Manejar la excepción (por ejemplo, mostrar un mensaje al usuario)
            Console.WriteLine($"Error al refrescar la lista de objetos: {ex.Message}");
        }
        finally {
            _semaphore.Release();
        }
    }

    protected virtual void AdicionarTuplaObjeto(O objeto) {
        var presentadorTupla = ObtenerValoresTupla(objeto);
        if (presentadorTupla == null) return;

        presentadorTupla.ObjetoSeleccionado += OnObjetoSeleccionado;
        presentadorTupla.EditarObjeto += OnEditarObjeto;
        presentadorTupla.EliminarObjeto += OnEliminarObjeto;

        _tuplasObjetos.Add(presentadorTupla);

        Vista.Vistas?.Registrar(
            $"vistaTupla{objeto.GetType().Name}{objeto.Id}",
            presentadorTupla.Vista,
            new Point(0, VariablesGlobales.CoordenadaYUltimaTupla),
            new Size(0, VariablesGlobales.AlturaTuplaPredeterminada), "H");

        presentadorTupla.Vista.Mostrar();

        VariablesGlobales.CoordenadaYUltimaTupla += VariablesGlobales.AlturaTuplaPredeterminada;
    }

    private void DeseleccionarTuplas(IVistaTupla vista) {
        _tuplasObjetos.ForEach(tupla => { 
            if (!tupla.Vista.Equals(vista)) 
                tupla.TuplaSeleccionada = false; 
        });
    }

    protected abstract Pt ObtenerValoresTupla(O objeto);

    protected virtual void OnObjetoSeleccionado(object? sender, EventArgs e) {
        DeseleccionarTuplas(sender as IVistaTupla);
    }

    protected virtual void OnEditarObjeto(object? sender, EventArgs e) {
        EditarObjeto?.Invoke(sender, e);
    }

    protected virtual async void OnEliminarObjeto(object? sender, EventArgs e) {
        if (sender is O objeto)
            try {
                //DatosObjeto.Eliminar(objeto.Id);
                Vista.PaginaActual = 1;

                await RefrescarListaObjetos();
            }
            catch (Exception ex) {
                throw new Exception($"Error al eliminar el objeto: {ex.Message}");
            }
    }

    private async void OnBuscarDatos(object? sender, EventArgs e) {
        if (sender is not object[] objetoSplit || objetoSplit.Length < 2)
            return;

        var criterioBusqueda = (C)objetoSplit[0];
        var datoBusqueda = objetoSplit[1] is string[] datosBusquedaMultiple
            ? string.Join(";", datosBusquedaMultiple)
            : objetoSplit[1].ToString();

        await BusquedaDatos(criterioBusqueda, datoBusqueda);
    }

    private async void OnAlturaContenedorTuplasModificada(object? sender, EventArgs e) {
        if (Vista is Form vistaForm)
            if (!vistaForm.Visible)
                return;

        await RefrescarListaObjetos();
    }

    private async void OnSincronizarDatos(object? sender, EventArgs e) {
        await RefrescarListaObjetos();
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