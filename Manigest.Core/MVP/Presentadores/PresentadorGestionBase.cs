using Manigest.Core.MVP.Modelos.Plantillas;
using Manigest.Core.MVP.Modelos.Repositorios.Plantillas;
using Manigest.Core.MVP.Presentadores.Plantillas;
using Manigest.Core.MVP.Vistas.Plantillas;
using Manigest.Core.Utiles;

using System.Drawing;

namespace Manigest.Core.MVP.Presentadores {
    public abstract class PresentadorGestionBase<Pt, Vg, Vt, O, Do, C> : PresentadorBase<Vg>, IPresentadorGestion<Vg, Do, O, C>
        where Pt : IPresentadorTupla<Vt, O>
        where Vg : IVistaContenedor, IGestorDatos, IBuscadorDatos, IGestorTablaDatos
        where Vt : IVistaTupla
        where Do : class, IRepositorioDatos<O, C>, new()
        where O : class, IObjetoUnico
        where C : Enum {
        protected readonly List<Pt> _tuplasObjetos;

        protected PresentadorGestionBase(Vg vista) : base(vista) {
            Vista.BuscarDatos += delegate (object? sender, EventArgs e) { 
                RefrescarListaObjetos(CriterioBusquedaObjeto, sender?.ToString()); 
            };
            Vista.AlturaContenedorTuplasModificada += RecalcularTuplasMaximasContenedor;
            Vista.SincronizarDatos += delegate { RefrescarListaObjetos(); };

            // Colecciones
            _tuplasObjetos = new List<Pt>();
        }

        public virtual Do DatosObjeto => new();
        public abstract C CriterioBusquedaObjeto { get; }

        public event EventHandler? EditarObjeto;

        private void RecalcularTuplasMaximasContenedor(object? sender, EventArgs e) {
            if (Vista.Habilitada)
                VariablesGlobales.TuplasMaximasContenedor = Vista.AlturaContenedorVistas / VariablesGlobales.AlturaTuplaPredeterminada;
        }

        protected virtual void AdicionarTuplaObjeto(O objeto) {
            var presentadorTupla = ObtenerValoresTupla(objeto);

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
                new Size(0, 42), "H");
            presentadorTupla.Vista.Mostrar();

            // Incremento de la útima coordenada Y de la tupla
            VariablesGlobales.CoordenadaYUltimaTupla += VariablesGlobales.AlturaTuplaPredeterminada;
        }

        protected abstract Pt ObtenerValoresTupla(O objeto);

        protected virtual void EliminarObjeto(object? sender, EventArgs e) {
            if (sender != null && sender is O objeto) {
                DatosObjeto.Eliminar(objeto.Id);
                Vista.PaginaActual = 1;

                RefrescarListaObjetos(CriterioBusquedaObjeto);
            }
        }

        public virtual void RefrescarListaObjetos(C criterioBusquedaObjeto = default, string? datoBusqueda = "") {
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
            var objetos = string.IsNullOrEmpty(datoBusqueda) ?
                DatosObjeto.Obtener().ToList() :
                DatosObjeto.Obtener(criterioBusquedaObjeto, datoBusqueda).ToList();
            var calculoPaginas = objetos.Count / VariablesGlobales.TuplasMaximasContenedor;
            var entero = objetos.Count % VariablesGlobales.TuplasMaximasContenedor == 0;

            Vista.PaginasTotales = calculoPaginas < 1 ? 1 : entero ? calculoPaginas : calculoPaginas + 1;

            var incremento = (Vista.PaginaActual - 1) * VariablesGlobales.TuplasMaximasContenedor;

            for (var i = 0; i + incremento < objetos.Count && i < VariablesGlobales.TuplasMaximasContenedor; i++) {
                var objeto = objetos[i + incremento];

                AdicionarTuplaObjeto(objeto);
            }
        }
    }
}
