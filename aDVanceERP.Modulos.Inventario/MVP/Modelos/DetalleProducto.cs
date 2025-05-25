using aDVanceERP.Core.MVP.Modelos.Plantillas;

namespace aDVanceERP.Modulos.Inventario.MVP.Modelos;

public class DetalleProducto : IObjetoUnico {
    public DetalleProducto() {
        IdUnidadMedida = 0;
        IdColorProductoPrimario = 0;
        IdColorProductoSecundario = 0;
        IdTipoProducto = 0;
        IdDisenoProducto = 0;
        Descripcion = "No hay descripción disponible";
    }

    public DetalleProducto(long id, long idUnidadMedida, long idColorProductoPrimario, long idColorProductoSecundario, long idTipoProducto, long idDiseñoProducto, string descripcion) {
        Id = id;
        IdUnidadMedida = idUnidadMedida;
        IdColorProductoPrimario = idColorProductoPrimario;
        IdColorProductoSecundario = idColorProductoSecundario;
        IdTipoProducto = idTipoProducto;
        IdDisenoProducto = idDiseñoProducto;
        Descripcion = descripcion ?? "No hay descripción disponible";
    }

    public long Id { get; set; }
    public long IdUnidadMedida { get; set; }
    public long IdColorProductoPrimario { get; set; }
    public long IdColorProductoSecundario { get; set; }
    public long IdTipoProducto { get; set; }
    public long IdDisenoProducto { get; set; }
    public string? Descripcion { get; set; }
}

public enum CriterioBusquedaDetalleProducto {
    Todos,
    Id,
    UnidadMedida,
    ColorPrimario,
    ColorSecundario,
    TipoProducto,
    DisenoProducto
}

public static class UtilesBusquedaDetallesProducto {
    public static object[] CriterioBusquedaDetallesProducto = {
        "Todos los detalles de productos",
        "Identificador de BD",
        "Unidad de medida del producto",
        "Color primario del producto",
        "Color secundario del producto",
        "Tipo de producto",
        "Diseño del producto"
    };
}
