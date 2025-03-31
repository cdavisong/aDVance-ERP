using aDVanceERP.Core.MVP.Modelos.Plantillas;
using aDVanceERP.Core.MVP.Vistas.Plantillas;
using aDVanceERP.Modulos.CompraVenta.MVP.Modelos;

namespace aDVanceERP.Modulos.CompraVenta.MVP.Vistas.Venta.Plantillas {
    public interface IVistaGestionVentas : IVistaContenedor, IGestorDatos, IBuscadorDatos<CriterioBusquedaVenta>, IGestorTablaDatos {
        string FormatoReporte { get; }
        string ValorBrutoVenta { get; set; }

        event EventHandler? DescargarReporte;
        event EventHandler? ImprimirReporte;

        void ActualizarValorBrutoVentas();
    }
}
