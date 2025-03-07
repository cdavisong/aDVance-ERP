using aDVanceERP.Core.MVP.Presentadores;
using aDVanceERP.Core.Utiles.Datos;
using aDVanceERP.Desktop.MVP.Vistas.ContenedorEstadisticas.Plantillas;

namespace aDVanceERP.Desktop.MVP.Presentadores.ContenedorEstadisticas {
    public class PresentadorContenedorEstadisticas : PresentadorBase<IVistaContenedorEstadisticas> {
        public PresentadorContenedorEstadisticas(IVistaContenedorEstadisticas vista) : base(vista) {            
        }

        internal void RefrescarEstadísticas() {
            Vista.CantidadArticulosRegistrados = UtilesArticulo.ObtenerStockTotalArticulos();
            Vista.MontoInversionArticulos = UtilesArticulo.ObtenerMontoInvertidoEnArticulos();
            Vista.CantidadArticulosVendidos = UtilesVenta.ObtenerTotalArticulosVendidosHoy();
            Vista.MontoVentaArticulosVendidos = UtilesVenta.ObtenerValorBrutoVentaDia(DateTime.Now);
            Vista.MontoGananciaTotalNegocio = UtilesVenta.ObtenerValorGananciaTotalNegocio();
        }
    }
}
