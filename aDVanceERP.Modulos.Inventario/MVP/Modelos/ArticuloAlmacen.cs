using aDVanceERP.Core.MVP.Modelos.Plantillas;

namespace aDVanceERP.Modulos.Inventario.MVP.Modelos; 

public class ArticuloAlmacen : IObjetoUnico {
    public ArticuloAlmacen() { }

    public ArticuloAlmacen(long idArticuloAlmacen, long idArticulo, long idAlmacen, int stock) {
        Id = idArticuloAlmacen;
        IdArticulo = idArticulo;
        IdAlmacen = idAlmacen;
        Stock = stock;
    }

    public long IdArticulo { get; set; }
    public long IdAlmacen { get; set; }
    public int Stock { get; set; }

    public long Id { get; set; }
}

public enum CriterioBusquedaArticuloAlmacen {
    Todos,
    Id,
    IdArticulo,
    IdAlmacen
}