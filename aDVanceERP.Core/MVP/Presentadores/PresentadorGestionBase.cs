using aDVanceERP.Core.MVP.Modelos.Plantillas;
using aDVanceERP.Core.MVP.Modelos.Repositorios.Plantillas;
using aDVanceERP.Core.MVP.Presentadores.Plantillas;
using aDVanceERP.Core.MVP.Vistas.Plantillas;
using aDVanceERP.Core.Utiles;

namespace aDVanceERP.Core.MVP.Presentadores {
    public abstract class PresentadorGestionBase<Pt, Vg, Vt, O, Do, C> : PresentadorBase<Vg>, IPresentadorGestion<Vg, Do, O, C>
        where Pt : IPresentadorTupla<Vt, O>
        where Vg : IVistaContenedor, IGestorDatos, IBuscadorDatos<C>, IGestorTablaDatos
        where Vt : IVistaTupla
        where Do : class, IRepositorioDatos<O, C>, new()
        where O : class, IObjetoUnico, new()
        where C : Enum {
        protected readonly List<Pt> _tuplasObjetos;

        protected PresentadorGestionBase(Vg vista) : base(vista) {
            _tuplasObjetos = new List<Pt>();

            Vista.BuscarDatos += OnBuscarDatos;
            Vista.AlturaContenedorTuplasModificada += OnAlturaContenedorTuplasModificada;
            Vista.SincronizarDatos += OnSincronizarDatos;
        }

        public Do DatosObjeto => new Do();
        public C? CriterioBusquedaObjeto { get; protected set; }
        public string? DatoBusquedaObjeto { get; protected set; }

        public event EventHandler? EditarObjeto;

        protected virtual void AdicionarTuplaObjeto(O objeto) {
            var presentadorTupla = ObtenerValoresTupla(objeto);
            if (presentadorTupla == null) return;

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

        protected abstract Pt ObtenerValoresTupla(O objeto);

        protected virtual void EliminarObjeto(object? sender, EventArgs e) {
            if (sender is O objeto) {
                DatosObjeto.Eliminar(objeto.Id);                
                Vista.PaginaActual = 1;
                
                RefrescarListaObjetos();
            }
        }

        public void BusquedaDatos(C criterio, string dato) {
            CriterioBusquedaObjeto = criterio;
            DatoBusquedaObjeto = dato;
            
            RefrescarListaObjetos();
        }

        public virtual void RefrescarListaObjetos() {
            if (Vista.TuplasMaximasContenedor == 0) return;

            Vista.Cerrar();

            _tuplasObjetos.ForEach(tupla => tupla.Vista.Cerrar());
            _tuplasObjetos.Clear();

            VariablesGlobales.CoordenadaYUltimaTupla = 0;

            var objetos = DatosObjeto.Obtener(CriterioBusquedaObjeto, DatoBusquedaObjeto).ToList();
            var calculoPaginas = objetos.Count / Vista.TuplasMaximasContenedor;
            var entero = objetos.Count % Vista.TuplasMaximasContenedor == 0;

            Vista.PaginasTotales = calculoPaginas < 1 ? 1 : (entero ? calculoPaginas : calculoPaginas + 1);

            var incremento = (Vista.PaginaActual - 1) * Vista.TuplasMaximasContenedor;

            for (var i = 0; i + incremento < objetos.Count && i < Vista.TuplasMaximasContenedor; i++) {
                AdicionarTuplaObjeto(objetos[i + incremento]);
            }
        }

        private async Task<IEnumerable<O>> ObtenerAsync(C criterio, string dato) {
            // Aquí deberías implementar la lógica para obtener los objetos de forma asincrónica
            // Este método es un ejemplo y debería estar en el repositorio correspondiente
            return await Task.FromResult(new List<O>());
        }


        private void OnBuscarDatos(object? sender, EventArgs e) {
            if (sender is object[] objetoSplit && objetoSplit.Length >= 2) {
                var criterioBusqueda = (C) objetoSplit[0];
                var datoBusqueda = objetoSplit[1] is string[] datosBusquedaMultiple
                    ? string.Join(";", datosBusquedaMultiple)
                    : objetoSplit[1].ToString();

                BusquedaDatos(criterioBusqueda, datoBusqueda);
            }
        }

        private void OnAlturaContenedorTuplasModificada(object? sender, EventArgs e) {
            RefrescarListaObjetos();
        }

        private void OnSincronizarDatos(object? sender, EventArgs e) {
            RefrescarListaObjetos();
        }
    }
}