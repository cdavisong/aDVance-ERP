using aDVanceERP.Core.MVP.Vistas.Plantillas;

namespace aDVancePOS.Modulos.TerminalVenta.MVP.Vistas.Venta.Plantillas;

public interface IVistaTuplaVentaArticulo : IVistaTupla {
    string IdArticulo { get; set; }
    string NombreArticulo { get; set; }
    string PrecioVentaFinal { get; set; }
    string Cantidad { get; set; }
    string Subtotal { get; set; }

    event EventHandler? PrecioVentaModificado;
}

