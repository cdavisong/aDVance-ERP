using aDVanceERP.Core.MVP.Vistas.Plantillas;

namespace aDVanceERP.Modulos.Inventario.MVP.Vistas.Producto.Plantillas; 

public interface IVistaTuplaProducto : IVistaTupla {
    string Id { get; set; }
    string NombreAlmacen { get; set; }
    string Codigo { get; set; }
    string Nombre { get; set; }
    string Descripcion { get; set; }
    decimal PrecioCompraBase { get; set; }
    decimal PrecioVentaBase { get; set; }
    float Stock { get; set; }

    event EventHandler? MovimientoPositivoStock;
    event EventHandler? MovimientoNegativoStock;
}