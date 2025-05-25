using aDVanceERP.Core.MVP.Modelos.Plantillas;

namespace aDVanceERP.Modulos.Inventario.MVP.Modelos;

public class ColorProducto : IObjetoUnico {
    public ColorProducto() {
        Id = 0;
        Nombre = string.Empty;
        CodigoArgb = 0;
    }

    public ColorProducto(long id, string nombre, int codigoArgb) {
        Id = id;
        Nombre = nombre;
        CodigoArgb = codigoArgb;
    }

    public long Id { get; set; }
    public string Nombre { get; set; }
    public int CodigoArgb { get; set; }
}

public enum CriterioBusquedaColorProducto {
    Todos,
    Id,
    Nombre
}

public static class UtilesBusquedaColoresProducto {
    public static object[] CriterioBusquedaColoresProducto = {
        "Todos los colores de productos",
        "Identificador de BD",
        "Nombre del color del producto"
    };
}