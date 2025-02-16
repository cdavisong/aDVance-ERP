using Manigest.Core.MVP.Vistas.Plantillas;

namespace Manigest.Modulos.Ventas.MVP.Vistas.Venta.Plantillas {
    public interface IVistaTuplaDetalleVentaArticulo : IVistaTupla {
        string NombreArticulo { get; set; }
        string Precio {  get; set; }
        string Cantidad { get; set; }
    }
}
