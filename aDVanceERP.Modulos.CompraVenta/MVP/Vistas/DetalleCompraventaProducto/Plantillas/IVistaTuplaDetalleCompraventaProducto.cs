using aDVanceERP.Core.MVP.Vistas.Plantillas;

namespace aDVanceERP.Modulos.CompraVenta.MVP.Vistas.DetalleCompraventaProducto.Plantillas; 

public interface IVistaTuplaDetalleCompraventaProducto : IVistaTupla {
    string IdProducto { get; set; }
    string NombreProducto { get; set; }
    string PrecioCompraventaFinal { get; set; }
    string Cantidad { get; set; }

    event EventHandler? PrecioCompraventaModificado;
}