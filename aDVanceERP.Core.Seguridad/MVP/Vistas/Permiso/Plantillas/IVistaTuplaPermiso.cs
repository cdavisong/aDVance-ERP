using aDVanceERP.Core.Vistas.Interfaces;

namespace aDVanceERP.Core.Seguridad.MVP.Vistas.Permiso.Plantillas;

public interface IVistaTuplaPermiso : IVistaTupla {
    string? IdPermiso { get; set; }
    string? NombrePermiso { get; set; }
}