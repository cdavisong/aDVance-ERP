using aDVanceERP.Core.Interfaces;

namespace aDVanceERP.Core.Presentadores;

public abstract class PresentadorVistaGestionBase<Vg, Pt, Vt, En, Rep, Fb> : PresentadorVistaBase<Vg>, IPresentadorVistaGestionBase<Vg, Pt, Vt, En, Rep, Fb>
    where Vg : class, IVistaGestion<Fb>
    where Pt : class, IPresentadorVistaTuplaBase<Vt, En>
    where Vt : class, IVistaTupla
    where En : class, IEntidadBd, new()
    where Rep : class, IRepoBase<En, Fb>
    where Fb : Enum {

    protected PresentadorVistaGestionBase(Vg vista, Rep repositorioEntidadBd) : base(vista) {
        RepositorioEntidadBd = repositorioEntidadBd;

        Vista.BarraBusqueda.Buscar += OnBuscar;
        Vista.TablaResultadosBusqueda.SincronizarDatosEntidadesBd += OnSincronizarDatosEntidadesBd;
    }

    public Rep RepositorioEntidadBd { get; }

    public void ActualizarResultadosBusqueda() {
        var tuplasResultado = new List<Pt>();
        var limite = Vista.TablaResultadosBusqueda.TuplasMaximasPanel;
        var desplazamiento = (Vista.TablaResultadosBusqueda.PaginaActual - 1) * Vista.TablaResultadosBusqueda.TuplasMaximasPanel;
        var entidadesResultado = RepositorioEntidadBd.Obtener(
            Vista.BarraBusqueda.FiltroBusqueda,
            Vista.BarraBusqueda.CriterioBusqueda,
            limite,
            desplazamiento
        );
        
        foreach (var entidadResultado in entidadesResultado.resultados) {
            var presentadorTupla = ;
        }

        // Actualizar tabla de resultados
        Vista.TablaResultadosBusqueda.ActualizarResultadosBusqueda(entidadesResultado.cantidad, entidadesResultado.resultados);
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

    protected abstract Pt ObtenerValoresTupla(En entidadBd);

    private void DeseleccionarTuplas(IVistaTupla vista) {
        _tuplasObjetos.ForEach(tupla => {
            if (!tupla.Vista.Equals(vista))
                tupla.TuplaSeleccionada = false;
        });
    }

    

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

    private async void OnBuscar(object? sender, EventArgs e) {
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

    private async void OnSincronizarDatosEntidadesBd(object? sender, EventArgs e) {
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