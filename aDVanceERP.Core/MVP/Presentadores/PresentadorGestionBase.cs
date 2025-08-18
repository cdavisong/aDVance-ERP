using aDVanceERP.Core.Modelos.Comun.Interfaces;
using aDVanceERP.Core.MVP.Modelos.Plantillas;
using aDVanceERP.Core.MVP.Presentadores.Plantillas;
using aDVanceERP.Core.MVP.Vistas.Plantillas;
using aDVanceERP.Core.Repositorios.Interfaces;
using aDVanceERP.Core.Utiles;

namespace aDVanceERP.Core.MVP.Presentadores;

public abstract class PresentadorGestionBase<Pt, Vg, Vt, En, Re, Fb> : PresentadorBase<Vg>,
    IPresentadorGestion<Vg, Re, En, Fb>
    where Pt : IPresentadorTupla<Vt, En>
    where Vg : class, IVistaContenedor, IGestorDatos, IBuscadorDatos<Fb>, IGestorTablaDatos
    where Vt : IVistaTupla
    where Re : class, IRepoEntidadBaseDatos<En, Fb>, new()
    where En : class, IEntidadBaseDatos, new()
    where Fb : Enum {
    protected readonly List<Pt> _tuplasEntidades;
    private bool disposedValue;

    protected PresentadorGestionBase(Vg vista) : base(vista) {
        _tuplasEntidades = new List<Pt>();

        Vista.BuscarDatos += OnBuscarDatos;
        Vista.AlturaContenedorTuplasModificada += OnAlturaContenedorTuplasModificada;
        Vista.SincronizarDatos += OnSincronizarDatos;
    }

    public Re RepositorioEntidad => new();
    public Fb? FiltroBusqueda { get; protected set; }
    public string? CriterioBusqueda { get; protected set; }
    public IEnumerable<Pt> TuplasSeleccionadas => _tuplasEntidades.Where(t => t.TuplaSeleccionada);

    public event EventHandler? EditarObjeto;

    public void BusquedaEntidades(Fb filtroBusqueda, string? criterioBusqueda) {
        FiltroBusqueda = filtroBusqueda;
        CriterioBusqueda = criterioBusqueda;

        ActualizarResultadosBusqueda();

        Vista.PaginaActual = 1;
    }

    public virtual void ActualizarResultadosBusqueda() {
        try {
            if (Vista.TuplasMaximasContenedor == 0) return;

            Vista.Vistas?.Cerrar(true);

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
            var datos = RepositorioEntidad.Buscar(FiltroBusqueda, CriterioBusqueda, Vista.TuplasMaximasContenedor, incremento);
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

    protected virtual void AdicionarTuplaObjeto(En objeto) {
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
        EditarObjeto?.Invoke(sender, e);
    }

    protected virtual void OnEliminarObjeto(object? sender, EventArgs e) {
        if (sender is En objeto)
            try {
                RepositorioEntidad.Eliminar(objeto.Id);
                Vista.PaginaActual = 1;

                ActualizarResultadosBusqueda();
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