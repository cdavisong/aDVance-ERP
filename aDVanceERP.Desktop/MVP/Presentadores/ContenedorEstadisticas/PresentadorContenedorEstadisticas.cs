using aDVanceERP.Core.MVP.Presentadores;
using aDVanceERP.Core.Utiles.Datos;
using aDVanceERP.Desktop.MVP.Vistas.ContenedorEstadisticas.Plantillas;

namespace aDVanceERP.Desktop.MVP.Presentadores.ContenedorEstadisticas; 

public class PresentadorContenedorEstadisticas : PresentadorBase<IVistaContenedorEstadisticas> {
    public PresentadorContenedorEstadisticas(IVistaContenedorEstadisticas vista) : base(vista) {
        vista.FechaEstadsticasModificada += delegate(object? sender, EventArgs args) {
            if (sender is DateTime fecha)
                Vista.DatosEstadisticosVentas = UtilesVenta.ObtenerDatosEstadisticosVentas(fecha);
        };
    }

    internal async void RefrescarEstadísticas() {
        Vista.CantidadArticulosRegistrados = await UtilesArticulo.ObtenerStockTotalArticulos();
        Vista.MontoInversionArticulos = await UtilesArticulo.ObtenerMontoInvertidoEnArticulos();
        Vista.CantidadArticulosVendidos = UtilesVenta.ObtenerTotalArticulosVendidosHoy();
        Vista.MontoVentaArticulosVendidos = UtilesVenta.ObtenerValorBrutoVentaDia(DateTime.Now);
        Vista.MontoGananciaTotalNegocio = UtilesVenta.ObtenerValorGananciaTotalNegocio();
    }
}