using aDVanceERP.Core.Utiles;
using aDVanceERP.Core.Utiles.Datos;
using aDVanceERP.Modulos.Inventario.MVP.Modelos;
using aDVanceERP.Modulos.Inventario.MVP.Presentadores;
using aDVanceERP.Modulos.Inventario.MVP.Vistas.Movimiento;

namespace aDVanceERP.Desktop.MVP.Presentadores.ContenedorModulos {
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

        private void InicializarVistaRegistroMovimiento(string signo, string nombreAlmacen) {
            InicializarVistaRegistroMovimiento();

            if (string.IsNullOrEmpty(signo)) {
                _registroMovimiento.Vista.CargarMotivos(UtilesMovimientoArticuloAlmacen.MotivoMovimientoPositivo);
                _registroMovimiento.Vista.CargarMotivos(UtilesMovimientoArticuloAlmacen.MotivoMovimientoNegativo);
            } else {
                _registroMovimiento.Vista.CargarMotivos(signo.Equals("+")
                    ? UtilesMovimientoArticuloAlmacen.MotivoMovimientoPositivo
                    : UtilesMovimientoArticuloAlmacen.MotivoMovimientoNegativo);

                if (!nombreAlmacen.Equals("-")) {
                    _registroMovimiento.Vista.NombreAlmacenOrigen = signo.Equals("-") ? nombreAlmacen : "Ninguno";
                    _registroMovimiento.Vista.NombreAlmacenDestino = signo.Equals("+") ? nombreAlmacen : "Ninguno";
                }
            }
        }

        private void InicializarVistaRegistroMovimiento(string signo, string nombreAlmacen, Articulo objeto) {
            InicializarVistaRegistroMovimiento(signo, nombreAlmacen);

            _registroMovimiento.Vista.NombreArticulo = objeto.Nombre;
        }

        private void MostrarVistaRegistroMovimiento(object? sender, EventArgs e) {
            if (sender is object[] datosAlmacenArticulo)
                InicializarVistaRegistroMovimiento(datosAlmacenArticulo[0].ToString(), datosAlmacenArticulo[1].ToString(), datosAlmacenArticulo[2] as Articulo);
            else
                InicializarVistaRegistroMovimiento(string.Empty, string.Empty);

            _registroMovimiento.Vista.Mostrar();
            _registroMovimiento = null;
        }

        private void MostrarVistaEdicionMovimiento(object? sender, EventArgs e) {
            InicializarVistaRegistroMovimiento(string.Empty, string.Empty);

            _registroMovimiento.PopularVistaDesdeObjeto(sender as Movimiento);
            _registroMovimiento.Vista.Mostrar();
            _registroMovimiento = null;
        }
    }
}
