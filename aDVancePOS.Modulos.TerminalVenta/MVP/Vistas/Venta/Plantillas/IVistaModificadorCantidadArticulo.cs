using aDVanceERP.Core.MVP.Vistas.Plantillas;

namespace aDVancePOS.Modulos.TerminalVenta.MVP.Vistas.Venta.Plantillas; 

public interface IVistaModificadorCantidadArticulo : IVista {
    int CantidadArticulo { get; set; }
}