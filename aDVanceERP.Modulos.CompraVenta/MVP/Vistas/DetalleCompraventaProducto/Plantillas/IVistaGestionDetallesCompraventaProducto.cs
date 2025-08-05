using aDVanceERP.Core.Interfaces.Comun;
using aDVanceERP.Core.MVP.Vistas.Plantillas;

namespace aDVanceERP.Modulos.CompraVenta.MVP.Vistas.DetalleCompraventaProducto.Plantillas;

public interface IVistaGestionDetallesCompraventaProductos : IVistaContenedor, IGestorDatos {
    void AdicionarProducto(string nombreAlmacen = "", string nombreProducto = "", string cantidad = "");
}