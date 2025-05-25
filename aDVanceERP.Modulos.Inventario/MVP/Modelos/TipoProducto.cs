using aDVanceERP.Core.MVP.Modelos.Plantillas;

namespace aDVanceERP.Modulos.Inventario.MVP.Modelos;

public class TipoProducto : IObjetoUnico {
    public TipoProducto() {
        Id = 0;
        Nombre = string.Empty;
        Descripcion = string.Empty;
    }

    public TipoProducto(long id, string nombre, string descripcion) {
        Id = id;
        Nombre = nombre;
        Descripcion = descripcion;
    }

    public long Id { get; set; }
    public string Nombre { get; set; }
    public string Descripcion { get; set; }
}

public enum CriterioBusquedaTipoProducto {
    Todos,
    Id,
    Nombre
}

public static class UtilesBusquedaTiposProducto {
    public static object[] CriterioBusquedaTiposProducto = {
        "Todos los tipos de producto",
        "Identificador de BD",
        "Nombre del tipo de producto"
    };
}