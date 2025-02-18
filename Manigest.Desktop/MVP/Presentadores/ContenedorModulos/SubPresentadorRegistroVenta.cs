using Manigest.Core.Utiles;
using Manigest.Core.Utiles.Datos;
using Manigest.Modulos.Inventario.MVP.Modelos;
using Manigest.Modulos.Inventario.MVP.Modelos.Repositorios;
using Manigest.Modulos.Ventas.MVP.Modelos;
using Manigest.Modulos.Ventas.MVP.Modelos.Repositorios;
using Manigest.Modulos.Ventas.MVP.Presentadores;
using Manigest.Modulos.Ventas.MVP.Vistas.Venta;

namespace Manigest.Desktop.MVP.Presentadores.ContenedorModulos {
    public partial class PresentadorContenedorModulos {
        private PresentadorRegistroVenta _registroVentaArticulo;

        public List<string[]> Articulos { get; private set; } = new List<string[]>();

        private void InicializarVistaRegistroVentaArticulo() {
            _registroVentaArticulo = new PresentadorRegistroVenta(new VistaRegistroVenta());
            _registroVentaArticulo.Vista.CargarRazonesSocialesClientes(UtilesCliente.ObtenerRazonesSocialesClientes());
            _registroVentaArticulo.Vista.CargarNombresAlmacenes(UtilesAlmacen.ObtenerNombresAlmacenes(true));
            _registroVentaArticulo.Vista.Coordenadas = new Point(Vista.Dimensiones.Width - _registroVentaArticulo.Vista.Dimensiones.Width - 20, VariablesGlobales.AlturaBarraTituloPredeterminada);
            _registroVentaArticulo.Vista.Dimensiones = new Size(_registroVentaArticulo.Vista.Dimensiones.Width, Vista.Dimensiones.Height);
            _registroVentaArticulo.Salir += delegate {
                Articulos = _registroVentaArticulo.Vista.Articulos;

                RegistrarArticulos();
                RegistrarPagos();
                RegistrarTransferencia();

                _gestionVentasArticulos.RefrescarListaObjetos();
            };
        }

        private void MostrarVistaRegistroVentaArticulo(object? sender, EventArgs e) {
            InicializarVistaRegistroVentaArticulo();

            _registroVentaArticulo.Vista.EfectuarPago += delegate { 
                MostrarVistaRegistroPago(_registroVentaArticulo.Vista.Total, e);

                _registroVentaArticulo.Vista.PagoConfirmado = Pagos.Count > 0;
            };
            _registroVentaArticulo.Vista.Mostrar();
            _registroVentaArticulo = null;
        }

        private void MostrarVistaEdicionVentaArticulo(object? sender, EventArgs e) {
            InicializarVistaRegistroVentaArticulo();

            _registroVentaArticulo.PopularVistaDesdeObjeto(sender as Venta);
            _registroVentaArticulo.Vista.EfectuarPago += delegate { 
                MostrarVistaEdicionPago(sender, e);

                _registroVentaArticulo.Vista.PagoConfirmado = Pagos.Count > 0;
            };
            _registroVentaArticulo.Vista.Mostrar();
            _registroVentaArticulo = null;
        }

        private void RegistrarArticulos() {
            if (Articulos.Count == 0)
                return;

            var datosArticulo = DatosDetalleVentaArticulo.Instance;
            var datosMovimiento = DatosMovimiento.Instance;
            var ultimoIdVenta = UtilesBD.ObtenerUltimoIdTabla("venta");

            foreach (var articulo in Articulos) {
                var detalleVentaArticulo = new DetalleVentaArticulo(
                        0,
                        ultimoIdVenta,
                        long.Parse(articulo[0]),
                        float.Parse(articulo[2]),
                        int.Parse(articulo[3])
                    );

                datosArticulo.Adicionar(detalleVentaArticulo);

                var stockArticulo = UtilesArticulo.ObtenerStockTotalArticulo(detalleVentaArticulo.IdArticulo);
                
                datosMovimiento.Adicionar(new Movimiento(
                        0,
                        detalleVentaArticulo.IdArticulo,
                        long.Parse(articulo[4]),
                        0,
                        stockArticulo,
                        detalleVentaArticulo.Cantidad,
                        stockArticulo - detalleVentaArticulo.Cantidad,
                        MotivoMovimiento.Venta,
                        DateTime.Now
                    ));

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
