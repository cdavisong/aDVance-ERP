using aDVanceERP.Core.Modelos.Comun.Interfaces;

namespace aDVanceERP.Core.Seguridad.MVP.Modelos; 

public class RolUsuario : IEntidadBaseDatos {
    public RolUsuario() { }

    public RolUsuario(long id, string nombre) {
        Id = id;
        Nombre = nombre;
    }

    public string? Nombre { get; }

    public long Id { get; set; }
}

public enum CriterioBusquedaRolUsuario {
    Todos,
    Id,
    Nombre
}

public static class UtilesBusquedaRolUsuario {
    public static string[] CriterioBusquedaBusquedaRolUsuario = {
        "Todos los roles",
        "Identificador de BD",
        "Nombre del rol"
    };
}