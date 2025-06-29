using aDVanceERP.Core.MVP.Modelos.Plantillas;

namespace aDVanceERP.Modulos.Taller.Modelos;

public class ProductoManoObra : IObjetoUnico {
    public ProductoManoObra() { }

    public ProductoManoObra(long id, long idProducto, long idActividadProduccion) {
        Id = id;
        IdProducto = idProducto;
        IdActividadProduccion = idActividadProduccion;
    }

    public long Id { get; set; }
    public long IdProducto { get; set; }
    public long IdActividadProduccion { get; set; }
}

public enum CriterioBusquedaProductoManoObra {
    Todos,
    Id,
    IdProducto,
    IdActividadProduccion
}

public static class UtilesBusquedaProductoManoObra {
    public static object[] CriterioBusquedaProductoManoObra = {
        "Todos los productos de mano de obra",
        "Identificador de BD",
        "Identificador del producto",
        "Identificador de la actividad de producción"
    };
}