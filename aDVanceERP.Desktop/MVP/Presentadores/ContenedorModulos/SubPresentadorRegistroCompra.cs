using aDVanceERP.Core.Excepciones;
using aDVanceERP.Core.Mensajes.MVP.Modelos;
using aDVanceERP.Core.Mensajes.Utiles;
using aDVanceERP.Core.Utiles.Datos;
using aDVanceERP.Desktop.Utiles;
using aDVanceERP.Modulos.CompraVenta.MVP.Modelos;
using aDVanceERP.Modulos.CompraVenta.MVP.Presentadores;
using aDVanceERP.Modulos.CompraVenta.MVP.Vistas.Compra;
using aDVanceERP.Modulos.Inventario.MVP.Modelos.Repositorios;
using aDVanceERP.Modulos.Inventario.MVP.Modelos;

namespace aDVanceERP.Desktop.MVP.Presentadores.ContenedorModulos {
    public partial class PresentadorContenedorModulos {
        private PresentadorRegistroCompra? _registroCompraArticulo;

        private async Task InicializarVistaRegistroCompraArticulo() {
            try {
                _registroCompraArticulo = new PresentadorRegistroCompra(new VistaRegistroCompra());
                _registroCompraArticulo.Vista.EstablecerCoordenadasVistaRegistro(Vista.Dimensiones.Width);
                _registroCompraArticulo.Vista.EstablecerDimensionesVistaRegistro(Vista.Dimensiones.Height);
                _registroCompraArticulo.Vista.CargarRazonesSocialesProveedores(UtilesProveedor.ObtenerRazonesSocialesProveedores());
                _registroCompraArticulo.Vista.CargarNombresAlmacenes(UtilesAlmacen.ObtenerNombresAlmacenes());
                _registroCompraArticulo.Vista.CargarNombresArticulos(await UtilesArticulo.ObtenerNombresArticulos());
                _registroCompraArticulo.Salir += async (sender, args) => {
                    var salida = sender as string;
                    
                    if (string.IsNullOrEmpty(salida))
                        AdicionarMovimientoCompraArticulo(sender, args);

                    await _gestionCompras.RefrescarListaObjetos();
                };
            } catch (ExcepcionConexionServidorMySQL e) {
                CentroNotificaciones.Mostrar(e.Message, TipoNotificacion.Error);
            }
        }        

        private async void MostrarVistaRegistroCompraArticulo(object? sender, EventArgs e) {
            await InicializarVistaRegistroCompraArticulo();

            _registroCompraArticulo?.Vista.Mostrar();
            _registroCompraArticulo?.Dispose();
        }

        private async void MostrarVistaEdicionCompraArticulo(object? sender, EventArgs e) {
            await InicializarVistaRegistroCompraArticulo();

            if (_registroCompraArticulo != null && sender is Compra compra) {
                _registroCompraArticulo.PopularVistaDesdeObjeto(compra);
                _registroCompraArticulo.Vista.Mostrar();
            }

            _registroCompraArticulo?.Dispose();
        }

        private void AdicionarMovimientoCompraArticulo(object? sender, EventArgs e) {
            if (_registroCompraArticulo?.Vista.NombreArticulo == null) 
                return;

            var idArticulo = UtilesArticulo.ObtenerIdArticulo(_registroCompraArticulo.Vista.NombreArticulo).Result;
            var idAlmacenDestino = UtilesAlmacen.ObtenerIdAlmacen(_registroCompraArticulo.Vista.NombreAlmacen).Result;

            using (var datosMovimiento = new DatosMovimiento()) {
                datosMovimiento.Adicionar(new Movimiento(
                    0,
                    idArticulo,
                    0,
                    idAlmacenDestino,
                    DateTime.Now,
                    _registroCompraArticulo.Vista.Cantidad,
                    UtilesMovimiento.ObtenerIdTipoMovimiento("Compra")
                ));
            }

            UtilesMovimiento.ModificarStockArticuloAlmacen(
                idArticulo,
                0,
                idAlmacenDestino,
                _registroCompraArticulo.Vista.Cantidad
            );
        }
    }
}
