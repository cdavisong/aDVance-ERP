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
            Vista.BuscarDatos += delegate (object? sender, EventArgs e) {
                var objetoSplit = sender as object[];

                if (objetoSplit == null)
                    return;

                var criterioBusqueda = (C) objetoSplit[0];
                var datoBusqueda = string.Empty;

                if (objetoSplit[1] is string[] datosBusquedaMultiple)
                    datoBusqueda = string.Join(";", datosBusquedaMultiple);
                else datoBusqueda = objetoSplit[1].ToString();

                BusquedaDatos(criterioBusqueda, datoBusqueda);
            };
            Vista.AlturaContenedorTuplasModificada += delegate {
                RefrescarListaObjetos();
            };
            Vista.SincronizarDatos += delegate {
                RefrescarListaObjetos();
            };

            // Colecciones
            _tuplasObjetos = new List<Pt>();
        }

        public virtual Do DatosObjeto => new();

        public C CriterioBusquedaObjeto { get; protected set; }

        public string DatoBusquedaObjeto { get; protected set; }

        public event EventHandler? EditarObjeto;

        protected virtual void AdicionarTuplaObjeto(O objeto) {
            var presentadorTupla = ObtenerValoresTupla(objeto);

            if (presentadorTupla == null)
                return;

            presentadorTupla.EditarObjeto += delegate (object? sender, EventArgs e) {
                EditarObjeto?.Invoke(sender, e);
            };
            presentadorTupla.EliminarObjeto += EliminarObjeto;

            _tuplasObjetos.Add(presentadorTupla);

            // Registro y muestra
            Vista.Vistas.Registrar(
                $"vistaTupla{objeto.GetType().Name}{objeto.Id}",
                presentadorTupla.Vista,
                new Point(0, VariablesGlobales.CoordenadaYUltimaTupla),
                new Size(0, VariablesGlobales.AlturaTuplaPredeterminada), "H");
            presentadorTupla.Vista.Mostrar();

            // Incremento de la útima coordenada Y de la tupla
            VariablesGlobales.CoordenadaYUltimaTupla += VariablesGlobales.AlturaTuplaPredeterminada;
        }

        protected abstract Pt ObtenerValoresTupla(O objeto);

        protected virtual void EliminarObjeto(object? sender, EventArgs e) {
            if (sender != null && sender is O objeto) {
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
            // Cerrar las vistas
            Vista.Cerrar();

            // Eliminar tuplas visibles, presentadores de la lista y eventos de los mismos
            foreach (var tupla in _tuplasObjetos) {
                tupla.Vista.Cerrar();
            }

            _tuplasObjetos.Clear();

            // Restablecer útima coordenada Y de la tupla
            VariablesGlobales.CoordenadaYUltimaTupla = 0;

            // Adicionar tuplas de clientes registrados            
            //var objetos = string.IsNullOrEmpty(DatoBusquedaObjeto) ?
            //    DatosObjeto.Obtener().ToList() :
            //    DatosObjeto.Obtener(CriterioBusquedaObjeto, DatoBusquedaObjeto).ToList();
            var objetos = DatosObjeto.Obtener(CriterioBusquedaObjeto, DatoBusquedaObjeto).ToList();
            var calculoPaginas = objetos.Count / Vista.TuplasMaximasContenedor;
            var entero = objetos.Count % Vista.TuplasMaximasContenedor == 0;

            Vista.PaginasTotales = calculoPaginas < 1 ? 1 : entero ? calculoPaginas : calculoPaginas + 1;

            var incremento = (Vista.PaginaActual - 1) * Vista.TuplasMaximasContenedor;

            for (var i = 0; i + incremento < objetos.Count && i < Vista.TuplasMaximasContenedor; i++) {
                var objeto = objetos[i + incremento];

                AdicionarTuplaObjeto(objeto);
            }
        }
    }
}
