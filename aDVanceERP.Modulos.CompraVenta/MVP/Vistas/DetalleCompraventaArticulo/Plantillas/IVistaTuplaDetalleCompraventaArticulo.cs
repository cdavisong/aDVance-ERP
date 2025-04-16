using aDVanceERP.Core.MVP.Vistas.Plantillas;

namespace aDVanceERP.Modulos.CompraVenta.MVP.Vistas.DetalleCompraventaArticulo.Plantillas; 

public interface IVistaTuplaDetalleCompraventaArticulo : IVistaTupla {
    string IdArticulo { get; set; }
    string NombreArticulo { get; set; }
    string PrecioCompraventaFinal { get; set; }
    string Cantidad { get; set; }

    event EventHandler? PrecioCompraventaModificado;
}