using aDVanceERP.Core.MVP.Vistas.Plantillas;

namespace aDVanceERP.Core.Seguridad.MVP.Vistas.Permiso.Plantillas {
    public interface IVistaTuplaPermiso : IVistaTupla {
        string? IdPermiso { get; set; }
        string? NombrePermiso { get; set; }
    }
}
