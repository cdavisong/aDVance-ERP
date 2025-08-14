using aDVanceERP.Core.Modelos.Comun.Interfaces;
using aDVanceERP.Core.MVP.Modelos.Plantillas;
using aDVanceERP.Core.MVP.Presentadores.Plantillas;
using aDVanceERP.Core.MVP.Vistas.Plantillas;
using aDVanceERP.Core.Repositorios.Interfaces;
using aDVanceERP.Core.Utiles;

namespace aDVanceERP.Core.MVP.Presentadores;

public abstract class PresentadorGestionBase<Pt, Vg, Vt, O, Do, C> : PresentadorBase<Vg>,
    IPresentadorGestion<Vg, Do, O, C>
    where Pt : IPresentadorTupla<Vt, O>
    where Vg : class, IVistaContenedor, IGestorDatos, IBuscadorDatos<C>, IGestorTablaDatos
    where Vt : IVistaTupla
    where Do : class, IRepoEntidadBaseDatos<O, C>, new()
    where O : class, IEntidadBaseDatos, new()
    where C : Enum {
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

    public C? FiltroBusquedaObjeto { get; protected set; }
    public string? DatoBusquedaObjeto { get; protected set; }

    public event EventHandler? EditarObjeto;

    public void BusquedaDatos(C criterio, string? dato) {
        FiltroBusquedaObjeto = criterio;
        DatoBusquedaObjeto = dato;

        RefrescarListaObjetos();

        Vista.PaginaActual = 1;
    }

    public virtual void RefrescarListaObjetos() {
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
            var datos = DatosObjeto.Obtener(FiltroBusquedaObjeto, DatoBusquedaObjeto, Vista.TuplasMaximasContenedor, incremento);
            var entidades = datos.resultados.ToList();
            var calculoPaginas = datos.cantidad / Vista.TuplasMaximasContenedor;
            var entero = datos.cantidad % Vista.TuplasMaximasContenedor == 0;

            Vista.PaginasTotales = calculoPaginas < 1 ? 1 : entero ? calculoPaginas : calculoPaginas + 1;

            for (var i = 0; i < entidades.Count && i < Vista.TuplasMaximasContenedor; i++)
                AdicionarTuplaObjeto(entidades[i]);
        }
        catch (Exception ex) {
            //TODO: Manejar la excepción (por ejemplo, mostrar un mensaje al usuario)
            Console.WriteLine($"Error al refrescar la lista de objetos: {ex.Message}");
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

    protected virtual void OnEliminarObjeto(object? sender, EventArgs e) {
        if (sender is O objeto)
            try {
                DatosObjeto.Eliminar(objeto.Id);
                Vista.PaginaActual = 1;

                RefrescarListaObjetos();
            }
            catch (Exception ex) {
                throw new Exception($"Error al eliminar el objeto: {ex.Message}");
            }
    }

    private void OnBuscarDatos(object? sender, EventArgs e) {
        if (sender is not object[] objetoSplit || objetoSplit.Length < 2)
            return;

        var criterioBusqueda = (C)objetoSplit[0];
        var datoBusqueda = objetoSplit[1] is string[] datosBusquedaMultiple
            ? string.Join(";", datosBusquedaMultiple)
            : objetoSplit[1].ToString();

        BusquedaDatos(criterioBusqueda, datoBusqueda);
    }

    private void OnAlturaContenedorTuplasModificada(object? sender, EventArgs e) {
        if (Vista is Form vistaForm)
            if (!vistaForm.Visible)
                return;

        RefrescarListaObjetos();
    }

    private void OnSincronizarDatos(object? sender, EventArgs e) {
        RefrescarListaObjetos();
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