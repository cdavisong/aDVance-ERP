using aDVanceERP.Core.MVP.Modelos.Plantillas;
using aDVanceERP.Core.MVP.Modelos.Repositorios.Plantillas;
using aDVanceERP.Core.MVP.Presentadores.Plantillas;
using aDVanceERP.Core.MVP.Vistas.Plantillas;
using aDVanceERP.Core.Utiles;

namespace aDVanceERP.Core.MVP.Presentadores {
    public abstract class PresentadorGestionBase<Pt, Vg, Vt, O, Do, C>
        : PresentadorBase<Vg>, IPresentadorGestion<Vg, Do, O, C>
        where Pt : IPresentadorTupla<Vt, O>
        where Vg : IVistaContenedor, IGestorDatos, IBuscadorDatos<C>, IGestorTablaDatos
        where Vt : IVistaTupla
        where Do : class, IRepositorioDatos<O, C>, new()
        where O : class, IObjetoUnico, new()
        where C : Enum {
        #region Campos y Propiedades

        protected readonly List<Pt> _tuplasObjetos;
        private readonly SemaphoreSlim _semaphore = new(1, 1);

        public Do DatosObjeto => new();
        public C? CriterioBusquedaObjeto { get; protected set; }
        public string? DatoBusquedaObjeto { get; protected set; }

        public event EventHandler? EditarObjeto;

        #endregion

        #region Constructor e Inicialización

        protected PresentadorGestionBase(Vg vista) : base(vista) {
            _tuplasObjetos = new List<Pt>();

            RegistrarManejadoresEventos();
        }

        private void RegistrarManejadoresEventos() {
            Vista.BuscarDatos += OnBuscarDatos;
            Vista.AlturaContenedorTuplasModificada += OnAlturaContenedorTuplasModificada;
            Vista.SincronizarDatos += OnSincronizarDatos;
        }

        #endregion

        #region Métodos Públicos

        public void BusquedaDatos(C criterio, string dato) {
            CriterioBusquedaObjeto = criterio;
            DatoBusquedaObjeto = dato;
            Vista.PaginaActual = 1;

            RefrescarListaObjetos();
        }

        public virtual void RefrescarListaObjetos() {
            new Thread(() => {
                _semaphore.Wait();

                try {
                    if (Vista.TuplasMaximasContenedor == 0) 
                        return;

                    LimpiarVistasExistentes();
                    ActualizarConfiguracionPaginacion();
                    CargarObjetosPaginados();
                } catch (Exception ex) {
                    ManejarErrorRefresco(ex);
                } finally {
                    _semaphore.Release();
                }

                return; // Asegurar que el hilo termine correctamente
            }).Start();            
        }

        #endregion

        #region Métodos Protegidos

        protected virtual void AdicionarTuplaObjeto(O objeto) {
            var presentadorTupla = ObtenerValoresTupla(objeto);

            if (presentadorTupla == null) 
                return;

            ConfigurarEventosTupla(presentadorTupla);

            _tuplasObjetos.Add(presentadorTupla);

            (Vista as Control)?.Invoke((MethodInvoker) (() => {
                RegistrarVistaTupla(presentadorTupla, objeto);
                ActualizarPosicionamientoInterfaz(presentadorTupla);
            }));
        }

        protected abstract Pt ObtenerValoresTupla(O objeto);

        #endregion

        #region Métodos Privados

        private void LimpiarVistasExistentes() {
            Vista.Vistas?.CerrarVistas();

            _tuplasObjetos.ForEach(tupla => tupla.Vista.Cerrar());
            _tuplasObjetos.Clear();

            VariablesGlobales.CoordenadaYUltimaTupla = 0;
        }

        private void ActualizarConfiguracionPaginacion() {
            var totalObjetos = (int) DatosObjeto.Cantidad(); // Conversión explícita a int
            var paginas = CalcularTotalPaginas(totalObjetos);
            
            (Vista as Control)?.Invoke((MethodInvoker) (() => { 
                Vista.PaginasTotales = paginas; 
            }));            
        }

        private int CalcularTotalPaginas(int totalObjetos) {
            if (Vista.TuplasMaximasContenedor == 0) 
                return 1;

            var paginasBase = totalObjetos / Vista.TuplasMaximasContenedor;
            var tieneResto = totalObjetos % Vista.TuplasMaximasContenedor != 0;
            
            return paginasBase < 1 ? 1 : (tieneResto ? paginasBase + 1 : paginasBase);
        }

        private void CargarObjetosPaginados() {
            var incremento = (Vista.PaginaActual - 1) * Vista.TuplasMaximasContenedor;
            var objetos = DatosObjeto.Obtener(
                CriterioBusquedaObjeto,
                DatoBusquedaObjeto,
                Vista.TuplasMaximasContenedor,
                incremento
            ).ToList();

            for (int i = 0; i < objetos.Count && i < Vista.TuplasMaximasContenedor; i++) {
                AdicionarTuplaObjeto(objetos[i]);
            }
        }

        private void ConfigurarEventosTupla(Pt tupla) {
            tupla.EditarObjeto += (sender, e) => EditarObjeto?.Invoke(sender, e);
            tupla.EliminarObjeto += EliminarObjeto;
        }

        private void RegistrarVistaTupla(Pt presentadorTupla, O objeto) {
            Vista.Vistas?.Registrar(
                $"vistaTupla{objeto.GetType().Name}{objeto.Id}",
                presentadorTupla.Vista,
                new Point(0, VariablesGlobales.CoordenadaYUltimaTupla),
                new Size(0, VariablesGlobales.AlturaTuplaPredeterminada),
                "H"
            );
        }

        private void ActualizarPosicionamientoInterfaz(Pt presentadorTupla) {
            presentadorTupla.Vista.Mostrar();

            VariablesGlobales.CoordenadaYUltimaTupla += VariablesGlobales.AlturaTuplaPredeterminada;
        }

        private void ManejarErrorRefresco(Exception ex) {
            // TODO: Implementar manejo de errores apropiado
            Console.WriteLine($"Error al refrescar lista: {ex.Message}");
        }
        #endregion

        #region Manejadores de Eventos
        private void OnBuscarDatos(object? sender, EventArgs e) {
            if (sender is object[] parametros && parametros.Length >= 2) {
                var criterio = (C) parametros[0];
                var dato = parametros[1] is string[] datosMultiples
                    ? string.Join(";", datosMultiples)
                    : parametros[1].ToString();

                BusquedaDatos(criterio, dato);
            }
        }

        private void OnAlturaContenedorTuplasModificada(object? sender, EventArgs e) {
            if (Vista is Form form && !form.Visible) return;
            RefrescarListaObjetos();
        }

        private void OnSincronizarDatos(object? sender, EventArgs e) => RefrescarListaObjetos();

        protected virtual void EliminarObjeto(object? sender, EventArgs e) {
            if (sender is O objeto) {
                try {
                    DatosObjeto.Eliminar(objeto.Id);
                    Vista.PaginaActual = 1;
                    RefrescarListaObjetos();
                } catch (Exception ex) {
                    // TODO: Implementar manejo de errores
                    Console.WriteLine($"Error eliminando objeto: {ex.Message}");
                }
            }
        }

        #endregion
    }
}