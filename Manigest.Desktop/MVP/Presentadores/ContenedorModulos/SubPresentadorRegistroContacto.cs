using Manigest.Core.Utiles;
using Manigest.Modulos.Contactos.MVP.Modelos;
using Manigest.Modulos.Contactos.MVP.Presentadores;
using Manigest.Modulos.Contactos.MVP.Vistas.Contacto;

namespace Manigest.Desktop.MVP.Presentadores.ContenedorModulos {
    public partial class PresentadorContenedorModulos {
        private PresentadorRegistroContacto _registroContacto;

        private void InicializarVistaRegistroContacto() {
            _registroContacto = new PresentadorRegistroContacto(new VistaRegistroContacto());
            _registroContacto.Vista.Coordenadas = new Point(Vista.Dimensiones.Width - _registroContacto.Vista.Dimensiones.Width - 20, VariablesGlobales.AlturaBarraTituloPredeterminada);
            _registroContacto.Vista.Dimensiones = new Size(_registroContacto.Vista.Dimensiones.Width, Vista.Dimensiones.Height);
            _registroContacto.Salir += delegate { _gestionContactos.RefrescarListaObjetos(); };
        }

        private void MostrarVistaRegistroContacto(object? sender, EventArgs e) {
            InicializarVistaRegistroContacto();

            _registroContacto.Vista.Mostrar();
            _registroContacto = null;
        }

        private void MostrarVistaEdicionContacto(object? sender, EventArgs e) {
            InicializarVistaRegistroContacto();

            _registroContacto.PopularVistaDesdeObjeto(sender as Contacto);
            _registroContacto.Vista.Mostrar();
            _registroContacto = null;
        }
    }
}
