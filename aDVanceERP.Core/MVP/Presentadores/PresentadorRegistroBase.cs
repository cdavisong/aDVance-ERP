using aDVanceERP.Core.MVP.Modelos.Plantillas;
using aDVanceERP.Core.MVP.Modelos.Repositorios.Plantillas;
using aDVanceERP.Core.MVP.Presentadores.Plantillas;
using aDVanceERP.Core.MVP.Vistas.Plantillas;

namespace aDVanceERP.Core.MVP.Presentadores {
    public abstract class PresentadorRegistroBase<Vr, O, Do, C> : PresentadorBase<Vr>, IPresentadorRegistro<Vr, Do, O, C>, IDisposable
        where Vr : IVistaRegistro
        where Do : class, IRepositorioDatos<O, C>, new()
        where O : class, IObjetoUnico, new()
        where C : Enum {
        protected O? _objeto = null;
        private bool _disposed = false; // Para evitar llamadas redundantes a Dispose

        protected PresentadorRegistroBase(Vr vista) : base(vista) {
            Vista.RegistrarDatos += RegistrarDatosObjeto;
            Vista.EditarDatos += EditarDatosObjeto;
            Vista.Salir += OnSalir;
        }

        public Do DatosObjeto => new Do();

        public event EventHandler? DatosRegistradosActualizados;
        public event EventHandler? Salir;

        public abstract void PopularVistaDesdeObjeto(O objeto);

        protected abstract O? ObtenerObjetoDesdeVista();

        protected virtual bool RegistroEdicionDatosAutorizado() {
            return true;
        }

        protected virtual void RegistroAuxiliar() { }

        protected virtual void RegistrarDatosObjeto(object? sender, EventArgs e) {
            RegistrarEditarObjetoAsync(sender, e);
        }

        protected virtual void EditarDatosObjeto(object? sender, EventArgs e) {
            RegistrarEditarObjetoAsync(sender, e);
        }

        private void RegistrarEditarObjetoAsync(object? sender, EventArgs e) {
            if (!RegistroEdicionDatosAutorizado())
                return;

            _objeto = ObtenerObjetoDesdeVista();

            if (_objeto == null)
                return;

            if (Vista.ModoEdicionDatos && _objeto.Id != 0) {
                DatosObjeto.Editar(_objeto);
            } else if (_objeto.Id != 0) {
                DatosObjeto.Editar(_objeto);
            } else {
                _objeto.Id = DatosObjeto.Adicionar(_objeto);
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
            if (!_disposed) {
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
        }

        ~PresentadorRegistroBase() {
            Dispose(false);
        }
    }
}