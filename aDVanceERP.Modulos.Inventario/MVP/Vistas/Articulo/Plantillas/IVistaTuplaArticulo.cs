using aDVanceERP.Core.MVP.Vistas.Plantillas;

namespace aDVanceERP.Modulos.Inventario.MVP.Vistas.Articulo.Plantillas {
    public interface IVistaTuplaArticulo : IVistaTupla {
        string Id { get; set; }
        string NombreAlmacen { get; set; }
        string Codigo { get; set; }
        string Nombre { get; set; }
        string Descripcion { get; set; }
        decimal PrecioAdquisicion { get; set; }
        decimal PrecioCesion { get; set; }
        int Stock { get; set; }

        event EventHandler? MovimientoPositivoStock;
        event EventHandler? MovimientoNegativoStock;
    }
}
