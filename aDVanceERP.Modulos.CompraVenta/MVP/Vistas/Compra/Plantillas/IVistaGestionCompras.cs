using aDVanceERP.Core.Modelos.Comun.Interfaces;
using aDVanceERP.Core.MVP.Vistas.Plantillas;
using aDVanceERP.Modulos.CompraVenta.MVP.Modelos;

namespace aDVanceERP.Modulos.CompraVenta.MVP.Vistas.Compra.Plantillas;

public interface IVistaGestionCompras : IVistaContenedor, IGestorDatos, IBuscadorEntidades<FiltroBusquedaCompra>,
    IGestorTablaDatos {
    string FormatoReporte { get; }
    string ValorBrutoCompra { get; }

    event EventHandler? DescargarReporte;
    event EventHandler? ImprimirReporte;

    void ActualizarValorBrutoCompras();
}