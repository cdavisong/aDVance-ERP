using aDVanceERP.Core.Modelos.Modulos.Inventario;
using aDVanceERP.Core.MVP.Presentadores;
using aDVanceERP.Core.Repositorios.Modulos.Inventario;
using aDVanceERP.Modulos.Inventario.MVP.Vistas.Producto;
using aDVanceERP.Modulos.Inventario.MVP.Vistas.Producto.Plantillas;

namespace aDVanceERP.Modulos.Inventario.MVP.Presentadores;

public class PresentadorGestionProductos : PresentadorGestionBase<PresentadorTuplaProducto, IVistaGestionProductos,
    IVistaTuplaProducto, Producto, RepoProducto, FiltroBusquedaProducto> {
    public PresentadorGestionProductos(IVistaGestionProductos vista) : base(vista) { }

    public event EventHandler? MovimientoPositivoStock;
    public event EventHandler? MovimientoNegativoStock;

    protected override PresentadorTuplaProducto ObtenerValoresTupla(Producto entidad) {
        var presentadorTupla = new PresentadorTuplaProducto(new VistaTuplaProducto(), entidad);
        var detalleProducto = RepoDetalleProducto.Instancia.ObtenerPorId(entidad.IdDetalleProducto);
        var unidadMedidaProducto = RepoUnidadMedida.Instancia.ObtenerPorId(detalleProducto?.IdUnidadMedida ?? 0);
        var inventarioProducto = RepoInventario.Instancia.Buscar(FiltroBusquedaInventario.IdProducto, entidad.Id.ToString());

        presentadorTupla.Vista.Id = entidad.Id.ToString();
        presentadorTupla.Vista.Codigo = entidad.Codigo ?? string.Empty;
        presentadorTupla.Vista.FechaUltimoMovimiento = inventarioProducto.resultados.Min(inv => inv.UltimaActualizacion);
        presentadorTupla.Vista.NombreAlmacen = string.IsNullOrEmpty(Vista.NombreAlmacen) || Vista.NombreAlmacen.Contains("Todos")
            ? "-"
            : Vista.NombreAlmacen;
        presentadorTupla.Vista.Nombre = entidad.Nombre ?? string.Empty;
        presentadorTupla.Vista.Descripcion = detalleProducto?.Descripcion ?? "No hay descripción disponible";
        presentadorTupla.Vista.CostoUnitario = entidad.Categoria == CategoriaProducto.ProductoTerminado ? entidad.CostoProduccionUnitario : entidad.PrecioCompra;
        presentadorTupla.Vista.PrecioVentaBase = entidad.PrecioVentaBase;
        presentadorTupla.Vista.UnidadMedida = unidadMedidaProducto?.Abreviatura ?? "u";
        presentadorTupla.Vista.Stock = string.IsNullOrEmpty(Vista.NombreAlmacen) || Vista.NombreAlmacen.Contains("Todos")
            ? inventarioProducto.resultados.Sum(inv => inv.Cantidad)
            : inventarioProducto.resultados.Find(inv => RepoAlmacen.Instancia.ObtenerPorId(inv.IdAlmacen)?.Nombre.Equals(Vista.NombreAlmacen) ?? false)?.Cantidad ?? 0;
        presentadorTupla.Vista.MovimientoPositivoStock += delegate (object? sender, EventArgs args) {
            var nombreAlmacen = sender as string;
            var objetoPos = new object[] { "+", nombreAlmacen ?? string.Empty, entidad };

            MovimientoPositivoStock?.Invoke(objetoPos, EventArgs.Empty);
        };
        presentadorTupla.Vista.MovimientoNegativoStock += delegate (object? sender, EventArgs args) {
            var nombreAlmacen = sender as string;
            var objetoNeg = new object[] { "-", nombreAlmacen ?? string.Empty, entidad };

            MovimientoNegativoStock?.Invoke(objetoNeg, EventArgs.Empty);
        };

        return presentadorTupla;
    }
}