using aDVanceERP.Core.MVP.Modelos.Plantillas;
using aDVanceERP.Core.MVP.Vistas.Plantillas;
using aDVanceERP.Modulos.Ventas.MVP.Modelos;

namespace aDVanceERP.Modulos.Ventas.MVP.Vistas.Venta.Plantillas {
    public interface IVistaGestionVentas : IVistaContenedor, IGestorDatos, IBuscadorDatos<CriterioBusquedaVenta>, IGestorTablaDatos {
        string FormatoReporte { get; }
        string ValorBrutoVenta { get; }

        event EventHandler? DescargarReporte;
        event EventHandler? ImprimirReporte;
    }
}
