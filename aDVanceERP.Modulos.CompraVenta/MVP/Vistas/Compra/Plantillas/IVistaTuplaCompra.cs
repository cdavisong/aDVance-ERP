using aDVanceERP.Core.MVP.Vistas.Plantillas;

namespace aDVanceERP.Modulos.CompraVenta.MVP.Vistas.Compra.Plantillas {
    public interface IVistaTuplaCompra : IVistaTupla {
        string Id { get; set; }
        string Fecha { get; set; }
        string NombreAlmacen { get; set; }
        string NombreProveedor { get; set; }
        string NombreArticulo { get; set; }
        string CantidadProducto { get; set; }
        string MontoTotal { get; set; }
    }
}
