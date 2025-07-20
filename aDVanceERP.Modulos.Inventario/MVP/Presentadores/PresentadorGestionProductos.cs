using aDVanceERP.Core.MVP.Presentadores;
using aDVanceERP.Core.Utiles.Datos;
using aDVanceERP.Modulos.Inventario.MVP.Modelos;
using aDVanceERP.Modulos.Inventario.MVP.Modelos.Repositorios;
using aDVanceERP.Modulos.Inventario.MVP.Vistas.Producto;
using aDVanceERP.Modulos.Inventario.MVP.Vistas.Producto.Plantillas;

namespace aDVanceERP.Modulos.Inventario.MVP.Presentadores; 

public class PresentadorGestionProductos : PresentadorGestionBase<PresentadorTuplaProducto, IVistaGestionProductos,
    IVistaTuplaProducto, Producto, DatosProducto, CriterioBusquedaProducto> {
    public PresentadorGestionProductos(IVistaGestionProductos vista) : base(vista) { }

    public event EventHandler? MovimientoPositivoStock;
    public event EventHandler? MovimientoNegativoStock;

    protected override PresentadorTuplaProducto ObtenerValoresTupla(Producto objeto) {
        var presentadorTupla = new PresentadorTuplaProducto(new VistaTuplaProducto(), objeto);

        presentadorTupla.Vista.Id = objeto.Id.ToString();
        presentadorTupla.Vista.NombreAlmacen = string.IsNullOrEmpty(Vista.NombreAlmacen) || Vista.NombreAlmacen.Contains("Todos")
            ? "-"
            : Vista.NombreAlmacen;
        presentadorTupla.Vista.Codigo = objeto.Codigo ?? string.Empty;
        presentadorTupla.Vista.Nombre = objeto.Nombre ?? string.Empty;
        presentadorTupla.Vista.Descripcion = UtilesDetalleProducto.ObtenerDescripcionProducto(objeto.Id).Result ?? "No hay descripción disponible";
        presentadorTupla.Vista.CostoUnitario = objeto.Categoria == CategoriaProducto.ProductoTerminado ? objeto.CostoProduccionUnitario : objeto.PrecioCompra;
        presentadorTupla.Vista.PrecioVentaBase = objeto.PrecioVentaBase;
        presentadorTupla.Vista.UnidadMedida = UtilesDetalleProducto.ObtenerUnidadMedidaProducto(objeto.Id, true).Result ?? "u";
        presentadorTupla.Vista.Stock = string.IsNullOrEmpty(Vista.NombreAlmacen) || Vista.NombreAlmacen.Contains("Todos")
            ? UtilesProducto.ObtenerStockTotalProducto(objeto.Id).Result
            : UtilesProducto.ObtenerStockProducto(objeto.Nombre, Vista.NombreAlmacen).Result;
        presentadorTupla.Vista.MovimientoPositivoStock += delegate (object? sender, EventArgs args) {
            var nombreAlmacen = sender as string;
            var objetoPos = new object[] { "+", nombreAlmacen ?? string.Empty, objeto };
            MovimientoPositivoStock?.Invoke(objetoPos, EventArgs.Empty);
        };
        presentadorTupla.Vista.MovimientoNegativoStock += delegate (object? sender, EventArgs args) {
            var nombreAlmacen = sender as string;
            var objetoNeg = new object[] { "-", nombreAlmacen ?? string.Empty, objeto };
            MovimientoNegativoStock?.Invoke(objetoNeg, EventArgs.Empty);
        };

        return presentadorTupla;
    }
}