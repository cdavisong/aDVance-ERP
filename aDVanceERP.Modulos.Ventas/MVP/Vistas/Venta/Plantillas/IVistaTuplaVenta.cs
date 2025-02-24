using aDVanceERP.Core.MVP.Vistas.Plantillas;

namespace aDVanceERP.Modulos.Ventas.MVP.Vistas.Venta.Plantillas {
    public interface IVistaTuplaVenta : IVistaTupla {
        string Id { get; set; }
        string Fecha { get; set; }
        string NombreAlmacen { get; set; }
        string NombreCliente { get; set; }
        string CantidadProductos { get; set; }
        string MontoTotal { get; set; }
    }
}
