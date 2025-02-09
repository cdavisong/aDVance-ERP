using Manigest.Core.Utiles;
using Manigest.Core.Utiles.Datos;
using Manigest.Modulos.Inventario.MVP.Modelos;
using Manigest.Modulos.Inventario.MVP.Presentadores;
using Manigest.Modulos.Inventario.MVP.Vistas.Movimiento;

namespace Manigest.Desktop.MVP.Presentadores.ContenedorModulos {
    public partial class PresentadorContenedorModulos {
        private PresentadorRegistroMovimiento _registroMovimiento;

        private void InicializarVistaRegistroMovimiento() {
            _registroMovimiento = new PresentadorRegistroMovimiento(new VistaRegistroMovimiento());
            _registroMovimiento.Vista.CargarNombresArticulos(UtilesArticulo.ObtenerNombresArticulos());
            _registroMovimiento.Vista.CargarNombresAlmacenes(UtilesAlmacen.ObtenerNombresAlmacenes());
            _registroMovimiento.Vista.Coordenadas = new Point(Vista.Dimensiones.Width - _registroMovimiento.Vista.Dimensiones.Width - 20, VariablesGlobales.AlturaBarraTituloPredeterminada);
            _registroMovimiento.Vista.Dimensiones = new Size(_registroMovimiento.Vista.Dimensiones.Width, Vista.Dimensiones.Height);
            _registroMovimiento.Salir += delegate { _gestionMovimientos.RefrescarListaObjetos(); };
        }

        private void InicializarVistaRegistroMovimiento(string signo) {
            InicializarVistaRegistroMovimiento();

            if (string.IsNullOrEmpty(signo)) {
                _registroMovimiento.Vista.CargarMotivos(UtilesMovimientoArticuloAlmacen.MotivoMovimientoPositivo);
                _registroMovimiento.Vista.CargarMotivos(UtilesMovimientoArticuloAlmacen.MotivoMovimientoNegativo);                
            } else
                _registroMovimiento.Vista.CargarMotivos(signo.Equals("+") 
                    ? UtilesMovimientoArticuloAlmacen.MotivoMovimientoPositivo 
                    : UtilesMovimientoArticuloAlmacen.MotivoMovimientoNegativo);
        }

        private void InicializarVistaRegistroMovimiento(string signo, Articulo objeto) {
            InicializarVistaRegistroMovimiento(signo);

            _registroMovimiento.Vista.NombreArticulo = objeto.Nombre;
        }

        private void MostrarVistaRegistroMovimiento(object? sender, EventArgs e) {
            if (sender is object[] objetoSigno)
                InicializarVistaRegistroMovimiento(objetoSigno[0].ToString(), objetoSigno[1] as Articulo);
            else
                InicializarVistaRegistroMovimiento(string.Empty);

            _registroMovimiento.Vista.Mostrar();
            _registroMovimiento = null;
        }

        private void MostrarVistaEdicionMovimiento(object? sender, EventArgs e) {
            InicializarVistaRegistroMovimiento(string.Empty);

            _registroMovimiento.PopularVistaDesdeObjeto(sender as Movimiento);
            _registroMovimiento.Vista.Mostrar();
            _registroMovimiento = null;
        }
    }
}
