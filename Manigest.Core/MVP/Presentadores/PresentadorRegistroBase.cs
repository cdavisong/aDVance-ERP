using Manigest.Core.Excepciones;
using Manigest.Core.MVP.Modelos.Plantillas;
using Manigest.Core.MVP.Modelos.Repositorios.Plantillas;
using Manigest.Core.MVP.Presentadores.Plantillas;
using Manigest.Core.MVP.Vistas.Plantillas;

namespace Manigest.Core.MVP.Presentadores {
    public abstract class PresentadorRegistroBase<Vr, O, Do, C> : PresentadorBase<Vr>, IPresentadorRegistro<Vr, Do, O, C>
        where Vr : IVistaRegistro
        where Do : class, IRepositorioDatos<O, C>, new()
        where O : class, IObjetoUnico
        where C : Enum {
        protected O _objeto;

        protected PresentadorRegistroBase(Vr vista, O objeto) : base(vista) {
            _objeto = objeto;

            Vista.RegistrarDatos += RegistrarDatosObjeto;
            Vista.EditarDatos += EditarDatosObjeto;
            Vista.Salir += delegate (object? sender, EventArgs e) {
                Salir?.Invoke(sender, e);
                Vista.Cerrar();
            };
        }

        public virtual Do DatosObjeto => new();

        public event EventHandler? DatosRegistradosActualizados;
        public event EventHandler? Salir;

        public abstract void PopularVistaDesdeObjeto(O objeto);

        protected abstract O ObtenerObjetoDesdeVista();

        protected virtual bool RegistroEdicionDatosAutorizado() {
            return true;
        }

        protected virtual void RegistroAuxiliar() { }

        protected virtual void RegistrarDatosObjeto(object? sender, EventArgs e) {
            RegistrarEditarObjeto(sender, e);
        }

        protected virtual void EditarDatosObjeto(object? sender, EventArgs e) {
            RegistrarEditarObjeto(sender, e);
        }

        private void RegistrarEditarObjeto(object? sender, EventArgs e) {
            if (!RegistroEdicionDatosAutorizado())
                return;

            try {
                _objeto = ObtenerObjetoDesdeVista();

                if (_objeto == null)
                    return;

                if (Vista.ModoEdicionDatos && _objeto.Id != 0) {
                    DatosObjeto.Editar(_objeto);
                } else if (_objeto.Id != 0) {
                    DatosObjeto.Editar(_objeto);
                } else _objeto.Id = DatosObjeto.Adicionar(_objeto);

                RegistroAuxiliar();

                // lanzar eventos
                DatosRegistradosActualizados?.Invoke(sender, e);
                Salir?.Invoke(sender, e);
                Vista.Cerrar();
            } catch (ExcepcionConexionServidorMySQL) {
                // ...
            }
        }
    }
}
