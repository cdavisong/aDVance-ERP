using aDVanceERP.Core.Utiles.Datos;
using aDVanceERP.Modulos.Inventario.MVP.Modelos;
using aDVanceERP.Modulos.Inventario.Repositorios;
using aDVanceERP.Modulos.Taller.Modelos;
using aDVanceERP.Modulos.Taller.Presentadores.OrdenProduccion;
using aDVanceERP.Modulos.Taller.Repositorios;
using aDVanceERP.Modulos.Taller.Vistas.OrdenProduccion;

namespace aDVanceERP.Desktop.MVP.Presentadores.ContenedorModulos {
    public partial class PresentadorContenedorModulos {
        private PresentadorGestionOrdenesProduccion? _gestionOrdenesProduccion;

        private void InicializarVistaGestionOrdenesProduccion() {
            _gestionOrdenesProduccion = new PresentadorGestionOrdenesProduccion(new VistaGestionOrdenesProduccion());
            _gestionOrdenesProduccion.OrdenProduccionCerrada += RegistrarNuevoProducto;
            _gestionOrdenesProduccion.OrdenProduccionCerrada += RegistrarMovimientosOrdenProduccionCerrada;
            _gestionOrdenesProduccion.EditarObjeto += MostrarVistaEdicionOrdenProduccion;
            _gestionOrdenesProduccion.Vista.RegistrarDatos += MostrarVistaRegistroOrdenProduccion;

            if (Vista.Vistas != null)
                Vista.Vistas?.Registrar("vistaGestionOrdenesProduccion", _gestionOrdenesProduccion.Vista);
        }

        private void MostrarVistaGestionOrdenesProduccion(object? sender, EventArgs e) {
            if (_gestionOrdenesProduccion?.Vista == null)
                return;

            _gestionOrdenesProduccion.Vista.CargarCriteriosBusqueda(UtilesBusquedaOrdenProduccion.FiltroBusquedaOrdenProduccion);
            _gestionOrdenesProduccion.Vista.Restaurar();
            _gestionOrdenesProduccion.Vista.Mostrar();

            _gestionOrdenesProduccion.ActualizarResultadosBusqueda();
        }

        private void RegistrarNuevoProducto(object? sender, OrdenProduccion e) {
            using (var repoProducto = new RepoProducto()) {
                var productoExistente = repoProducto.Buscar(FiltroBusquedaProducto.Nombre, e.NombreProducto);

                if (productoExistente.cantidad > 0)
                    return;

                var idDetalleProducto = 0L;

                using (var repoDetalleProducto = new RepoDetalleProducto()) {
                    var detalleProducto = new DetalleProducto() {
                        Id = 0,
                        IdUnidadMedida = UtilesUnidadMedida.ObtenerIdUnidadMedida("Unidad").Result,
                        Descripcion = "No hay descripción disponible"
                    };

                    idDetalleProducto = repoDetalleProducto.Adicionar(detalleProducto);
                }

                var producto = new Producto() {
                    Id = 0,
                    Categoria = CategoriaProducto.ProductoTerminado,
                    Nombre = e.NombreProducto,
                    Codigo = UtilesCodigoBarras.GenerarEan13(e.NombreProducto),
                    IdDetalleProducto = idDetalleProducto,
                    IdProveedor = 0,
                    PrecioCompra = 0,
                    CostoProduccionUnitario = e.PrecioUnitario,
                    PrecioVentaBase = e.PrecioUnitario
                };

                repoProducto.Adicionar(producto);
            }
        }

        private void RegistrarMovimientosOrdenProduccionCerrada(object? sender, OrdenProduccion e) {
            var idProducto = UtilesProducto.ObtenerIdProducto(e.NombreProducto).Result;

            // Actualizar el costo unitario de producción en el producto correspondiente
            UtilesProducto.ActualizarCostoProduccionUnitario(idProducto, e.PrecioUnitario);

            // Movimiento de materiales utilizados en la orden de producción
            using (var datosObjeto = new RepoOrdenMateriaPrima()) {
                var materiasPrimas = datosObjeto.Buscar(FiltroBusquedaOrdenMateriaPrima.OrdenProduccion, e.Id.ToString()).resultados;

                if (materiasPrimas != null && materiasPrimas.Count() > 0) {
                    using (var datosMovimiento = new RepoMovimiento()) {
                        foreach (var materiaPrima in materiasPrimas) {
                            datosMovimiento.Adicionar(new Movimiento(
                                0,
                                materiaPrima.IdProducto,
                                materiaPrima.IdAlmacen,
                                0,
                                materiaPrima.FechaRegistro,
                                materiaPrima.Cantidad,
                                UtilesMovimiento.ObtenerIdTipoMovimiento("Gasto material")
                            ));

                            // Disminuir el cantidad de materiales utilizados en la orden de producción
                            UtilesMovimiento.ModificarInventario(
                                materiaPrima.IdProducto,
                                materiaPrima.IdAlmacen,
                                0,
                                materiaPrima.Cantidad,
                                UtilesProducto.ObtenerCostoUnitario(materiaPrima.IdProducto).Result
                            );
                        }
                    }
                }
            }

            // Movimiento generado por la orden de producción
            using (var repoMovimiento = new RepoMovimiento()) {
                repoMovimiento.Adicionar(new Movimiento(
                    0,
                    idProducto,
                    0,
                    e.IdAlmacen,
                    e.FechaCierre ?? DateTime.Now,
                    e.Cantidad,
                    UtilesMovimiento.ObtenerIdTipoMovimiento("Producción")
                ));
            }

            // Aumentar el cantidad del producto terminado en el almacén seleccionado
            UtilesMovimiento.ModificarInventario(
                idProducto,
                0,
                e.IdAlmacen,
                e.Cantidad,
                UtilesProducto.ObtenerCostoUnitario(idProducto).Result
            );
        }
    }
}