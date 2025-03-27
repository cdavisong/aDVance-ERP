using aDVanceERP.Core.MVP.Modelos.Plantillas;
using aDVanceERP.Core.MVP.Modelos.Repositorios.Plantillas;
using aDVanceERP.Core.MVP.Presentadores.Plantillas;
using aDVanceERP.Core.MVP.Vistas.Plantillas;

namespace aDVanceERP.Core.MVP.Presentadores {
    public abstract class PresentadorRegistroBase<Vr, O, Do, C> : PresentadorBase<Vr>, IPresentadorRegistro<Vr, Do, O, C>, IDisposable
        where Vr : class, IVistaRegistro
        where Do : class, IRepositorioDatos<O, C>, new()
        where O : class, IObjetoUnico, new()
        where C : Enum {
        private bool _disposed = false; // Para evitar llamadas redundantes a Dispose

        protected PresentadorRegistroBase(Vr vista) : base(vista) {
            Vista.RegistrarDatos += RegistrarDatosObjeto;
            Vista.EditarDatos += EditarDatosObjeto;
            Vista.Salir += OnSalir;
        }

        protected O? Objeto { get; set; } // Objeto que se va a registrar o editar

        public Do DatosObjeto {
            get => new();
        }

        public event EventHandler? DatosRegistradosActualizados;
        public event EventHandler? Salir;

        public abstract void PopularVistaDesdeObjeto(O objeto);

        protected abstract Task<O?> ObtenerObjetoDesdeVista();

        protected virtual bool RegistroEdicionDatosAutorizado() {
            return true;
        }

        protected virtual void RegistroAuxiliar() { }

        protected virtual void RegistrarDatosObjeto(object? sender, EventArgs e) {
            _ = RegistrarEditarObjetoAsync(sender, e); // Llamar asincrónicamente sin esperar
        }

        protected virtual void EditarDatosObjeto(object? sender, EventArgs e) {
            _ = RegistrarEditarObjetoAsync(sender, e); // Llamar asincrónicamente sin esperar
        }

        private async Task RegistrarEditarObjetoAsync(object? sender, EventArgs e) {
            if (!RegistroEdicionDatosAutorizado())
                return;

            Objeto = await ObtenerObjetoDesdeVista();

            if (Objeto == null)
                return;

            if (Vista.ModoEdicionDatos && Objeto.Id != 0) {
                await DatosObjeto.EditarAsync(Objeto);
            } else if (Objeto.Id != 0) {
                await DatosObjeto.EditarAsync(Objeto);
            } else {
                Objeto.Id = await DatosObjeto.AdicionarAsync(Objeto);
            }

            RegistroAuxiliar();

            DatosRegistradosActualizados?.Invoke(sender, e);
            Salir?.Invoke(sender, e);
            Vista.Cerrar();
        }

        private void OnSalir(object? sender, EventArgs e) {
            Salir?.Invoke(sender, e);
            Vista.Cerrar();
        }

        // Implementación de IDisposable
        public void Dispose() {
            Dispose(true);
            GC.SuppressFinalize(this); // Evitar que el GC llame al finalizador
        }

        protected virtual void Dispose(bool disposing) {
            if (_disposed) 
                return;

            if (disposing) {
                // Liberar recursos administrados
                if (Vista is IDisposable disposableVista) {
                    disposableVista.Dispose();
                }

                // Liberar otros recursos administrados si es necesario
            }

            // Liberar recursos no administrados si es necesario

            _disposed = true;
        }

        ~PresentadorRegistroBase() {
            Dispose(false);
        }
    }
}