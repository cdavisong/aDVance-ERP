using aDVanceERP.Core.Modelos.Modulos.Inventario;
using aDVanceERP.Core.MVP.Presentadores;
using aDVanceERP.Core.Utiles.Datos;
using aDVanceERP.Modulos.Inventario.MVP.Vistas.Movimiento;
using aDVanceERP.Modulos.Inventario.MVP.Vistas.Movimiento.Plantillas;
using aDVanceERP.Modulos.Inventario.Repositorios;

using System.Globalization;

namespace aDVanceERP.Modulos.Inventario.MVP.Presentadores;

public class PresentadorGestionMovimientos : PresentadorGestionBase<PresentadorTuplaMovimiento, IVistaGestionMovimientos
    , IVistaTuplaMovimiento, Movimiento, DatosMovimiento, CriterioBusquedaMovimiento> {
    public PresentadorGestionMovimientos(IVistaGestionMovimientos vista) : base(vista) { }

    protected override PresentadorTuplaMovimiento ObtenerValoresTupla(Movimiento objeto) {
        var presentadorTupla = new PresentadorTuplaMovimiento(new VistaTuplaMovimiento(), objeto);

        presentadorTupla.Vista.Id = objeto.Id.ToString();
        presentadorTupla.Vista.NombreProducto = UtilesProducto.ObtenerNombreProducto(objeto.IdProducto).Result ?? string.Empty;
        presentadorTupla.Vista.NombreAlmacenOrigen = UtilesAlmacen.ObtenerNombreAlmacen(objeto.IdAlmacenOrigen) ?? string.Empty;
        presentadorTupla.Vista.ActualizarIconoStock(UtilesMovimiento.ObtenerEfectoTipoMovimiento(objeto.IdTipoMovimiento));
        presentadorTupla.Vista.NombreAlmacenDestino = UtilesAlmacen.ObtenerNombreAlmacen(objeto.IdAlmacenDestino) ?? string.Empty;
        presentadorTupla.Vista.CantidadMovida = objeto.CantidadMovida.ToString("N2", CultureInfo.InvariantCulture);
        presentadorTupla.Vista.TipoMovimiento = UtilesMovimiento.ObtenerNombreTipoMovimiento(objeto.IdTipoMovimiento) ?? string.Empty;
        presentadorTupla.Vista.Fecha = objeto.Fecha.ToString("yyyy-MM-dd");

        return presentadorTupla;
    }
}