using aDVanceERP.Core.MVP.Presentadores;
using aDVanceERP.Core.Utiles.Datos;
using aDVanceERP.Modulos.Inventario.MVP.Modelos;
using aDVanceERP.Modulos.Inventario.MVP.Modelos.Repositorios;
using aDVanceERP.Modulos.Inventario.MVP.Vistas.Movimiento;
using aDVanceERP.Modulos.Inventario.MVP.Vistas.Movimiento.Plantillas;

namespace aDVanceERP.Modulos.Inventario.MVP.Presentadores {
    public class PresentadorGestionMovimientos : PresentadorGestionBase<PresentadorTuplaMovimiento, IVistaGestionMovimientos, IVistaTuplaMovimiento, Movimiento, DatosMovimiento, CriterioBusquedaMovimiento> {
        public PresentadorGestionMovimientos(IVistaGestionMovimientos vista) : base(vista) {
        }

        protected override PresentadorTuplaMovimiento ObtenerValoresTupla(Movimiento objeto) {
            var presentadorTupla = new PresentadorTuplaMovimiento(new VistaTuplaMovimiento(), objeto);

            presentadorTupla.Vista.Id = objeto.Id.ToString();
            presentadorTupla.Vista.NombreArticulo = UtilesArticulo.ObtenerNombreArticulo(objeto.IdArticulo).Result ?? string.Empty;
            presentadorTupla.Vista.NombreAlmacenOrigen = UtilesAlmacen.ObtenerNombreAlmacen(objeto.IdAlmacenOrigen) ?? string.Empty;
            presentadorTupla.Vista.ActualizarIconoStock(UtilesMovimiento.ObtenerEfectoTipoMovimiento(objeto.IdTipoMovimiento).Equals("Carga"));
            presentadorTupla.Vista.NombreAlmacenDestino = UtilesAlmacen.ObtenerNombreAlmacen(objeto.IdAlmacenDestino) ?? string.Empty;
            presentadorTupla.Vista.CantidadMovida = objeto.CantidadMovida.ToString();
            presentadorTupla.Vista.TipoMovimiento = UtilesMovimiento.ObtenerNombreTipoMovimiento(objeto.IdTipoMovimiento) ?? string.Empty;
            presentadorTupla.Vista.Fecha = objeto.Fecha.ToString("yyyy-MM-dd");

            return presentadorTupla;
        }
    }

}
