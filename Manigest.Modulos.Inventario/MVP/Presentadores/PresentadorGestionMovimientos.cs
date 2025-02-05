using Manigest.Core.MVP.Presentadores;
using Manigest.Modulos.Inventario.MVP.Modelos.Repositorios;
using Manigest.Modulos.Inventario.MVP.Modelos;
using Manigest.Modulos.Inventario.MVP.Vistas.Movimiento.Plantillas;
using Manigest.Modulos.Inventario.MVP.Vistas.Movimiento;

namespace Manigest.Modulos.Inventario.MVP.Presentadores {
    public class PresentadorGestionMovimientos : PresentadorGestionBase<PresentadorTuplaMovimiento, IVistaGestionMovimientos, IVistaTuplaMovimiento, Movimiento, DatosMovimiento, CriterioBusquedaMovimiento> {
        public PresentadorGestionMovimientos(IVistaGestionMovimientos vista) : base(vista) {
        }

        public override CriterioBusquedaMovimiento CriterioBusquedaObjeto => CriterioBusquedaMovimiento.Articulo;

        protected override PresentadorTuplaMovimiento ObtenerValoresTupla(Movimiento objeto) {
            var datosArticulo = new DatosArticulo();
            var datosAlmacen = new DatosAlmacen();
            var presentadorTupla = new PresentadorTuplaMovimiento(new VistaTuplaMovimiento(), objeto);

            presentadorTupla.Vista.Id = objeto.Id.ToString();
            presentadorTupla.Vista.NombreArticulo = datosArticulo.Obtener(CriterioBusquedaArticulo.Id, objeto.IdArticulo.ToString()).FirstOrDefault()?.Nombre ?? string.Empty;
            presentadorTupla.Vista.NombreAlmacenOrigen = datosAlmacen.Obtener(CriterioBusquedaAlmacen.Id, objeto.IdAlmacenOrigen.ToString()).FirstOrDefault()?.Nombre ?? string.Empty;
            presentadorTupla.Vista.ActualizarIconoStock(objeto.CantidadFinal > objeto.CantidadInicial);
            presentadorTupla.Vista.NombreAlmacenDestino = datosAlmacen.Obtener(CriterioBusquedaAlmacen.Id, objeto.IdAlmacenDestino.ToString()).FirstOrDefault()?.Nombre ?? string.Empty;
            presentadorTupla.Vista.CantidadMovida = objeto.CantidadMovida.ToString();
            presentadorTupla.Vista.Motivo = objeto.Motivo.ToString();
            presentadorTupla.Vista.Fecha = objeto.Fecha.ToString("yyyy-MM-dd");

            return presentadorTupla;
        }
    }

}
