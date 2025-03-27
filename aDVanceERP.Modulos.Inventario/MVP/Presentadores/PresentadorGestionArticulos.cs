using aDVanceERP.Core.MVP.Presentadores;
using aDVanceERP.Core.Utiles.Datos;
using aDVanceERP.Modulos.Inventario.MVP.Modelos;
using aDVanceERP.Modulos.Inventario.MVP.Modelos.Repositorios;
using aDVanceERP.Modulos.Inventario.MVP.Vistas.Articulo;
using aDVanceERP.Modulos.Inventario.MVP.Vistas.Articulo.Plantillas;

namespace aDVanceERP.Modulos.Inventario.MVP.Presentadores {
    public class PresentadorGestionArticulos : PresentadorGestionBase<PresentadorTuplaArticulo, IVistaGestionArticulos, IVistaTuplaArticulo, Articulo, DatosArticulo, CriterioBusquedaArticulo> {
        public PresentadorGestionArticulos(IVistaGestionArticulos vista) : base(vista) {
        }

        public event EventHandler? MovimientoPositivoStock;
        public event EventHandler? MovimientoNegativoStock;

        protected override PresentadorTuplaArticulo ObtenerValoresTupla(Articulo objeto) {
            var presentadorTupla = new PresentadorTuplaArticulo(new VistaTuplaArticulo(), objeto);

            presentadorTupla.Vista.Id = objeto.Id.ToString();
            presentadorTupla.Vista.NombreAlmacen = string.IsNullOrEmpty(objeto.NombreAlmacen) ? "-" : objeto.NombreAlmacen;
            presentadorTupla.Vista.Codigo = objeto.Codigo ?? string.Empty;
            presentadorTupla.Vista.Nombre = objeto.Nombre ?? string.Empty;
            presentadorTupla.Vista.Descripcion = objeto.Descripcion ?? string.Empty;
            presentadorTupla.Vista.PrecioAdquisicion = objeto.PrecioCompraBase;
            presentadorTupla.Vista.PrecioCesion = objeto.PrecioVentaBase;
            presentadorTupla.Vista.Stock = string.IsNullOrEmpty(objeto.Stock) ? UtilesArticulo.ObtenerStockTotalArticulo(objeto.Id).Result : int.Parse(objeto.Stock);
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
}
