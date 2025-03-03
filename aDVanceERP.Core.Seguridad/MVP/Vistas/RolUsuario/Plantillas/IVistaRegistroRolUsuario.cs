using aDVanceERP.Core.MVP.Vistas.Plantillas;

namespace aDVanceERP.Core.Seguridad.MVP.Vistas.RolUsuario.Plantillas {
    public interface IVistaRegistroRolUsuario : IVistaRegistro {
        string? NombreRolUsuario { get; set; }
        byte NivelAcceso { get; set; }
    }
}
