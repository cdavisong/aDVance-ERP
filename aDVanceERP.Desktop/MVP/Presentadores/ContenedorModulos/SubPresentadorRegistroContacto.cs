using aDVanceERP.Desktop.Utiles;
using aDVanceERP.Modulos.Contactos.MVP.Modelos;
using aDVanceERP.Modulos.Contactos.MVP.Presentadores;
using aDVanceERP.Modulos.Contactos.MVP.Vistas.Contacto;

namespace aDVanceERP.Desktop.MVP.Presentadores.ContenedorModulos {
    public partial class PresentadorContenedorModulos {
        private PresentadorRegistroContacto _registroContacto;

        private void InicializarVistaRegistroContacto() {
            _registroContacto = new PresentadorRegistroContacto(new VistaRegistroContacto());
            _registroContacto.Vista.EstablecerCoordenadasVistaRegistro(Vista.Dimensiones.Width);
            _registroContacto.Vista.EstablecerDimensionesVistaRegistro(Vista.Dimensiones.Height);
            _registroContacto.Salir += delegate {
                if (_gestionContactos != null) {
                    _gestionContactos.RefrescarListaObjetos();
                }
            };
        }

        private void MostrarVistaRegistroContacto(object? sender, EventArgs e) {
            InicializarVistaRegistroContacto();

            if (_registroContacto != null) {
                _registroContacto.Vista.Mostrar();
            }

            _registroContacto?.Dispose();
        }

        private void MostrarVistaEdicionContacto(object? sender, EventArgs e) {
            InicializarVistaRegistroContacto();

            if (_registroContacto != null && sender is Contacto contacto) {
                _registroContacto.PopularVistaDesdeObjeto(contacto);
                _registroContacto.Vista.Mostrar();
            }

            _registroContacto?.Dispose();
        }
    }
}
