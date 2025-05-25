using aDVanceERP.Core.MVP.Modelos.Plantillas;

namespace aDVanceERP.Modulos.Inventario.MVP.Modelos;

public class DisenoProducto : IObjetoUnico {
    public DisenoProducto() {
        Nombre = string.Empty;
        Descripcion = string.Empty;
    }

    public DisenoProducto(long id, string nombre, string descripcion) {
        Id = id;
        Nombre = nombre;
        Descripcion = descripcion;
    }

    public long Id { get; set; }
    public string Nombre { get; set; }
    public string Descripcion { get; set; }
}

public enum CriterioBusquedaDisenoProducto {
    Todos,
    Id,
    Nombre,
    Descripcion
}

public static class UtilesBusquedaDisenosProducto {
    public static object[] CriterioBusquedaDisenosProducto = {
        "Todos los diseños de productos",
        "Identificador de BD",
        "Nombre del diseño del producto",
        "Descripción del diseño del producto"
    };
}