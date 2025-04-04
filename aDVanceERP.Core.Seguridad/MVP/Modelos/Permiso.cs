using aDVanceERP.Core.MVP.Modelos.Plantillas;

namespace aDVanceERP.Core.Seguridad.MVP.Modelos; 

public class Permiso : IObjetoUnico {
    public Permiso() { }

    public Permiso(long id, long idModuloAplicacion, string? nombre) {
        Id = id;
        IdModuloAplicacion = idModuloAplicacion;
        Nombre = nombre;
    }

    public long IdModuloAplicacion { get; }
    public string? Nombre { get; }

    public long Id { get; set; }
}

public enum CriterioBusquedaPermiso {
    Todos,
    Id,
    Nombre
}

public static class UtilesBusquedaPermiso {
    public static string[] CriterioBusquedaBusquedaPermiso = {
        "Todos los permisos",
        "Identificador de BD",
        "Nombre del permiso"
    };
}