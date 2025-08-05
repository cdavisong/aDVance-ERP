using aDVanceERP.Core.Interfaces.Comun;
using aDVanceERP.Core.MVP.Vistas.Plantillas;
using aDVanceERP.Modulos.CompraVenta.MVP.Modelos;

namespace aDVanceERP.Modulos.CompraVenta.MVP.Vistas.Venta.Plantillas;

public interface IVistaGestionVentas : IVistaContenedor, IGestorDatos, IBuscadorDatos<CriterioBusquedaVenta>,
    IGestorTablaDatos {
    string FormatoReporte { get; }
    bool HabilitarBtnConfirmarEntrega { get; set; }
    bool HabilitarBtnConfirmarPagos { get; set; }
    string ValorBrutoVenta { get; set; }

    event EventHandler? DescargarReporte;
    event EventHandler? ImprimirReporte;
    event EventHandler<string>? ImportarVentasArchivo;
    event EventHandler? ConfirmarEntrega;
    event EventHandler? ConfirmarPagos;

    void ActualizarValorBrutoVentas();
}