using aDVanceERP.Core.MVP.Vistas.Plantillas;

namespace aDVanceERP.Core.Seguridad.MVP.Vistas.RolUsuario.Plantillas {
    public interface IVistaTuplaRolUsuario : IVistaTupla {
        string? Id { get; set; }
        string? NombreRolUsuario { get; set; }
        string? NivelAcceso { get; set; }
        string? CantidadUsuarios { get; set; }
    }
}
