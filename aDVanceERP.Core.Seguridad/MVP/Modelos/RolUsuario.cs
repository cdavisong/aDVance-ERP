using aDVanceERP.Core.MVP.Modelos.Plantillas;

namespace aDVanceERP.Core.Seguridad.MVP.Modelos; 

public class RolUsuario : IEntidad {
    public RolUsuario() { }

    public RolUsuario(long id, string nombre) {
        Id = id;
        Nombre = nombre;
    }

    public string? Nombre { get; }

    public long Id { get; set; }
}

public enum FbRolCuentaUsuario {
    Todos,
    Id,
    Nombre
}

public static class UtilesBusquedaRolCuentaUsuario {
    public static string[] FbRolCuentaUsuario = {
        "Todos los roles",
        "Identificador de BD",
        "Nombre del rol"
    };
}