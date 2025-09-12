using aDVanceERP.Core.Vistas.Comun.Interfaces;

namespace aDVanceERP.Core.Seguridad.MVP.Vistas.Permiso.Plantillas;

public interface IVistaTuplaPermiso : IVistaTupla {
    string? IdPermiso { get; set; }
    string? NombrePermiso { get; set; }
}