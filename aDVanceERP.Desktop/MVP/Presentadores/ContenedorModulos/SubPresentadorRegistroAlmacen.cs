using aDVanceERP.Core.Utiles;
using aDVanceERP.Modulos.Inventario.MVP.Modelos;
using aDVanceERP.Modulos.Inventario.MVP.Presentadores;
using aDVanceERP.Modulos.Inventario.MVP.Vistas.Almacen;

namespace aDVanceERP.Desktop.MVP.Presentadores.ContenedorModulos {
    public partial class PresentadorContenedorModulos {
        private PresentadorRegistroAlmacen _registroAlmacen;

        private void InicializarVistaRegistroAlmacen() {
            _registroAlmacen = new PresentadorRegistroAlmacen(new VistaRegistroAlmacen());
            _registroAlmacen.Vista.Coordenadas = new Point(Vista.Dimensiones.Width - _registroAlmacen.Vista.Dimensiones.Width - 20, VariablesGlobales.AlturaBarraTituloPredeterminada);
            _registroAlmacen.Vista.Dimensiones = new Size(_registroAlmacen.Vista.Dimensiones.Width, Vista.Dimensiones.Height);
            _registroAlmacen.Salir += delegate { _gestionAlmacenes.RefrescarListaObjetos(); };
        }

        private void MostrarVistaRegistroAlmacen(object? sender, EventArgs e) {
            InicializarVistaRegistroAlmacen();

            _registroAlmacen.Vista.Mostrar();
            _registroAlmacen = null;
        }

        private void MostrarVistaEdicionAlmacen(object? sender, EventArgs e) {
            InicializarVistaRegistroAlmacen();

            _registroAlmacen.PopularVistaDesdeObjeto(sender as Almacen);
            _registroAlmacen.Vista.Mostrar();
            _registroAlmacen = null;
        }
    }
}
