using Manigest.Core.MVP.Presentadores;
using Manigest.Modulos.Inventario.MVP.Modelos.Repositorios;
using Manigest.Modulos.Inventario.MVP.Modelos;
using Manigest.Modulos.Inventario.MVP.Vistas.Movimiento.Plantillas;
using Manigest.Modulos.Inventario.MVP.Vistas.Movimiento;
using Manigest.Core.Utiles.Datos;

namespace Manigest.Modulos.Inventario.MVP.Presentadores {
    public class PresentadorGestionMovimientos : PresentadorGestionBase<PresentadorTuplaMovimiento, IVistaGestionMovimientos, IVistaTuplaMovimiento, Movimiento, DatosMovimiento, CriterioBusquedaMovimiento> {
        public PresentadorGestionMovimientos(IVistaGestionMovimientos vista) : base(vista) {            
        }

        protected override PresentadorTuplaMovimiento ObtenerValoresTupla(Movimiento objeto) {
            var presentadorTupla = new PresentadorTuplaMovimiento(new VistaTuplaMovimiento(), objeto);

            presentadorTupla.Vista.Id = objeto.Id.ToString();
            presentadorTupla.Vista.NombreArticulo = UtilesArticulo.ObtenerNombreArticulo(objeto.IdArticulo) ?? string.Empty;
            presentadorTupla.Vista.NombreAlmacenOrigen = UtilesAlmacen.ObtenerNombreAlmacen(objeto.IdAlmacenOrigen) ?? string.Empty;
            presentadorTupla.Vista.ActualizarIconoStock(objeto.CantidadFinal > objeto.CantidadInicial);
            presentadorTupla.Vista.NombreAlmacenDestino = UtilesAlmacen.ObtenerNombreAlmacen(objeto.IdAlmacenDestino) ?? string.Empty;
            presentadorTupla.Vista.CantidadMovida = objeto.CantidadMovida.ToString();
            presentadorTupla.Vista.Motivo = objeto.Motivo.ToString();
            presentadorTupla.Vista.Fecha = objeto.Fecha.ToString("yyyy-MM-dd");

            return presentadorTupla;
        }
    }

}
