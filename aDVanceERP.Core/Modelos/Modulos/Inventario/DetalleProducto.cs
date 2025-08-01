using aDVanceERP.Core.Modelos.Comun;

namespace aDVanceERP.Core.Modelos.Modulos.Inventario;

public class DetalleProducto : IEntidadBd {
    public DetalleProducto() {
        IdUnidadMedida = 0;
        Descripcion = "No hay descripción disponible";
    }

    public DetalleProducto(long id, long idUnidadMedida, string descripcion) {
        Id = id;
        IdUnidadMedida = idUnidadMedida;
        Descripcion = descripcion ?? "No hay descripción disponible";
    }

    public long Id { get; set; }
    public long IdUnidadMedida { get; set; }
    public string? Descripcion { get; set; }
}

public enum CriterioBusquedaDetalleProducto {
    Todos,
    Id,
    UnidadMedida,
    Descripcion
}

public static class UtilesBusquedaDetallesProducto {
    public static object[] CriterioBusquedaDetallesProducto = {
        "Todos los detalles de productos",
        "Identificador de BD",
        "Unidad de medida del producto",
        "Descripción del producto"
    };
}
