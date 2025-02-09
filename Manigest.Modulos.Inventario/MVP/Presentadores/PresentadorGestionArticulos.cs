using Manigest.Core.MVP.Presentadores;
using Manigest.Modulos.Inventario.MVP.Modelos.Repositorios;
using Manigest.Modulos.Inventario.MVP.Modelos;
using Manigest.Modulos.Inventario.MVP.Vistas.Articulo.Plantillas;
using Manigest.Modulos.Inventario.MVP.Vistas.Articulo;
using Manigest.Core.Utiles.Datos;

namespace Manigest.Modulos.Inventario.MVP.Presentadores {
    public class PresentadorGestionArticulos : PresentadorGestionBase<PresentadorTuplaArticulo, IVistaGestionArticulos, IVistaTuplaArticulo, Articulo, DatosArticulo, CriterioBusquedaArticulo> {
        public PresentadorGestionArticulos(IVistaGestionArticulos vista) : base(vista) {
        }

        public override CriterioBusquedaArticulo CriterioBusquedaObjeto { get; protected set; } = CriterioBusquedaArticulo.Nombre;

        public event EventHandler? MovimientoPositivoStock;
        public event EventHandler? MovimientoNegativoStock;

        protected override PresentadorTuplaArticulo ObtenerValoresTupla(Articulo objeto) {
            var presentadorTupla = new PresentadorTuplaArticulo(new VistaTuplaArticulo(), objeto);

            presentadorTupla.Vista.Id = objeto.Id.ToString();
            // TODO: Crear los mecanismos para obtener el nombre de almacen
            presentadorTupla.Vista.NombreAlmacen = "-";
            presentadorTupla.Vista.Codigo = objeto.Codigo;
            presentadorTupla.Vista.Nombre = objeto.Nombre;
            presentadorTupla.Vista.Descripcion = objeto.Descripcion;
            presentadorTupla.Vista.PrecioAdquisicion = objeto.PrecioAdquisicion;
            presentadorTupla.Vista.PrecioCesion = objeto.PrecioCesion;
            presentadorTupla.Vista.Stock = UtilesArticulo.ObtenerStockTotalArticulo(objeto.Id);
            presentadorTupla.Vista.MovimientoPositivoStock += delegate {
                var objetoPos = new object[] { "+", objeto };
                MovimientoPositivoStock?.Invoke(objetoPos, EventArgs.Empty); 
            };
            presentadorTupla.Vista.MovimientoNegativoStock += delegate {
                var objetoNeg = new object[] { "-", objeto };
                MovimientoNegativoStock?.Invoke(objetoNeg, EventArgs.Empty);
            };

            return presentadorTupla;
        }
    }
}
