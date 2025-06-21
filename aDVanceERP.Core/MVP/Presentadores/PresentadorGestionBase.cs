using aDVanceERP.Core.MVP.Modelos.Plantillas;
using aDVanceERP.Core.MVP.Modelos.Repositorios.Plantillas;
using aDVanceERP.Core.MVP.Presentadores.Plantillas;
using aDVanceERP.Core.MVP.Vistas.Plantillas;
using aDVanceERP.Core.Utiles;

namespace aDVanceERP.Core.MVP.Presentadores; 

public abstract class PresentadorGestionBase<Pt, Vg, Vt, O, Do, C> : PresentadorBase<Vg>,
    IPresentadorGestion<Vg, Do, O, C>
    where Pt : IPresentadorTupla<Vt, O>
    where Vg : class, IVistaContenedor, IGestorDatos, IBuscadorDatos<C>, IGestorTablaDatos
    where Vt : IVistaTupla
    where Do : class, IRepositorioDatosEntidad<O, C>, new()
    where O : class, IEntidad, new()
    where C : Enum {
    private readonly SemaphoreSlim _semaphore = new(1, 1); // Para controlar la concurrencia
    protected readonly List<Pt> _tuplasObjetos;

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

            Vista.Cerrar();

            _tuplasObjetos.ForEach(tupla => tupla.Vista.Cerrar());
            _tuplasObjetos.Clear();

            VariablesGlobales.CoordenadaYUltimaTupla = 0;

            var incremento = (Vista.PaginaActual - 1) * Vista.TuplasMaximasContenedor;
            var objetos = (await DatosObjeto.ObtenerAsync(CriterioBusquedaObjeto, DatoBusquedaObjeto,
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

        presentadorTupla.ObjetoSeleccionado += delegate { DeseleccionarTuplas(presentadorTupla.Vista); };
        presentadorTupla.EditarObjeto += (sender, e) => EditarObjeto?.Invoke(sender, e);
        presentadorTupla.EliminarObjeto += EliminarObjeto;

        _tuplasObjetos.Add(presentadorTupla);

        Vista.Vistas?.Registrar(
            $"vistaTupla{objeto.GetType().Name}{objeto.Id}",
            presentadorTupla.Vista,
            new Point(0, VariablesGlobales.CoordenadaYUltimaTupla),
            new Size(0, VariablesGlobales.AlturaTuplaPredeterminada), "H");

        presentadorTupla.Vista.Mostrar();

        VariablesGlobales.CoordenadaYUltimaTupla += VariablesGlobales.AlturaTuplaPredeterminada;
    }

    private void DeseleccionarTuplas(Vt vista) {
        _tuplasObjetos.ForEach(tupla => { 
            if (!tupla.Vista.Equals(vista)) 
                tupla.TuplaSeleccionada = false; 
        });
    }

    protected abstract Pt ObtenerValoresTupla(O objeto);

    protected virtual async void EliminarObjeto(object? sender, EventArgs e) {
        if (sender is O objeto)
            try {
                await DatosObjeto.EliminarAsync(objeto.Id);
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
}