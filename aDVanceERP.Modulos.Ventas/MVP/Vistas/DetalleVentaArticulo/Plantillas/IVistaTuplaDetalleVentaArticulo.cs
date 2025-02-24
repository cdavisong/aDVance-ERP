using aDVanceERP.Core.MVP.Vistas.Plantillas;

namespace aDVanceERP.Modulos.Ventas.MVP.Vistas.DetalleVentaArticulo.Plantillas {
    public interface IVistaTuplaDetalleVentaArticulo : IVistaTupla {
        string IdArticulo { get; set; }
        string NombreArticulo { get; set; }
        string Precio { get; set; }
        string Cantidad { get; set; }
    }
}
