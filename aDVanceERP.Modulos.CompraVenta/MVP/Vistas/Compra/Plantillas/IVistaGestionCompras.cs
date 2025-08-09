using aDVanceERP.Core.Interfaces;
using aDVanceERP.Core.MVP.Vistas.Plantillas;
using aDVanceERP.Modulos.CompraVenta.MVP.Modelos;

namespace aDVanceERP.Modulos.CompraVenta.MVP.Vistas.Compra.Plantillas;

public interface IVistaGestionCompras : IVistaContenedor, IGestorDatos, IBarraBusquedaEntidadesBd<CriterioBusquedaCompra>,
    ITablaResultadosBusqueda {
    string FormatoReporte { get; }
    string ValorBrutoCompra { get; }

    event EventHandler? DescargarReporte;
    event EventHandler? ImprimirReporte;

    void ActualizarValorBrutoCompras();
}