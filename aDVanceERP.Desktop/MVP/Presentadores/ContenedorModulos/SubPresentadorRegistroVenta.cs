using aDVanceERP.Core.Excepciones;
using aDVanceERP.Core.Mensajes.MVP.Modelos;
using aDVanceERP.Core.Mensajes.Utiles;
using aDVanceERP.Core.Utiles.Datos;
using aDVanceERP.Desktop.Utiles;
using aDVanceERP.Modulos.CompraVenta.MVP.Modelos;
using aDVanceERP.Modulos.CompraVenta.MVP.Presentadores;
using aDVanceERP.Modulos.Inventario.MVP.Modelos;
using aDVanceERP.Modulos.Inventario.MVP.Modelos.Repositorios;
using aDVanceERP.Modulos.CompraVenta.MVP.Modelos;
using aDVanceERP.Modulos.CompraVenta.MVP.Modelos.Repositorios;
using aDVanceERP.Modulos.CompraVenta.MVP.Vistas.Venta;

namespace aDVanceERP.Desktop.MVP.Presentadores.ContenedorModulos {
    public partial class PresentadorContenedorModulos {
        private PresentadorRegistroVenta _registroVentaArticulo;

        public List<string[]>? Articulos { get; private set; } = new List<string[]>();

        private async Task InicializarVistaRegistroVentaArticulo() {
            try {
                _registroVentaArticulo = new PresentadorRegistroVenta(new VistaRegistroVenta());
                _registroVentaArticulo.Vista.EstablecerCoordenadasVistaRegistro(Vista.Dimensiones.Width);
                _registroVentaArticulo.Vista.EstablecerDimensionesVistaRegistro(Vista.Dimensiones.Height);
                _registroVentaArticulo.Vista.CargarRazonesSocialesClientes(UtilesCliente.ObtenerRazonesSocialesClientes());
                _registroVentaArticulo.Vista.CargarNombresAlmacenes(UtilesAlmacen.ObtenerNombresAlmacenes(true));
                _registroVentaArticulo.Vista.RegistrarDatos += delegate {
                    Articulos = _registroVentaArticulo.Vista.Articulos;

                    RegistrarArticulos();
                    RegistrarPagos();
                    RegistrarTransferencia();
                };
                _registroVentaArticulo.Salir += async (sender, e) => {
                    if (_gestionVentasArticulos != null) {
                        await _gestionVentasArticulos.RefrescarListaObjetos();
                    }
                };
            } catch (ExcepcionConexionServidorMySQL e) {
                CentroNotificaciones.Mostrar(e.Message, TipoNotificacion.Error);
            }
            
        }

        private async void MostrarVistaRegistroVentaArticulo(object? sender, EventArgs e) {
            await InicializarVistaRegistroVentaArticulo();

            if (_registroVentaArticulo != null) {
                _registroVentaArticulo.Vista.EfectuarPago += delegate {
                    MostrarVistaRegistroPago(_registroVentaArticulo?.Vista.Total, e);

                    _registroVentaArticulo.Vista.PagoConfirmado = Pagos.Count > 0;
                };
                _registroVentaArticulo?.Vista.Mostrar();
            }

            _registroVentaArticulo?.Dispose();
        }

        private async void MostrarVistaEdicionVentaArticulo(object? sender, EventArgs e) {
            await InicializarVistaRegistroVentaArticulo();

            if (_registroVentaArticulo != null && sender is Venta venta) {
                _registroVentaArticulo.PopularVistaDesdeObjeto(venta);
                _registroVentaArticulo.Vista.EfectuarPago += delegate {
                    MostrarVistaEdicionPago(sender, e);

                    _registroVentaArticulo.Vista.PagoConfirmado = Pagos.Count > 0;
                };
                _registroVentaArticulo.Vista.Mostrar();
            }

            _registroVentaArticulo?.Dispose();
        }

        private void RegistrarArticulos() {
            if (Articulos == null || Articulos.Count == 0)
                return;

            var ultimoIdVenta = UtilesBD.ObtenerUltimoIdTabla("venta");

            foreach (var articulo in Articulos) {
                var detalleVentaArticulo = new DetalleVentaArticulo(
                        0,
                        ultimoIdVenta,
                        long.Parse(articulo[0]),
                        float.Parse(articulo[2]),
                        int.Parse(articulo[3])
                    );

                using (var datosArticulo = new DatosDetalleVentaArticulo()) {
                    datosArticulo.Adicionar(detalleVentaArticulo);
                }

                var stockArticulo = UtilesArticulo.ObtenerStockTotalArticulo(detalleVentaArticulo.IdArticulo);

                using (var datosMovimiento = new DatosMovimiento()) {
                    datosMovimiento.Adicionar(new Movimiento(
                        0,
                        detalleVentaArticulo.IdArticulo,
                        long.Parse(articulo[4]),
                        0,
                        detalleVentaArticulo.Cantidad,
                        "Venta",
                        DateTime.Now
                    ));
                }

                UtilesMovimientoArticuloAlmacen.ModificarStockArticuloAlmacen(
                        detalleVentaArticulo.IdArticulo,
                        long.Parse(articulo[4]),
                        0,
                        detalleVentaArticulo.Cantidad
                    );
            }

            Articulos.Clear();
        }
    }
}
