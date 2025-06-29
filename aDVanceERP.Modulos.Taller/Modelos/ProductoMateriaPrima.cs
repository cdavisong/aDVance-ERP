using aDVanceERP.Core.MVP.Modelos.Plantillas;

namespace aDVanceERP.Modulos.Taller.Modelos;

public class ProductoMateriaPrima : IObjetoUnico {
    public ProductoMateriaPrima() { }

    public ProductoMateriaPrima(long id, long idProducto, long idMateriaPrima, float cantidad) {
        Id = id;
        IdProducto = idProducto;
        IdMateriaPrima = idMateriaPrima;
        Cantidad = cantidad;
    }

    public long Id { get; set; }
    public long IdProducto { get; set; }
    public long IdMateriaPrima { get; set; }
    public float Cantidad { get; set; }
}

public enum CriterioBusquedaProductoMateriaPrima {
    Todos,
    Id,
    IdProducto,
    IdMateriaPrima
}

public static class UtilesBusquedaProductoMateriaPrima {
    public static object[] CriterioBusquedaProductoMateriaPrima = {
        "Todos los productos de materia prima",
        "Identificador de BD",
        "Identificador del producto",
        "Identificador de la materia prima"
    };
}