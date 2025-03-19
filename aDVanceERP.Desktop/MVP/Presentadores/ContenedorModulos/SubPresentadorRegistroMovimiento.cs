using aDVanceERP.Core.Utiles.Datos;
using aDVanceERP.Desktop.Utiles;
using aDVanceERP.Modulos.Inventario.MVP.Modelos;
using aDVanceERP.Modulos.Inventario.MVP.Presentadores;
using aDVanceERP.Modulos.Inventario.MVP.Vistas.Movimiento;

namespace aDVanceERP.Desktop.MVP.Presentadores.ContenedorModulos {
    public partial class PresentadorContenedorModulos {
        private PresentadorRegistroMovimiento _registroMovimiento;

        public string Signo { get; private set; }

        private async Task InicializarVistaRegistroMovimiento() {
            _registroMovimiento = new PresentadorRegistroMovimiento(new VistaRegistroMovimiento());
            _registroMovimiento.Vista.CargarNombresArticulos(await UtilesArticulo.ObtenerNombresArticulos());
            _registroMovimiento.Vista.CargarNombresAlmacenes(UtilesAlmacen.ObtenerNombresAlmacenes());
            _registroMovimiento.Vista.EstablecerCoordenadasVistaRegistro(Vista.Dimensiones.Width);
            _registroMovimiento.Vista.EstablecerDimensionesVistaRegistro(Vista.Dimensiones.Height);
            _registroMovimiento.Vista.RegistrarTipoMovimiento += MostrarVistaRegistroTipoMovimiento;
            _registroMovimiento.Salir += async (sender, e) => {
                if (_gestionMovimientos != null) {
                    await _gestionMovimientos.RefrescarListaObjetos();
                }
            };
        }

        private async Task InicializarVistaRegistroMovimiento(string signo, string nombreAlmacen) {
            await InicializarVistaRegistroMovimiento();

            if (_registroMovimiento != null) {
                Signo = signo;

                if (string.IsNullOrEmpty(signo)) {
                    _registroMovimiento.Vista.CargarTiposMovimientos(UtilesMovimiento.ObtenerNombresTiposMovimientos());
                } else {
                    _registroMovimiento.Vista.CargarTiposMovimientos(UtilesMovimiento.ObtenerNombresTiposMovimientos(signo));

                    if (!nombreAlmacen.Equals("-")) {
                        _registroMovimiento.Vista.NombreAlmacenOrigen = signo.Equals("-") ? nombreAlmacen : "Ninguno";
                        _registroMovimiento.Vista.NombreAlmacenDestino = signo.Equals("+") ? nombreAlmacen : "Ninguno";
                    }
                }
            }
        }

        private async Task InicializarVistaRegistroMovimiento(string signo, string nombreAlmacen, Articulo objeto) {
            await InicializarVistaRegistroMovimiento(signo, nombreAlmacen);

            if (_registroMovimiento != null) {
                _registroMovimiento.Vista.NombreArticulo = objeto?.Nombre ?? string.Empty;
            }
        }

        private async void MostrarVistaRegistroMovimiento(object? sender, EventArgs e) {
            if (sender is object[] datosAlmacenArticulo)
                await InicializarVistaRegistroMovimiento(datosAlmacenArticulo[0].ToString(), datosAlmacenArticulo[1].ToString(), datosAlmacenArticulo[2] as Articulo);
            else
                await InicializarVistaRegistroMovimiento(string.Empty, string.Empty);

            if (_registroMovimiento != null) {
                _registroMovimiento.Vista.Mostrar();
            }

            _registroMovimiento?.Dispose();
        }

        private async void MostrarVistaEdicionMovimiento(object? sender, EventArgs e) {
            await InicializarVistaRegistroMovimiento(string.Empty, string.Empty);

            if (_registroMovimiento != null && sender is Movimiento movimiento) {
                _registroMovimiento.PopularVistaDesdeObjeto(movimiento);
                _registroMovimiento.Vista.Mostrar();
            }

            _registroMovimiento?.Dispose();
        }
    }
}
