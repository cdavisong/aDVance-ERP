using aDVanceERP.Core.MVP.Modelos.Plantillas;

namespace aDVanceERP.Modulos.Inventario.MVP.Modelos {
    public class ArticuloAlmacen : IObjetoUnico {
        public ArticuloAlmacen(long idArticuloAlmacen, long idArticulo, long idAlmacen, int stock) {
            Id = idArticuloAlmacen;
            IdArticulo = idArticulo;
            IdAlmacen = idAlmacen;
            Stock = stock;
        }

        public ArticuloAlmacen(long idArticulo, long idAlmacen, int stock)
            : this(0, idArticulo, idAlmacen, stock) { }

        public long Id { get; set; }
        public long IdArticulo { get; set; }
        public long IdAlmacen { get; set; }
        public int Stock { get; set; }
    }

    public enum CriterioBusquedaArticuloAlmacen {
        Todos,
        Id,
        IdArticulo,
        IdAlmacen
    }
}
