using aDVanceERP.Core.MVP.Modelos.Plantillas;

namespace aDVanceERP.Core.Seguridad.MVP.Modelos; 

public class PermisoRolUsuario : IEntidad {
    public PermisoRolUsuario() { }

    public PermisoRolUsuario(long id, long idRolUsuario, long idPermiso) {
        Id = id;
        IdRolUsuario = idRolUsuario;
        IdPermiso = idPermiso;
    }

    public long IdRolUsuario { get; }
    public long IdPermiso { get; }

    public long Id { get; set; }
}

public enum FbPermisoRolCuentaUsuario {
    Todos,
    Id
}

public static class UtilesBusquedaPermisoRolCuentaUsuario {
    public static string[] FbPermisoRolCuentaUsuario = {
        "Todos los permisos de un rol",
        "Identificador de BD"
    };
}